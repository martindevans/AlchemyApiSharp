using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;

namespace AlchemyAPI.FullMetal
{
    public class NamedEntity
    {
        private readonly KeyValuePair<string, EntityType> _type;
        /// <summary>
        /// The type of this entity
        /// </summary>
        public KeyValuePair<string, EntityType> Type
        {
            get { return _type; }
        }

        /// <summary>
        /// If the type string could not be understood, this is the raw value of the type field
        /// </summary>
        public string RawTypeString { get; private set; }

        /// <summary>
        /// The name of this entity
        /// </summary>
        public string Name { get; private set; }

        public float? Relevance { get; private set; }

        public int? Count { get; private set; }

        /// <summary>
        /// The text which this entity was extracted from
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// The subtypes of this entity (if any) paired with the raw string of the subtype
        /// </summary>
        public IEnumerable<KeyValuePair<string, EntitySubtype>> Subtypes { get; private set; }

        /// <summary>
        /// Quotes from this entity
        /// </summary>
        public IEnumerable<Quotation> Quotes { get; private set; }

        /// <summary>
        /// The sentiment towards this entity
        /// </summary>
        public Sentiment Sentiment { get; private set; }

        public Disambigutation Disambigutation { get; private set; }

        public NamedEntity(XElement entity)
        {
            _type = ParseType(entity);
            Subtypes = ParseSubtypes(entity).ToArray();
            Quotes = ParseQuotes(entity).ToArray();

            Name = entity.MaybeGetElementValue("name");
            Relevance = entity.MaybeParseElementValue<float>("relevance", float.Parse);
            Count = entity.MaybeParseElementValue<int>("count", int.Parse);
            Text = entity.MaybeGetElementValue("text");

            //Sentiment
            var sentimentElement = entity.Element("sentiment");
            if (sentimentElement != null)
                Sentiment = new Sentiment(sentimentElement);

            //Disambiguation
            var disambiguationElement = entity.Element("disambiguated");
            if (disambiguationElement != null)
                Disambigutation = new Disambigutation(disambiguationElement);
        }

        private static IEnumerable<Quotation> ParseQuotes(XElement entity)
        {
            var disambiguatedElement = entity.Element("quotations");
            if (disambiguatedElement == null)
                yield break;

            foreach (var quote in disambiguatedElement.Elements("quotation"))
                yield return new Quotation(quote);
        }


        private static IEnumerable<KeyValuePair<string, EntitySubtype>> ParseSubtypes(XElement entity)
        {
            var disambiguatedElement = entity.Element("disambiguated");
            if (disambiguatedElement == null)
                yield break;

            foreach (var subtype in disambiguatedElement.Elements("subType"))
            {
                var cleaned = subtype.Value.Replace(".", ""); //e.g. type U.S.CongressPerson
                cleaned = cleaned.Replace("-", ""); //e.g. type Non-ProfitOrganisation

                EntitySubtype sub;
                if (!Enum.TryParse<EntitySubtype>(cleaned, true, out sub))
                    sub = EntitySubtype.UnknownSubtype;

                yield return new KeyValuePair<string, EntitySubtype>(subtype.Value, sub);
            }
        }

        private static KeyValuePair<string, EntityType> ParseType(XElement entity)
        {
            EntityType e = EntityType.None;
            string raw = null;

            var typeElement = entity.Element("type");
            if (typeElement != null)
            {
                raw = typeElement.Value;
                var cleaned = raw.Replace(".", ""); //e.g. type U.S.CongressPerson
                cleaned = cleaned.Replace("-", ""); //e.g. type Non-ProfitOrganisation

                if (!Enum.TryParse<EntityType>(cleaned, true, out e))
                    e = EntityType.UnknownType;
            }

            return new KeyValuePair<string,EntityType>(raw, e);
        }
    }

    /// <summary>
    /// <seealso cref="http://www.alchemyapi.com/api/entity/types.html"/>
    /// </summary>
    public enum EntityType
    {
        /// <summary>
        /// The type is not contained in this enum, parse the RawTypeString yourself
        /// </summary>
        UnknownType,

        /// <summary>
        /// No type was specified
        /// </summary>
        None,

