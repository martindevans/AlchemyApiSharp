using System;
using System.Text;
using System.Web;

namespace AlchemyAPI
{
    public enum OutputMode
    {
        None,
        Xml,
        Rdf
    };

	public class BaseParams
	{
        public string Url { get; set; }
	    public string Html { get; set; }
	    public string Text { get; set; }
	    public OutputMode OutputMode { get; set; }
	    public string CustomParameters { get; private set; }

	    public BaseParams()
	    {
            OutputMode = OutputMode.Xml;
	    }

		public String GetCustomParameters()
		{
			return CustomParameters;
		}

		public void SetCustomParameters(params object[] argsRest)
		{
		    StringBuilder builder = new StringBuilder("");

			for (int i = 0; i < argsRest.Length; ++i)
			{
                builder.Append2("&", argsRest[i].ToString());
			    if (++i < argsRest.Length)
                    builder.Append2("=", HttpUtility.UrlEncode((string)argsRest[i]));
			}

            CustomParameters = builder.ToString();
		}

		public void ResetBaseParams()
		{
			Url = null;
			Html = null;
			Text = null;
		}

		virtual public String getParameterString()
		{
		    StringBuilder builder = new StringBuilder("");

		    if (Url != null)
		        builder.Append2("&url=", HttpUtility.UrlEncode(Url));

		    if (Html != null)
		        builder.Append2("&html=", HttpUtility.UrlEncode(Html));

		    if (Text != null)
                builder.Append2("&text=", HttpUtility.UrlEncode(Text));

		    if (CustomParameters != null)
		        builder.Append(CustomParameters);

			if (OutputMode != OutputMode.None)
			{
                if (OutputMode == OutputMode.Xml)
                    builder.Append("&outputMode=xml");
                else if (OutputMode == OutputMode.Rdf)
                    builder.Append("&outputMode=rdf");
			}

		    return builder.ToString();
		}
	}
}
