using System;
using System.Text;

namespace AlchemyAPI
{
	public class TextParams : BaseParams
	{
	    public bool? UseMetadata { get; set; }
        public bool? ExtractLinks { get; set; }

	    override public String getParameterString()
	    {
	        StringBuilder builder = new StringBuilder(base.getParameterString());

	        if (UseMetadata.HasValue)
	            builder.Append2("&useMetadata=", (UseMetadata.Value ? "1" : "0"));
	        if (ExtractLinks.HasValue)
	            builder.Append2("&extractLinks=", (ExtractLinks.Value ? "1" : "0"));

            return builder.ToString();
		}
	}
}