        Anatomy,
        Automobile,
        Anniversary,
        City,
        Company,
        Continent,
        Country,
        Degree,
        Drug,
        EntertainmentAward,
        Facility,
        FieldTerminology,
        FinancialMarketIndex,
        GeographicFeature,
        HealthCondition,
        Holiday,
        JobTitle,
        Movie,
        MusicGroup,
        NaturalDisaster,
        TropicalCyclone,
        OperatingSystem,
        Organization,
        Person,
        PrintMedia,
        RadioProgram,
        RadioStation,
        Region,
        Sport,
        StateOrCounty,
        Technology,
        TelevisionShow,
        TelevisionStation
    }

    public enum EntitySubtype
    {
        /// <summary>
        /// The type is not contained in this enum, parse the raw value yourself
        /// </summary>
        UnknownSubtype,

        PoliticalDistrict,
        AdministrativeDivision,
        GovernmentalJurisdiction,

        MartialArt,

        EnglishRegion,
        FrenchRegion,
        ItalianRegion,
        VideoGameRegion,
        WineRegion,

        Magazine,
        Newspaper,
        SchoolNewspaper,

        Academic,
        AircraftDesigner,
        Appointee,
        Architect,
        ArchitectureFirmPartner,
        Astronaut,
        Astronomer,
        Author,
        AutomotiveDesigner,
        AwardJudge,
        AwardNominee,
        AwardWinner,
        BasketballCoach,
        BasketballPlayer,
        Bassist,
        Blogger,
        BoardMember,
        Boxer,
        BroadcastArtist,
        Celebrity,
        Chef,
        ChessPlayer,
        ChivalricOrderFounder,
        ChivalricOrderMember,
        ChivalricOrderOfficer,
        Collector,
        ComicBookColorist,
        ComicBookCreator,
        ComicBookEditor,
        ComicBookInker,
        ComicBookLetterer,
        ComicBookPenciler,
        ComicBookWriter,
        ComicStripArtist,
        ComicStripCharacter,
        ComicStripCreator,
        CompanyAdvisor,
        CompanyFounder,
        CompanyShareholder,
        Composer,
        ComputerDesigner,
        ComputerScientist,
        ConductedEnsemble,
        Conductor,
        CricketBowler,
        CricketCoach,
        CricketPlayer,
        CricketUmpire,
        Cyclist,
        Dedicatee,
        Dedicator,
        Deity,
        DietFollower,
        DisasterSurvivor,
        DisasterVictim,
        Drummer,
        ElementDiscoverer,
        FashionDesigner,
        FictionalCreature,
        FictionalUniverseCreator,
        FilmActor,
        FilmArtDirector,
        FilmCastingDirector,
        FilmCharacter,
        FilmCinematographer,
        FilmCostumerDesigner,
        FilmCrewmember,
        FilmCritic,
        FilmDirector,
        FilmEditor,
        FilmMusicContributor,
        FilmProducer,
        FilmProductionDesigner,
        FilmSetDesigner,
        FilmTheorist,
        FilmWriter,
        FootballCoach,
        FootballPlayer,
        FootballReferee,
        FootballTeamManager,
        FoundingFigure,
        GameDesigner,
        Golfer,
        Guitarist,
        HallOfFameInductee,
        Hobbyist,
        HockeyCoach,
        HockeyPlayer,
        HonoraryDegreeRecipient,
        Illustrator,
        Interviewer,
        Inventor,
        LandscapeArchitect,
        LanguageCreator,
        Lyricist,
        MartialArtist,
        MilitaryCommander,
        MilitaryPerson,
        Monarch,
        Mountaineer,
        MusicalArtist,
        MusicalGroupMember,
        NoblePerson,
        NobleTitle,
        OlympicAthlete,
        OperaCharacter,
        OperaDirector,
        OperaLibretto,
        OperaSinger,
        PeriodicalEditor,
        Physician,
        PoliticalAppointer,
        Politician,
        ProAthlete,
        ProgrammingLanguageDesigner,
        ProgrammingLanguageDeveloper,
        ProjectParticipant,
        RecordingEngineer,
        RecordProducer,
        ReligiousLeader,
        SchoolFounder,
        ShipDesigner,
        Songwriter,
        SportsLeagueAwardWinner,
        SportsOfficial,
        Surgeon,
        TennisPlayer,
        TennisTournamentChampion,
        TheaterActor,
        TheaterCharacter,
        TheaterChoreographer,
        TheaterDesigner,
        TheaterDirector,
        TheaterProducer,
        TheatricalComposer,
        TheatricalLyricist,
        Translator,
        TVActor,
        TVCharacter,
        TVDirector,
        TVPersonality,
        TVProducer,
        TVProgramCreator,
        TVWriter,
        USCongressperson,
        USPresident,
        USVicePresident,
        VideoGameActor,
        VideoGameDesigner,
        VisualArtist,

