// <copyright file="AnyIFI.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Actor.Identifier

/// <summary>
/// A discriminated union for every possible inverse functional identifier.
/// </summary>
type public InverseFunctionalIdentifier = 
    | Mailbox of IMailbox 
    | MailboxSha1Sum of IMailboxSha1Sum 
    | OpenID of IOpenID 
    | Account of IAccount

type public InverseFunctionalIdentifier with
    /// <summary>
    /// Retrieve the inverse functional identifier in this instance.
    /// </summary>
    member this.Item =
        match this with
        | Mailbox mbox -> mbox :> IInverseFunctionalIdentifier
        | MailboxSha1Sum sha -> sha :> IInverseFunctionalIdentifier
        | OpenID id -> id :> IInverseFunctionalIdentifier
        | Account account -> account :> IInverseFunctionalIdentifier

    /// <summary>
    /// A function to create an AnyIFI object from an inverse functional identifier.
    /// </summary>
    static member From (ifi: IInverseFunctionalIdentifier) =
        match ifi with
        | :? IMailbox as mbox -> Mailbox mbox
        | :? IMailboxSha1Sum as sha -> MailboxSha1Sum sha
        | :? IOpenID as openId -> OpenID openId
        | :? IAccount as account -> Account account
        | _ -> invalidArg "ifi" "Unknown inverse functional identifier"
