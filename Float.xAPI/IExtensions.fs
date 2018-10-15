// <copyright file="IExtensions.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI

open System
open System.Collections.Generic

/// <summary>
/// Extensions are available as part of Activity Definitions, as part of a Statement's "context" property, or as part of a Statement's "result" property.
/// In each case, extensions are intended to provide a natural way to extend those properties for some specialized use.
/// The contents of these extensions might be something valuable to just one application, or it might be a convention used by an entire Community of Practice.
/// </summary>
type public IExtensions = KeyValuePair<Uri, string> seq
