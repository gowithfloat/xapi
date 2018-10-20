// <copyright file="Mailbox.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Actor.Identifier

open System.Net.Mail
open Float.xAPI.Interop

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

[<CustomEquality;NoComparison;Struct>]
type public Mailbox =
    /// <inheritdoc />
    val Address: MailAddress

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Actor.Identifier.Mailbox"/> class.
    /// </summary>
    /// <param name="address">The address associated with this mailbox.</param>
    new (address) =
        nullArg address "address"
        { Address = address }

    /// <inheritdoc />
    override this.ToString() = sprintf "mailto:%s" this.Address.Address

    /// <inheritdoc />
    override this.GetHashCode() = hash this.Address

    /// <inheritdoc />
    override this.Equals other = 
        match other with
        | :? IMailbox as mailbox -> this.Address = mailbox.Address
        | _ -> false

    static member op_Equality (lhs: IMailbox, rhs: IMailbox) = lhs.Equals(rhs)
    static member op_Inequality (lhs: IMailbox, rhs: IMailbox) = not(lhs.Equals(rhs))

    interface IMailbox with
        member this.Address = this.Address
        member this.Equals other = this.Equals other
