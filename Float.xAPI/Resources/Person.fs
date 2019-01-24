// <copyright file="Person.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Resources

open Float.xAPI.Actor.Identifier

// todo: should this be string or ProfileId?

/// <summary>
/// The Person Object is very similar to an Agent Object, but instead of each attribute having a single value, each attribute has an array value, and it is legal to include multiple identifying properties.
/// This is different from the FOAF concept of person, person is being used here to indicate a person-centric view of the LRS Agent data, but Agents just refer to one persona (a person in one context).
/// </summary>
type Person = (string * IInverseFunctionalIdentifier) seq
