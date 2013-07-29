using System;
using System.IO;
using AlchemyAPI;
using ExampleCommon;

namespace Example_Sentiment
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
            // Extract sentiment for a web URL.
            string xml = Api.URLGetTextSentiment("http://www.techcrunch.com/");
            Console.WriteLine(xml);


            // Extract sentiment from a text string.
            xml = Api.TextGetTextSentiment("Hello there, my name is Bob Jones.  I live in the United States of America.  Where do you live, Fred?");
            Console.WriteLine(xml);


            // Load a HTML document to analyze.
            StreamReader streamReader = new StreamReader("example.html");
            string htmlDoc = streamReader.ReadToEnd();
            streamReader.Close();


            // Extract sentiment from a HTML document.
            xml = Api.HTMLGetTextSentiment(htmlDoc, "http://www.test.com/");
            Console.WriteLine(xml);


            // Extract named entities with entity-targeted sentiment.
            EntityParams entityParams = new EntityParams
            {
                Sentiment = true
            };
            xml = Api.TextGetRankedNamedEntities("Bryan Adams' genius is unsurpassed.", entityParams);
            Console.WriteLine(xml);


            // Extract keywords with keyword-targeted sentiment.
            KeywordParams keywordParams = new KeywordParams
            {
                Sentiment = true
            };
            xml = Api.TextGetRankedKeywords("Bryan Adams' genius is unsurpassed.", keywordParams);
            Console.WriteLine(xml);

            // Extract Targeted Sentiment
            TargetedSentimentParams sentimentParams = new TargetedSentimentParams
            {
                ShowSourceText = true
            };
            xml = Api.TextGetTargetedSentiment("This car is terrible.", "car", sentimentParams);
            Console.WriteLine(xml);

            sentimentParams.ShowSourceText = true;
            xml = Api.TextGetTargetedSentiment("This car is terribly good.", "car", sentimentParams);
            Console.WriteLine(xml);

            xml = Api.URLGetTargetedSentiment("http://techcrunch.com/2012/03/01/keen-on-anand-rajaraman-how-walmart-wants-to-leapfrog-over-amazon-tctv/", "Walmart", sentimentParams);
            Console.WriteLine(xml);

            xml = Api.HTMLGetTargetedSentiment(htmlDoc, "http://www.test.com/", "WujWuj", sentimentParams);
            Console.WriteLine(xml);

            base.Example();
        }
    }
}
