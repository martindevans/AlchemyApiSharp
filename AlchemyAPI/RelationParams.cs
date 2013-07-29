using System;
using System.Globalization;
using System.Text;
using System.Web;

namespace AlchemyAPI
{
	public class RelationParams : BaseParams
	{
		public bool? Disambiguate {get; set; }
        public bool? LinkedData {get; set; }
        public bool? Coreference {get; set; }
        public bool? Entities {get; set; }
        public bool? SentimentExcludeEntities {get; set; }
        public bool? RequireEntities {get; set; }
		public uint? MaxRetrieve {get; set; }
		public SourceTextModes SourceTextMode {get; set; }
        public bool? ShowSourceText {get; set; }
		public string CQuery {get; set; }
		public string XPath {get; set; }
		public string BaseUrl {get; set; }
        public bool? Sentiment { get; set; }

		override public String getParameterString()
		{
		    StringBuilder builder = new StringBuilder(base.getParameterString());

		    builder.Append(SourceTextMode.GetUrlParameter());

		    if (ShowSourceText.HasValue)
		        builder.Append2("&showSourceText=", (ShowSourceText.Value ? "1" : "0"));
		    if (Disambiguate.HasValue)
		        builder.Append2("&disambiguate=", (Disambiguate.Value ? "1" : "0"));
		    if (LinkedData.HasValue)
		        builder.Append2("&linkedData=", (LinkedData.Value ? "1" : "0"));
		    if (Coreference.HasValue)
		        builder.Append2("&coreference=", (Coreference.Value ? "1" : "0"));
		    if (Entities.HasValue)
		        builder.Append2("&entities=", (Entities.Value ? "1" : "0"));
		    if (SentimentExcludeEntities.HasValue)
		        builder.Append2("&sentimentExcludeEntities=", (SentimentExcludeEntities.Value ? "1" : "0"));
		    if (RequireEntities.HasValue)
		        builder.Append2("&requireEntities=", (RequireEntities.Value ? "1" : "0"));
		    if (Sentiment.HasValue)
		        builder.Append2("&sentiment=", (Sentiment.Value ? "1" : "0"));
		    if (CQuery != null)
		        builder.Append2("&cquery=", HttpUtility.UrlEncode(CQuery));
		    if (XPath != null)
		        builder.Append2("&xpath=", HttpUtility.UrlEncode(XPath));
		    if (MaxRetrieve.HasValue)
		        builder.Append2("&maxRetrieve=", MaxRetrieve.Value.ToString(CultureInfo.InvariantCulture));
		    if (BaseUrl != null)
		        builder.Append2("&baseUrl=", HttpUtility.UrlEncode(BaseUrl));
		   
			return builder.ToString();
		}
	}
}
