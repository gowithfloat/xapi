// <copyright file="AnyIFI.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Actor.Identifier

/// <summary>
/// A discriminated union for every possible IFI type.
/// </summary>
type public AnyIFI = 
    | Mailbox of IMailbox 
    | MailboxSha1Sum of IMailboxSha1Sum 
    | OpenID of IOpenID 
    | Account of IAccount

type public AnyIFI with
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
    static member FromIdentifier (ifi: IInverseFunctionalIdentifier) =
        match ifi with
        | :? IMailbox as mbox -> AnyIFI.Mailbox mbox
        | :? IMailboxSha1Sum as sha -> AnyIFI.MailboxSha1Sum sha
        | :? IOpenID as openId -> AnyIFI.OpenID openId
        | :? IAccount as account -> AnyIFI.Account account
        | _ -> invalidArg "ifi" "Unknown inverse functional identifier"
