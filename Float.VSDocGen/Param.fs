// <copyright file="Param.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.VSDocGen

/// <summary>
/// One parameter to a function.
/// </summary>
type Param =
    val Name: string
    val Description: string

    new(name: string, description: string) =
        { Name = name; Description = description }

    /// <inheritdoc />
    override this.ToString() =
        sprintf "#### %O\n%O" this.Name this.Description
    