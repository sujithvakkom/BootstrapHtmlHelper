
using System;
using System.Collections.Generic;

namespace BootstrapHtmlHelper.ChartJs
{
    public partial class dataset<T>
    {
        readonly ChartColorList colorList = new ChartColorList();
        public dataset(data<T> parent,ChartType chartType,int index,string label, IDictionary<string,decimal> data)
        {
            this.index = index;
            this.label = label;
            //this.data = data;
            this.data = new decimal[parent.labels.Length];
            int i = 0;
            foreach (var id in parent.labels)
            {
                this.data[i] = data.ContainsKey(id) ? data[id] : 0;
                i++;
            }
            setColor(chartType);
        }
        public dataset(
            data<T> parent,ChartType chartType,int index,string label, string stage, IDictionary<string, decimal> data)
        {
            this.index = index;
            this.label = label;
            this.stage = stage;
            //this.data = data;
            this.data = new decimal[parent.labels.Length];
            int i = 0;
            foreach (var id in parent.labels)
            {
                this.data[i] = data.ContainsKey(id) ? data[id] : 0;
                i++;
            }
            setColor(chartType);
        }

        private void setColor(
            ChartType chartType)
        {
            var count = index * data.Length;
            backgroundColor = new string[data.Length];
            for (int i = 0; i < backgroundColor.Length; i++)
            {
                switch (chartType)
                {
                    case ChartType.line:
                        backgroundColor[i] = "rgba(255,255,255,0)";
                        break;
                    default:
                        backgroundColor[i] = colorList[((index + i) * 10) % colorList.Count].RGBA;
                        break;
                }
            }
            borderColor = new string[data.Length];
            for (int i = 0; i < borderColor.Length; i++)
            {
                borderColor[i] = colorList[((index + i) * 10) % colorList.Count].RGBA;
            }
        }
        /*X Axis values */
        public string label { get; set; }
        public decimal[] data { get; set; }
        public string[] backgroundColor { get; set; }
        public string[] borderColor { get; set; }
        private decimal _borderWidth;
        public decimal borderWidth { get { return _borderWidth <= 0 ? 0 : _borderWidth; } set { _borderWidth = value; } }

        public string stage { get; private set; }

        private string[] IDField;
        private int index;
        private data<object> data1;
    }

}