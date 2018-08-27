// <copyright file="Account.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Actor.Identifier

open System

/// <summary>
/// A user account on an existing system, such as a private system (LMS or intranet) or a public system (social networking site).
/// </summary>
type public IAccount =
    /// <summary>
    /// The unique id or name used to log in to this account.
    /// This is based on FOAF's accountName.
    /// </summary>
    abstract member Name: string

    /// <summary>
    /// The canonical home page for the system the account is on.
    /// This is based on FOAF's accountServiceHomePage.
    /// </summary>
    abstract member HomePage: Uri

    /// <summary>
    /// An account is a type of inverse functional identifier.
    /// </summary>
    inherit IInverseFunctionalIdentifier

[<CustomEquality;NoComparison>]
type public Account =
    struct
        /// <inheritdoc />
        val Name: string

        /// <inheritdoc />
        val HomePage: Uri

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Float.xAPI.Actor.Identifier.Account"/> class.
        /// </summary>
        /// <param name="name">The unique id or name used to log in to this account.</param>
        /// <param name="homePage">The canonical home page for the system the account is on.</param>
        new (name, homePage) =
            { Name = name; HomePage = homePage }

        override this.GetHashCode() = hash (this.Name, this.HomePage)
        override this.ToString() = sprintf "<%A: Name %A HomePage %A" (this.GetType().Name) this.Name this.HomePage
        override this.Equals(other) = 
            match other with
            | :? IAccount as account -> (this.Name, this.HomePage) = (account.Name, account.HomePage)
            | _ -> false

        interface IEquatable<IAccount> with
            member this.Equals other =
                (this.Name, this.HomePage) = (other.Name, other.HomePage)

        interface IAccount with
            member this.Name = this.Name
            member this.HomePage = this.HomePage
    end
