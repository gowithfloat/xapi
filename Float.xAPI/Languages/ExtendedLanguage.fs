// <copyright file="ExtendedLanguage.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Languages

open Float.Common.Interop

// todo: extended language subtags should be tied to specific languages only (the registry specifies the parent tag)

/// <summary>
/// Extended language subtags specify a dialect within a language.
/// see: https://www.iana.org/assignments/language-subtag-registry/language-subtag-registry
/// </summary>
[<StructuralEquality;StructuralComparison>]
type ExtendedLanguage =
    | AlgerianSaharanArabic // aao
    | TajikiArabic // abh
    | BaharnaArabic // abv
    | MesopotamianArabic // acm
    | TaizziAdeniArabic // acq
    | HijaziArabic // acw
    | OmaniArabic // acx
    | CypriotArabic // acy
    | DhofariArabic // adf
    | AdamorobeSignLanguage // ads
    | TunisianArabic // aeb
    | SaidiArabic // aec
    | ArgentineSignLanguage // aed
    | ArmenianSignLanguage // aen
    | GulfArabic // afb
    | AfghanSignLanguage // afg
    | SouthLevantineArabic // ajp
    | NorthLevantineArabic // apc
    | SudaneseArabic // apd
    | StandardArabic // arb
    | AlgerianArabic // arq
    | NajdiArabic // ars
    | MoroccanArabic // ary
    | EgyptianArabic // arz
    | AmericanSignLanguage // ase
    | Auslan // asf
    | AlgerianSignLanguage // asp
    | AustrianSignLanguage // asq
    | AustralianAboriginesSignLanguage // asw
    | UzbekiArabic // auz
    | EasternEgyptianBedawiArabic // avl
    | HadramiArabic // ayh
    | LibyanArabic // ayl
    | SanaaniArabic // ayn
    | NorthMesopotamianArabic // ayp
    | BabaliaCreoleArabic // bbz
    | BritishSignLanguage // bfi
    | BanKhorSignLanguage // bfk
    | Banjar // bjn
    | BamakoSignLanguage // bog
    | BulgarianSignLanguage // bqn
    | BengkalaSignLanguage // bqy
    | BacaneseMalay // btj
    | BerauMalay // bve
    | BolivianSignLanguage // bvl
    | BukitMalay // bvu
    | BrazilianSignLanguage // bzs
    | MinDongChinese // cdo
    | ChadianSignLanguage // cds
    | JinyuChinese // cjy
    | MandarinChinese // cmn
    | CocosIslandsMalay // coa
    | PuXianChinese // cpx
    | CatalanSignLanguage // csc
    | ChiangmaiSignLanguage // csd
    | CzechSignLanguage // cse
    | CubaSignLanguage // csf
    | ChileanSignLanguage // csg
    | ChineseSignLanguage // csl
    | ColombianSignLanguage // csn
    | CroatiaSignLanguage // csq
    | CostaRicanSignLanguage // csr
    | HuizhouChinese // czh
    | MinZhongChinese // czo
    | DominicanSignLanguage // doq
    | DutchSignLanguage // dse
    | DanishSignLanguage // dsl
    | Duano // dup
    | EcuadorianSignLanguage // ecs
    | EgyptSignLanguage // esl
    | SalvadoranSignLanguage // esn
    | EstonianSignLanguage // eso
    | EthiopianSignLanguage // eth
    | QuebecSignLanguage // fcs
    | FinnishSignLanguage // fse
    | FrenchSignLanguage // fsl
    | FinlandSwedishSignLanguage // fss
    | GanChinese // gan
    | GhandrukSignLanguage // gds
    | GoanKonkani // gom
    | GhanaianSignLanguage // gse
    | GermanSignLanguage // gsg
    | GuatemalanSignLanguage // gsm
    | GreekSignLanguage // gss
    | GuineanSignLanguage // gus
    | HanoiSignLanguage // hab
    | HaiphongSignLanguage // haf
    | HakkaChinese // hak
    | HondurasSignLanguage // hds
    | Haji // hji
    | HongKongSignLanguage // hks
    | HoChiMinhCitySignLanguage // hos
    | HawaiiSignLanguage // hps
    | HungarianSignLanguage // hsh
    | HausaSignLanguage // hsl
    | XiangChinese // hsn
    | IcelandicSignLanguage // icl
    | InuitSignLanguage // iks
    | InternationalSign // ils
    | IndonesianSignLanguage // inl
    | IndianSignLanguage // ins
    | ItalianSignLanguage // ise
    | IrishSignLanguage // isg
    | IsraeliSignLanguage // isr
    | Jakun // jak
    | JambiMalay // jax
    | JamaicanCountrySignLanguage // jcs
    | JhankotSignLanguage // jhs
    | JamaicanSignLanguage // jls
    | JordanianSignLanguage // jos
    | JapaneseSignLanguage // jsl
    | JumlaSignLanguage // jus
    | SelangorSignLanguage // kgi
    | Konkani // knn
    | Kubu // kvb
    | KoreanSignLanguage // kvk
    | Kerinci // kvr
    | Brunei // kxd
    | LibyanSignLanguage // lbs
    | Loncong // lce
    | Lubu // lcf
    | Col // liw
    | LithuanianSignLanguage // lls
    | LyonsSignLanguage // lsg
    | LatvianSignLanguage // lsl
    | LaosSignLanguage // lso
    | PanamanianSignLanguage // lsp
    | TrinidadAndTobagoSignLanguage // lst
    | MauritianSignLanguage // lsy
    | Latgalian // ltg
    | StandardLatvian // lvs
    | MalawianSignLanguage // lws
    | LiteraryChinese // lzh
    | NorthMoluccanMalay // max
    | MalteseSignLanguage // mdl
    | KedahMalay // meo
    | PattaniMalay // mfa
    | Bangka // mfb
    | MexicanSignLanguage // mfs
    | Minangkabau // min
    | MinBeiChinese // mnp
    | KotaBangunKutaiMalay // mqg
    | Martha'sVineyardSignLanguage // mre
    | YucatecMayaSignLanguage // msd
    | SabahMalay // msi
    | MongolianSignLanguage // msr
    | Musi // mui
    | MadagascarSignLanguage // mzc
    | MonasticSignLanguage // mzg
    | MozambicanSignLanguage // mzy
    | MinNanChinese // nan
    | NamibianSignLanguage // nbs
    | NicaraguanSignLanguage // ncs
    | NigerianSignLanguage // nsi
    | NorwegianSignLanguage // nsl
    | NepaleseSignLanguage // nsp
    | MaritimeSignLanguage // nsr
    | NewZealandSignLanguage // nzs
    | OldKentishSignLanguage // okl
    | OrangKanaq // orn
    | OrangSeletar // ors
    | Pekal // pel
    | SudaneseCreoleArabic // pga
    | PapuaNewGuineanSignLanguage // pgz
    | PakistanSignLanguage // pks
    | PeruvianSignLanguage // prl
    | ProvidenciaSignLanguage // prz
    | PersianSignLanguage // psc
    | PlainsIndianSignLanguage // psd
    | CentralMalay // pse
    | PenangSignLanguage // psg
    | PuertoRicanSignLanguage // psl
    | PolishSignLanguage // pso
    | PhilippineSignLanguage // psp
    | PortugueseSignLanguage // psr
    | ParaguayanSignLanguage // pys
    | RomanianSignLanguage // rms
    | RennelleseSignLanguage // rsi
    | RussianSignLanguage // rsl
    | MiriwoongSignLanguage // rsm
    | SaudiArabianSignLanguage // sdl
    | LangueDesSignesDeBelgiqueFrancophone // sfb
    | SouthAfricanSignLanguage // sfs
    | SwissGermanSignLanguage // sgg
    | SierraLeoneSignLanguage // sgx
    | ChadianArabic // shu
    | SwissItalianSignLanguage // slf
    | SingaporeSignLanguage // sls
    | AlbanianSignLanguage // sqk
    | SriLankanSignLanguage // sqs
    | ShihhiArabic // ssh
    | SpanishSignLanguage // ssp
    | SwissFrenchSignLanguage // ssr
    | SlovakianSignLanguage // svk
    | CongoSwahili // swc
    | Kiswahili // swh
    | SwedishSignLanguage // swl
    | AlSayyidBedouinSignLanguage // syy
    | SolomonIslandsSignLanguage // szs
    | Temuan // tmw
    | TunisianSignLanguage // tse
    | TurkishSignLanguage // tsm
    | ThaiSignLanguage // tsq
    | TaiwanSignLanguage // tss
    | TebulSignLanguage // tsy
    | TanzanianSignLanguage // tza
    | UgandanSignLanguage // ugn
    | UruguayanSignLanguage // ugy
    | UkrainianSignLanguage // ukl
    | UrubúKaaporSignLanguage // uks
    | UrakLawoi // urk
    | NorthernUzbek // uzn
    | SouthernUzbek // uzs
    | VlaamseGebarentaal // vgt
    | Kaur // vkk
    | TenggarongKutaiMalay // vkt
    | MoldovaSignLanguage // vsi
    | VenezuelanSignLanguage // vsl
    | ValencianSignLanguage // vsv
    | WestBengalSignLanguage // wbs
    | WuChinese // wuu
    | KenyanSignLanguage // xki
    | MalaysianSignLanguage // xml
    | ManadoMalay // xmm
    | MoroccanSignLanguage // xms
    | YiddishSignLanguage // yds
    | YolŋuSignLanguage // ygs
    | YanNhaŋuSignLanguage // yhs
    | YugoslavianSignLanguage // ysl
    | YueChinese // yue
    | ZimbabweSignLanguage // zib
    | Malay // zlm
    | NegeriSembilanMalay // zmi
    | ZambianSignLanguage // zsl
    | StandardMalay // zsm

    static member table = 
        [
            AlgerianSaharanArabic, "aao";
            TajikiArabic, "abh";
            BaharnaArabic, "abv";
            MesopotamianArabic, "acm";
            TaizziAdeniArabic, "acq";
            HijaziArabic, "acw";
            OmaniArabic, "acx";
            CypriotArabic, "acy";
            DhofariArabic, "adf";
            AdamorobeSignLanguage, "ads";
            TunisianArabic, "aeb";
            SaidiArabic, "aec";
            ArgentineSignLanguage, "aed";
            ArmenianSignLanguage, "aen";
            GulfArabic, "afb";
            AfghanSignLanguage, "afg";
            SouthLevantineArabic, "ajp";
            NorthLevantineArabic, "apc";
            SudaneseArabic, "apd";
            StandardArabic, "arb";
            AlgerianArabic, "arq";
            NajdiArabic, "ars";
            MoroccanArabic, "ary";
            EgyptianArabic, "arz";
            AmericanSignLanguage, "ase";
            Auslan, "asf";
            AlgerianSignLanguage, "asp";
            AustrianSignLanguage, "asq";
            AustralianAboriginesSignLanguage, "asw";
            UzbekiArabic, "auz";
            EasternEgyptianBedawiArabic, "avl";
            HadramiArabic, "ayh";
            LibyanArabic, "ayl";
            SanaaniArabic, "ayn";
            NorthMesopotamianArabic, "ayp";
            BabaliaCreoleArabic, "bbz";
            BritishSignLanguage, "bfi";
            BanKhorSignLanguage, "bfk";
            Banjar, "bjn";
            BamakoSignLanguage, "bog";
            BulgarianSignLanguage, "bqn";
            BengkalaSignLanguage, "bqy";
            BacaneseMalay, "btj";
            BerauMalay, "bve";
            BolivianSignLanguage, "bvl";
            BukitMalay, "bvu";
            BrazilianSignLanguage, "bzs";
            MinDongChinese, "cdo";
            ChadianSignLanguage, "cds";
            JinyuChinese, "cjy";
            MandarinChinese, "cmn";
            CocosIslandsMalay, "coa";
            PuXianChinese, "cpx";
            CatalanSignLanguage, "csc";
            ChiangmaiSignLanguage, "csd";
            CzechSignLanguage, "cse";
            CubaSignLanguage, "csf";
            ChileanSignLanguage, "csg";
            ChineseSignLanguage, "csl";
            ColombianSignLanguage, "csn";
            CroatiaSignLanguage, "csq";
            CostaRicanSignLanguage, "csr";
            HuizhouChinese, "czh";
            MinZhongChinese, "czo";
            DominicanSignLanguage, "doq";
            DutchSignLanguage, "dse";
            DanishSignLanguage, "dsl";
            Duano, "dup";
            EcuadorianSignLanguage, "ecs";
            EgyptSignLanguage, "esl";
            SalvadoranSignLanguage, "esn";
            EstonianSignLanguage, "eso";
            EthiopianSignLanguage, "eth";
            QuebecSignLanguage, "fcs";
            FinnishSignLanguage, "fse";
            FrenchSignLanguage, "fsl";
            FinlandSwedishSignLanguage, "fss";
            GanChinese, "gan";
            GhandrukSignLanguage, "gds";
            GoanKonkani, "gom";
            GhanaianSignLanguage, "gse";
            GermanSignLanguage, "gsg";
            GuatemalanSignLanguage, "gsm";
            GreekSignLanguage, "gss";
            GuineanSignLanguage, "gus";
            HanoiSignLanguage, "hab";
            HaiphongSignLanguage, "haf";
            HakkaChinese, "hak";
            HondurasSignLanguage, "hds";
            Haji, "hji";
            HongKongSignLanguage, "hks";
            HoChiMinhCitySignLanguage, "hos";
            HawaiiSignLanguage, "hps";
            HungarianSignLanguage, "hsh";
            HausaSignLanguage, "hsl";
            XiangChinese, "hsn";
            IcelandicSignLanguage, "icl";
            InuitSignLanguage, "iks";
            InternationalSign, "ils";
            IndonesianSignLanguage, "inl";
            IndianSignLanguage, "ins";
            ItalianSignLanguage, "ise";
            IrishSignLanguage, "isg";
            IsraeliSignLanguage, "isr";
            Jakun, "jak";
            JambiMalay, "jax";
            JamaicanCountrySignLanguage, "jcs";
            JhankotSignLanguage, "jhs";
            JamaicanSignLanguage, "jls";
            JordanianSignLanguage, "jos";
            JapaneseSignLanguage, "jsl";
            JumlaSignLanguage, "jus";
            SelangorSignLanguage, "kgi";
            Konkani, "knn";
            Kubu, "kvb";
            KoreanSignLanguage, "kvk";
            Kerinci, "kvr";
            Brunei, "kxd";
            LibyanSignLanguage, "lbs";
            Loncong, "lce";
            Lubu, "lcf";
            Col, "liw";
            LithuanianSignLanguage, "lls";
            LyonsSignLanguage, "lsg";
            LatvianSignLanguage, "lsl";
            LaosSignLanguage, "lso";
            PanamanianSignLanguage, "lsp";
            TrinidadAndTobagoSignLanguage, "lst";
            MauritianSignLanguage, "lsy";
            Latgalian, "ltg";
            StandardLatvian, "lvs";
            MalawianSignLanguage, "lws";
            LiteraryChinese, "lzh";
            NorthMoluccanMalay, "max";
            MalteseSignLanguage, "mdl";
            KedahMalay, "meo";
            PattaniMalay, "mfa";
            Bangka, "mfb";
            MexicanSignLanguage, "mfs";
            Minangkabau, "min";
            MinBeiChinese, "mnp";
            KotaBangunKutaiMalay, "mqg";
            Martha'sVineyardSignLanguage, "mre";
            YucatecMayaSignLanguage, "msd";
            SabahMalay, "msi";
            MongolianSignLanguage, "msr";
            Musi, "mui";
            MadagascarSignLanguage, "mzc";
            MonasticSignLanguage, "mzg";
            MozambicanSignLanguage, "mzy";
            MinNanChinese, "nan";
            NamibianSignLanguage, "nbs";
            NicaraguanSignLanguage, "ncs";
            NigerianSignLanguage, "nsi";
            NorwegianSignLanguage, "nsl";
            NepaleseSignLanguage, "nsp";
            MaritimeSignLanguage, "nsr";
            NewZealandSignLanguage, "nzs";
            OldKentishSignLanguage, "okl";
            OrangKanaq, "orn";
            OrangSeletar, "ors";
            Pekal, "pel";
            SudaneseCreoleArabic, "pga";
            PapuaNewGuineanSignLanguage, "pgz";
            PakistanSignLanguage, "pks";
            PeruvianSignLanguage, "prl";
            ProvidenciaSignLanguage, "prz";
            PersianSignLanguage, "psc";
            PlainsIndianSignLanguage, "psd";
            CentralMalay, "pse";
            PenangSignLanguage, "psg";
            PuertoRicanSignLanguage, "psl";
            PolishSignLanguage, "pso";
            PhilippineSignLanguage, "psp";
            PortugueseSignLanguage, "psr";
            ParaguayanSignLanguage, "pys";
            RomanianSignLanguage, "rms";
            RennelleseSignLanguage, "rsi";
            RussianSignLanguage, "rsl";
            MiriwoongSignLanguage, "rsm";
            SaudiArabianSignLanguage, "sdl";
            LangueDesSignesDeBelgiqueFrancophone, "sfb";
            SouthAfricanSignLanguage, "sfs";
            SwissGermanSignLanguage, "sgg";
            SierraLeoneSignLanguage, "sgx";
            ChadianArabic, "shu";
            SwissItalianSignLanguage, "slf";
            SingaporeSignLanguage, "sls";
            AlbanianSignLanguage, "sqk";
            SriLankanSignLanguage, "sqs";
            ShihhiArabic, "ssh";
            SpanishSignLanguage, "ssp";
            SwissFrenchSignLanguage, "ssr";
            SlovakianSignLanguage, "svk";
            CongoSwahili, "swc";
            Kiswahili, "swh";
            SwedishSignLanguage, "swl";
            AlSayyidBedouinSignLanguage, "syy";
            SolomonIslandsSignLanguage, "szs";
            Temuan, "tmw";
            TunisianSignLanguage, "tse";
            TurkishSignLanguage, "tsm";
            ThaiSignLanguage, "tsq";
            TaiwanSignLanguage, "tss";
            TebulSignLanguage, "tsy";
            TanzanianSignLanguage, "tza";
            UgandanSignLanguage, "ugn";
            UruguayanSignLanguage, "ugy";
            UkrainianSignLanguage, "ukl";
            UrubúKaaporSignLanguage, "uks";
            UrakLawoi, "urk";
            NorthernUzbek, "uzn";
            SouthernUzbek, "uzs";
            VlaamseGebarentaal, "vgt";
            Kaur, "vkk";
            TenggarongKutaiMalay, "vkt";
            MoldovaSignLanguage, "vsi";
            VenezuelanSignLanguage, "vsl";
            ValencianSignLanguage, "vsv";
            WestBengalSignLanguage, "wbs";
            WuChinese, "wuu";
            KenyanSignLanguage, "xki";
            MalaysianSignLanguage, "xml";
            ManadoMalay, "xmm";
            MoroccanSignLanguage, "xms";
            YiddishSignLanguage, "yds";
            YolŋuSignLanguage, "ygs";
            YanNhaŋuSignLanguage, "yhs";
            YugoslavianSignLanguage, "ysl";
            YueChinese, "yue";
            ZimbabweSignLanguage, "zib";
            Malay, "zlm";
            NegeriSembilanMalay, "zmi";
            ZambianSignLanguage, "zsl";
            StandardMalay, "zsm";
        ]
        |> Map.ofList

    /// <inheritdoc />
    override this.ToString() =
        match ExtendedLanguage.table.TryFind this with
        | Some x -> x
        | None -> invalidArg "this" "Unable to find region in lookup"

    /// <summary>
    /// Convert a string to an ExtendedLanguageTag object.
    /// </summary>
    static member FromString(str: string) = invert(ExtendedLanguage.table).TryFind str
