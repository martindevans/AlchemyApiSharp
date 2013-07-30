using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Xml;

namespace AlchemyAPI
{

    public class Alchemy
    {
        private string _apiKey;
        public string ApiKey
        {
            get { return _apiKey; }
            set
            {
                _apiKey = value;
                if (_apiKey.Length < 5)
                    throw new ArgumentException("value");
            }
        }

        private string _apiHost = "access";
        public string ApiHost
        {
            get { return _apiHost; }
            set
            {
                _apiHost = value ?? "access";   //Use a default api host
                if (_apiHost.Length < 2)
                    throw new ArgumentException("value");
            }
        }

        public bool UseSSL { get; set; }

        private int _requestCount;
        public int RequestCount
        {
            get { return _requestCount; }
        }

        private string _requestUri
        {
            get { return "http" + (UseSSL ? "s" : "") + "://" + _apiHost + ".alchemyapi.com/calls/"; }
        }

        public Alchemy()
        {
            _apiKey = "";
            UseSSL = true;
        }

        public void LoadAPIKey(string filename)
        {
            string line;
            using (StreamReader reader = File.OpenText(filename))
                line = reader.ReadLine();

            ApiKey = line.Trim();
        }

        public string URLGetAuthor(string url)
        {
            CheckURL(url);

            return URLGetAuthor(url, new BaseParams());
        }

        public string URLGetAuthor(string url, BaseParams parameters)
        {
            CheckURL(url);
            parameters.Url = url;

            return GET("URLGetAuthor", "url", parameters);
        }

        public string HTMLGetAuthor(string html, string url)
        {
            CheckHTML(html, url);

            return HTMLGetAuthor(html, url, new BaseParams());
        }

        public string HTMLGetAuthor(string html, string url, BaseParams parameters)
        {
            CheckHTML(html, url);
            parameters.Html = html;
            parameters.Url = url;

            return POST("HTMLGetAuthor", "html", parameters);
        }

        public string URLGetRankedNamedEntities(string url)
        {
            CheckURL(url);

            return URLGetRankedNamedEntities(url, new EntityParams());
        }

        public string URLGetRankedNamedEntities(string url, EntityParams parameters)
        {
            CheckURL(url);
            parameters.Url = url;

            return GET("URLGetRankedNamedEntities", "url", parameters);
        }

        public string HTMLGetRankedNamedEntities(string html, string url)
        {
            CheckHTML(html, url);

            return HTMLGetRankedNamedEntities(html, url, new EntityParams());
        }


        public string HTMLGetRankedNamedEntities(string html, string url, EntityParams parameters)
        {
            CheckHTML(html, url);
            parameters.Html = html;
            parameters.Url = url;

            return POST("HTMLGetRankedNamedEntities", "html", parameters);
        }

        public string TextGetRankedNamedEntities(string text)
        {
            CheckText(text);

            return TextGetRankedNamedEntities(text, new EntityParams());
        }

        public string TextGetRankedNamedEntities(string text, EntityParams parameters)
        {
            CheckText(text);
            parameters.Text = text;

            return POST("TextGetRankedNamedEntities", "text", parameters);
        }

        public string URLGetRankedConcepts(string url)
        {
            CheckURL(url);

            return URLGetRankedConcepts(url, new ConceptParams());
        }

        public string URLGetRankedConcepts(string url, ConceptParams parameters)
        {
            CheckURL(url);
            parameters.Url = url;

            return GET("URLGetRankedConcepts", "url", parameters);
        }

        public string HTMLGetRankedConcepts(string html, string url)
        {
            CheckHTML(html, url);

            return HTMLGetRankedConcepts(html, url, new ConceptParams());
        }

        public string HTMLGetRankedConcepts(string html, string url, ConceptParams parameters)
        {
            CheckHTML(html, url);
            parameters.Html = html;
            parameters.Url = url;

            return POST("HTMLGetRankedConcepts", "html", parameters);
        }

