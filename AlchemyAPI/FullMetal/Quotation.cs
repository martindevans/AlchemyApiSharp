using System.Xml.Linq;

namespace AlchemyAPI.FullMetal
{
    public class Quotation
    {
        public readonly string Text;
        public readonly Sentiment Sentiment;

        internal Quotation(XElement quote)
        {
            var q = quote.Element("text");
            if (q != null)
                Text = q.Value;

            var s = quote.Element("sentiment");
            if (s != null)
                Sentiment = new Sentiment(s);
        }
    }
}
