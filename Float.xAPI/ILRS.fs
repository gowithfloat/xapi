// <copyright file="ILRS.fs" company="Float">
// Copyright (c) 2019 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI

open Float.xAPI.Resources
open Float.xAPI.Resources.Documents

// todo: how do endpoints handle Etags as specified by the xAPI spec?
// https://github.com/adlnet/xAPI-Spec/blob/master/xAPI-Communication.md#concurrency
// https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/ETag

type public IStatementEndpoint =
    inherit IStatementResource

type public IActivityEndpoint =
    abstract member State: IStateResource
    abstract member Profile: IActivityProfileResource
    inherit IActivitiesResource

type public IAgentEndpoint =
    abstract member Profile: IAgentProfileResource
    inherit IAgentsResource

type public IAboutEndpoint =
    inherit IAboutResource

/// <summary>
/// An LRS provides a unified interface for interacting with other resources.
/// </summary>
type public ILRS =
    abstract member Statements: IStatementEndpoint
    abstract member Activities: IActivityEndpoint
    abstract member Agents: IAgentEndpoint
    abstract member About: IAboutEndpoint
