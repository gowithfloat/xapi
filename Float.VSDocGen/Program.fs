// <copyright file="Program.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.VSDocGen

open System.IO
open System
open Float.Common.Interop
open FSharp.Data
open System.Xml
open System.Xml.Linq
open System.Text
open System.Security.Cryptography

// see: http://fsharp.github.io/FSharp.Data/library/XmlProvider.html
// see: http://fsharp.github.io/FSharp.Data/reference/fsharp-data-xmlprovider.html
// see: https://medium.com/real-world-fsharp/parsing-itunes-xml-data-with-f-b0cdf4c601fe

type Doc = XmlProvider<"""
<doc>
<assembly><name>Example.Assembly</name></assembly>
<members>
<member name="M:Example.Assembly.SomeType.SomeMethod">
 <summary>
 This is a summary for a method.
 </summary>
</member>
<member name="T:Example.Assembly.SomeType">
 <summary>
 This is a summary for a type.
 </summary>
</member>
<member name="F:Example.Assembly.SomeType.InheritedMethod">
 <inheritdoc />
</member>
<member name="M:Example.Assembly.SomeType.SomeMethod(System.String)">
 <summary>
 This is a summary for a method that takes a string parameter.
 </summary>
 <param name="string">A string parameter.</param>
</member>
<member name="M:Example.Assembly.SomeType.SomeMethod(System.String,System.String)">
 <summary>
 This is a summary for a method that takes two string parameters.
 </summary>
 <param name="string1">The first string parameter.</param>
 <param name="string2">The second string parameter.</param>
</member>
<member name="M:Example.Assembly.SomeType.#ctor(System.String)">
 <summary>
 Initializes a new instance of the <see cref="T:Example.Assembly.SomeType"/> struct.
 </summary>
 <param name="string">A string parameter.</param>
</member>
</members>
</doc> """>

module Main =
    let createParam(xml: Doc.Param) =
        Param(xml.Name, xml.Value)

    let createMember(xml: Doc.Member) =
        let splitName = xml.Name.Split(':', '(', ')')
        let classifier = MemberCategory.FromString splitName.[0]
        let isInherited = match xml.Inheritdoc with
                          | Some _ -> true
                          | None -> false
        let summary = match xml.Summary with
                      | None -> None
                      | Some x -> x.Value
        let param = xml.Params |> Seq.map createParam

        Member(classifier, splitName.[1], summary, isInherited, Some param)

    let paramToString(param: Param) =
        "#### " + param.Name + "\n" + param.Description

    let memberToString(mem: Member) =
        "## " 
          + mem.Name 
          + "\n" 
          + match mem.Summary with
            | Some sum -> sum.Trim(' ', '\n', '\r')
            | _ -> "No summary."
          + "\n"
          + match mem.Params with 
            | Some par -> "### Parameters\n" + (par |> Seq.map paramToString |> String.concat "\n")
            | _ -> ""

    [<EntryPoint>]
    let main argv =
        match argv.Length with
        | len when len < 2 ->
            printfn "missing required inputs: input path (VS generated XML) and output path (for markdown file)"
            1
        | len when len > 2 -> 
            printfn "too many inputs: just specify input path (VS generated XML) and output path (for markdown file)"
            1 // return an integer exit code
        | _ ->
            let (inputFilePath, outputFilePath) = (argv.[0], argv.[1])
            let doc = Doc.Parse(File.ReadAllText inputFilePath)
            let result = doc.Members |> Seq.map createMember
            let output = doc.Members |> Seq.map createMember |> Seq.map memberToString
            File.WriteAllLines(outputFilePath, List.concat(seq [["# " + doc.Assembly.Name]; List.ofSeq output]))
            0 // return an integer exit code
