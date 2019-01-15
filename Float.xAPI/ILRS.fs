// <copyright file="ILRS.fs" company="Float">
// Copyright (c) 2019 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI

open Float.xAPI.Resources
open Float.xAPI.Resources.Documents

/// <summary>
/// An LRS just conforms to the other interfaces for returning resources.
/// </summary>
type public ILRS =
    // abstract member statements: IStatementResource
    inherit IStatementResource
    inherit IActivitiesResource
    inherit IAgentsResource
    inherit IStateResource
    inherit IActivityProfileResource
    inherit IAgentProfileResource
