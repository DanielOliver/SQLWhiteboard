//------------------------------------------------------------------------------
// <copyright file="TSQLClassifier.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace SqlWhiteboard.TSQL.Classifier
{
    /// <summary>
    /// Classifier that classifies all text as an instance of the "TSQLClassifier" classification type.
    /// </summary>
    internal class TSQLClassifier : IClassifier
    {
        /// <summary>
        /// Classification type.
        /// </summary>
        private readonly IClassificationType classificationType;


        private readonly SqlWhiteboard.Logic.RuleEngine ruleEngine;

        /// <summary>
        /// Initializes a new instance of the <see cref="TSQLClassifier"/> class.
        /// </summary>
        /// <param name="registry">Classification registry.</param>
        internal TSQLClassifier(IClassificationTypeRegistryService registry)
        {
            this.classificationType = registry.GetClassificationType("TSQLClassifier");
            this.ruleEngine = new SqlWhiteboard.Logic.RuleEngine();
        }

        #region IClassifier

#pragma warning disable 67

        /// <summary>
        /// An event that occurs when the classification of a span of text has changed.
        /// </summary>
        /// <remarks>
        /// This event gets raised if a non-text change would affect the classification in some way,
        /// for example typing /* would cause the classification to change in C# without directly
        /// affecting the span.
        /// </remarks>
        public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;

#pragma warning restore 67

        /// <summary>
        /// Gets all the <see cref="ClassificationSpan"/> objects that intersect with the given range of text.
        /// </summary>
        /// <remarks>
        /// This method scans the given SnapshotSpan for potential matches for this classification.
        /// In this instance, it classifies everything and returns each span as a new ClassificationSpan.
        /// </remarks>
        /// <param name="span">The span currently being classified.</param>
        /// <returns>A list of ClassificationSpans that represent spans identified to be of this classification.</returns>
        public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
        {
            var document = span.Snapshot.GetOpenDocumentInCurrentContextWithChanges();
            var semanticModel = document.GetSemanticModelAsync().Result;
            
            var changedSpan = new TextSpan(span.Start, span.Length);
            var changedNodes = semanticModel
                .SyntaxTree.GetRoot()
                .DescendantNodesAndSelf(changedSpan)
                .OfType<LiteralExpressionSyntax>()
                .Where(x => x.IsKind(Microsoft.CodeAnalysis.CSharp.SyntaxKind.StringLiteralExpression))
                .ToList();

            var result = new List<ClassificationSpan>();
            foreach (var item in changedNodes)
            {
                var text = item.Token.ValueText;
                var isValidTSql = ruleEngine.IsValidTSQL(text);
                if(isValidTSql)
                {
                    var intersect = span.Intersection(new Span(item.Span.Start, item.Span.Length));
                    if (intersect != null)
                    {
                        result.Add(new ClassificationSpan(intersect.Value, classificationType));
                    }
                }
            }            
            return result;
        }

        #endregion
    }
}
