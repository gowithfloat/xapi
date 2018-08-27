// <copyright file="Mailbox.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Actor.Identifier

open System
open System.Net.Mail

/// <summary>
/// A personal mailbox, ie. an Internet mailbox associated with exactly one owner, the first owner of this mailbox.
/// This is a 'static inverse functional property', in that there is (across time and change) at most one individual that ever has any particular value for foaf:mbox. 
/// </summary>
type public IMailbox =
    /// <summary>
    /// Only email addresses that have only ever been and will ever be assigned to this Agent, but no others, SHOULD be used for this property and mbox_sha1sum.
    /// </summary>
    abstract member Address: MailAddress

    inherit IInverseFunctionalIdentifier

[<CustomEquality;NoComparison>]
type public Mailbox =
    struct
        /// <inheritdoc />
        val Address: MailAddress

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Float.xAPI.Actor.Identifier.Mailbox"/> class.
        /// </summary>
        /// <param name="address">The address associated with this mailbox.</param>
        new (address) =
            { Address = address }

        override this.GetHashCode() = hash this.Address
        override this.ToString() = sprintf "mailto:%s" this.Address.Address
        override this.Equals(other) = 
            match other with
            | :? IMailbox as mailbox -> this.Address = mailbox.Address
            | _ -> false

        interface IEquatable<IMailbox> with
            member this.Equals other =
                this.Address = other.Address

        interface IMailbox with
            member this.Address = this.Address
    end
