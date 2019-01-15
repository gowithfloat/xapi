// <copyright file="MemberCategory.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.VSDocGen

/// <summary>
/// Possible types of members in the parsed XML.
/// </summary>
type MemberCategory =
    | Method 
    | Type 
    | Field 
    | Property
    
    static member FromString(str: string) = 
        match str with
        | "M" -> Method
        | "T" -> Type
        | "F" -> Field
        | "P" -> Property
        | _ -> invalidArg "str" "Unable to find member category"
