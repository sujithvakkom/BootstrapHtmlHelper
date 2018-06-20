namespace BootstrapHtmlHelper.ChartJs
{
    public partial class chart<T>
    {
        public chart(ChartType type, data<T> data, options options) {
            this.chartType = type;
            this.data = data;
            this.options = options;
        }
        #region type
        private ChartType _chartType;
        public ChartType chartType
        {
            private get
            {
                return _chartType;
            }
            set
            {
                _chartType = value;
                _type = _chartType.ToString();
            }
        }

        private string _type = null;
        public string type
        {
            get { return _type == null ? ChartType.line.ToString() : _type; }
            private set { _type = value; }
        }
        #endregion
        public data<T> data { get; set; }
        public options options { get; set; }
    }
}