// <copyright file="Verb.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI

open System
open Float.xAPI.Languages
open Float.Common.Interop

/// <summary>
/// The Verb defines the action between an Actor and an Activity.
/// </summary>
type public IVerb =
    /// <summary>
    /// Corresponds to a Verb definition.
    /// Each Verb definition corresponds to the meaning of a Verb, not the word.
    /// </summary>
    abstract member Id: Uri

    /// <summary>
    /// The human readable representation of the Verb in one or more languages.
    /// This does not have any impact on the meaning of the Statement, but serves to give a human-readable display of the meaning already determined by the chosen Verb.
    /// </summary>
    abstract member Display: ILanguageMap

    inherit IEquatable<IVerb>

[<CustomEquality;NoComparison;Struct>]
type public Verb =
    /// <inheritdoc />
    val Id: Uri

    /// <inheritdoc />
    val Display: ILanguageMap

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Verb"/> struct.
    /// </summary>
    /// <param name="id">The verb definition. Required.</param>
    /// <param name="display">The human readable representation of the verb. Recommended.</param>
    public new (id, display) =
        nullArg id "id"
        nullArg display "display"
        emptySeqArg display "display"
        { Id = id; Display = display }

    /// <inheritdoc />
    override this.GetHashCode() = hash this.Id

    /// <inheritdoc />
    override this.Equals other =
        match other with
        | :? IVerb as verb -> this.Id = verb.Id
        | _ -> false

    static member op_Equality (lhs: Verb, rhs: IVerb) = lhs.Equals(rhs)
    static member op_Inequality (lhs: Verb, rhs: IVerb) = not(lhs.Equals(rhs))

    interface IVerb with
        member this.Id = this.Id
        member this.Display = this.Display
        member this.Equals other = this.Equals other

    /// <summary>
    /// The certainty that an LRS has an accurate and complete collection of data is guaranteed by the fact that Statements cannot be logically changed or deleted.
    /// This immutability of Statements is a key factor in enabling the distributed nature of Experience API.
    /// However, not all Statements are perpetually valid once they have been issued.
    /// Mistakes or other factors could dictate that a previously made Statement is marked as invalid.
    /// This is called "voiding a Statement" and this reserved Verb is used for this purpose.
    /// </summary>
    static member public Voided =
        Verb(Uri("http://adlnet.gov/expapi/verbs/voided"), LanguageMap(LanguageTag.EnglishUS, "voided"))
