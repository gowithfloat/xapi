// <copyright file="StatementResultFormat.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Resources

/// <summary>
/// An optional formatting requirement on statement resource requests.
/// </summary>
type StatementResultFormat =
    /// <summary>
    /// Only include minimum information necessary in Agent, Activity, Verb and Group Objects to identify them.
    /// For Anonymous Groups this means including the minimum information needed to identify each member.
    /// </summary>
    | Ids

    /// <summary>
    /// Return Agent, Activity, Verb and Group Objects populated exactly as they were when the Statement was received.
    /// An LRS requesting Statements for the purpose of importing them would use a format of "exact" in order to maintain Statement Immutability.
    /// </summary>
    | Exact

    /// <summary>
    /// Return Activity Objects and Verbs populated with the canonical definition of the Activity Objects and Display of the Verbs as determined by the LRS, after applying the language filtering process defined below, and return the original Agent and Group Objects as in "exact" mode. 
    /// </summary>
    | Canonical
