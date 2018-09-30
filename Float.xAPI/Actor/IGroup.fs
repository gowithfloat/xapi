// <copyright file="IGroup.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Actor

/// <summary>
/// A Group represents a collection of Agents and can be used in most of the same situations an Agent can be used.
/// There are two types of Groups: Anonymous Groups and Identified Groups.
/// </summary>
type public IGroup =
    /// <summary>
    /// The members of this Group.
    /// </summary>
    abstract member Member: IAgent seq // todo: this is optional for an identified group

    inherit IActor