        public string TextGetRankedConcepts(string text)
        {
            CheckText(text);

            return TextGetRankedConcepts(text, new ConceptParams());
        }

        public string TextGetRankedConcepts(string text, ConceptParams parameters)
        {
            CheckText(text);
            parameters.Text = text;

            return POST("TextGetRankedConcepts", "text", parameters);
        }

        public string URLGetRankedKeywords(string url)
        {
            CheckURL(url);

            return URLGetRankedKeywords(url, new KeywordParams());
        }

        public string URLGetRankedKeywords(string url, KeywordParams parameters)
        {
            CheckURL(url);
            parameters.Url = url;

            return GET("URLGetRankedKeywords", "url", parameters);
        }

        public string HTMLGetRankedKeywords(string html, string url)
        {
            CheckHTML(html, url);

            return HTMLGetRankedKeywords(html, url, new KeywordParams());
        }

        public string HTMLGetRankedKeywords(string html, string url, KeywordParams parameters)
        {
            CheckHTML(html, url);
            parameters.Html = html;
            parameters.Url = url;

            return POST("HTMLGetRankedKeywords", "html", parameters);
        }

        public string TextGetRankedKeywords(string text)
        {
            CheckText(text);

            return TextGetRankedKeywords(text, new KeywordParams());
        }

        public string TextGetRankedKeywords(string text, KeywordParams parameters)
        {
            CheckText(text);
            parameters.Text = text;

            return POST("TextGetRankedKeywords", "text", parameters);
        }

        public string URLGetLanguage(string url)
        {
            CheckURL(url);

            return URLGetLanguage(url, new LanguageParams());
        }

        public string URLGetLanguage(string url, LanguageParams parameters)
        {
            CheckURL(url);
            parameters.Url = url;

            return GET("URLGetLanguage", "url", parameters);
        }

        public string HTMLGetLanguage(string html, string url)
        {
            CheckHTML(html, url);

            return HTMLGetLanguage(html, url, new LanguageParams());
        }

        public string HTMLGetLanguage(string html, string url, LanguageParams parameters)
        {
            CheckHTML(html, url);
            parameters.Html = html;
            parameters.Url = url;

            return POST("HTMLGetLanguage", "html", parameters);
        }

        public string TextGetLanguage(string text)
        {
            CheckText(text);

            return TextGetLanguage(text, new LanguageParams());
        }

        public string TextGetLanguage(string text, LanguageParams parameters)
        {
            CheckText(text);
            parameters.Text = text;

            return POST("TextGetLanguage", "text", parameters);
        }

        public string URLGetCategory(string url)
        {
            CheckURL(url);

            return URLGetCategory(url, new CategoryParams());
        }

        public string URLGetCategory(string url, CategoryParams parameters)
        {
            CheckURL(url);
            parameters.Url = url;

            return GET("URLGetCategory", "url", parameters);
        }

        public string HTMLGetCategory(string html, string url)
        {
            CheckHTML(html, url);

            return HTMLGetCategory(html, url, new CategoryParams());
        }

        public string HTMLGetCategory(string html, string url, CategoryParams parameters)
        {
            CheckHTML(html, url);
            parameters.Html = html;
            parameters.Url = url;

            return POST("HTMLGetCategory", "html", parameters);
        }

        public string TextGetCategory(string text)
        {
            CheckText(text);

            return TextGetCategory(text, new CategoryParams());
        }

        public string TextGetCategory(string text, CategoryParams parameters)
        {
            CheckText(text);
            parameters.Text = text;

            return POST("TextGetCategory", "text", parameters);
        }

        public string URLGetText(string url)
        {
            CheckURL(url);

            return URLGetText(url, new TextParams());
        }

        public string URLGetText(string url, TextParams parameters)
        {
            CheckURL(url);
            parameters.Url = url;

            return GET("URLGetText", "url", parameters);
        }

