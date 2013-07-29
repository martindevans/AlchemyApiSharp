using System;
using System.IO;
using AlchemyAPI;
using ExampleCommon;

namespace Example_Parameters
{
    class Program
        :BaseExample
    {
        static void Main(string[] args)
        {
            new Program().Example();
        }

        protected override void Example()
        {
            // Create an AlchemyAPI object.
            KeywordParams keywordParams = new KeywordParams();
            EntityParams entityParams = new EntityParams();

            keywordParams.MaxRetrieve = 1;
            keywordParams.ShowSourceText = true;
            keywordParams.SourceTextMode = SourceTextModes.Raw;
            keywordParams.Sentiment = true;

            // Extract a ranked list of named entities from a web URL with parameters.
            string xml = Api.URLGetRankedKeywords("http://www.techcrunch.com/", keywordParams);
            Console.WriteLine(xml);

            // Load a HTML document to analyze.
            StreamReader streamReader = new StreamReader("example.html");
            string htmlDoc = streamReader.ReadToEnd();
            streamReader.Close();

            entityParams.MaxRetrieve = 3;
            entityParams.Disambiguate = true;
            entityParams.OutputMode = OutputMode.Rdf;
            entityParams.Sentiment = true;
            // Extract a ranked list of named entities from a HTML document with parameters.
            xml = Api.HTMLGetRankedNamedEntities(htmlDoc, "http://www.test.com/", entityParams);
            Console.WriteLine(xml);

            base.Example();
        }
    }
}
