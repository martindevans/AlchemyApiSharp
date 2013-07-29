using System;
using System.Globalization;
using System.Text;
using System.Web;

namespace AlchemyAPI
{
	public class ConceptParams : BaseParams
	{
	    public uint? MaxRetrieve { get; set; }
        public SourceTextModes SourceTextMode { get; set; }
        public bool? ShowSourceText { get; set; }
        public bool? LinkedData { get; set; }
        public string CQuery { get; set; }
        public string XPath { get; set; }

		override public String getParameterString()
		{
		    StringBuilder builder = new StringBuilder(base.getParameterString());

		    builder.Append(SourceTextMode.GetUrlParameter());

		    if (ShowSourceText.HasValue)
		        builder.Append2("&showSourceText=", (ShowSourceText.Value ? "1" : "0"));
		    if (LinkedData.HasValue)
		        builder.Append2("&linkedData=", (LinkedData.Value ? "1" : "0"));
		    if (CQuery != null)
		        builder.Append2("&cquery=", HttpUtility.UrlEncode(CQuery));
		    if (XPath != null)
		        builder.Append2("&xpath=", HttpUtility.UrlEncode(XPath));
		    if (MaxRetrieve.HasValue)
		        builder.Append2("&maxRetrieve=", MaxRetrieve.Value.ToString(CultureInfo.InvariantCulture));

            return builder.ToString();
		}
	}
}