        public string HTMLGetText(string html, string url)
        {
            CheckHTML(html, url);

            return HTMLGetText(html, url, new TextParams());
        }

        public string HTMLGetText(string html, string url, TextParams parameters)
        {
            CheckHTML(html, url);
            parameters.Html = html;
            parameters.Url = url;

            return POST("HTMLGetText", "html", parameters);
        }

        public string URLGetRawText(string url)
        {
            CheckURL(url);

            return URLGetRawText(url, new BaseParams());
        }

        public string URLGetRawText(string url, BaseParams parameters)
        {
            CheckURL(url);
            parameters.Url = url;

            return GET("URLGetRawText", "url", parameters);
        }

        public string HTMLGetRawText(string html, string url)
        {
            CheckHTML(html, url);

            return HTMLGetRawText(html, url, new BaseParams());
        }

        public string HTMLGetRawText(string html, string url, BaseParams parameters)
        {
            CheckHTML(html, url);
            parameters.Html = html;
            parameters.Url = url;

            return POST("HTMLGetRawText", "html", parameters);
        }

        public string URLGetTitle(string url)
        {
            CheckURL(url);

            return URLGetTitle(url, new BaseParams());
        }

        public string URLGetTitle(string url, BaseParams parameters)
        {
            CheckURL(url);
            parameters.Url = url;

            return GET("URLGetTitle", "url", parameters);
        }

        public string HTMLGetTitle(string html, string url)
        {
            CheckHTML(html, url);

            return HTMLGetTitle(html, url, new BaseParams());
        }

        public string HTMLGetTitle(string html, string url, BaseParams parameters)
        {
            CheckHTML(html, url);
            parameters.Html = html;
            parameters.Url = url;

            return POST("HTMLGetTitle", "html", parameters);
        }

        public string URLGetFeedLinks(string url)
        {
            CheckURL(url);

            return URLGetFeedLinks(url, new BaseParams());
        }

        public string URLGetFeedLinks(string url, BaseParams parameters)
        {
            CheckURL(url);
            parameters.Url = url;

            return GET("URLGetFeedLinks", "url", parameters);
        }

        public string HTMLGetFeedLinks(string html, string url)
        {
            CheckHTML(html, url);

            return HTMLGetFeedLinks(html, url, new BaseParams());
        }

        public string HTMLGetFeedLinks(string html, string url, BaseParams parameters)
        {
            CheckHTML(html, url);
            parameters.Html = html;
            parameters.Url = url;

            return POST("HTMLGetFeedLinks", "html", parameters);
        }

        public string URLGetMicroformats(string url)
        {
            CheckURL(url);

            return URLGetMicroformats(url, new BaseParams());
        }

        public string URLGetMicroformats(string url, BaseParams parameters)
        {
            CheckURL(url);
            parameters.Url = url;

            return GET("URLGetMicroformatData", "url", parameters);
        }

        public string HTMLGetMicroformats(string html, string url)
        {
            CheckHTML(html, url);

            return HTMLGetMicroformats(html, url, new BaseParams());
        }

        public string HTMLGetMicroformats(string html, string url, BaseParams parameters)
        {
            CheckHTML(html, url);
            parameters.Html = html;
            parameters.Url = url;

            return POST("HTMLGetMicroformatData", "html", parameters);
        }

        public string URLGetConstraintQuery(string url, string query)
        {
            CheckURL(url);
            if (query.Length < 2)
                throw new ApplicationException("Invalid constraint query specified.");

            ConstraintQueryParams cqParams = new ConstraintQueryParams
            {
                CQuery = query
            };

            return URLGetConstraintQuery(url, cqParams);
        }

        public string URLGetConstraintQuery(string url, ConstraintQueryParams parameters)
        {
            CheckURL(url);
            if (parameters.CQuery.Length < 2)
                throw new ApplicationException("Invalid constraint query specified.");

            parameters.Url = url;

            return POST("URLGetConstraintQuery", "url", parameters);
        }

