﻿using System;
using System.Collections.Generic;
using System.Text;
using PatcherLib.Datatypes;

namespace FFTPatcher.Datatypes
{
    public enum PropositionEnum
    {
        DestinyOfTheCompany = 0x01,
        SunkenSalvageTour = 0x02,
        SailorTour = 0x03,
        LarnerChannelWaves = 0x04,
        AttractiveWorkplace = 0x05,
        SalvageTheTradeShip1 = 0x06,
        EnvoyShipFalcon = 0x07,
        HeirOfMesa = 0x08,
        SalvageTheTradeShip2 = 0x09,
        EmissaryOfLionel = 0x0A,
        ZalandEmbassy = 0x0B,
        StolenAncientWritings = 0x0C,
        GoodWorkplaceAndJob = 0x0D,
        SeaofGrediaIsland = 0x0E,
        StrandedTradeShip = 0x0F,
        TradeShipDouing = 0x10,
        MineExcavationTour = 0x11,
        MinersTour = 0x12,
        WillOfElderTopa = 0x13,
        MinersTour2 = 0x14,
        DreamOfAMiner = 0x15,
        Vacancy = 0x16,
        MinersWanted = 0x17,
        GirlAtGulgVolcano = 0x18,
        HiddenTrapAtTheMaze = 0x19,
        HimkaCliffs = 0x1A,
        TheLordsOre = 0x1B,
        OneActivity = 0x1C,
        MinersWanted2 = 0x1D,
        RoladeOreCompany = 0x1E,
        TestimonyOfExminer = 0x1F,
        DeathCanyon = 0x20,
        DiscoveryRace = 0x21,
        PoeskasLakeBottom = 0x22,
        DiscoveryRace2 = 0x23,
        LegendaryTraces = 0x24,
        DiscoveryRace3 = 0x25,
        DeepInSweegyWoods = 0x26,
        RuinsAtBedDesert = 0x27,
        AdventurerRamzen = 0x28,
        ISawIt = 0x29,
        DiscoveryTour = 0x2A,
        StormofZigolis = 0x2B,
        OminousDungeon = 0x2C,
        AdventurerWanted = 0x2D,
        ISawItISwear = 0x2E,
        ConcernsOfAMerchant = 0x2F,
        MountainOfRain = 0x30,
        DefeatGoldenGotsko = 0x31,
        DefeatBehemoth = 0x32,
        TrapOfTheBandits = 0x33,
        SonPappal = 0x34,
        WithinTheDarkness = 0x35,
        DefeatWhirlwindKarz = 0x36,
        MinimumsMelancholy1 = 0x37,
        TerrorofAssaultCave = 0x38,
        ChallengeOfZero = 0x39,
        PhantomThiefZero = 0x3A,
        ThiefZeroReturns = 0x3B,
        ThiefZeroReborn = 0x3C,
        ThiefZerosLastStand = 0x3D,
        LegendaryMonster = 0x3E,
        SullenExperiment = 0x3F,
        FiarsRequest = 0x40,
        DreamChild = 0x41,
        ProtectTheLittleLife = 0x42,
        IfWishesComeTrue = 0x43,
        MyLittleCarrot = 0x44,
        SecretDoor = 0x45,
        OrdersOfCoastGuard = 0x46,
        DevilInTheDark = 0x47,
        Mother = 0x48,
        MyTreasure = 0x49,
        TheGreatestPlan = 0x4A,
        SecretSociety = 0x4B,
        HowMuchIsLifeworth = 0x4C,
        LetterToMyLove = 0x4D,
        MinimumsMelancholy2 = 0x4E,
        RoadOfBeasts = 0x4F,
        TrueRomance = 0x50,
        ShyKatedona = 0x51,
        MasterMath = 0x52,
        SadTravelingArtist = 0x53,
        MinimumsMelancholy3 = 0x54,
        MachinistContest = 0x55,
        TravelingArtistMameko = 0x56,
        ChocoboRestaurant = 0x57,
        WanderingGambler1 = 0x58,
        WanderingGambler2 = 0x59,
        RingingOfTheBell = 0x5A,
        Memories = 0x5B,
        HardLecture = 0x5C,
        WintheYardowFight = 0x5D,
        WintheZalandFight = 0x5E,
        WintheMagicContest = 0x5F,
        MeisterContest = 0x60,


