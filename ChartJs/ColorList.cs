using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BootstrapHtmlHelper.ChartJs
{
    public class ChartColorList : List<ChartColor>
    {
        public ChartColorList()
        {
            //List
            this.Add(new ChartColor() { Name = "Black", ID = "#000000", RGB = "rgb(0,0,0)", RGBA = "rgba(0,0,0,1)", RGBA50 = "rgba(0,0,0,0.5)" });
            this.Add(new ChartColor() { Name = "White", ID = "#FFFFFF", RGB = "rgb(255,255,255)", RGBA = "rgba(255,255,255,1)", RGBA50 = "rgba(255,255,255,0.5)" });
            this.Add(new ChartColor() { Name = "Red", ID = "#FF0000", RGB = "rgb(255,0,0)", RGBA = "rgba(255,0,0,1)", RGBA50 = "rgba(255,0,0,0.5)" });
            this.Add(new ChartColor() { Name = "Lime", ID = "#00FF00", RGB = "rgb(0,255,0)", RGBA = "rgba(0,255,0,1)", RGBA50 = "rgba(0,255,0,0.5)" });
            this.Add(new ChartColor() { Name = "Blue", ID = "#0000FF", RGB = "rgb(0,0,255)", RGBA = "rgba(0,0,255,1)", RGBA50 = "rgba(0,0,255,0.5)" });
            this.Add(new ChartColor() { Name = "Yellow", ID = "#FFFF00", RGB = "rgb(255,255,0)", RGBA = "rgba(255,255,0,1)", RGBA50 = "rgba(255,255,0,0.5)" });
            this.Add(new ChartColor() { Name = "Cyan / Aqua", ID = "#00FFFF", RGB = "rgb(0,255,255)", RGBA = "rgba(0,255,255,1)", RGBA50 = "rgba(0,255,255,0.5)" });
            this.Add(new ChartColor() { Name = "Magenta / Fuchsia", ID = "#FF00FF", RGB = "rgb(255,0,255)", RGBA = "rgba(255,0,255,1)", RGBA50 = "rgba(255,0,255,0.5)" });
            this.Add(new ChartColor() { Name = "Silver", ID = "#C0C0C0", RGB = "rgb(192,192,192)", RGBA = "rgba(192,192,192,1)", RGBA50 = "rgba(192,192,192,0.5)" });
            this.Add(new ChartColor() { Name = "Gray", ID = "#808080", RGB = "rgb(128,128,128)", RGBA = "rgba(128,128,128,1)", RGBA50 = "rgba(128,128,128,0.5)" });
            this.Add(new ChartColor() { Name = "Maroon", ID = "#800000", RGB = "rgb(128,0,0)", RGBA = "rgba(128,0,0,1)", RGBA50 = "rgba(128,0,0,0.5)" });
            this.Add(new ChartColor() { Name = "Olive", ID = "#808000", RGB = "rgb(128,128,0)", RGBA = "rgba(128,128,0,1)", RGBA50 = "rgba(128,128,0,0.5)" });
            this.Add(new ChartColor() { Name = "Green", ID = "#008000", RGB = "rgb(0,128,0)", RGBA = "rgba(0,128,0,1)", RGBA50 = "rgba(0,128,0,0.5)" });
            this.Add(new ChartColor() { Name = "Purple", ID = "#800080", RGB = "rgb(128,0,128)", RGBA = "rgba(128,0,128,1)", RGBA50 = "rgba(128,0,128,0.5)" });
            this.Add(new ChartColor() { Name = "Teal", ID = "#008080", RGB = "rgb(0,128,128)", RGBA = "rgba(0,128,128,1)", RGBA50 = "rgba(0,128,128,0.5)" });
            this.Add(new ChartColor() { Name = "Navy", ID = "#000080", RGB = "rgb(0,0,128)", RGBA = "rgba(0,0,128,1)", RGBA50 = "rgba(0,0,128,0.5)" });
            this.Add(new ChartColor() { Name = "maroon", ID = "#800000", RGB = "rgb(128,0,0)", RGBA = "rgba(128,0,0,1)", RGBA50 = "rgba(128,0,0,0.5)" });
            this.Add(new ChartColor() { Name = "dark red", ID = "#8B0000", RGB = "rgb(139,0,0)", RGBA = "rgba(139,0,0,1)", RGBA50 = "rgba(139,0,0,0.5)" });
            this.Add(new ChartColor() { Name = "brown", ID = "#A52A2A", RGB = "rgb(165,42,42)", RGBA = "rgba(165,42,42,1)", RGBA50 = "rgba(165,42,42,0.5)" });
            this.Add(new ChartColor() { Name = "firebrick", ID = "#B22222", RGB = "rgb(178,34,34)", RGBA = "rgba(178,34,34,1)", RGBA50 = "rgba(178,34,34,0.5)" });
            this.Add(new ChartColor() { Name = "crimson", ID = "#DC143C", RGB = "rgb(220,20,60)", RGBA = "rgba(220,20,60,1)", RGBA50 = "rgba(220,20,60,0.5)" });
            this.Add(new ChartColor() { Name = "red", ID = "#FF0000", RGB = "rgb(255,0,0)", RGBA = "rgba(255,0,0,1)", RGBA50 = "rgba(255,0,0,0.5)" });
            this.Add(new ChartColor() { Name = "tomato", ID = "#FF6347", RGB = "rgb(255,99,71)", RGBA = "rgba(255,99,71,1)", RGBA50 = "rgba(255,99,71,0.5)" });
            this.Add(new ChartColor() { Name = "coral", ID = "#FF7F50", RGB = "rgb(255,127,80)", RGBA = "rgba(255,127,80,1)", RGBA50 = "rgba(255,127,80,0.5)" });
            this.Add(new ChartColor() { Name = "indian red", ID = "#CD5C5C", RGB = "rgb(205,92,92)", RGBA = "rgba(205,92,92,1)", RGBA50 = "rgba(205,92,92,0.5)" });
            this.Add(new ChartColor() { Name = "light coral", ID = "#F08080", RGB = "rgb(240,128,128)", RGBA = "rgba(240,128,128,1)", RGBA50 = "rgba(240,128,128,0.5)" });
            this.Add(new ChartColor() { Name = "dark salmon", ID = "#E9967A", RGB = "rgb(233,150,122)", RGBA = "rgba(233,150,122,1)", RGBA50 = "rgba(233,150,122,0.5)" });
            this.Add(new ChartColor() { Name = "salmon", ID = "#FA8072", RGB = "rgb(250,128,114)", RGBA = "rgba(250,128,114,1)", RGBA50 = "rgba(250,128,114,0.5)" });
            this.Add(new ChartColor() { Name = "light salmon", ID = "#FFA07A", RGB = "rgb(255,160,122)", RGBA = "rgba(255,160,122,1)", RGBA50 = "rgba(255,160,122,0.5)" });
            this.Add(new ChartColor() { Name = "orange red", ID = "#FF4500", RGB = "rgb(255,69,0)", RGBA = "rgba(255,69,0,1)", RGBA50 = "rgba(255,69,0,0.5)" });
            this.Add(new ChartColor() { Name = "dark orange", ID = "#FF8C00", RGB = "rgb(255,140,0)", RGBA = "rgba(255,140,0,1)", RGBA50 = "rgba(255,140,0,0.5)" });
            this.Add(new ChartColor() { Name = "orange", ID = "#FFA500", RGB = "rgb(255,165,0)", RGBA = "rgba(255,165,0,1)", RGBA50 = "rgba(255,165,0,0.5)" });
            this.Add(new ChartColor() { Name = "gold", ID = "#FFD700", RGB = "rgb(255,215,0)", RGBA = "rgba(255,215,0,1)", RGBA50 = "rgba(255,215,0,0.5)" });
            this.Add(new ChartColor() { Name = "dark golden rod", ID = "#B8860B", RGB = "rgb(184,134,11)", RGBA = "rgba(184,134,11,1)", RGBA50 = "rgba(184,134,11,0.5)" });
            this.Add(new ChartColor() { Name = "golden rod", ID = "#DAA520", RGB = "rgb(218,165,32)", RGBA = "rgba(218,165,32,1)", RGBA50 = "rgba(218,165,32,0.5)" });
            this.Add(new ChartColor() { Name = "pale golden rod", ID = "#EEE8AA", RGB = "rgb(238,232,170)", RGBA = "rgba(238,232,170,1)", RGBA50 = "rgba(238,232,170,0.5)" });
            this.Add(new ChartColor() { Name = "dark khaki", ID = "#BDB76B", RGB = "rgb(189,183,107)", RGBA = "rgba(189,183,107,1)", RGBA50 = "rgba(189,183,107,0.5)" });
            this.Add(new ChartColor() { Name = "khaki", ID = "#F0E68C", RGB = "rgb(240,230,140)", RGBA = "rgba(240,230,140,1)", RGBA50 = "rgba(240,230,140,0.5)" });
            this.Add(new ChartColor() { Name = "olive", ID = "#808000", RGB = "rgb(128,128,0)", RGBA = "rgba(128,128,0,1)", RGBA50 = "rgba(128,128,0,0.5)" });
            this.Add(new ChartColor() { Name = "yellow", ID = "#FFFF00", RGB = "rgb(255,255,0)", RGBA = "rgba(255,255,0,1)", RGBA50 = "rgba(255,255,0,0.5)" });
            this.Add(new ChartColor() { Name = "yellow green", ID = "#9ACD32", RGB = "rgb(154,205,50)", RGBA = "rgba(154,205,50,1)", RGBA50 = "rgba(154,205,50,0.5)" });
            this.Add(new ChartColor() { Name = "dark olive green", ID = "#556B2F", RGB = "rgb(85,107,47)", RGBA = "rgba(85,107,47,1)", RGBA50 = "rgba(85,107,47,0.5)" });
            this.Add(new ChartColor() { Name = "olive drab", ID = "#6B8E23", RGB = "rgb(107,142,35)", RGBA = "rgba(107,142,35,1)", RGBA50 = "rgba(107,142,35,0.5)" });
            this.Add(new ChartColor() { Name = "lawn green", ID = "#7CFC00", RGB = "rgb(124,252,0)", RGBA = "rgba(124,252,0,1)", RGBA50 = "rgba(124,252,0,0.5)" });
            this.Add(new ChartColor() { Name = "chart reuse", ID = "#7FFF00", RGB = "rgb(127,255,0)", RGBA = "rgba(127,255,0,1)", RGBA50 = "rgba(127,255,0,0.5)" });
            this.Add(new ChartColor() { Name = "green yellow", ID = "#ADFF2F", RGB = "rgb(173,255,47)", RGBA = "rgba(173,255,47,1)", RGBA50 = "rgba(173,255,47,0.5)" });
            this.Add(new ChartColor() { Name = "dark green", ID = "#006400", RGB = "rgb(0,100,0)", RGBA = "rgba(0,100,0,1)", RGBA50 = "rgba(0,100,0,0.5)" });
            this.Add(new ChartColor() { Name = "green", ID = "#008000", RGB = "rgb(0,128,0)", RGBA = "rgba(0,128,0,1)", RGBA50 = "rgba(0,128,0,0.5)" });
            this.Add(new ChartColor() { Name = "forest green", ID = "#228B22", RGB = "rgb(34,139,34)", RGBA = "rgba(34,139,34,1)", RGBA50 = "rgba(34,139,34,0.5)" });
            this.Add(new ChartColor() { Name = "lime", ID = "#00FF00", RGB = "rgb(0,255,0)", RGBA = "rgba(0,255,0,1)", RGBA50 = "rgba(0,255,0,0.5)" });
            this.Add(new ChartColor() { Name = "lime green", ID = "#32CD32", RGB = "rgb(50,205,50)", RGBA = "rgba(50,205,50,1)", RGBA50 = "rgba(50,205,50,0.5)" });
            this.Add(new ChartColor() { Name = "light green", ID = "#90EE90", RGB = "rgb(144,238,144)", RGBA = "rgba(144,238,144,1)", RGBA50 = "rgba(144,238,144,0.5)" });
            this.Add(new ChartColor() { Name = "pale green", ID = "#98FB98", RGB = "rgb(152,251,152)", RGBA = "rgba(152,251,152,1)", RGBA50 = "rgba(152,251,152,0.5)" });
            this.Add(new ChartColor() { Name = "dark sea green", ID = "#8FBC8F", RGB = "rgb(143,188,143)", RGBA = "rgba(143,188,143,1)", RGBA50 = "rgba(143,188,143,0.5)" });
            this.Add(new ChartColor() { Name = "medium spring green", ID = "#00FA9A", RGB = "rgb(0,250,154)", RGBA = "rgba(0,250,154,1)", RGBA50 = "rgba(0,250,154,0.5)" });
            this.Add(new ChartColor() { Name = "spring green", ID = "#00FF7F", RGB = "rgb(0,255,127)", RGBA = "rgba(0,255,127,1)", RGBA50 = "rgba(0,255,127,0.5)" });
            this.Add(new ChartColor() { Name = "sea green", ID = "#2E8B57", RGB = "rgb(46,139,87)", RGBA = "rgba(46,139,87,1)", RGBA50 = "rgba(46,139,87,0.5)" });
            this.Add(new ChartColor() { Name = "medium aqua marine", ID = "#66CDAA", RGB = "rgb(102,205,170)", RGBA = "rgba(102,205,170,1)", RGBA50 = "rgba(102,205,170,0.5)" });
            this.Add(new ChartColor() { Name = "medium sea green", ID = "#3CB371", RGB = "rgb(60,179,113)", RGBA = "rgba(60,179,113,1)", RGBA50 = "rgba(60,179,113,0.5)" });
            this.Add(new ChartColor() { Name = "light sea green", ID = "#20B2AA", RGB = "rgb(32,178,170)", RGBA = "rgba(32,178,170,1)", RGBA50 = "rgba(32,178,170,0.5)" });
            this.Add(new ChartColor() { Name = "dark slate gray", ID = "#2F4F4F", RGB = "rgb(47,79,79)", RGBA = "rgba(47,79,79,1)", RGBA50 = "rgba(47,79,79,0.5)" });
            this.Add(new ChartColor() { Name = "teal", ID = "#008080", RGB = "rgb(0,128,128)", RGBA = "rgba(0,128,128,1)", RGBA50 = "rgba(0,128,128,0.5)" });
            this.Add(new ChartColor() { Name = "dark cyan", ID = "#008B8B", RGB = "rgb(0,139,139)", RGBA = "rgba(0,139,139,1)", RGBA50 = "rgba(0,139,139,0.5)" });
            this.Add(new ChartColor() { Name = "aqua", ID = "#00FFFF", RGB = "rgb(0,255,255)", RGBA = "rgba(0,255,255,1)", RGBA50 = "rgba(0,255,255,0.5)" });
            this.Add(new ChartColor() { Name = "cyan", ID = "#00FFFF", RGB = "rgb(0,255,255)", RGBA = "rgba(0,255,255,1)", RGBA50 = "rgba(0,255,255,0.5)" });
            this.Add(new ChartColor() { Name = "light cyan", ID = "#E0FFFF", RGB = "rgb(224,255,255)", RGBA = "rgba(224,255,255,1)", RGBA50 = "rgba(224,255,255,0.5)" });
            this.Add(new ChartColor() { Name = "dark turquoise", ID = "#00CED1", RGB = "rgb(0,206,209)", RGBA = "rgba(0,206,209,1)", RGBA50 = "rgba(0,206,209,0.5)" });
            this.Add(new ChartColor() { Name = "turquoise", ID = "#40E0D0", RGB = "rgb(64,224,208)", RGBA = "rgba(64,224,208,1)", RGBA50 = "rgba(64,224,208,0.5)" });
            this.Add(new ChartColor() { Name = "medium turquoise", ID = "#48D1CC", RGB = "rgb(72,209,204)", RGBA = "rgba(72,209,204,1)", RGBA50 = "rgba(72,209,204,0.5)" });
            this.Add(new ChartColor() { Name = "pale turquoise", ID = "#AFEEEE", RGB = "rgb(175,238,238)", RGBA = "rgba(175,238,238,1)", RGBA50 = "rgba(175,238,238,0.5)" });
            this.Add(new ChartColor() { Name = "aqua marine", ID = "#7FFFD4", RGB = "rgb(127,255,212)", RGBA = "rgba(127,255,212,1)", RGBA50 = "rgba(127,255,212,0.5)" });
            this.Add(new ChartColor() { Name = "powder blue", ID = "#B0E0E6", RGB = "rgb(176,224,230)", RGBA = "rgba(176,224,230,1)", RGBA50 = "rgba(176,224,230,0.5)" });
            this.Add(new ChartColor() { Name = "cadet blue", ID = "#5F9EA0", RGB = "rgb(95,158,160)", RGBA = "rgba(95,158,160,1)", RGBA50 = "rgba(95,158,160,0.5)" });
            this.Add(new ChartColor() { Name = "steel blue", ID = "#4682B4", RGB = "rgb(70,130,180)", RGBA = "rgba(70,130,180,1)", RGBA50 = "rgba(70,130,180,0.5)" });
            this.Add(new ChartColor() { Name = "corn flower blue", ID = "#6495ED", RGB = "rgb(100,149,237)", RGBA = "rgba(100,149,237,1)", RGBA50 = "rgba(100,149,237,0.5)" });
            this.Add(new ChartColor() { Name = "deep sky blue", ID = "#00BFFF", RGB = "rgb(0,191,255)", RGBA = "rgba(0,191,255,1)", RGBA50 = "rgba(0,191,255,0.5)" });
            this.Add(new ChartColor() { Name = "dodger blue", ID = "#1E90FF", RGB = "rgb(30,144,255)", RGBA = "rgba(30,144,255,1)", RGBA50 = "rgba(30,144,255,0.5)" });
            this.Add(new ChartColor() { Name = "light blue", ID = "#ADD8E6", RGB = "rgb(173,216,230)", RGBA = "rgba(173,216,230,1)", RGBA50 = "rgba(173,216,230,0.5)" });
            this.Add(new ChartColor() { Name = "sky blue", ID = "#87CEEB", RGB = "rgb(135,206,235)", RGBA = "rgba(135,206,235,1)", RGBA50 = "rgba(135,206,235,0.5)" });
            this.Add(new ChartColor() { Name = "light sky blue", ID = "#87CEFA", RGB = "rgb(135,206,250)", RGBA = "rgba(135,206,250,1)", RGBA50 = "rgba(135,206,250,0.5)" });
            this.Add(new ChartColor() { Name = "midnight blue", ID = "#191970", RGB = "rgb(25,25,112)", RGBA = "rgba(25,25,112,1)", RGBA50 = "rgba(25,25,112,0.5)" });
            this.Add(new ChartColor() { Name = "navy", ID = "#000080", RGB = "rgb(0,0,128)", RGBA = "rgba(0,0,128,1)", RGBA50 = "rgba(0,0,128,0.5)" });
            this.Add(new ChartColor() { Name = "dark blue", ID = "#00008B", RGB = "rgb(0,0,139)", RGBA = "rgba(0,0,139,1)", RGBA50 = "rgba(0,0,139,0.5)" });
            this.Add(new ChartColor() { Name = "medium blue", ID = "#0000CD", RGB = "rgb(0,0,205)", RGBA = "rgba(0,0,205,1)", RGBA50 = "rgba(0,0,205,0.5)" });
            this.Add(new ChartColor() { Name = "blue", ID = "#0000FF", RGB = "rgb(0,0,255)", RGBA = "rgba(0,0,255,1)", RGBA50 = "rgba(0,0,255,0.5)" });
            this.Add(new ChartColor() { Name = "royal blue", ID = "#4169E1", RGB = "rgb(65,105,225)", RGBA = "rgba(65,105,225,1)", RGBA50 = "rgba(65,105,225,0.5)" });
            this.Add(new ChartColor() { Name = "blue violet", ID = "#8A2BE2", RGB = "rgb(138,43,226)", RGBA = "rgba(138,43,226,1)", RGBA50 = "rgba(138,43,226,0.5)" });
            this.Add(new ChartColor() { Name = "indigo", ID = "#4B0082", RGB = "rgb(75,0,130)", RGBA = "rgba(75,0,130,1)", RGBA50 = "rgba(75,0,130,0.5)" });
            this.Add(new ChartColor() { Name = "dark slate blue", ID = "#483D8B", RGB = "rgb(72,61,139)", RGBA = "rgba(72,61,139,1)", RGBA50 = "rgba(72,61,139,0.5)" });
            this.Add(new ChartColor() { Name = "slate blue", ID = "#6A5ACD", RGB = "rgb(106,90,205)", RGBA = "rgba(106,90,205,1)", RGBA50 = "rgba(106,90,205,0.5)" });
            this.Add(new ChartColor() { Name = "medium slate blue", ID = "#7B68EE", RGB = "rgb(123,104,238)", RGBA = "rgba(123,104,238,1)", RGBA50 = "rgba(123,104,238,0.5)" });
            this.Add(new ChartColor() { Name = "medium purple", ID = "#9370DB", RGB = "rgb(147,112,219)", RGBA = "rgba(147,112,219,1)", RGBA50 = "rgba(147,112,219,0.5)" });
            this.Add(new ChartColor() { Name = "dark magenta", ID = "#8B008B", RGB = "rgb(139,0,139)", RGBA = "rgba(139,0,139,1)", RGBA50 = "rgba(139,0,139,0.5)" });
            this.Add(new ChartColor() { Name = "dark violet", ID = "#9400D3", RGB = "rgb(148,0,211)", RGBA = "rgba(148,0,211,1)", RGBA50 = "rgba(148,0,211,0.5)" });
            this.Add(new ChartColor() { Name = "dark orchid", ID = "#9932CC", RGB = "rgb(153,50,204)", RGBA = "rgba(153,50,204,1)", RGBA50 = "rgba(153,50,204,0.5)" });
            this.Add(new ChartColor() { Name = "medium orchid", ID = "#BA55D3", RGB = "rgb(186,85,211)", RGBA = "rgba(186,85,211,1)", RGBA50 = "rgba(186,85,211,0.5)" });
            this.Add(new ChartColor() { Name = "purple", ID = "#800080", RGB = "rgb(128,0,128)", RGBA = "rgba(128,0,128,1)", RGBA50 = "rgba(128,0,128,0.5)" });
            this.Add(new ChartColor() { Name = "thistle", ID = "#D8BFD8", RGB = "rgb(216,191,216)", RGBA = "rgba(216,191,216,1)", RGBA50 = "rgba(216,191,216,0.5)" });
            this.Add(new ChartColor() { Name = "plum", ID = "#DDA0DD", RGB = "rgb(221,160,221)", RGBA = "rgba(221,160,221,1)", RGBA50 = "rgba(221,160,221,0.5)" });
            this.Add(new ChartColor() { Name = "violet", ID = "#EE82EE", RGB = "rgb(238,130,238)", RGBA = "rgba(238,130,238,1)", RGBA50 = "rgba(238,130,238,0.5)" });
            this.Add(new ChartColor() { Name = "magenta / fuchsia", ID = "#FF00FF", RGB = "rgb(255,0,255)", RGBA = "rgba(255,0,255,1)", RGBA50 = "rgba(255,0,255,0.5)" });
            this.Add(new ChartColor() { Name = "orchid", ID = "#DA70D6", RGB = "rgb(218,112,214)", RGBA = "rgba(218,112,214,1)", RGBA50 = "rgba(218,112,214,0.5)" });
            this.Add(new ChartColor() { Name = "medium violet red", ID = "#C71585", RGB = "rgb(199,21,133)", RGBA = "rgba(199,21,133,1)", RGBA50 = "rgba(199,21,133,0.5)" });
            this.Add(new ChartColor() { Name = "pale violet red", ID = "#DB7093", RGB = "rgb(219,112,147)", RGBA = "rgba(219,112,147,1)", RGBA50 = "rgba(219,112,147,0.5)" });
            this.Add(new ChartColor() { Name = "deep pink", ID = "#FF1493", RGB = "rgb(255,20,147)", RGBA = "rgba(255,20,147,1)", RGBA50 = "rgba(255,20,147,0.5)" });
            this.Add(new ChartColor() { Name = "hot pink", ID = "#FF69B4", RGB = "rgb(255,105,180)", RGBA = "rgba(255,105,180,1)", RGBA50 = "rgba(255,105,180,0.5)" });
            this.Add(new ChartColor() { Name = "light pink", ID = "#FFB6C1", RGB = "rgb(255,182,193)", RGBA = "rgba(255,182,193,1)", RGBA50 = "rgba(255,182,193,0.5)" });
            this.Add(new ChartColor() { Name = "pink", ID = "#FFC0CB", RGB = "rgb(255,192,203)", RGBA = "rgba(255,192,203,1)", RGBA50 = "rgba(255,192,203,0.5)" });
            this.Add(new ChartColor() { Name = "antique white", ID = "#FAEBD7", RGB = "rgb(250,235,215)", RGBA = "rgba(250,235,215,1)", RGBA50 = "rgba(250,235,215,0.5)" });
            this.Add(new ChartColor() { Name = "beige", ID = "#F5F5DC", RGB = "rgb(245,245,220)", RGBA = "rgba(245,245,220,1)", RGBA50 = "rgba(245,245,220,0.5)" });
            this.Add(new ChartColor() { Name = "bisque", ID = "#FFE4C4", RGB = "rgb(255,228,196)", RGBA = "rgba(255,228,196,1)", RGBA50 = "rgba(255,228,196,0.5)" });
            this.Add(new ChartColor() { Name = "blanched almond", ID = "#FFEBCD", RGB = "rgb(255,235,205)", RGBA = "rgba(255,235,205,1)", RGBA50 = "rgba(255,235,205,0.5)" });
            this.Add(new ChartColor() { Name = "wheat", ID = "#F5DEB3", RGB = "rgb(245,222,179)", RGBA = "rgba(245,222,179,1)", RGBA50 = "rgba(245,222,179,0.5)" });
            this.Add(new ChartColor() { Name = "corn silk", ID = "#FFF8DC", RGB = "rgb(255,248,220)", RGBA = "rgba(255,248,220,1)", RGBA50 = "rgba(255,248,220,0.5)" });
            this.Add(new ChartColor() { Name = "lemon chiffon", ID = "#FFFACD", RGB = "rgb(255,250,205)", RGBA = "rgba(255,250,205,1)", RGBA50 = "rgba(255,250,205,0.5)" });
            this.Add(new ChartColor() { Name = "light golden rod yellow", ID = "#FAFAD2", RGB = "rgb(250,250,210)", RGBA = "rgba(250,250,210,1)", RGBA50 = "rgba(250,250,210,0.5)" });
            this.Add(new ChartColor() { Name = "light yellow", ID = "#FFFFE0", RGB = "rgb(255,255,224)", RGBA = "rgba(255,255,224,1)", RGBA50 = "rgba(255,255,224,0.5)" });
            this.Add(new ChartColor() { Name = "saddle brown", ID = "#8B4513", RGB = "rgb(139,69,19)", RGBA = "rgba(139,69,19,1)", RGBA50 = "rgba(139,69,19,0.5)" });
            this.Add(new ChartColor() { Name = "sienna", ID = "#A0522D", RGB = "rgb(160,82,45)", RGBA = "rgba(160,82,45,1)", RGBA50 = "rgba(160,82,45,0.5)" });
            this.Add(new ChartColor() { Name = "chocolate", ID = "#D2691E", RGB = "rgb(210,105,30)", RGBA = "rgba(210,105,30,1)", RGBA50 = "rgba(210,105,30,0.5)" });
            this.Add(new ChartColor() { Name = "peru", ID = "#CD853F", RGB = "rgb(205,133,63)", RGBA = "rgba(205,133,63,1)", RGBA50 = "rgba(205,133,63,0.5)" });
            this.Add(new ChartColor() { Name = "sandy brown", ID = "#F4A460", RGB = "rgb(244,164,96)", RGBA = "rgba(244,164,96,1)", RGBA50 = "rgba(244,164,96,0.5)" });
            this.Add(new ChartColor() { Name = "burly wood", ID = "#DEB887", RGB = "rgb(222,184,135)", RGBA = "rgba(222,184,135,1)", RGBA50 = "rgba(222,184,135,0.5)" });
            this.Add(new ChartColor() { Name = "tan", ID = "#D2B48C", RGB = "rgb(210,180,140)", RGBA = "rgba(210,180,140,1)", RGBA50 = "rgba(210,180,140,0.5)" });
            this.Add(new ChartColor() { Name = "rosy brown", ID = "#BC8F8F", RGB = "rgb(188,143,143)", RGBA = "rgba(188,143,143,1)", RGBA50 = "rgba(188,143,143,0.5)" });
            this.Add(new ChartColor() { Name = "moccasin", ID = "#FFE4B5", RGB = "rgb(255,228,181)", RGBA = "rgba(255,228,181,1)", RGBA50 = "rgba(255,228,181,0.5)" });
            this.Add(new ChartColor() { Name = "navajo white", ID = "#FFDEAD", RGB = "rgb(255,222,173)", RGBA = "rgba(255,222,173,1)", RGBA50 = "rgba(255,222,173,0.5)" });
            this.Add(new ChartColor() { Name = "peach puff", ID = "#FFDAB9", RGB = "rgb(255,218,185)", RGBA = "rgba(255,218,185,1)", RGBA50 = "rgba(255,218,185,0.5)" });
            this.Add(new ChartColor() { Name = "misty rose", ID = "#FFE4E1", RGB = "rgb(255,228,225)", RGBA = "rgba(255,228,225,1)", RGBA50 = "rgba(255,228,225,0.5)" });
            this.Add(new ChartColor() { Name = "lavender blush", ID = "#FFF0F5", RGB = "rgb(255,240,245)", RGBA = "rgba(255,240,245,1)", RGBA50 = "rgba(255,240,245,0.5)" });
            this.Add(new ChartColor() { Name = "linen", ID = "#FAF0E6", RGB = "rgb(250,240,230)", RGBA = "rgba(250,240,230,1)", RGBA50 = "rgba(250,240,230,0.5)" });
            this.Add(new ChartColor() { Name = "old lace", ID = "#FDF5E6", RGB = "rgb(253,245,230)", RGBA = "rgba(253,245,230,1)", RGBA50 = "rgba(253,245,230,0.5)" });
            this.Add(new ChartColor() { Name = "papaya whip", ID = "#FFEFD5", RGB = "rgb(255,239,213)", RGBA = "rgba(255,239,213,1)", RGBA50 = "rgba(255,239,213,0.5)" });
            this.Add(new ChartColor() { Name = "sea shell", ID = "#FFF5EE", RGB = "rgb(255,245,238)", RGBA = "rgba(255,245,238,1)", RGBA50 = "rgba(255,245,238,0.5)" });
            this.Add(new ChartColor() { Name = "mint cream", ID = "#F5FFFA", RGB = "rgb(245,255,250)", RGBA = "rgba(245,255,250,1)", RGBA50 = "rgba(245,255,250,0.5)" });
            this.Add(new ChartColor() { Name = "slate gray", ID = "#708090", RGB = "rgb(112,128,144)", RGBA = "rgba(112,128,144,1)", RGBA50 = "rgba(112,128,144,0.5)" });
            this.Add(new ChartColor() { Name = "light slate gray", ID = "#778899", RGB = "rgb(119,136,153)", RGBA = "rgba(119,136,153,1)", RGBA50 = "rgba(119,136,153,0.5)" });
            this.Add(new ChartColor() { Name = "light steel blue", ID = "#B0C4DE", RGB = "rgb(176,196,222)", RGBA = "rgba(176,196,222,1)", RGBA50 = "rgba(176,196,222,0.5)" });
            this.Add(new ChartColor() { Name = "lavender", ID = "#E6E6FA", RGB = "rgb(230,230,250)", RGBA = "rgba(230,230,250,1)", RGBA50 = "rgba(230,230,250,0.5)" });
            this.Add(new ChartColor() { Name = "floral white", ID = "#FFFAF0", RGB = "rgb(255,250,240)", RGBA = "rgba(255,250,240,1)", RGBA50 = "rgba(255,250,240,0.5)" });
            this.Add(new ChartColor() { Name = "alice blue", ID = "#F0F8FF", RGB = "rgb(240,248,255)", RGBA = "rgba(240,248,255,1)", RGBA50 = "rgba(240,248,255,0.5)" });
            this.Add(new ChartColor() { Name = "ghost white", ID = "#F8F8FF", RGB = "rgb(248,248,255)", RGBA = "rgba(248,248,255,1)", RGBA50 = "rgba(248,248,255,0.5)" });
            this.Add(new ChartColor() { Name = "honeydew", ID = "#F0FFF0", RGB = "rgb(240,255,240)", RGBA = "rgba(240,255,240,1)", RGBA50 = "rgba(240,255,240,0.5)" });
            this.Add(new ChartColor() { Name = "ivory", ID = "#FFFFF0", RGB = "rgb(255,255,240)", RGBA = "rgba(255,255,240,1)", RGBA50 = "rgba(255,255,240,0.5)" });
            this.Add(new ChartColor() { Name = "azure", ID = "#F0FFFF", RGB = "rgb(240,255,255)", RGBA = "rgba(240,255,255,1)", RGBA50 = "rgba(240,255,255,0.5)" });
            this.Add(new ChartColor() { Name = "snow", ID = "#FFFAFA", RGB = "rgb(255,250,250)", RGBA = "rgba(255,250,250,1)", RGBA50 = "rgba(255,250,250,0.5)" });
            this.Add(new ChartColor() { Name = "black", ID = "#000000", RGB = "rgb(0,0,0)", RGBA = "rgba(0,0,0,1)", RGBA50 = "rgba(0,0,0,0.5)" });
            this.Add(new ChartColor() { Name = "dim gray / dim grey", ID = "#696969", RGB = "rgb(105,105,105)", RGBA = "rgba(105,105,105,1)", RGBA50 = "rgba(105,105,105,0.5)" });
            this.Add(new ChartColor() { Name = "gray / grey", ID = "#808080", RGB = "rgb(128,128,128)", RGBA = "rgba(128,128,128,1)", RGBA50 = "rgba(128,128,128,0.5)" });
            this.Add(new ChartColor() { Name = "dark gray / dark grey", ID = "#A9A9A9", RGB = "rgb(169,169,169)", RGBA = "rgba(169,169,169,1)", RGBA50 = "rgba(169,169,169,0.5)" });
            this.Add(new ChartColor() { Name = "silver", ID = "#C0C0C0", RGB = "rgb(192,192,192)", RGBA = "rgba(192,192,192,1)", RGBA50 = "rgba(192,192,192,0.5)" });
            this.Add(new ChartColor() { Name = "light gray / light grey", ID = "#D3D3D3", RGB = "rgb(211,211,211)", RGBA = "rgba(211,211,211,1)", RGBA50 = "rgba(211,211,211,0.5)" });
            this.Add(new ChartColor() { Name = "gainsboro", ID = "#DCDCDC", RGB = "rgb(220,220,220)", RGBA = "rgba(220,220,220,1)", RGBA50 = "rgba(220,220,220,0.5)" });
            this.Add(new ChartColor() { Name = "white smoke", ID = "#F5F5F5", RGB = "rgb(245,245,245)", RGBA = "rgba(245,245,245,1)", RGBA50 = "rgba(245,245,245,0.5)" });
            this.Add(new ChartColor() { Name = "white", ID = "#FFFFFF", RGB = "rgb(255,255,255)", RGBA = "rgba(255,255,255,1)", RGBA50 = "rgba(255,255,255,0.5)" });

        }
    }

    public class ChartColor
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string RGB { get; set; }
        public string RGBA { get; set; }
        public string RGBA50 { get; set; }

        public ChartColor()
        {

        }
    }
}
