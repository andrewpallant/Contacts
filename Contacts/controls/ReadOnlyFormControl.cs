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
    [ToolboxData("<{0}:ReadOnlyFormControl runat=server></{0}:ReadOnlyFormControl>")]
    public class ReadOnlyFormControl : WebControl
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

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
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

        protected override void RenderContents(HtmlTextWriter output)
        {
            String strOutput = String.Format("<dt>{0}</dt>", LabelText);
            strOutput += String.Format("<dd><span>{0}</span></dd>", ValueText);

            output.Write(strOutput);
        }
    }
}
