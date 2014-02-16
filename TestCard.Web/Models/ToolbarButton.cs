using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestCard.Web.Models
{
    public class ToolbarButton
    {
        public string Text { get; set; }
        public string ButtonType { get; set; }
        public string Url { get; set; }

        private TextType _Type = TextType.SingleLine;

        public TextType Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        public enum TextType { SingleLine, Multiline }
    }
}