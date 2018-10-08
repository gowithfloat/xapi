// <copyright file="Definition.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Activities.Definitions

open System

module Definition =
    /// <summary>
    /// Interaction Activities SHOULD have this Activity type.
    /// </summary>
    let InteractionUri = Uri("http://adlnet.gov/expapi/activities/cmi.interaction")
