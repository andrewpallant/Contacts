using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Contacts.controls
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:FormControl runat=server></{0}:FormControl>")]
    public class FormControl : WebControl
    {
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string LabelText
        {
            get
            {
                String s = (String)ViewState[ID + ".LabelText"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState[ID + ".LabelText"] = value;
            }
        }

        public string ValueText
        {
            get
            {
                String s = (String)ViewState[ID + ".ValueText"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState[ID + ".ValueText"] = value;
            }
        }

        private String _RowClass = "";
        public String RowClass
        {
            set{ _RowClass = value; }
            get{ return _RowClass; }
        }

        private String _LabelClass = "";
        public String LabelClass
        {
            set{ _LabelClass = value; }
            get{ return _LabelClass; }
        }

        private String _Col2Class = "";
        public String Col2Class
        {
            set{ _Col2Class = value; }
            get{ return _Col2Class; }
        }

        private String _Col1Class = "";
        public String Col1Class
        {
            set{ _Col1Class = value; }
            get{ return _Col1Class; }
        }

        private String _InputClass = "";
        public String InputClass
        {
            set{ _InputClass = value; }
            get{ return _InputClass; }
        }

        protected override void LoadViewState(object savedState)
        {
            base.LoadViewState(savedState);
            if (this.Page.IsPostBack)
            {
                ValueText = Page.Request[this.ID];
            }
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            String strOutput = "";
            strOutput += String.Format(@"<div class=""{0}"">", _RowClass);
            strOutput += String.Format(@"    <span class=""{0} {1}"">{2}</span>", LabelClass, Col1Class, LabelText);
            strOutput += String.Format(@"    <div class=""{0}"">", Col2Class);
            strOutput += String.Format(@"        <input Name=""{0}"" ID=""{0}"" class=""{1}"" Value=""{2}"" />", ID, InputClass, ValueText);
            strOutput +=               @"    </div>";
            strOutput +=               @"</div>";

            output.Write(strOutput);
        }
    }
}