        TheHighwind = 0x01,
        SalvageExpedition = 0x02,
        DivingExpedition = 0x03,
        RhanaStrait = 0x04,
        DredgeWork = 0x05,
        TheHindenburg = 0x06,
        TheFalcon = 0x07,
        MesasLegacy = 0x08,
        TheDurga = 0x09,
        LionelEmissary = 0x0A,
        ZalandEmbassyAntiques = 0x0B,
        StolenTomes = 0x0C,
        SalvageWork = 0x0D,
        GleddiaIsle = 0x0E,
        FounderedVessel = 0x0F,
        TheDawnQueen = 0x10,
        AbandonedMine = 0x11,
        CoalMiningExpedition = 0x12,
        OldToppasWill = 0x13,
        SecondCoalMiningExpedition = 0x14,
        MinersDream = 0x15,
        MinerShortage = 0x16,
        CoalMinersWanted = 0x17,
        MountGulgMotherLode = 0x18,
        EndlessCaverns = 0x19,
        HimcaCliffs = 0x1A,
        OreOfTheGods = 0x1B,
        PastGlory = 0x1C,
        MoreCoalMinersWanted = 0x1D,
        LorraideMine = 0x1E,
        MinersTale = 0x1F,
        DeathsGorge = 0x20,
        FrontierMarathon = 0x21,
        LakePoescasDepths = 0x22,
        SecondFrontierMarathon = 0x23,
        AncientWonder = 0x24,
        ThirdFrontierMarathon = 0x25,
        TheSiedgeWeald = 0x26,
        BeddhaSandwaste = 0x27,
        LamzenTheAdventurer = 0x28,
        TrickOfTheLight = 0x29,
        FrontierExpedition = 0x2A,
        FenlandMystery = 0x2B,
        CellarDungeon = 0x2C,
        AdventurersWanted = 0x2D,
        ShadowsFromThePast = 0x2E,
        MerchantsRegret = 0x2F,
        RainSweptSlopes = 0x30,
        TwilightGustkov = 0x31,
        TheBehemoth = 0x32,
        Bandits = 0x33,
        YoungLordPappal = 0x34,
        InTheDarkness = 0x35,
        TheTyphoon = 0x36,
        CountMinimas1 = 0x37,
        TerrorsMaw = 0x38,
        ZerrosChallenge = 0x39,
        ZerroStrikes = 0x3A,
        ZerrosReturn = 0x3B,
        ZerroStrikesAgain = 0x3C,
        ZerrosFinalHeist = 0x3D,
        HellspawnedBeast = 0x3E,
        MetamorphosedMisery = 0x3F,
        FiasWish = 0x40,
        MissingBoy = 0x41,
        FathersNightmare = 0x42,
        DucalDisaster = 0x43,
        MyLittleCarrotPSP = 0x44,
        CriesInTheDark = 0x45,
        ShorelineDefense = 0x46,
        DevilInTheDarkPSP = 0x47,
        Nightwalker = 0x48,
        UninvitedGuests = 0x49,
        HistoricRevolt = 0x4A,
        SecretSocietyPSP = 0x4B,
        Appraisal = 0x4C,
        LettredAmour = 0x4D,
        CountMinimas2 = 0x4E,
        BeastlyTrail = 0x4F,
        TrueRomancePSP = 0x50,
        Cattedona = 0x51,
        ArithmeticksTutorWanted = 0x52,
        MinstrelinDistress = 0x53,
        CountMinimas3 = 0x54,
        ClockworkFaire = 0x55,
        MamecoTheMinstrel = 0x56,
        GysahlGreens = 0x57,
        WanderingGambler1PSP = 0x58,
        WanderingGambler2PSP = 0x59,
        GuardDuty = 0x5A,
        MemoriesPSP = 0x5B,
        Tutoring = 0x5C,
        TheYardrowMelee = 0x5D,
        TheZalandMelee = 0x5E,
        TheGarilandMagickMelee = 0x5F,
        ArteficersContest = 0x60,
    }

    public enum PropositionType
    {
        Salvage = 1,
        Mining = 2,
        Exploration = 3,
        Combat = 4,
        Investigation1 = 5,
        Investigation2 = 6,
        OddJobs = 7,
        Contest = 8,
    }

    public enum BraveFaithNeutral
    {
        Brave = 1,
        Faith = 2,
        Neutral = 3,
    }

    public enum Reward
    {
        Gil = 0,
        Treasure = 1,
        Land = 2,
    }

    public enum PrereqType
    {
        None = 1,
        CertainMonth = 2,
        FinishedJob = 4,
    }

    public class Proposition : IChangeable, ISupportDigest, ISupportDefault<Proposition>
    {
        private const byte maxPropositionByte = (byte)PropositionType.Contest;
        private const byte minPropositionByte = (byte)PropositionType.Salvage;
        private const byte maxBraveFaithByte = (byte)BraveFaithNeutral.Neutral;
        private const byte minBraveFaithByte = (byte)BraveFaithNeutral.Brave;
        private const byte minRewardByte = (byte)Reward.Gil;
        private const byte maxRewardByte = (byte)Reward.Land;
        private const byte minTownByte = (byte)Town.Lesalia;
        private const byte maxTownByte = (byte)Town.Zarghidas;

        public PropositionType Type { get; set; }
        public BraveFaithNeutral BraveFaith { get; set; }
        public Town Town { get; set; }
        public PrereqType PrereqType { get; set; }

        public byte PrereqByte { get; set; }

        public PropositionEnum PrereqProp
        {
            get { return (PropositionEnum)PrereqByte; }
            set { PrereqByte = (byte)value; }
        }

        public Zodiac PrereqZodiac
        {
            get { return (Zodiac)PrereqByte; }
            set { PrereqByte = (byte)value; }
        }

