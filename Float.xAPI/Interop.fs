// <copyright file="Interop.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float

open System
open System.Text
open System.Security.Cryptography

/// <summary>
/// An exception thrown by IRI checks.
/// </summary>
type InvalidIriException(argName: string) = inherit Exception(sprintf "The given value was not an absolute IRI: %O" argName)

/// <summary>
/// Defines functions used internally to ensure proper parameters are received from C#.
/// </summary>
module internal Interop =
    /// <summary>
    /// Private function to raise an argument exception if a condition is true.
    /// </summary>
    let inline private ifRaise x name =
        if x then raise (ArgumentException name)

    /// <summary>
    /// Private function to raise a not implemented exception.
    /// </summary>
    let inline private notImplemented message =
        raise (NotImplementedException message)

    /// <summary>
    /// Raise an argument null exception if the given value is null.
    /// </summary>
    let inline internal nullArg x name =
        if (isNull (box x)) then raise (ArgumentNullException name)

    //let inline defaultArg<'T when 'T :> struct>(x: 'T, name: string) =
        //if (x = 'T()) then raise (ArgumentException name)

    /// <summary>
    /// Raise an argument exception if the given sequence is empty.
    /// </summary>
    let inline internal emptySeqArg x name =
        ifRaise (Seq.isEmpty x) name
        
    /// <summary>
    /// Raise an argument exception if the given sequence has a value and is empty.
    /// </summary>
    let inline internal emptyOptionalSeqArg x name =
        match x with
        | Some s -> emptySeqArg s name
        | _ -> ()

    /// <summary>
    /// Return the type name of the given object.
    /// </summary>
    let inline internal typeName(x: obj): string =
        x.GetType().Name

    /// <summary>
    /// Sugar for calling toString on an object.
    /// </summary>
    let inline internal toString x =
        x.ToString()

    /// <summary>
    /// Sugar for calling toLower on a string.
    /// </summary>
    let inline internal toLowerString(x: string) =
        x.ToLower()

    /// <summary>
    /// Fold a sequence down to a string, with comma delineation.
    /// </summary>
    let inline internal seqToString x =
        (Seq.fold (fun (sb:StringBuilder) element -> if sb.Length = 0 then sb.Append(element.ToString()) else sb.Append(", ").Append(element.ToString())) (StringBuilder()) x).ToString()
        
    /// <summary>
    /// Throw an argument exception if the given string is null or whitespace.
    /// </summary>
    let inline internal invalidStringArg x name =
        ifRaise (String.IsNullOrWhiteSpace x) name
        
    /// <summary>
    /// Throw an argument exception if the given Uri is not a well formed absolute URI string.
    /// </summary>
    let inline internal invalidAbsoluteUri(x: Uri) (name: string) =
        if (not(Uri.IsWellFormedUriString(x.OriginalString, UriKind.Absolute))) then raise (InvalidIriException name)
        
    /// <summary>
    /// Throw an argument exception if the given string is not a well formed absolute URI string.
    /// </summary>
    let inline internal invalidAbsoluteUriString(x: string) (name: string) =
        if (not(Uri.IsWellFormedUriString(x, UriKind.Absolute))) then raise (InvalidIriException name)

    /// <summary>
    /// Throw an argument exception if any given string in a list is null or whitespace.
    /// </summary>
    let inline internal invalidStringSeqArg x name =
        for y in x do
            invalidStringArg y name
        
    /// <summary>
    /// Throw an argument exception if the given optional string exists and is null or whitespace.
    /// </summary>
    let inline internal invalidOptionalStringArg x name =
        match x with
        | Some n -> invalidStringArg n name
        | None -> ()

    /// <summary>
    /// Returns true if the given URI is not absolute.
    /// </summary>
    let inline internal isNotAbsolute(x: Uri) =
        not x.IsAbsoluteUri

    /// <summary>
    /// Returns the number as a string if given a value, or an empty string if not.
    /// </summary>
    let inline internal optIntToString(x: int option) =
        match x with
        | Some y -> y.ToString()
        | None -> ""

    /// <summary>
    /// Returns the string as an optional integer; will be None if parsing fails.
    /// </summary>
    let inline internal parseInt str =
        match Int32.TryParse(str) with
        | (true, a) -> Some a
        | (false, _) -> None

    /// <summary>
    /// Throw an argument exception if the given URI is not absolute.
    /// </summary>
    let inline internal invalidIRIArg x name =
        ifRaise (isNotAbsolute x) name

    /// <summary>
    /// Returns the bytes from the given string using UTF-8 encoding.
    /// </summary>
    let inline internal bytesFrom(str: string) =
        (UTF8Encoding()).GetBytes str

    /// <summary>
    /// Returns a string from the given bytes with standard formatting.
    /// </summary>
    let inline internal stringFrom(bytes: seq<byte>) =
        BitConverter.ToString(bytes |> Seq.toArray).Replace("-", String.Empty).ToLower()

    /// <summary>
    /// Computes the SHA1 hash of the given string.
    /// </summary>
    let inline internal computeSha<'T when 'T :> HashAlgorithm>(x: string, algorithm: 'T) =
        algorithm.ComputeHash(bytesFrom(x))
        
    /// <summary>
    /// Null coalescing operator for F#.
    /// </summary>
    let inline internal (|?) (a: 'a option) b = 
        match a with
        | Some c -> c
        | None -> b
        
    /// <summary>
    /// Converts an object and name to string, only if the object is Some.
    /// </summary>
    let inline internal toStringOrNone obj name =
        match obj with
        | Some ob -> sprintf "%O %O" name (ob.ToString())
        | _ -> ""
        
    /// <summary>
    /// Converts an object and name to string, only if the object is Some.
    /// </summary>
    let inline internal stringToStringOrNone obj name =
        match obj with
        | Some ob -> sprintf "%O %A" name (ob.ToString())
        | _ -> ""
        
    /// <summary>
    /// Converts a sequence to string, only if the object is Some.
    /// </summary>
    let inline internal seqToStringOrNone seq name =
        match seq with
        | Some s -> sprintf "%O %O" name (seqToString s)
        | _ -> ""

    /// <summary>
    /// Swap values in a tuple,
    /// </summary>
    let inline internal swap (x, y) = y, x

    /// <summary>
    /// Swap all tuples in a list.
    /// </summary>
    let inline internal swapAll tuples = List.map swap tuples

    /// <summary>
    /// Swap all keys and values in a list.
    /// </summary>
    let inline internal invert map = map |> Map.toList |> swapAll |> Map.ofList
