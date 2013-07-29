using System;
using System.Globalization;
using System.Text;
using System.Web;

namespace AlchemyAPI
{
	public class KeywordParams : BaseParams
	{
		public enum KeywordExtractModes
		{
			None,
			Normal,
			Strict
		}

	    public uint? MaxRetrieve { get; set; }
	    public SourceTextModes SourceTextMode { get; set; }
	    public bool? ShowSourceText { get; set; }
        public string CQuery { get; set; }
        public string XPath { get; set; }
        public string BaseUrl { get; set; }
	    public KeywordExtractModes KeywordExtractMode { get; set; }
	    public bool? Sentiment { get; set; }

		override public String getParameterString()
		{
		    StringBuilder builder = new StringBuilder(base.getParameterString());

		    builder.Append(SourceTextMode.GetUrlParameter());

		    if (ShowSourceText.HasValue)
		        builder.Append2("&showSourceText=", (ShowSourceText.Value ? "1" : "0"));
		    if (Sentiment.HasValue)
		        builder.Append2("&sentiment=", (Sentiment.Value ? "1" : "0"));
		    if (CQuery != null)
		        builder.Append2("&cquery=", HttpUtility.UrlEncode(CQuery));
		    if (XPath != null)
		        builder.Append2("&xpath=", HttpUtility.UrlEncode(XPath));
		    if (MaxRetrieve.HasValue)
		        builder.Append2("&maxRetrieve=", MaxRetrieve.ToString());
		    if (BaseUrl != null)
		        builder.Append2("&baseUrl=", HttpUtility.UrlEncode(BaseUrl));
		    if (KeywordExtractMode != KeywordExtractModes.None)
		        builder.Append2("&keywordExtractMode=", (KeywordExtractModes.Strict == KeywordExtractMode ? "strict" : "normal"));

            return builder.ToString();
		}
	}
}
