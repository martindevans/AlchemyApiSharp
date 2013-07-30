using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace AlchemyAPI.FullMetal
{
    public class FullMetalAlchemy
    {
        private Alchemy _alchemy;

        public int RequestCount
        {
            get { return _alchemy.RequestCount; }
        }

        /// <summary>
        /// Create a new FMA API interface
        /// </summary>
        /// <param name="apiKey">The Alchemy API key</param>
        public FullMetalAlchemy(string apiKey)
        {
            _alchemy = new Alchemy
            {
                ApiKey = apiKey,
                UseSSL = true
            };

            Text = new Text(_alchemy);
        }

        public Text Text { get; private set; }
    }

    public class Text
    {
        private readonly Alchemy _alchemy;

        internal Text(Alchemy alchemy)
        {
            _alchemy = alchemy;
        }

        public IEnumerable<NamedEntity> GetNamedEntities(string text)
        {
            var result = _alchemy.TextGetRankedNamedEntities(text, new EntityParams
            {
                Coreference = true,
                Disambiguate = true,
                LinkedData = true,
                OutputMode = OutputMode.Xml,
                Quotations = true,
                Sentiment = true,
                ShowSourceText = true,
            });

            XDocument xml = XDocument.Parse(result);
            XElement resultsElement = xml.Element("results");
            if (resultsElement == null)
                yield break;
            XElement entitiesElement = resultsElement.Element("entities");
            if (entitiesElement == null)
                yield break;

            foreach (var entity in entitiesElement.Elements("entity"))
            {
                yield return new NamedEntity(entity);
            }
        }
    }
}
