// <copyright file="IDictionaryRepresentable.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI

/// <summary>
/// We ensure that types can be converted to a standard dictionary format.
/// This format could then be used to create a JSON representation, or similar.
/// </summary>
type public IDictionaryRepresentable =
    /// <summary>
    /// Create a dictionary representation of this object.
    /// </summary>
    abstract member ToDictionary: unit -> (string * obj) seq
