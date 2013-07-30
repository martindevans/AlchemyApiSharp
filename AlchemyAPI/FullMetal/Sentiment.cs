
using System;
using System.Xml.Linq;

namespace AlchemyAPI.FullMetal
{
    public class Sentiment
    {
        public readonly Sentiments Type;
        public readonly float Score;

        internal Sentiment(XElement element)
        {
            var t = element.Element("type");
            if (t.Value != null)
                Type = (Sentiments)Enum.Parse(typeof(Sentiments), t.Value, true);

            var v = element.Element("score");
            if (v != null)
                Score = float.Parse(v.Value);
        }
    }

    public enum Sentiments
    {
        Positive,
        Negative,
        Neutral
    }
}
