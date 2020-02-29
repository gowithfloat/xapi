// <copyright file="Extensions.fs" company="Float">
// Copyright (c) 2020 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Json

open System.Collections.Generic
open System.Runtime.CompilerServices

[<Extension>]
type MapExtensions =
    [<Extension>]
    static member inline Get(dict: Map<'TKey, 'TValue>, key: 'TKey, def: 'TValue): 'TValue option =
        let value = ref def

        match dict.TryGetValue(key, value) with
        | true -> Some !value
        | false -> None
        