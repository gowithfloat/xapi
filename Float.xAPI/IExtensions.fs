// <copyright file="IExtensions.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI

open System
open System.Collections.Generic

// todo: in F#, this should just be (Uri * string) seq, but that prevents dictionary usage in C#
// is there a way to use a simple F# tuple here but allow dictionary use in C#?
// one option is a discriminated union:
// | Pairs of KeyValuePair<Uri, string> seq
// | Tuples of Tuple<Uri, string> seq
// | Sequence of (Uri * string) seq

/// <summary>
/// Extensions are available as part of Activity Definitions, as part of a Statement's "context" property, or as part of a Statement's "result" property.
/// In each case, extensions are intended to provide a natural way to extend those properties for some specialized use.
/// The contents of these extensions might be something valuable to just one application, or it might be a convention used by an entire Community of Practice.
/// </summary>
type public IExtensions = KeyValuePair<Uri, string> seq
