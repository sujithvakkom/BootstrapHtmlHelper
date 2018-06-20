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
        private Expression<Func<T, PointPair>> Selection;
        private int colorIndex = 0;

        public data(
            ChartType chartType,
            IQueryable<T> source,
            Expression<Func<T, String>> yAxixsLabelField,
            Expression<Func<T, String>> graphLabelField,
            Expression<Func<T, PointPair>> selector)
        {
            this.dataSource = source;
            this.YAxixsLabelField = yAxixsLabelField;
            this.Selection = selector;
            //Expression<Func<TSource, TResult>> selector
            this.labels = source.Select(YAxixsLabelField).Distinct().ToArray();
            var graphLables =source.Select(graphLabelField).Distinct().ToArray();
            datasets = new List<dataset<T>>();
            foreach (var label in graphLables)
            {
                colorIndex++;
                datasets.Add(
                    new dataset<T>(
                        this,
                        chartType,
                        colorIndex,
                        label,
                        source
                        .Where(EqualToExpression(graphLabelField, label))
                        .Select(selector).ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase)
                        ));
            }

        }
        public data(
            ChartType chartType,
            IQueryable<T> source,
            Expression<Func<T, String>> yAxixsLabelField,
            Expression<Func<T, String>> graphLabelField,
            Expression<Func<T, String>> stageField,
            Expression<Func<T, PointPair>> selector)
        {
            this.dataSource = source;
            this.YAxixsLabelField = yAxixsLabelField;
            this.Selection = selector;
            //Expression<Func<TSource, TResult>> selector
            labels = source.Select(YAxixsLabelField).Distinct().ToArray();
            var graphLables = source.Select(graphLabelField).Distinct().ToArray();
            var stages = source.Select(stageField).Distinct().ToArray();
            datasets = new List<dataset<T>>();
            foreach (var label in labels)
            {
                foreach (var stage in graphLables)
                    datasets.Add(new dataset<T>(
                        this,
                        chartType,
                        colorIndex,
                        label, 
                        stage,
                        source
                        .Where(EqualToExpression(YAxixsLabelField, label))
                        .Where(EqualToExpression(stageField, stage))
                        .Select(selector).ToDictionary(x=>x.Key,x=>x.Value, StringComparer.OrdinalIgnoreCase)
                        ));
            }
        }
        /// <summary>
        /// X Axis labels
        /// </summary>
        public string[] labels { get; set; }

        public List<dataset<T>> datasets { get; set; }

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