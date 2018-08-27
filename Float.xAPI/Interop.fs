// <copyright file="Interop.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI

open System
open System.Text
open System.Security.Cryptography

module Interop =
    let inline private ifRaise x name =
        if x then raise (ArgumentException name)

    [<CompiledName("NullArg")>]
    let inline nullArg x name =
        if (isNull (box x)) then raise (ArgumentNullException name)

    let inline emptySeqArg x name =
        ifRaise (Seq.isEmpty x) name

    [<CompiledName("InvalidStringArg")>]
    let inline invalidStringArg x name =
        ifRaise (String.IsNullOrWhiteSpace x) name

    let inline private isNotAbsolute(x: Uri) =
        not x.IsAbsoluteUri

    [<CompiledName("InvalidIRIArg")>]
    let inline invalidIRIArg x name =
        ifRaise (isNotAbsolute x) name

    let inline bytesFrom(str: string) =
        (new UTF8Encoding()).GetBytes str

    let inline stringFrom bytes =
        BitConverter.ToString(bytes).Replace("-", String.Empty).ToLower()

    let inline computeSha x =
        SHA1.Create().ComputeHash(bytesFrom(x))
