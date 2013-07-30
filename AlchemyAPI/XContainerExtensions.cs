using System;
using System.Xml.Linq;

namespace AlchemyAPI
{
    static class XContainerExtensions
    {
        public static string MaybeGetElementValue(this XContainer container, string element)
        {
            var el = container.Element(element);
            return el != null ? el.Value : null;
        }

        public static T? MaybeParseElementValue<T>(this XContainer container, string elementName, Func<string, T> parse) where T : struct
        {
            var v = MaybeGetElementValue(container, elementName);
            if (v == null)
                return null;
            return parse(v);
        }
    }
}
