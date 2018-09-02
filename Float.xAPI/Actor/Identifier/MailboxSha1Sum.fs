// <copyright file="MailboxSha1Sum.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Actor.Identifier

open System
open Float.xAPI
open Float.xAPI.Interop

/// <summary>
/// The sha1sum of the URI of an Internet mailbox associated with exactly one owner, the first owner of the mailbox.
/// </summary>
type public IMailboxSha1Sum =
    /// <summary>
    /// The hex-encoded SHA1 hash of a mailto IRI (i.e. the value of an mbox property).
    /// An LRS MAY include Agents with a matching hash when a request is based on an mbox.
    /// </summary>
    abstract member MboxSha1Sum: SHA1Hash

    inherit IInverseFunctionalIdentifier

[<StructuralEquality;NoComparison;Struct>]
type public MailboxSha1Sum =
    /// <inheritdoc />
    val MboxSha1Sum: SHA1Hash

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Actor.Identifier.MailboxSha1Sum"/> struct.
    /// </summary>
    /// <param name="mboxSha1Sum">The hex-encoded SHA1 hash of a mailto IRI.</param>
    new (mboxSha1Sum) =
        nullArg mboxSha1Sum "mboxSha1Sum"
        { MboxSha1Sum = mboxSha1Sum }

    /// <inheritdoc />
    override this.ToString() = sprintf "mbox_sha1sum: %A" this.MboxSha1Sum

    static member op_Equality (lhs: MailboxSha1Sum, rhs: IMailboxSha1Sum) = lhs.Equals(rhs)
    static member op_Inequality (lhs: MailboxSha1Sum, rhs: IMailboxSha1Sum) = not(lhs.Equals(rhs))

    interface IMailboxSha1Sum with
        member this.MboxSha1Sum = this.MboxSha1Sum
