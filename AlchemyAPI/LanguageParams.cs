using System;
using System.Text;
using System.Web;

namespace AlchemyAPI
{
	public class LanguageParams : BaseParams
	{
	    public SourceTextModes SourceTextMode { get; set; }
        public string CQuery { get; set; }
        public string XPath { get; set; }
		
		override public String getParameterString()
		{
		    StringBuilder builder = new StringBuilder(base.getParameterString());

		    builder.Append(SourceTextMode.GetUrlParameter());

		    if (CQuery != null)
		        builder.Append2("&cquery=", HttpUtility.UrlEncode(CQuery));
		    if (XPath != null)
		        builder.Append2("&xpath=", HttpUtility.UrlEncode(XPath));

            return builder.ToString();
		}
	}
}
