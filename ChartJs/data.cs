using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
namespace BootstrapHtmlHelper.ChartJs
{
    public partial class data<T>
    {
        internal Type DataSetType { get { return typeof(T); } }
        private IQueryable<T> dataSource;
        private Expression<Func<T, string>> YAxixsLabelField;
        private Expression<Func<T, decimal>> Selection;
        public data(IQueryable<T> source,
            Expression<Func<T, String>> yAxixsLabelField,
            Expression<Func<T, bool>> yAxixsPredicate,
            Expression<Func<T, decimal>> selector)
        {
            this.dataSource = source;
            this.YAxixsLabelField = yAxixsLabelField;
            this.Selection = selector;
            //Expression<Func<TSource, TResult>> selector
            labels = source.Select(YAxixsLabelField).Distinct().ToArray();
            datasets = new List<dataset>();
            foreach (var label in labels)
                datasets.Add(
                    new dataset(label,
                    source.Where(
                        EqualToExpression(YAxixsLabelField, label)
                        ).Select(selector).ToArray()
                    ));

        }
        public data(IQueryable<T> source,
            Expression<Func<T, String>> yAxixsLabelField,
            Expression<Func<T, bool>> yAxixsPredicate,
            Expression<Func<T, String>> stageField,
            Expression<Func<T, decimal>> selector)
        {
            this.dataSource = source;
            this.YAxixsLabelField = yAxixsLabelField;
            this.Selection = selector;
            //Expression<Func<TSource, TResult>> selector
            labels = source.Select(YAxixsLabelField).Distinct().ToArray();
            var stages = source.Select(stageField).Distinct().ToArray();
            foreach (var label in labels)
            {
                foreach (var stage in stages)
                    datasets.Add(new dataset(label, stage,
                        source.Where(EqualToExpression(YAxixsLabelField, label))
                        .Where(EqualToExpression(stageField, stage))
                        .Select(selector).ToArray()
                        ));
            }
        }
        /// <summary>
        /// X Axis labels
        /// </summary>
        public string[] labels { get; set; }

        public List<dataset> datasets { get; set; }

        private Expression<Func<TSource, bool>> EqualToExpression<TSource, TValue>
             (Expression<Func<TSource, TValue>> selectValue, TValue targetValue)
        {
            return Expression.Lambda<Func<TSource, bool>>(
                Expression.Equal(selectValue.Body,
                Expression.Constant(targetValue)),
                selectValue.Parameters);
        }
    }
}