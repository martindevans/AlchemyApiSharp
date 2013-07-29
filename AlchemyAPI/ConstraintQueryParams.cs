using System.Text;
using System.Web;

namespace AlchemyAPI
{
	public class ConstraintQueryParams : BaseParams
	{
	    public string CQuery { get; set; }

		override public string getParameterString()
		{
		    StringBuilder builder = new StringBuilder(base.getParameterString());

		    if (CQuery != null)
		        builder.Append2("&cquery=", HttpUtility.UrlEncode(CQuery));

            return builder.ToString();
		}
	}
}
