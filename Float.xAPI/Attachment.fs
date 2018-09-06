// <copyright file="Attachments.fs" company="Float">
// Copyright (c) 2018 (c) Float,LLC, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI

open System
open System.Net.Mime
open System.Runtime.InteropServices
open Float.xAPI.Languages
open Interop

/// <summary>
/// In some cases an Attachment is logically an important part of a Learning Record.
/// It could be an essay, a video, etc.
/// Another example of such an Attachment is (the image of) a certificate that was granted as a result of an experience.
/// It is useful to have a way to store these Attachments in and retrieve them from an LRS.
/// </summary>
type public IAttachment =
    /// <summary>
    /// Identifies the usage of this Attachment.
    /// For example: one expected use case for Attachments is to include a "completion certificate".
    /// An IRI corresponding to this usage MUST be coined, and used with completion certificate attachments.
    /// </summary>
    abstract member UsageType: Uri

    /// <summary>
    /// Display name (title) of this Attachment.
    /// </summary>
    abstract member Display: ILanguageMap

    /// <summary>
    /// A description of the Attachment.
    /// </summary>
    abstract member Description: ILanguageMap option

    /// <summary>
    /// The content type of the Attachment.
    /// </summary>
    abstract member ContentType: ContentType

    /// <summary>
    /// The length of the Attachment data in octets.
    /// </summary>
    abstract member Length: uint

    /// <summary>
    /// The SHA-2 hash of the Attachment data.
    /// </summary>
    abstract member Sha2: ISHAHash

    /// <summary>
    /// An IRL at which the Attachment data can be retrieved, or from which it used to be retrievable.
    /// </summary>
    abstract member FileUrl: Uri option

[<NoComparison;NoEquality;Struct>]
type public Attachment =
    /// <inheritdoc />
    val UsageType: Uri

    /// <inheritdoc />
    val Display: ILanguageMap

    /// <inheritdoc />
    val Description: ILanguageMap option

    /// <inheritdoc />
    val ContentType: ContentType

    /// <inheritdoc />
    val Length: uint

    /// <inheritdoc />
    val Sha2: ISHAHash

    /// <inheritdoc />
    val FileUrl: Uri option

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Attachment"/> struct.
    /// </summary>
    /// <param name="usageType">Identifies the usage of this Attachment.</param>
    /// <param name="display">Display name of this Attachment.</param>
    /// <param name="contentType">The content type of the Attachment.</param>
    /// <param name="length">The length of the Attachment data in octets.</param>
    /// <param name="sha">The SHA-2 hash of the Attachment data.</param>
    /// <param name="description">A description of the Attachment.</param>
    /// <param name="fileUrl">An IRL at which the Attachment data can be retrieved, or from which it used to be retrievable.</param>
    public new (usageType, display, contentType, length, sha, [<Optional;DefaultParameterValue(null)>] ?description, [<Optional;DefaultParameterValue(null)>] ?fileUrl) =
        invalidIRIArg usageType "usageType"
        nullArg display "display"
        emptySeqArg display "display"
        nullArg contentType "contentType"
        { UsageType = usageType; Display = display; ContentType = contentType; Length = length; Sha2 = sha; Description = description; FileUrl = fileUrl }

    override this.ToString() = sprintf "<%A: UsageType %A Display %A Description %A ContentType %A Length %A Sha2 %A FileUrl %A>" (this.GetType().Name) this.UsageType this.Display this.Description this.ContentType this.Length this.Sha2 this.FileUrl

    interface IAttachment with
        member this.UsageType = this.UsageType
        member this.Display = this.Display
        member this.Description = this.Description
        member this.ContentType = this.ContentType
        member this.Length = this.Length
        member this.Sha2 = this.Sha2
        member this.FileUrl = this.FileUrl
