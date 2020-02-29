// <copyright file="ObjectType.fs" company="Float">
// Copyright (c) 2019 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI

/// <summary>
/// If not specified, the objectType is assumed to be Activity.
/// Other valid values are: Agent, Group, SubStatement or StatementRef.
/// The properties of an Object change according to the objectType.
/// </summary>
type ObjectType =
    /// <summary>
    /// A Statement can represent an Activity as the Object of the Statement.
    /// </summary>
    | Activity
    /// <summary>
    /// An Agent (an individual) is a persona or system.
    /// </summary>
    | Agent
    /// <summary>
    /// A Group represents a collection of Agents and can be used in most of the same situations an Agent can be used.
    /// </summary>
    | Group
    /// <summary>
    /// A SubStatement is like a StatementRef in that it is included as part of a containing Statement.
    /// Unlike a StatementRef, it does not represent an event that has occurred.
    /// </summary>
    | SubStatement
    /// <summary>
    /// A Statement Reference MUST specify an "objectType" property with the value StatementRef.
    /// </summary>
    | StatementReference
    
    /// <inheritdoc />
    override this.ToString() =
        match this with
        | Activity -> "Activity"
        | Agent -> "Agent"
        | Group -> "Group"
        | SubStatement -> "SubStatement"
        | StatementReference -> "StatementRef"


    /// <summary>
    /// Convert a string to an object type. Returns none if the string is not a valid object type.
    /// </summary>
    static member FromString objtyp =
        match objtyp with
        | "Activity" -> Some Activity
        | "Agent" -> Some Agent
        | "Group" -> Some Group
        | "SubStatement" -> Some SubStatement
        | "StatementRef" -> Some StatementReference
        | _ -> None