        AstronomicalSurveyProjectOrganization,
        AwardPresentingOrganization,
        Club,
        CollegeUniversity,
        CricketAdministrativeBody,
        FinancialSupportProvider,
        FootballOrganization,
        FraternitySorority,
        GovernmentAgency,
        LegislativeCommittee,
        Legislature,
        MartialArtsOrganization,
        MembershipOrganization,
        NaturalOrCulturalPreservationAgency,
        NonProfitOrganisation,
        OrganizationCommittee,
        PeriodicalPublisher,
        PoliticalParty,
        ReligiousOrder,
        ReligiousOrganization,
        ReportIssuingInstitution,
        SoccerClub,
        SpaceAgency,
        SportsAssociation,
        StudentOrganization,
        TopLevelDomainRegistry,
        TradeUnion,

        TropicalCyclone,

        BodyOfWater,
        Cave,
        GeologicalFormation,
        Glacier,
        Island,
        IslandGroup,
        Lake,
        Mountain,
        MountainPass,
        MountainRange,
        OilField,
        Park,
        ProtectedArea,
        River,
        Waterfall,

        Airport,
        Bridge,
        HistoricPlace,
        Hospital,
        Lighthouse,
        ShoppingMall,
        SkiArea,
        Skyscraper,
        Stadium,
        Station,

        AircraftManufacturer,
        Airline,
        AirportOperator,
        ArchitectureFirm,
        AutomobileCompany,
        BicycleManufacturer,
        BottledWater,
        BreweryBrandOfBeer,
        BroadcastDistributor,
        CandyBarManufacturer,
        ComicBookPublisher,
        ComputerManufacturerBrand,
        Distillery,
        EngineeringFirm,
        FashionLabel,
        FilmCompany,
        FilmDistributor,
        GamePublisher,
        ManufacturingPlant,
        MusicalInstrumentCompany,
        OperatingSystemDeveloper,
        ProcessorManufacturer,
        ProductionCompany,
        RadioNetwork,
        RecordLabel,
        Restaurant,
        RocketEngineDesigner,
        RocketManufacturer,
        ShipBuilder,
        SoftwareDeveloper,
        SpacecraftManufacturer,
        SpiritBottler,
        SpiritProductManufacturer,
        TransportOperator,
        TVNetwork,
        VentureFundedCompany,
        VentureInvestor,
        VideoGameDeveloper,
        VideoGameEngineDeveloper,
        VideoGamePublisher,
        WineProducer,
    }

