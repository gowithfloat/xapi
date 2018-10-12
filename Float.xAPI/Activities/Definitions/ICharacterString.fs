// <copyright file="ICharacterString.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Activities.Definitions

open Float.xAPI.Languages

/// <summary>
/// Some of the values within the responses described in the xAPI specification can be prepended with certain additional parameters.
/// These were originally based on the characterstring delimiters defined in the SCORM 2004 4th Edition Run-Time Environment.
/// </summary>
type ICharacterString =
    interface end

/// <summary>
/// A character string with a language property.
/// </summary>
type ICharacterStringLanguage =
    /// <summary>
    /// The language used within the item.
    /// </summary>
    abstract member Language: ILanguageTag option

    inherit ICharacterString

/// <summary>
/// A character string that can match a string.
/// </summary>
type ICharacterStringMatchString =
    /// <summary>
    /// Returns true if the given string matches this character string.
    /// </summary>
    abstract member Match: string -> bool

    inherit ICharacterString

/// <summary>
/// A character string that can match a sequence of strings.
/// </summary>
type ICharacterStringMatchSequence =
    /// <summary>
    /// Returns true if the given strings match this character string.
    /// </summary>
    abstract member Match: string seq -> bool

    inherit ICharacterString

/// <summary>
/// A character string that can match a number.
/// </summary>
type ICharacterStringMatchNumber =
    /// <summary>
    /// Returns true if the given number is within the bounds of this numeric character string.
    /// </summary>
    abstract member Match: int -> bool

    inherit ICharacterString

/// <summary>
/// A character string that can look up a response for a given input.
/// </summary>
type ICharacterStringMatchResponse =
    /// <summary>
    /// Returns a value for a response, or None if not found.
    /// </summary>
    abstract member Match: string -> string option

    inherit ICharacterString

/// <summary>
/// A character string that can match a dictionary of responses.
/// </summary>
type ICharacterStringMatchResponses =
    /// <summary>
    /// Returns true if all of the given responses are correct for this character string.
    /// </summary>
    abstract member Match: (string * string) seq -> bool

    inherit ICharacterString
    
/// <summary>
/// A "single" character string is used for matching or performance activity definitions.
/// </summary>
type ICharacterStringSingle =
    /// <summary>
    /// Characterstring parameters are not validated by the LRS.
    /// Systems interpreting Statement data can use their best judgement in interpreting (or ignoring) invalid characterstring parameters and values.
    /// </summary>
    abstract member Items: string seq

    inherit ICharacterStringLanguage
    inherit ICharacterStringMatchString
    inherit ICharacterStringMatchSequence

/// <summary>
/// A character string pair is used for matching or performance activity definitions.
/// </summary>
type ICharacterStringPair =
    /// <summary>
    /// Characterstring parameters are not validated by the LRS.
    /// Systems interpreting Statement data can use their best judgement in interpreting (or ignoring) invalid characterstring parameters and values.
    /// </summary>
    abstract member Items: (string * string) seq

    inherit ICharacterStringLanguage
    inherit ICharacterStringMatchResponse
    inherit ICharacterStringMatchResponses
    
/// <summary>
/// A numeric character string is used for numeric activity definitions.
/// </summary>
type ICharacterStringNumeric =
    /// <summary>
    /// The minimum acceptable response value.
    /// </summary>
    abstract member Min: int option

    /// <summary>
    /// The maximum acceptable response value.
    /// </summary>
    abstract member Max: int option

    inherit ICharacterStringMatchNumber
