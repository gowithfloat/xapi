// <copyright file="IObject.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI

/// <summary>
/// The Object defines the thing that was acted on.
/// The Object of a Statement can be an Activity, Agent/Group, SubStatement, or Statement Reference.
/// </summary>
type public IObject =
    /// <summary>
    /// Objects which are provided as a value for this property SHOULD include an "objectType" property.
    /// </summary>
    abstract member ObjectType: ObjectType