    public static class EntitySubtypeExtensions
    {
        public static EntityType SuperType(this EntitySubtype type)
        {
            switch (type)
            {
                case EntitySubtype.PoliticalDistrict:
                case EntitySubtype.AdministrativeDivision:
                case EntitySubtype.GovernmentalJurisdiction:
                    return EntityType.StateOrCounty;

                case EntitySubtype.MartialArt:
                    return EntityType.Sport;

                case EntitySubtype.EnglishRegion:
                case EntitySubtype.FrenchRegion:
                case EntitySubtype.ItalianRegion:
                case EntitySubtype.VideoGameRegion:
                case EntitySubtype.WineRegion:
                    return EntityType.Region;

                case EntitySubtype.Magazine:
                case EntitySubtype.Newspaper:
                case EntitySubtype.SchoolNewspaper:
                    return EntityType.PrintMedia;

                #region person cases
                case EntitySubtype.Academic:
                case EntitySubtype.AircraftDesigner:
                case EntitySubtype.Appointee:
                case EntitySubtype.Architect:
                case EntitySubtype.ArchitectureFirmPartner:
                case EntitySubtype.Astronaut:
                case EntitySubtype.Astronomer:
                case EntitySubtype.Author:
                case EntitySubtype.AutomotiveDesigner:
                case EntitySubtype.AwardJudge:
                case EntitySubtype.AwardNominee:
                case EntitySubtype.AwardWinner:
                case EntitySubtype.BasketballCoach:
                case EntitySubtype.BasketballPlayer:
                case EntitySubtype.Bassist:
                case EntitySubtype.Blogger:
                case EntitySubtype.BoardMember:
                case EntitySubtype.Boxer:
                case EntitySubtype.BroadcastArtist:
                case EntitySubtype.Celebrity:
                case EntitySubtype.Chef:
                case EntitySubtype.ChessPlayer:
                case EntitySubtype.ChivalricOrderFounder:
                case EntitySubtype.ChivalricOrderMember:
                case EntitySubtype.ChivalricOrderOfficer:
                case EntitySubtype.Collector:
                case EntitySubtype.ComicBookColorist:
                case EntitySubtype.ComicBookCreator:
                case EntitySubtype.ComicBookEditor:
                case EntitySubtype.ComicBookInker:
                case EntitySubtype.ComicBookLetterer:
                case EntitySubtype.ComicBookPenciler:
                case EntitySubtype.ComicBookWriter:
                case EntitySubtype.ComicStripArtist:
                case EntitySubtype.ComicStripCharacter:
                case EntitySubtype.ComicStripCreator:
                case EntitySubtype.CompanyAdvisor:
                case EntitySubtype.CompanyFounder:
                case EntitySubtype.CompanyShareholder:
                case EntitySubtype.Composer:
                case EntitySubtype.ComputerDesigner:
                case EntitySubtype.ComputerScientist:
                case EntitySubtype.ConductedEnsemble:
                case EntitySubtype.Conductor:
                case EntitySubtype.CricketBowler:
                case EntitySubtype.CricketCoach:
                case EntitySubtype.CricketPlayer:
                case EntitySubtype.CricketUmpire:
                case EntitySubtype.Cyclist:
                case EntitySubtype.Dedicatee:
                case EntitySubtype.Dedicator:
                case EntitySubtype.Deity:
                case EntitySubtype.DietFollower:
                case EntitySubtype.DisasterSurvivor:
                case EntitySubtype.DisasterVictim:
                case EntitySubtype.Drummer:
                case EntitySubtype.ElementDiscoverer:
                case EntitySubtype.FashionDesigner:
                case EntitySubtype.FictionalCreature:
                case EntitySubtype.FictionalUniverseCreator:
                case EntitySubtype.FilmActor:
                case EntitySubtype.FilmArtDirector:
                case EntitySubtype.FilmCastingDirector:
                case EntitySubtype.FilmCharacter:
                case EntitySubtype.FilmCinematographer:
                case EntitySubtype.FilmCostumerDesigner:
                case EntitySubtype.FilmCrewmember:
                case EntitySubtype.FilmCritic:
                case EntitySubtype.FilmDirector:
                case EntitySubtype.FilmEditor:
                case EntitySubtype.FilmMusicContributor:
                case EntitySubtype.FilmProducer:
                case EntitySubtype.FilmProductionDesigner:
                case EntitySubtype.FilmSetDesigner:
                case EntitySubtype.FilmTheorist:
                case EntitySubtype.FilmWriter:
                case EntitySubtype.FootballCoach:
                case EntitySubtype.FootballPlayer:
                case EntitySubtype.FootballReferee:
                case EntitySubtype.FootballTeamManager:
                case EntitySubtype.FoundingFigure:
                case EntitySubtype.GameDesigner:
                case EntitySubtype.Golfer:
                case EntitySubtype.Guitarist:
                case EntitySubtype.HallOfFameInductee:
                case EntitySubtype.Hobbyist:
                case EntitySubtype.HockeyCoach:
                case EntitySubtype.HockeyPlayer:
                case EntitySubtype.HonoraryDegreeRecipient:
                case EntitySubtype.Illustrator:
                case EntitySubtype.Interviewer:
                case EntitySubtype.Inventor:
                case EntitySubtype.LandscapeArchitect:
                case EntitySubtype.LanguageCreator:
                case EntitySubtype.Lyricist:
                case EntitySubtype.MartialArtist:
                case EntitySubtype.MilitaryCommander:
                case EntitySubtype.MilitaryPerson:
                case EntitySubtype.Monarch:
                case EntitySubtype.Mountaineer:
                case EntitySubtype.MusicalArtist:
                case EntitySubtype.MusicalGroupMember:
                case EntitySubtype.NoblePerson:
                case EntitySubtype.NobleTitle:
                case EntitySubtype.OlympicAthlete:
                case EntitySubtype.OperaCharacter:
                case EntitySubtype.OperaDirector:
                case EntitySubtype.OperaLibretto:
                case EntitySubtype.OperaSinger:
                case EntitySubtype.PeriodicalEditor:
                case EntitySubtype.Physician:
                case EntitySubtype.PoliticalAppointer:
                case EntitySubtype.Politician:
                case EntitySubtype.ProAthlete:
                case EntitySubtype.ProgrammingLanguageDesigner:
                case EntitySubtype.ProgrammingLanguageDeveloper:
                case EntitySubtype.ProjectParticipant:
                case EntitySubtype.RecordingEngineer:
                case EntitySubtype.RecordProducer:
                case EntitySubtype.ReligiousLeader:
                case EntitySubtype.SchoolFounder:
                case EntitySubtype.ShipDesigner:
                case EntitySubtype.Songwriter:
                case EntitySubtype.SportsLeagueAwardWinner:
                case EntitySubtype.SportsOfficial:
                case EntitySubtype.Surgeon:
                case EntitySubtype.TennisPlayer:
                case EntitySubtype.TennisTournamentChampion:
                case EntitySubtype.TheaterActor:
                case EntitySubtype.TheaterCharacter:
                case EntitySubtype.TheaterChoreographer:
                case EntitySubtype.TheaterDesigner:
                case EntitySubtype.TheaterDirector:
                case EntitySubtype.TheaterProducer:
                case EntitySubtype.TheatricalComposer:
                case EntitySubtype.TheatricalLyricist:
                case EntitySubtype.Translator:
                case EntitySubtype.TVActor:
                case EntitySubtype.TVCharacter:
                case EntitySubtype.TVDirector:
                case EntitySubtype.TVPersonality:
                case EntitySubtype.TVProducer:
                case EntitySubtype.TVProgramCreator:
                case EntitySubtype.TVWriter:
                case EntitySubtype.USCongressperson:
                case EntitySubtype.USPresident:
                case EntitySubtype.USVicePresident:
                case EntitySubtype.VideoGameActor:
                case EntitySubtype.VideoGameDesigner:
                case EntitySubtype.VisualArtist:
                #endregion
                    return EntityType.Person;

                #region organization cases
                case EntitySubtype.AstronomicalSurveyProjectOrganization:
                case EntitySubtype.AwardPresentingOrganization:
                case EntitySubtype.Club:
                case EntitySubtype.CollegeUniversity:
                case EntitySubtype.CricketAdministrativeBody:
                case EntitySubtype.FinancialSupportProvider:
                case EntitySubtype.FootballOrganization:
                case EntitySubtype.FraternitySorority:
                case EntitySubtype.GovernmentAgency:
                case EntitySubtype.LegislativeCommittee:
                case EntitySubtype.Legislature:
                case EntitySubtype.MartialArtsOrganization:
                case EntitySubtype.MembershipOrganization:
                case EntitySubtype.NaturalOrCulturalPreservationAgency:
                case EntitySubtype.NonProfitOrganisation:
                case EntitySubtype.OrganizationCommittee:
                case EntitySubtype.PeriodicalPublisher:
                case EntitySubtype.PoliticalParty:
                case EntitySubtype.ReligiousOrder:
                case EntitySubtype.ReligiousOrganization:
                case EntitySubtype.ReportIssuingInstitution:
                case EntitySubtype.SoccerClub:
                case EntitySubtype.SpaceAgency:
                case EntitySubtype.SportsAssociation:
                case EntitySubtype.StudentOrganization:
                case EntitySubtype.TopLevelDomainRegistry:
                case EntitySubtype.TradeUnion:
                #endregion
                    return EntityType.Organization;

                case EntitySubtype.TropicalCyclone:
                    return EntityType.NaturalDisaster;

                #region geographic feature cases
                case EntitySubtype.BodyOfWater:
                case EntitySubtype.Cave:
                case EntitySubtype.GeologicalFormation:
                case EntitySubtype.Glacier:
                case EntitySubtype.Island:
                case EntitySubtype.IslandGroup:
                case EntitySubtype.Lake:
                case EntitySubtype.Mountain:
                case EntitySubtype.MountainPass:
                case EntitySubtype.MountainRange:
                case EntitySubtype.OilField:
                case EntitySubtype.Park:
                case EntitySubtype.ProtectedArea:
                case EntitySubtype.River:
                case EntitySubtype.Waterfall:
                #endregion
                    return EntityType.GeographicFeature;

                case EntitySubtype.Airport:
                case EntitySubtype.Bridge:
                case EntitySubtype.HistoricPlace:
                case EntitySubtype.Hospital:
                case EntitySubtype.Lighthouse:
                case EntitySubtype.ShoppingMall:
                case EntitySubtype.SkiArea:
                case EntitySubtype.Skyscraper:
                case EntitySubtype.Stadium:
                case EntitySubtype.Station:
                    return EntityType.Facility;

                case EntitySubtype.AircraftManufacturer:
                case EntitySubtype.Airline:
                case EntitySubtype.AirportOperator:
                case EntitySubtype.ArchitectureFirm:
                case EntitySubtype.AutomobileCompany:
                case EntitySubtype.BicycleManufacturer:
                case EntitySubtype.BottledWater:
                case EntitySubtype.BreweryBrandOfBeer:
                case EntitySubtype.BroadcastDistributor:
                case EntitySubtype.CandyBarManufacturer:
                case EntitySubtype.ComicBookPublisher:
                case EntitySubtype.ComputerManufacturerBrand:
                case EntitySubtype.Distillery:
                case EntitySubtype.EngineeringFirm:
                case EntitySubtype.FashionLabel:
                case EntitySubtype.FilmCompany:
                case EntitySubtype.FilmDistributor:
                case EntitySubtype.GamePublisher:
                case EntitySubtype.ManufacturingPlant:
                case EntitySubtype.MusicalInstrumentCompany:
                case EntitySubtype.OperatingSystemDeveloper:
                case EntitySubtype.ProcessorManufacturer:
                case EntitySubtype.ProductionCompany:
                case EntitySubtype.RadioNetwork:
                case EntitySubtype.RecordLabel:
                case EntitySubtype.Restaurant:
                case EntitySubtype.RocketEngineDesigner:
                case EntitySubtype.RocketManufacturer:
                case EntitySubtype.ShipBuilder:
                case EntitySubtype.SoftwareDeveloper:
                case EntitySubtype.SpacecraftManufacturer:
                case EntitySubtype.SpiritBottler:
                case EntitySubtype.SpiritProductManufacturer:
                case EntitySubtype.TransportOperator:
                case EntitySubtype.TVNetwork:
                case EntitySubtype.VentureFundedCompany:
                case EntitySubtype.VentureInvestor:
                case EntitySubtype.VideoGameDeveloper:
                case EntitySubtype.VideoGameEngineDeveloper:
                case EntitySubtype.VideoGamePublisher:
                case EntitySubtype.WineProducer:
                    return EntityType.Organization;

                default:
                    Trace.TraceWarning("Full Metal Alchemist does not understand subtype \"" + type.ToString() + " THIS IS A BUG, please file a bug report");
                    //If you get here please file a bug report!
                    //All of the subtypes ought to have a parent type, so if we get here it means a case has been missed off and needs to be added in
                    //Log a report here: https://github.com/martindevans/AlchemyApiSharp/issues
                    throw new ArgumentException("type");
            }
        }
    }
}
