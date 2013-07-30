using System.Xml.Linq;

namespace AlchemyAPI.FullMetal
{
    public class Disambigutation
    {
        public string Name { get; private set; }
        public string Website { get; private set; }

        public string Geo { get; private set; }

        public string Dbpedia { get; private set; }
        public string Yago { get; private set; }
        public string OpenCyc { get; private set; }
        public string Umbel { get; private set; }
        public string Freebase { get; private set; }
        public string CiaFactbook { get; private set; }
        public string Census { get; private set; }
        public string Geonames { get; private set; }
        public string MusicBrainz { get; private set; }
        public string Crunchbase { get; private set; }

        public Disambigutation(XElement disambiguationElement)
        {
            Name = disambiguationElement.MaybeGetElementValue("name");
            Website = disambiguationElement.MaybeGetElementValue("website");
            Geo = disambiguationElement.MaybeGetElementValue("geo");

            Dbpedia = disambiguationElement.MaybeGetElementValue("dbpedia");
            Yago = disambiguationElement.MaybeGetElementValue("yago");
            OpenCyc = disambiguationElement.MaybeGetElementValue("opencyc");
            Umbel = disambiguationElement.MaybeGetElementValue("umbel");
            Freebase = disambiguationElement.MaybeGetElementValue("freebase");
            CiaFactbook = disambiguationElement.MaybeGetElementValue("ciaFactbook");
            Census = disambiguationElement.MaybeGetElementValue("census");
            Geonames = disambiguationElement.MaybeGetElementValue("geonames");
            MusicBrainz = disambiguationElement.MaybeGetElementValue("musicBrainz");
            Crunchbase = disambiguationElement.MaybeGetElementValue("crunchbase");
        }
    }
}
