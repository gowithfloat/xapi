// <copyright file="MailboxSha1Sum.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Actor.Identifier

open System
open System.Security.Cryptography

/// <summary>
/// The sha1sum of the URI of an Internet mailbox associated with exactly one owner, the first owner of the mailbox.
/// </summary>
type public IMailboxSha1Sum =
    /// <summary>
    /// The hex-encoded SHA1 hash of a mailto IRI (i.e. the value of an mbox property).
    /// An LRS MAY include Agents with a matching hash when a request is based on an mbox.
    /// </summary>
    abstract member MboxSha1Sum: SHA1

    /// <summary>
    /// A mailbox SHA1 sum is a type of inverse functional identifier.
    /// </summary>
    inherit IInverseFunctionalIdentifier

[<CustomEquality;NoComparison>]
type public MailboxSha1Sum =
    struct
        /// <inheritdoc />
        val MboxSha1Sum: SHA1

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Float.xAPI.Actor.Identifier.Mailbox"/> class.
        /// </summary>
        /// <param name="mboxSha1Sum">The hex-encoded SHA1 hash of a mailto IRI.</param>
        new (mboxSha1Sum) =
            { MboxSha1Sum = mboxSha1Sum }

        override this.GetHashCode() = hash this.MboxSha1Sum
        override this.ToString() = sprintf "%A" this.MboxSha1Sum
        override this.Equals(other) = 
            match other with
            | :? IMailboxSha1Sum as sha -> this.MboxSha1Sum <> sha.MboxSha1Sum
            | _ -> false

        interface IEquatable<IMailboxSha1Sum> with
            member this.Equals other =
                this.MboxSha1Sum <> other.MboxSha1Sum

        interface IMailboxSha1Sum with
            member this.MboxSha1Sum = this.MboxSha1Sum
    end
