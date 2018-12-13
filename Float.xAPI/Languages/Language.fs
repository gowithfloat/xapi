// <copyright file="Language.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Languages

open Float.Common.Interop

/// <summary>
/// ISO 639-1 Language Codes
/// see: https://www.loc.gov/standards/iso639-2/php/English_list.php
/// This type was auto-generated; please report issues at https://github.com/gowithfloat/xapi/issues
/// </summary>
[<StructuralEquality;StructuralComparison>]
type Language =
    | Abkhazian // ab
    | Afar // aa
    | Afrikaans // af
    | Akan // ak
    | Albanian // sq
    | Amharic // am
    | Arabic // ar
    | Aragonese // an
    | Armenian // hy
    | Assamese // as
    | Avaric // av
    | Avestan // ae
    | Aymara // ay
    | Azerbaijani // az
    | Bambara // bm
    | Bashkir // ba
    | Basque // eu
    | Belarusian // be
    | Bengali // bn
    | Bihari // bh
    | Bislama // bi
    | BokmålNorwegian // nb
    | Bosnian // bs
    | Breton // br
    | Bulgarian // bg
    | Burmese // my
    | Castilian // es
    | Catalan // ca
    | CentralKhmer // km
    | Chamorro // ch
    | Chechen // ce
    | Chewa // ny
    | Chichewa // ny
    | Chinese // zh
    | Chuang // za
    | ChurchSlavic // cu
    | ChurchSlavonic // cu
    | Chuvash // cv
    | Cornish // kw
    | Corsican // co
    | Cree // cr
    | Croatian // hr
    | Czech // cs
    | Danish // da
    | Dhivehi // dv
    | Divehi // dv
    | Dutch // nl
    | Dzongkha // dz
    | English // en
    | Esperanto // eo
    | Estonian // et
    | Ewe // ee
    | Faroese // fo
    | Fijian // fj
    | Finnish // fi
    | Flemish // nl
    | French // fr
    | Fulah // ff
    | Gaelic // gd
    | Galician // gl
    | Ganda // lg
    | Georgian // ka
    | German // de
    | Gikuyu // ki
    | GreekModern // el
    | Greenlandic // kl
    | Guarani // gn
    | Gujarati // gu
    | Haitian // ht
    | HaitianCreole // ht
    | Hausa // ha
    | Hebrew // he
    | Herero // hz
    | Hindi // hi
    | HiriMotu // ho
    | Hungarian // hu
    | Icelandic // is
    | Ido // io
    | Igbo // ig
    | Indonesian // id
    | Interlingua // ia
    | Interlingue // ie
    | Inuktitut // iu
    | Inupiaq // ik
    | Irish // ga
    | Italian // it
    | Japanese // ja
    | Javanese // jv
    | Kalaallisut // kl
    | Kannada // kn
    | Kanuri // kr
    | Kashmiri // ks
    | Kazakh // kk
    | Kikuyu // ki
    | Kinyarwanda // rw
    | Kirghiz // ky
    | Komi // kv
    | Kongo // kg
    | Korean // ko
    | Kuanyama // kj
    | Kurdish // ku
    | Kwanyama // kj
    | Kyrgyz // ky
    | Lao // lo
    | Latin // la
    | Latvian // lv
    | Letzeburgesch // lb
    | Limburgan // li
    | Limburger // li
    | Limburgish // li
    | Lingala // ln
    | Lithuanian // lt
    | LubaKatanga // lu
    | Luxembourgish // lb
    | Macedonian // mk
    | Malagasy // mg
    | Malay // ms
    | Malayalam // ml
    | Maldivian // dv
    | Maltese // mt
    | Manx // gv
    | Maori // mi
    | Marathi // mr
    | Marshallese // mh
    | Moldavian // ro
    | Moldovan // ro
    | Mongolian // mn
    | Nauru // na
    | Navaho // nv
    | Navajo // nv
    | NdebeleNorth // nd
    | NdebeleSouth // nr
    | Ndonga // ng
    | Nepali // ne
    | NorthNdebele // nd
    | NorthernSami // se
    | Norwegian // no
    | NorwegianBokmål // nb
    | NorwegianNynorsk // nn
    | Nuosu // ii
    | Nyanja // ny
    | NynorskNorwegian // nn
    | Occidental // ie
    | Occitan // oc
    | Ojibwa // oj
    | OldBulgarian // cu
    | OldChurchSlavonic // cu
    | OldSlavonic // cu
    | Oriya // or
    | Oromo // om
    | Ossetian // os
    | Ossetic // os
    | Pali // pi
    | Panjabi // pa
    | Pashto // ps
    | Persian // fa
    | Polish // pl
    | Portuguese // pt
    | Punjabi // pa
    | Pushto // ps
    | Quechua // qu
    | Romanian // ro
    | Romansh // rm
    | Rundi // rn
    | Russian // ru
    | Samoan // sm
    | Sango // sg
    | Sanskrit // sa
    | Sardinian // sc
    | ScottishGaelic // gd
    | Serbian // sr
    | Shona // sn
    | SichuanYi // ii
    | Sindhi // sd
    | Sinhala // si
    | Sinhalese // si
    | Slovak // sk
    | Slovenian // sl
    | Somali // so
    | SothoSouthern // st
    | SouthNdebele // nr
    | Spanish // es
    | Sundanese // su
    | Swahili // sw
    | Swati // ss
    | Swedish // sv
    | Tagalog // tl
    | Tahitian // ty
    | Tajik // tg
    | Tamil // ta
    | Tatar // tt
    | Telugu // te
    | Thai // th
    | Tibetan // bo
    | Tigrinya // ti
    | Tonga // to
    | Tsonga // ts
    | Tswana // tn
    | Turkish // tr
    | Turkmen // tk
    | Twi // tw
    | Uighur // ug
    | Ukrainian // uk
    | Urdu // ur
    | Uyghur // ug
    | Uzbek // uz
    | Valencian // ca
    | Venda // ve
    | Vietnamese // vi
    | Volapük // vo
    | Walloon // wa
    | Welsh // cy
    | WesternFrisian // fy
    | Wolof // wo
    | Xhosa // xh
    | Yiddish // yi
    | Yoruba // yo
    | Zhuang // za
    | Zulu // zu

    static member table =
        [
            Abkhazian, "ab";
            Afar, "aa";
            Afrikaans, "af";
            Akan, "ak";
            Albanian, "sq";
            Amharic, "am";
            Arabic, "ar";
            Aragonese, "an";
            Armenian, "hy";
            Assamese, "as";
            Avaric, "av";
            Avestan, "ae";
            Aymara, "ay";
            Azerbaijani, "az";
            Bambara, "bm";
            Bashkir, "ba";
            Basque, "eu";
            Belarusian, "be";
            Bengali, "bn";
            Bihari, "bh";
            Bislama, "bi";
            BokmålNorwegian, "nb";
            Bosnian, "bs";
            Breton, "br";
            Bulgarian, "bg";
            Burmese, "my";
            Castilian, "es";
            Catalan, "ca";
            CentralKhmer, "km";
            Chamorro, "ch";
            Chechen, "ce";
            Chewa, "ny";
            Chichewa, "ny";
            Chinese, "zh";
            Chuang, "za";
            ChurchSlavic, "cu";
            ChurchSlavonic, "cu";
            Chuvash, "cv";
            Cornish, "kw";
            Corsican, "co";
            Cree, "cr";
            Croatian, "hr";
            Czech, "cs";
            Danish, "da";
            Dhivehi, "dv";
            Divehi, "dv";
            Dutch, "nl";
            Dzongkha, "dz";
            English, "en";
            Esperanto, "eo";
            Estonian, "et";
            Ewe, "ee";
            Faroese, "fo";
            Fijian, "fj";
            Finnish, "fi";
            Flemish, "nl";
            French, "fr";
            Fulah, "ff";
            Gaelic, "gd";
            Galician, "gl";
            Ganda, "lg";
            Georgian, "ka";
            German, "de";
            Gikuyu, "ki";
            GreekModern, "el";
            Greenlandic, "kl";
            Guarani, "gn";
            Gujarati, "gu";
            Haitian, "ht";
            HaitianCreole, "ht";
            Hausa, "ha";
            Hebrew, "he";
            Herero, "hz";
            Hindi, "hi";
            HiriMotu, "ho";
            Hungarian, "hu";
            Icelandic, "is";
            Ido, "io";
            Igbo, "ig";
            Indonesian, "id";
            Interlingua, "ia";
            Interlingue, "ie";
            Inuktitut, "iu";
            Inupiaq, "ik";
            Irish, "ga";
            Italian, "it";
            Japanese, "ja";
            Javanese, "jv";
            Kalaallisut, "kl";
            Kannada, "kn";
            Kanuri, "kr";
            Kashmiri, "ks";
            Kazakh, "kk";
            Kikuyu, "ki";
            Kinyarwanda, "rw";
            Kirghiz, "ky";
            Komi, "kv";
            Kongo, "kg";
            Korean, "ko";
            Kuanyama, "kj";
            Kurdish, "ku";
            Kwanyama, "kj";
            Kyrgyz, "ky";
            Lao, "lo";
            Latin, "la";
            Latvian, "lv";
            Letzeburgesch, "lb";
            Limburgan, "li";
            Limburger, "li";
            Limburgish, "li";
            Lingala, "ln";
            Lithuanian, "lt";
            LubaKatanga, "lu";
            Luxembourgish, "lb";
            Macedonian, "mk";
            Malagasy, "mg";
            Malay, "ms";
            Malayalam, "ml";
            Maldivian, "dv";
            Maltese, "mt";
            Manx, "gv";
            Maori, "mi";
            Marathi, "mr";
            Marshallese, "mh";
            Moldavian, "ro";
            Moldovan, "ro";
            Mongolian, "mn";
            Nauru, "na";
            Navaho, "nv";
            Navajo, "nv";
            NdebeleNorth, "nd";
            NdebeleSouth, "nr";
            Ndonga, "ng";
            Nepali, "ne";
            NorthNdebele, "nd";
            NorthernSami, "se";
            Norwegian, "no";
            NorwegianBokmål, "nb";
            NorwegianNynorsk, "nn";
            Nuosu, "ii";
            Nyanja, "ny";
            NynorskNorwegian, "nn";
            Occidental, "ie";
            Occitan, "oc";
            Ojibwa, "oj";
            OldBulgarian, "cu";
            OldChurchSlavonic, "cu";
            OldSlavonic, "cu";
            Oriya, "or";
            Oromo, "om";
            Ossetian, "os";
            Ossetic, "os";
            Pali, "pi";
            Panjabi, "pa";
            Pashto, "ps";
            Persian, "fa";
            Polish, "pl";
            Portuguese, "pt";
            Punjabi, "pa";
            Pushto, "ps";
            Quechua, "qu";
            Romanian, "ro";
            Romansh, "rm";
            Rundi, "rn";
            Russian, "ru";
            Samoan, "sm";
            Sango, "sg";
            Sanskrit, "sa";
            Sardinian, "sc";
            ScottishGaelic, "gd";
            Serbian, "sr";
            Shona, "sn";
            SichuanYi, "ii";
            Sindhi, "sd";
            Sinhala, "si";
            Sinhalese, "si";
            Slovak, "sk";
            Slovenian, "sl";
            Somali, "so";
            SothoSouthern, "st";
            SouthNdebele, "nr";
            Spanish, "es";
            Sundanese, "su";
            Swahili, "sw";
            Swati, "ss";
            Swedish, "sv";
            Tagalog, "tl";
            Tahitian, "ty";
            Tajik, "tg";
            Tamil, "ta";
            Tatar, "tt";
            Telugu, "te";
            Thai, "th";
            Tibetan, "bo";
            Tigrinya, "ti";
            Tonga, "to";
            Tsonga, "ts";
            Tswana, "tn";
            Turkish, "tr";
            Turkmen, "tk";
            Twi, "tw";
            Uighur, "ug";
            Ukrainian, "uk";
            Urdu, "ur";
            Uyghur, "ug";
            Uzbek, "uz";
            Valencian, "ca";
            Venda, "ve";
            Vietnamese, "vi";
            Volapük, "vo";
            Walloon, "wa";
            Welsh, "cy";
            WesternFrisian, "fy";
            Wolof, "wo";
            Xhosa, "xh";
            Yiddish, "yi";
            Yoruba, "yo";
            Zhuang, "za";
            Zulu, "zu";
        ]
        |> Map.ofList

    /// <inheritdoc />
    override this.ToString() =
        match Language.table.TryFind this with
        | Some x -> x
        | None -> invalidArg "this" "Unable to find language in lookup"


    /// <summary>
    /// Convert a string to a Language object.
    /// </summary>
    static member FromString(str: string) = invert(Language.table).TryFind str