        public string HTMLGetConstraintQuery(string html, string url, string query)
        {
            CheckHTML(html, url);
            if (query.Length < 2)
            {
                throw new ApplicationException("Invalid constraint query specified.");
            }

            ConstraintQueryParams cqParams = new ConstraintQueryParams
            {
                CQuery = query
            };

            return HTMLGetConstraintQuery(html, url, cqParams);
        }

        public string HTMLGetConstraintQuery(string html, string url, ConstraintQueryParams parameters)
        {
            CheckHTML(html, url);
            if (parameters.CQuery.Length < 2)
                throw new ApplicationException("Invalid constraint query specified.");

            parameters.Html = html;
            parameters.Url = url;

            return POST("HTMLGetConstraintQuery", "html", parameters);
        }

        public string URLGetTextSentiment(string url)
        {
            CheckURL(url);

            return URLGetTextSentiment(url, new BaseParams());
        }

        public string URLGetTextSentiment(string url, BaseParams parameters)
        {
            CheckURL(url);
            parameters.Url = url;

            return GET("URLGetTextSentiment", "url", parameters);
        }

        public string HTMLGetTextSentiment(string html, string url)
        {
            CheckHTML(html, url);

            return HTMLGetTextSentiment(html, url, new BaseParams());
        }

        public string HTMLGetTextSentiment(string html, string url, BaseParams parameters)
        {
            CheckHTML(html, url);
            parameters.Html = html;
            parameters.Url = url;

            return POST("HTMLGetTextSentiment", "html", parameters);
        }

        public string TextGetTextSentiment(string text)
        {
            CheckText(text);

            return TextGetTextSentiment(text, new BaseParams());
        }

        public string TextGetTextSentiment(string text, BaseParams parameters)
        {
            CheckText(text);
            parameters.Text = text;

            return POST("TextGetTextSentiment", "text", parameters);
        }

        //------
        public string URLGetTargetedSentiment(string url, string target)
        {
            CheckURL(url);
            CheckText(target);

            return URLGetTargetedSentiment(url, target, new TargetedSentimentParams());
        }

        public string URLGetTargetedSentiment(string url, string target, TargetedSentimentParams parameters)
        {
            CheckURL(url);
            CheckText(target);

            parameters.Url = url;
            parameters.Target = target;

            return GET("URLGetTargetedSentiment", "url", parameters);
        }

        public string HTMLGetTargetedSentiment(string html, string url, string target)
        {
            CheckHTML(html, url);
            CheckText(target);

            return HTMLGetTargetedSentiment(html, url, target, new TargetedSentimentParams());
        }

        public string HTMLGetTargetedSentiment(string html, string url, string target, TargetedSentimentParams parameters)
        {

            CheckHTML(html, url);
            CheckText(target);

            parameters.Html = html;
            parameters.Url = url;
            parameters.Target = target;

            return POST("HTMLGetTargetedSentiment", "html", parameters);
        }

        public string TextGetTargetedSentiment(string text, string target)
        {
            CheckText(text);
            CheckText(target);

            return TextGetTargetedSentiment(text, target, new TargetedSentimentParams());
        }

        public string TextGetTargetedSentiment(string text, string target, TargetedSentimentParams parameters)
        {
            CheckText(text);
            CheckText(target);

            parameters.Text = text;
            parameters.Target = target;

            return POST("TextGetTargetedSentiment", "text", parameters);
        }

        public string URLGetRelations(string url)
        {
            CheckURL(url);

            return URLGetRelations(url, new RelationParams());
        }

        public string URLGetRelations(string url, RelationParams parameters)
        {
            CheckURL(url);
            parameters.Url = url;

            return GET("URLGetRelations", "url", parameters);
        }

        public string HTMLGetRelations(string html, string url)
        {
            CheckHTML(html, url);

            return HTMLGetRelations(html, url, new RelationParams());
        }

