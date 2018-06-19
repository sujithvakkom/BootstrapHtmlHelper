namespace BusinessExcel.Models.ChartJs
{
    public partial class dataset
    {
        public dataset(string label, decimal[] data)
        {
            this.label = label;
            this.data = data;
        }
        public dataset(string label,string stage, decimal[] data)
        {
            this.label = label;
            this.stage = stage;
            this.data = data;
        }
        /*X Axis values */
        public string label { get; set; }
        public decimal[] data { get; set; }
        public string[] backgroundColor { get; set; }
        public string[] borderColor { get; set; }
        public decimal _borderWidth;
        public decimal borderWidth { get { return _borderWidth<=0 ? 0 : _borderWidth; } set { _borderWidth = value; } }

        public string stage { get; private set; }

        private string[] IDField;
    }

}