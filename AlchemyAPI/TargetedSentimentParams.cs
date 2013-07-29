using System;
using System.Text;
using System.Web;

namespace AlchemyAPI
{	
	public class TargetedSentimentParams : BaseParams
	{
	    public bool? ShowSourceText { get; set; }
	    public string Target { get; set; }

	    override public String getParameterString()
	    {
	        StringBuilder builder = new StringBuilder(base.getParameterString());

	        if (ShowSourceText.HasValue)
	            builder.Append2("&showSourceText=", (ShowSourceText.Value ? "1" : "0"));
	        if (Target != null)
	            builder.Append2("&target=", HttpUtility.UrlEncode(Target));

			return builder.ToString();
		}
	}
}

