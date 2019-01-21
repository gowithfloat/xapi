// <copyright file="IAboutResource.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Resources

open Float.xAPI

//type IAboutInformation = (Version seq * IExtensions)

/// <summary>
/// Returns information about this LRS, including the xAPI version supported.
/// Primarily this resource exists to allow Clients that support multiple xAPI versions to decide which version to use when communicating with the LRS.
/// Extensions are included to allow other uses to emerge.
/// </summary>
type IAboutResource =
    /// <summary>
    /// Returns basic metadata about this LRS.
    /// </summary>
    abstract member Information: string
