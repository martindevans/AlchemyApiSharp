using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace AlchemyAPI.FullMetal
{
    public class FullMetalAlchemy
    {
        internal readonly Alchemy Alchemy;

        public int RequestCount
        {
            get { return Alchemy.RequestCount; }
        }

        /// <summary>
        /// Create a new FMA API interface
        /// </summary>
        /// <param name="apiKey">The Alchemy API key</param>
        public FullMetalAlchemy(string apiKey)
        {
            Alchemy = new Alchemy
            {
                ApiKey = apiKey,
                UseSSL = true
            };

            Text = new Text(this);
        }

        /// <summary>
        /// Container for alchemy operations on text
        /// </summary>
        public Text Text { get; private set; }

        /// <summary>
        /// Container for alchemy operations on html
        /// </summary>
        public Html Html { get; private set; }

        /// <summary>
        /// Container for alchemy operations on urls
        /// </summary>
        public Url Url { get; private set; }

        internal IEnumerable<NamedEntity> ParseNamedEntities(XContainer root)
        {
            XElement resultsElement = root.Element("results");
            if (resultsElement == null)
                yield break;
            XElement entitiesElement = resultsElement.Element("entities");
            if (entitiesElement == null)
                yield break;

            foreach (var entity in entitiesElement.Elements("entity"))
                yield return new NamedEntity(entity);
        }
    }

    public class Text
    {
        private readonly FullMetalAlchemy _fma;

        internal Text(FullMetalAlchemy fma)
        {
            _fma = fma;
        }

        public IEnumerable<NamedEntity> GetNamedEntities(string text)
        {
            var result = _fma.Alchemy.TextGetRankedNamedEntities(text, new EntityParams
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
            return _fma.ParseNamedEntities(xml);
        }
    }

    public class Html
    {
        private readonly FullMetalAlchemy _fma;

        internal Html(FullMetalAlchemy fma)
        {
            _fma = fma;
        }

        public IEnumerable<NamedEntity> GetNamedEntities(string html, string url)
        {
            var result = _fma.Alchemy.HTMLGetRankedNamedEntities(html, url, new EntityParams
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
            return _fma.ParseNamedEntities(xml);
        }
    }

    public class Url
    {
        private readonly FullMetalAlchemy _fma;

        internal Url(FullMetalAlchemy fma)
        {
            _fma = fma;
        }

        public IEnumerable<NamedEntity> GetNamedEntities(string url)
        {
            var result = _fma.Alchemy.URLGetRankedNamedEntities(url, new EntityParams
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
            return _fma.ParseNamedEntities(xml);
        }
    }
}