        public string HTMLGetRelations(string html, string url, RelationParams parameters)
        {
            CheckHTML(html, url);
            parameters.Html = html;
            parameters.Url = url;

            return POST("HTMLGetRelations", "html", parameters);
        }

        public string TextGetRelations(string text)
        {
            CheckText(text);

            return TextGetRelations(text, new RelationParams());
        }

        public string TextGetRelations(string text, RelationParams parameters)
        {
            CheckText(text);
            parameters.Text = text;

            return POST("TextGetRelations", "text", parameters);
        }

        private void CheckHTML(string html, string url)
        {
            if (string.IsNullOrWhiteSpace(html))
                throw new ApplicationException("Enter a HTML document to analyze.");

            if (string.IsNullOrWhiteSpace(url))
                throw new ApplicationException("Enter a web URL to analyze.");
        }

        private void CheckText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ApplicationException("Enter some text to analyze.");
        }

        private void CheckURL(string url)
        {
            if (url.Length < 10)
                throw new ApplicationException("Enter a web URL to analyze.");
        }

        private string GET(string callName, string callPrefix, BaseParams parameters)
        {
            // callMethod, callPrefix, ... params
            StringBuilder uri = new StringBuilder();
            uri.Append(_requestUri).Append(callPrefix).Append("/").Append(callName);
            uri.Append("?apikey=").Append(_apiKey).Append(parameters.getParameterString());

            parameters.ResetBaseParams();

            Uri address = new Uri(uri.ToString());
            HttpWebRequest wreq = (HttpWebRequest) WebRequest.Create(address);
            wreq.Method = "GET";

            return DoRequest(wreq, parameters.OutputMode);
        }

        private string POST(string callName, string callPrefix, BaseParams parameters)
        {
            // callMethod, callPrefix, ... params
            Uri address = new Uri(_requestUri + callPrefix + "/" + callName);

            HttpWebRequest wreq = (HttpWebRequest)WebRequest.Create(address);
            wreq.Method = WebRequestMethods.Http.Post;
            wreq.ContentType = "application/x-www-form-urlencoded";
            wreq.Headers.Add("Accept-encoding", "gzip,deflate");
            wreq.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            StringBuilder d = new StringBuilder();
            d.Append("apikey=").Append(_apiKey).Append(parameters.getParameterString());

            parameters.ResetBaseParams();

            byte[] bd = Encoding.UTF8.GetBytes(d.ToString());

            wreq.ContentLength = bd.Length;
            using (Stream ps = wreq.GetRequestStream())
            {
                ps.Write(bd, 0, bd.Length);
            }

            return DoRequest(wreq, parameters.OutputMode);
        }

        private string DoRequest(HttpWebRequest wreq, OutputMode outputMode)
        {
            Interlocked.Increment(ref _requestCount);

            using (HttpWebResponse wres = (HttpWebResponse) wreq.GetResponse())
            {
                StreamReader r = new StreamReader(wres.GetResponseStream());

                string xml = r.ReadToEnd();

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);

                XmlElement root = xmlDoc.DocumentElement;

                if (OutputMode.Xml == outputMode)
                {
                    XmlNode status = root.SelectSingleNode("/results/status");

                    if (status.InnerText != "OK")
                        throw new ApplicationException("Error making API call.");
                }
                else if (OutputMode.Rdf == outputMode)
                {
                    XmlNamespaceManager nm = new XmlNamespaceManager(xmlDoc.NameTable);
                    nm.AddNamespace("rdf", "http://www.w3.org/1999/02/22-rdf-syntax-ns#");
                    nm.AddNamespace("aapi", "http://rdf.alchemyapi.com/rdf/v1/s/aapi-schema#");
                    XmlNode status = root.SelectSingleNode("/rdf:RDF/rdf:Description/aapi:ResultStatus", nm);

                    if (status.InnerText != "OK")
                        throw new ApplicationException("Error making API call.");
                }

                return xml;
            }
        }
    }
}