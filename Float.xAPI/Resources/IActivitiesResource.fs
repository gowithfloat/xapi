// <copyright file="IActivitiesResource.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Resources

open System
open Float.xAPI.Activities

/// <summary>
/// The Activities Resource provides a method to retrieve a full description of an Activity from the LRS.
/// </summary>
type IActivitiesResource =
    /// <summary>
    /// Loads the complete Activity Object specified.
    /// If an LRS does not have a canonical definition of the Activity to return, the LRS SHOULD* still return an Activity Object when queried.
    /// </summary>
    /// <param name="activityId">The id associated with the Activities to load.</param>
    abstract member GetActivity: ActivityId -> IActivity
