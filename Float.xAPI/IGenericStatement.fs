// <copyright file="IGenericStatement.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI

open System
open Float.xAPI
open Float.xAPI.Actor

/// <summary>
/// Both substatements and statements implement this base interface.
/// </summary>
type public IGenericStatement =
    /// <summary>
    /// Whom the Statement is about, as an Agent or Group Object.
    /// </summary>
    abstract member Actor: IActor

    /// <summary>
    /// Action taken by the Actor.
    /// </summary>
    abstract member Verb: IVerb

    /// <summary>
    /// Activity, Agent, or another Statement that is the Object of the Statement.
    /// </summary>
    abstract member Object: IObject

    /// <summary>
    /// Result Object, further details representing a measured outcome.
    /// </summary>
    abstract member Result: IResult option

    /// <summary>
    /// Context that gives the Statement more meaning.
    /// </summary>
    abstract member Context: IContext option

    /// <summary>
    /// Timestamp of when the events described within this Statement occurred.
    /// </summary>
    abstract member Timestamp: DateTime option

    /// <summary>
    /// A statement is an object.
    /// </summary>
    inherit IObject
