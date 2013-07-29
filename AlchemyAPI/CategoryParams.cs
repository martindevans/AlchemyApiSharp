using System.Text;
using System.Web;

namespace AlchemyAPI
{
	public class CategoryParams : BaseParams
	{
		public enum SourceTextModes
		{
			None,
			CleanedOrRaw,
			Cquery,
			Xpath
		}

	    public SourceTextModes SourceTextMode { get; set; }
        public string CQuery { get; set; }
        public string XPath { get; set; }
        public string BaseUrl { get; set; }

		override public string getParameterString()
		{
		    StringBuilder builder = new StringBuilder(base.getParameterString());

			if (SourceTextMode != SourceTextModes.None)
			{
                if (SourceTextMode == SourceTextModes.CleanedOrRaw)
                    builder.Append("&sourceText=cleaned_or_raw");
                else if (SourceTextMode == SourceTextModes.Cquery)
                    builder.Append("&sourceText=cquery");
                else if (SourceTextMode == SourceTextModes.Cquery)
                    builder.Append("&sourceText=xpath");
			}

		    if (CQuery != null)
		        builder.Append2("&cquery=", HttpUtility.UrlEncode(CQuery));
		    if (XPath != null)
		        builder.Append2("&xpath=", HttpUtility.UrlEncode(XPath));
		    if (BaseUrl != null)
		        builder.Append2("&baseUrl=", HttpUtility.UrlEncode(BaseUrl));

            return builder.ToString();
		}
	}
}
