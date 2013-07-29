using System;
using System.IO;
using AlchemyAPI;
using ExampleCommon;

namespace Example_Relations
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
            // Extract a ranked list of relations from a web URL.
            string xml = Api.URLGetRelations("http://www.techcrunch.com/");
            Console.WriteLine(xml);


            // Extract a ranked list of relations from a text string.
            xml = Api.TextGetRelations("Hello there, my name is Bob Jones.  I live in the United States of America.  Where do you live, Fred?");
            Console.WriteLine(xml);


            // Load a HTML document to analyze.
            StreamReader streamReader = new StreamReader("example.html");
            string htmlDoc = streamReader.ReadToEnd();
            streamReader.Close();


            // Extract a ranked list of relations from a HTML document.
            xml = Api.HTMLGetRelations(htmlDoc, "http://www.test.com/");
            Console.WriteLine(xml);

            RelationParams relationParams = new RelationParams
            {
                Sentiment = true,
                Entities = true,
                Disambiguate = true,
                SentimentExcludeEntities = true
            };
            xml = Api.TextGetRelations("Madonna enjoys tasty Pepsi.  I love her style.", relationParams);
            Console.WriteLine(xml);

            relationParams.Sentiment = true;
            relationParams.RequireEntities = true;
            relationParams.SentimentExcludeEntities = false;
            xml = Api.TextGetRelations("Madonna enjoys tasty Pepsi.  I love her style.", relationParams);
            Console.WriteLine(xml);

            base.Example();
        }
    }
}
