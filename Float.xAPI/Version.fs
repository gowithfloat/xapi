// <copyright file="Version.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI

open System

type uint = uint32

/// <summary>
/// Storage for version information.
/// See: https://semver.org/spec/v1.0.0.html
/// </summary>
type public IVersion =
    /// <summary>
    /// Major version X (X.y.z | X > 0) MUST be incremented if any backwards incompatible changes are introduced to the public API.
    /// </summary>
    abstract member Major: uint

    /// <summary>
    /// Minor version Y (x.Y.z | x > 0) MUST be incremented if new, backwards compatible functionality is introduced to the public API.
    /// It MAY be incremented if substantial new functionality or improvements are introduced within the private code
    /// </summary>
    abstract member Minor: uint

    /// <summary>
    /// Patch version Z (x.y.Z | x > 0) MUST be incremented if only backwards compatible bug fixes are introduced.
    /// </summary>
    abstract member Patch: uint

[<CustomComparison;CustomEquality;Struct>]
type public Version =
    /// <inheritdoc />
    val Major: uint

    /// <inheritdoc />
    val Minor: uint

    /// <inheritdoc />
    val Patch: uint

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Version"/> struct.
    /// </summary>
    /// <param name="major">The major version.</param>
    /// <param name="minor">The minor version.</param>
    /// <param name="patch">The patch version.</param>
    new(major, minor, patch) =
        { Major = major; Minor = minor; Patch = patch }

    /// <inheritdoc />
    override this.GetHashCode() = hash (this.Major, this.Minor, this.Patch)

    /// <inheritdoc />
    override this.ToString() = sprintf "%d.%d.%d" this.Major this.Minor this.Patch

    /// <inheritdoc />
    override this.Equals(other) =
        match other with
        | :? IVersion as version -> (this.Major, this.Minor, this.Patch) = (version.Major, version.Minor, version.Patch)
        | _ -> false

    member this.CompareTo = (this :> IComparable<IVersion>).CompareTo
    static member op_LessThan (lhs: Version, rhs: IVersion) = lhs.CompareTo(rhs) < 0
    static member op_GreaterThan (lhs: Version, rhs: IVersion) = lhs.CompareTo(rhs) > 0
    static member op_Equality (lhs: Version, rhs: IVersion) = lhs.CompareTo(rhs) = 0
    static member op_Inquality (lhs: Version, rhs: IVersion) = lhs.CompareTo(rhs) <> 0

    interface IEquatable<IVersion> with
       member this.Equals other =
         (this.Major, this.Minor, this.Patch) = (other.Major, other.Minor, other.Patch)

    interface IComparable<IVersion> with
      member this.CompareTo other =
          match compare this.Major other.Major with
          | 1 -> 1
          | -1 -> -1
          | _ -> 
            match compare this.Minor other.Minor with
            | 1 -> 1
            | -1 -> -1
            | _ -> compare this.Patch other.Patch

    interface IVersion with
        member this.Major = this.Major
        member this.Minor = this.Minor
        member this.Patch = this.Patch
        