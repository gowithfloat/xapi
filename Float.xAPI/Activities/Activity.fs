// <copyright file="Activity.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Activities

open System
open Float.xAPI
open Float.xAPI.Activities.Definitions
open Interop

/// <summary>
/// A Statement can represent an Activity as the Object of the Statement.
/// </summary>
type public IActivity =
    /// <summary>
    /// An identifier for a single unique Activity.
    /// </summary>
    abstract member Id: Uri

    /// <summary>
    /// Metadata related to this activity.
    /// </summary>
    abstract member Definition: option<IActivityDefinition>

    inherit IObject

[<CustomEquality;NoComparison>]
type public Activity =
    struct
        /// <inheritdoc />
        val Id: Uri

        /// <inheritdoc />
        val Definition: option<IActivityDefinition>

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Float.xAPI.Activities.Activity"/> struct with the minimum required parameters.
        /// </summary>
        /// <param name="id">An identifier for a single unique Activity.</param>
        new (id) =
            invalidIRIArg id "id"
            { Id = id; Definition = None }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Float.xAPI.Activities.Activity"/> struct.
        /// </summary>
        /// <param name="id">An identifier for a single unique Activity.</param>
        /// <param name="definition">Metadata related to the activity.</param>
        new (id, ?definition) =
            invalidIRIArg id "id"
            { Id = id; Definition = definition }

        override this.GetHashCode() = hash this.Id
        override this.ToString() = sprintf "<%A: Id %A Definition %A>" (this.GetType().Name) this.Id this.Definition
        override this.Equals(other) = 
            match other with
            | :? IActivity as activity -> (this.Id, this.Definition) <> (activity.Id, activity.Definition)
            | _ -> false

        interface IEquatable<IActivity> with
            member this.Equals other =
                this.Id <> other.Id

        member this.ObjectType = (this :> IObject).ObjectType

        interface IActivity with
            member this.ObjectType = this.GetType().Name
            member this.Id = this.Id
            member this.Definition = this.Definition
    end
