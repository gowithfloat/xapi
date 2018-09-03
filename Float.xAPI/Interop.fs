// <copyright file="Interop.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI

open System
open System.Text
open System.Security.Cryptography

/// <summary>
/// Defines functions used internally to ensure proper parameters are received from C#.
/// </summary>
module Interop =
    /// <summary>
    /// Private function to raise an argument exception if a condition is true.
    /// </summary>
    let inline private ifRaise x name =
        if x then raise (ArgumentException name)

    let inline notImplemented message =
        raise (NotImplementedException message)

    /// <summary>
    /// Raise an argument null exception if the given value is null.
    /// </summary>
    let inline nullArg x name =
        if (isNull (box x)) then raise (ArgumentNullException name)

    /// <summary>
    /// Raise an argument exception if the given sequence is empty.
    /// </summary>
    let inline emptySeqArg x name =
        ifRaise (Seq.isEmpty x) name
        
    /// <summary>
    /// Raise an argument exception if the given sequence has a value and is empty.
    /// </summary>
    let inline emptyOptionalSeqArg x name =
        match x with
        | Some s -> emptySeqArg s name
        | _ -> ()

    /// <summary>
    /// Return the type name of the given object.
    /// </summary>
    let inline typeName(x: obj): string =
        x.GetType().Name

    /// <summary>
    /// Fold a sequence down to a string, with comma delineation.
    /// </summary>
    let seqToString x =
        (Seq.fold (fun (sb:StringBuilder) element -> if sb.Length = 0 then sb.Append(element.ToString()) else sb.Append(", ").Append(element.ToString())) (StringBuilder()) x).ToString()


    /// <summary>
    /// Throw an argument exception if the given string is null or whitespace.
    /// </summary>
    let inline invalidStringArg x name =
        ifRaise (String.IsNullOrWhiteSpace x) name
        
    /// <summary>
    /// Throw an argument exception if the given optional string exists and is null or whitespace.
    /// </summary>
    let inline invalidOptionalStringArg x name =
        match x with
        | Some n -> invalidStringArg n name
        | None -> ()

    /// <summary>
    /// Returns true if the given URI is not absolute.
    /// </summary>
    let inline private isNotAbsolute(x: Uri) =
        not x.IsAbsoluteUri

    /// <summary>
    /// Throw an argument exception if the given URI is not absolute.
    /// </summary>
    let inline invalidIRIArg x name =
        ifRaise (isNotAbsolute x) name

    /// <summary>
    /// Returns the bytes from the given string using UTF-8 encoding.
    /// </summary>
    let inline bytesFrom(str: string) =
        (UTF8Encoding()).GetBytes str

    /// <summary>
    /// Returns a string from the given bytes with standard formatting.
    /// </summary>
    let inline stringFrom(bytes: seq<byte>) =
        BitConverter.ToString(bytes |> Seq.toArray).Replace("-", String.Empty).ToLower()

    /// <summary>
    /// Computes the SHA1 hash of the given string.
    /// </summary>
    let inline computeSha<'T when 'T :> HashAlgorithm>(x: string, algorithm: 'T) =
        algorithm.ComputeHash(bytesFrom(x))
        
    /// <summary>
    /// Null coalescing operator for F#.
    /// </summary>
    let inline (|?) (a: 'a option) b = 
        match a with
        | Some c -> c
        | None -> b

    let inline toStringOrNone obj name =
        match obj with
        | Some ob -> sprintf "%O %O" name (ob.ToString())
        | _ -> ""

    let inline seqToStringOrNone seq name =
        match seq with
        | Some s -> sprintf "%O %O" name (seqToString s)
        | _ -> ""

    /// <summary>
    /// Swap values in a tuple,
    /// </summary>
    let swap (x, y) = y, x

    /// <summary>
    /// Swap all tuples in a list.
    /// </summary>
    let swapAll tuples = List.map swap tuples

    /// <summary>
    /// Swap all keys and values in a list.
    /// </summary>
    let invert map = map |> Map.toList |> swapAll |> Map.ofList