        public bool HasChanged
        {
            get 
            {
                return Default != null &&
                    (BraveFaith != Default.BraveFaith ||
                    MaxDays != Default.MaxDays ||
                    MinDays != Default.MinDays ||
                    PrereqByte != Default.PrereqByte ||
                    PrereqType != Default.PrereqType ||
                    PriceIndex1 != Default.PriceIndex1 ||
                    PriceIndex2 != Default.PriceIndex2 ||
                    Reward != Default.Reward ||
                    Town != Default.Town ||
                    this.Type != Default.Type ||
                    this.Unknown0x09 != Default.Unknown0x09 ||
                    this.Unknown0x0B != Default.Unknown0x0B ||
                    this.Unknown0x0C != Default.Unknown0x0C ||
                    this.Unknown0x0F != Default.Unknown0x0F ||
                    this.Unknown0x14 != Default.Unknown0x14 ||
                    this.WhenUnlocked.ToByte() != Default.WhenUnlocked.ToByte());
            }
        }

        public IList<string> DigestableProperties
        {
            get { throw new NotImplementedException(); }
        }

        public Proposition Default
        {
            get;
            private set;
        }

        public string Name { get; private set; }
        public Proposition( string name, IList<byte> bytes, Proposition _default )
        {
            Default = _default;
            Name = name;

            byte propositionByte = bytes[0];
            Type = (PropositionType)propositionByte;
            //Type = propositionByte >= minPropositionByte && propositionByte <= maxPropositionByte ?
            //    (PropositionType)propositionByte :
            //    PropositionType.Unknown;

            byte braveFaithByte = bytes[1];
            BraveFaith = (BraveFaithNeutral)braveFaithByte;
            //BraveFaith = braveFaithByte >= minBraveFaithByte && braveFaithByte <= maxBraveFaithByte ?
            //    (BraveFaithNeutral)braveFaithByte :
            //    BraveFaithNeutral.Unknown;

            idBytes[0] = bytes[2];
            idBytes[1] = bytes[3];

            PriceIndex1 = bytes[4];
            PriceIndex2 = bytes[5];

            MinDays = bytes[6];
            MaxDays = bytes[7];

            idBytes[2] = bytes[8];

            Unknown0x09 = bytes[9];

            byte rewardByte = bytes[10];
            Reward = (Reward)rewardByte;
            //Reward = rewardByte >= minRewardByte && rewardByte <= maxRewardByte ?
            //    (Reward)rewardByte :
            //    Reward.Unknown;
            Unknown0x0B = bytes[11];
            Unknown0x0C = bytes[12];

            idBytes[3] = bytes[13];
            idBytes[4] = bytes[14];

            Unknown0x0F = bytes[15];

            Town = (Town)bytes[16];
            PrereqType = (PrereqType)bytes[17];

            idBytes[5] = bytes[18];
            dontCareByte = bytes[19];

            Unknown0x14 = bytes[20];

            WhenUnlocked = ShopAvailability.AllAvailabilities[bytes[21]];

            PrereqByte = bytes[22];
        }

        public ShopAvailability WhenUnlocked { get; set; }

        public IList<byte> ToByteArray()
        {
            List<byte> result = new List<byte>( 23 );
            result.Add( (byte)Type );
            result.Add( (byte)BraveFaith );
            result.Add( idBytes[0] );
            result.Add( idBytes[1] );
            result.Add( PriceIndex1 );
            result.Add( PriceIndex2 );
            result.Add( MinDays );
            result.Add( MaxDays );
            result.Add( idBytes[2] );
            result.Add( Unknown0x09 );
            result.Add( (byte)Reward );
            result.Add( Unknown0x0B );
            result.Add( Unknown0x0C );
            result.Add( idBytes[3] );
            result.Add( idBytes[4] );
            result.Add( Unknown0x0F );
            result.Add( (byte)Town );
            result.Add( (byte)PrereqType );
            result.Add( idBytes[5] );
            result.Add( dontCareByte );
            result.Add( Unknown0x14 );
            result.Add( WhenUnlocked.ToByte() );
            result.Add( PrereqByte );

            return result.AsReadOnly();
        }

        public Reward Reward { get; set; }

        public byte Unknown0x09 { get; set; }
        public byte Unknown0x0B { get; set; }
        public byte Unknown0x0C { get; set; }
        public byte Unknown0x0F { get; set; }
        public byte Unknown0x14 { get; set; }

        public byte MinDays { get; set; }
        public byte MaxDays { get; set; }
        public byte PriceIndex1 { get; set; }
        public byte PriceIndex2 { get; set; }

        private byte[] idBytes = new byte[6];
        private byte dontCareByte = 0;

        public Proposition( string name, IList<byte> bytes )
            : this( name, bytes, null as Proposition)
        {
        }
        public override string ToString()
        {
            return (HasChanged ? "*" : "") + Name;
        }


        public Proposition( string name, IList<byte> bytes, IList<byte> defaultBytes ) :
            this( name, bytes, new Proposition( name, defaultBytes ) )
        {
        }
    }
}