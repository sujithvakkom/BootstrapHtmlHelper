using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace BootstrapHtmlHelper.ChartJs
{
    public enum TooltipModes
    {
        point,
        nearest,
        dataset,
        index,
        x,
        y
    }
    public enum TooltipAxix
    {
        x,
        y
    }

    public class WrongTooltipData : Exception
    {
        public WrongTooltipData(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public partial class tooltips
    {
        public tooltips(string mode, string axis)
        {
            try
            {
                var tootipMode = Enum.Parse(typeof(TooltipModes), mode);
                var tooltipAxix = Enum.Parse(typeof(TooltipModes), axis);
                this.mode = tootipMode.ToString();

                this.axis = tooltipAxix.ToString();
            }
            catch (Exception ex)
            {
                throw (new WrongTooltipData("Wrong Mode or Axis",ex));
            }
        }
        public tooltips(TooltipModes mode, TooltipAxix axis)  {
                this.mode = mode.ToString();

                this.axis = axis.ToString();

        }

        #region MODE_Litterals
        /*
        point
        nearest
        dataset
        index
        x
        y
         */
        public readonly string MODE_POINT = "point";
        public readonly string MODE_NEAREST = "nearest";
        public readonly string MODE_DATASET = "dataset";
        public readonly string MODE_INDEX = "index";
        public readonly string MODE_X = "x";
        public readonly string MODE_Y = "y";
        #endregion
        public string mode { get; set; }

        #region AXIS_Litterals
        /*
        x
        y
         */
        public readonly string AXIS_X = "x";
        public readonly string AXIS_Y = "y";
        #endregion
        public string axis { get; set; }
    }
}