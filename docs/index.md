# Float.xAPI
## Float.xAPI.IDictionaryRepresentable.ToDictionary
Create a dictionary representation of this object.
### Parameters

## Float.xAPI.IDictionaryRepresentable
We ensure that types can be converted to a standard dictionary format.
 This format could then be used to create a JSON representation, or similar.
### Parameters

## Float.xAPI.SHAHash.Encoded
No summary.
### Parameters

## Float.xAPI.SHAHash.ToString
No summary.
### Parameters

## Float.xAPI.SHAHash.#ctor
Initializes a new instance of the  struct.
### Parameters
#### bytes
The encoded data.
## Float.xAPI.SHAHash.#ctor
Initializes a new instance of the  struct.
### Parameters
#### text
The text to encode.
#### algorithm
The algorithm to use when encoding. If none is provided, SHA1 will be used.
## Float.xAPI.ISHAHash.Encoded
The encoded data.
### Parameters

## Float.xAPI.ISHAHash
Storage for data in SHA1 hash format.
### Parameters

## Float.xAPI.IObject.ObjectType
Objects which are provided as a value for this property SHOULD include an "objectType" property.
### Parameters

## Float.xAPI.IObject
The Object defines the thing that was acted on.
 The Object of a Statement can be an Activity, Agent/Group, SubStatement, or Statement Reference.
### Parameters

## Float.xAPI.IExtensions
Extensions are available as part of Activity Definitions, as part of a Statement's "context" property, or as part of a Statement's "result" property.
 In each case, extensions are intended to provide a natural way to extend those properties for some specialized use.
 The contents of these extensions might be something valuable to just one application, or it might be a convention used by an entire Community of Practice.
### Parameters

## Float.xAPI.Verb.Display
No summary.
### Parameters

## Float.xAPI.Verb.Id
No summary.
### Parameters

## Float.xAPI.Verb.Voided
The certainty that an LRS has an accurate and complete collection of data is guaranteed by the fact that Statements cannot be logically changed or deleted.
 This immutability of Statements is a key factor in enabling the distributed nature of Experience API.
 However, not all Statements are perpetually valid once they have been issued.
 Mistakes or other factors could dictate that a previously made Statement is marked as invalid.
 This is called "voiding a Statement" and this reserved Verb is used for this purpose.
### Parameters

## Float.xAPI.Verb.GetHashCode
No summary.
### Parameters

## Float.xAPI.Verb.Equals
No summary.
### Parameters

## Float.xAPI.Verb.#ctor
Initializes a new instance of the  struct.
### Parameters
#### id
The verb definition. Required.
#### display
The human readable representation of the verb. Recommended.
## Float.xAPI.IVerb.Id
Corresponds to a Verb definition.
 Each Verb definition corresponds to the meaning of a Verb, not the word.
### Parameters

## Float.xAPI.IVerb.Display
The human readable representation of the Verb in one or more languages.
 This does not have any impact on the meaning of the Statement, but serves to give a human-readable display of the meaning already determined by the chosen Verb.
### Parameters

## Float.xAPI.IVerb
The Verb defines the action between an Actor and an Activity.
### Parameters

## Float.xAPI.Version.Patch
No summary.
### Parameters

## Float.xAPI.Version.Minor
No summary.
### Parameters

## Float.xAPI.Version.Major
No summary.
### Parameters

## Float.xAPI.Version.ToString
No summary.
### Parameters

## Float.xAPI.Version.GetHashCode
No summary.
### Parameters

## Float.xAPI.Version.Equals
No summary.
### Parameters

## Float.xAPI.Version.#ctor
Initializes a new instance of the  struct.
### Parameters
#### major
The major version.
#### minor
The minor version.
#### patch
The patch version.
## Float.xAPI.IVersion.Patch
Patch version Z (x.y.Z | x > 0) MUST be incremented if only backwards compatible bug fixes are introduced.
### Parameters

## Float.xAPI.IVersion.Minor
Minor version Y (x.Y.z | x > 0) MUST be incremented if new, backwards compatible functionality is introduced to the public API.
 It MAY be incremented if substantial new functionality or improvements are introduced within the private code
### Parameters

## Float.xAPI.IVersion.Major
Major version X (X.y.z | X > 0) MUST be incremented if any backwards incompatible changes are introduced to the public API.
### Parameters

## Float.xAPI.IVersion
Storage for version information.
 See: https://semver.org/spec/v1.0.0.html
### Parameters

## Float.xAPI.Score.Scaled
No summary.
### Parameters

## Float.xAPI.Score.Max
No summary.
### Parameters

## Float.xAPI.Score.Min
No summary.
### Parameters

## Float.xAPI.Score.Raw
No summary.
### Parameters

## Float.xAPI.Score.GetHashCode
No summary.
### Parameters

## Float.xAPI.Score.Equals
No summary.
### Parameters

## Float.xAPI.Score.#ctor
Initializes a new instance of the  struct.
 This constructor will compute the scaled value from the given parameters.
### Parameters
#### raw
The score achieved by the Actor in the experience described by the Statement.
#### min
The lowest possible score for the experience described by the Statement.
#### max
The highest possible score for the experience described by the Statement.
## Float.xAPI.Score.#ctor
Initializes a new instance of the  struct.
 This constructor will only set the scaled value.
### Parameters
#### scaled
The score related to the experience as modified by scaling and/or normalization.
## Float.xAPI.IScore.Scaled
The score related to the experience as modified by scaling and/or normalization.
### Parameters

## Float.xAPI.IScore.Raw
The score achieved by the Actor in the experience described by the Statement.
 This is not modified by any scaling or normalization.
### Parameters

## Float.xAPI.IScore.Min
The lowest possible score for the experience described by the Statement.
### Parameters

## Float.xAPI.IScore.Max
The highest possible score for the experience described by the Statement.
### Parameters

## Float.xAPI.IScore
Represents the outcome of a graded Activity achieved by an Agent.
### Parameters

## Float.xAPI.Result.Extensions
No summary.
### Parameters

## Float.xAPI.Result.Duration
No summary.
### Parameters

## Float.xAPI.Result.Response
No summary.
### Parameters

## Float.xAPI.Result.Completion
No summary.
### Parameters

## Float.xAPI.Result.Success
No summary.
### Parameters

## Float.xAPI.Result.Score
No summary.
### Parameters

## Float.xAPI.Result.#ctor
Initializes a new instance of the  struct.
### Parameters
#### score
The score of the Agent in relation to the success or quality of the experience.
#### success
Indicates whether or not the attempt on the Activity was successful.
#### completion
Indicates whether or not the Activity was completed.
#### response
A response appropriately formatted for the given Activity.
#### duration
Period of time over which the Statement occurred.
#### extensions
A map of other properties as needed.
## Float.xAPI.IResult.Success
Indicates whether or not the attempt on the Activity was successful.
### Parameters

## Float.xAPI.IResult.Score
The score of the Agent in relation to the success or quality of the experience.
### Parameters

## Float.xAPI.IResult.Response
A response appropriately formatted for the given Activity.
### Parameters

## Float.xAPI.IResult.Extensions
A map of other properties as needed.
### Parameters

## Float.xAPI.IResult.Duration
Period of time over which the Statement occurred.
### Parameters

## Float.xAPI.IResult.Completion
Indicates whether or not the Activity was completed.
### Parameters

## Float.xAPI.IResult
Represents a measured outcome related to the Statement in which it is included.
### Parameters

## Float.xAPI.StatementReference.Id
No summary.
### Parameters

## Float.xAPI.StatementReference.ObjectType
No summary.
### Parameters

## Float.xAPI.StatementReference.GetHashCode
No summary.
### Parameters

## Float.xAPI.StatementReference.Equals
No summary.
### Parameters

## Float.xAPI.StatementReference.#ctor
Initializes a new instance of the  struct.
### Parameters
#### id
The UUID of a Statement. Required.
## Float.xAPI.IStatementReference.Id
The UUID of a Statement.
### Parameters

## Float.xAPI.IStatementReference
A Statement Reference is a pointer to another pre-existing Statement.
### Parameters

## Float.xAPI.IContext.Team
Team that this Statement relates to, if not included as the Actor of the Statement.
### Parameters

## Float.xAPI.IContext.Statement
Another Statement to be considered as context for this Statement.
### Parameters

## Float.xAPI.IContext.Revision
Revision of the learning activity associated with this Statement. Format is free.
### Parameters

## Float.xAPI.IContext.Registration
The registration that the Statement is associated with.
### Parameters

## Float.xAPI.IContext.Platform
Platform used in the experience of this learning activity.
### Parameters

## Float.xAPI.IContext.Language
Code representing the language in which the experience being recorded in this Statement (mainly) occurred in, if applicable and known.
### Parameters

## Float.xAPI.IContext.Instructor
Instructor that the Statement relates to, if not included as the Actor of the Statement.
### Parameters

## Float.xAPI.IContext.Extensions
A map of any other domain-specific context relevant to this Statement.
### Parameters

## Float.xAPI.IContext.ContextActivities
A map of the types of learning activity context that this Statement is related to.
### Parameters

## Float.xAPI.IContext
An optional property that provides a place to add contextual information to a Statement.
### Parameters

## Float.xAPI.Context.Extensions
No summary.
### Parameters

## Float.xAPI.Context.Statement
No summary.
### Parameters

## Float.xAPI.Context.Language
No summary.
### Parameters

## Float.xAPI.Context.Platform
No summary.
### Parameters

## Float.xAPI.Context.Revision
No summary.
### Parameters

## Float.xAPI.Context.ContextActivities
No summary.
### Parameters

## Float.xAPI.Context.Team
No summary.
### Parameters

## Float.xAPI.Context.Instructor
No summary.
### Parameters

## Float.xAPI.Context.Registration
No summary.
### Parameters

## Float.xAPI.Context.#ctor
Initializes a new instance of the  struct.
### Parameters
#### registration
The registration that the Statement is associated with.
#### instructor
Instructor that the Statement relates to, if not included as the Actor of the Statement.
#### team
Team that this Statement relates to, if not included as the Actor of the Statement.
#### contextActivities
A map of the types of learning activity context that this Statement is related to.
#### revision
Revision of the learning activity associated with this Statement. Format is free.
#### platform
Platform used in the experience of this learning activity.
#### language
Code representing the language in which the experience being recorded in this Statement (mainly) occurred in, if applicable and known.
#### statement
Another Statement to be considered as context for this Statement.
#### extensions
A map of any other domain-specific context relevant to this Statement.
## Float.xAPI.Attachment.FileUrl
No summary.
### Parameters

## Float.xAPI.Attachment.Sha2
No summary.
### Parameters

## Float.xAPI.Attachment.Length
No summary.
### Parameters

## Float.xAPI.Attachment.ContentType
No summary.
### Parameters

## Float.xAPI.Attachment.Description
No summary.
### Parameters

## Float.xAPI.Attachment.Display
No summary.
### Parameters

## Float.xAPI.Attachment.UsageType
No summary.
### Parameters

## Float.xAPI.Attachment.#ctor
Initializes a new instance of the  struct.
### Parameters
#### usageType
Identifies the usage of this Attachment.
#### display
Display name of this Attachment.
#### contentType
The content type of the Attachment.
#### length
The length of the Attachment data in octets.
#### sha
The SHA-2 hash of the Attachment data.
#### description
A description of the Attachment.
#### fileUrl
An IRL at which the Attachment data can be retrieved, or from which it used to be retrievable.
## Float.xAPI.IAttachment.UsageType
Identifies the usage of this Attachment.
 For example: one expected use case for Attachments is to include a "completion certificate".
 An IRI corresponding to this usage MUST be coined, and used with completion certificate attachments.
### Parameters

## Float.xAPI.IAttachment.Sha2
The SHA-2 hash of the Attachment data.
### Parameters

## Float.xAPI.IAttachment.Length
The length of the Attachment data in octets.
### Parameters

## Float.xAPI.IAttachment.FileUrl
An IRL at which the Attachment data can be retrieved, or from which it used to be retrievable.
### Parameters

## Float.xAPI.IAttachment.Display
Display name (title) of this Attachment.
### Parameters

## Float.xAPI.IAttachment.Description
A description of the Attachment.
### Parameters

## Float.xAPI.IAttachment.ContentType
The content type of the Attachment.
### Parameters

## Float.xAPI.IAttachment
In some cases an Attachment is logically an important part of a Learning Record.
 It could be an essay, a video, etc.
 Another example of such an Attachment is (the image of) a certificate that was granted as a result of an experience.
 It is useful to have a way to store these Attachments in and retrieve them from an LRS.
### Parameters

## Float.xAPI.IGenericStatement.Verb
Action taken by the Actor.
### Parameters

## Float.xAPI.IGenericStatement.Timestamp
Timestamp of when the events described within this Statement occurred.
### Parameters

## Float.xAPI.IGenericStatement.Result
Result Object, further details representing a measured outcome.
### Parameters

## Float.xAPI.IGenericStatement.Object
Activity, Agent, or another Statement that is the Object of the Statement.
### Parameters

## Float.xAPI.IGenericStatement.Context
Context that gives the Statement more meaning.
### Parameters

## Float.xAPI.IGenericStatement.Actor
Whom the Statement is about, as an Agent or Group Object.
### Parameters

## Float.xAPI.IGenericStatement
Both substatements and statements implement this base interface.
### Parameters

## Float.xAPI.SubStatement.Timestamp
No summary.
### Parameters

## Float.xAPI.SubStatement.Context
No summary.
### Parameters

## Float.xAPI.SubStatement.Result
No summary.
### Parameters

## Float.xAPI.SubStatement.Object
No summary.
### Parameters

## Float.xAPI.SubStatement.Verb
No summary.
### Parameters

## Float.xAPI.SubStatement.Actor
No summary.
### Parameters

## Float.xAPI.SubStatement.ObjectType
No summary.
### Parameters

## Float.xAPI.SubStatement.#ctor
Initializes a new instance of the  struct.
### Parameters
#### actor
Whom the Statement is about, as an Agent or Group Object.
#### verb
Action taken by the Actor.
#### object
Activity, Agent, or another Statement that is the Object of the Statement.
#### result
Result Object, further details representing a measured outcome.
#### context
Context that gives the Statement more meaning.
#### timestamp
Timestamp of when the events described within this Statement occurred.
## Float.xAPI.SubStatement
A substatement is a statement without an ID.
### Parameters

## Float.xAPI.ISubStatement
A SubStatement is like a StatementRef in that it is included as part of a containing Statement, but unlike a StatementRef, it does not represent an event that has occurred.
 It can be used to describe, for example, a predication of a potential future Statement or the behavior a teacher looked for when evaluating a student (without representing the student actually doing that behavior).
### Parameters

## Float.xAPI.Statement.Attachments
No summary.
### Parameters

## Float.xAPI.Statement.Version
No summary.
### Parameters

## Float.xAPI.Statement.Authority
No summary.
### Parameters

## Float.xAPI.Statement.Stored
No summary.
### Parameters

## Float.xAPI.Statement.Timestamp
No summary.
### Parameters

## Float.xAPI.Statement.Context
No summary.
### Parameters

## Float.xAPI.Statement.Result
No summary.
### Parameters

## Float.xAPI.Statement.Object
No summary.
### Parameters

## Float.xAPI.Statement.Verb
No summary.
### Parameters

## Float.xAPI.Statement.Actor
No summary.
### Parameters

## Float.xAPI.Statement.Id
No summary.
### Parameters

## Float.xAPI.Statement.GetHashCode
No summary.
### Parameters

## Float.xAPI.Statement.Equals
No summary.
### Parameters

## Float.xAPI.Statement.#ctor
Initializes a new instance of the  struct.
### Parameters
#### actor
Whom the Statement is about, as an Agent or Group Object.
#### verb
Action taken by the Actor.
#### object
Activity, Agent, or another Statement that is the Object of the Statement.
#### id
UUID assigned by LRS if not set by the Learning Record Provider.
#### result
Result Object, further details representing a measured outcome.
#### context
Context that gives the Statement more meaning.
#### timestamp
Timestamp of when the events described within this Statement occurred.
#### stored
Timestamp of when this Statement was recorded. Set by LRS.
#### authority
Agent or Group who is asserting this Statement is true.
#### version
The Statement’s associated xAPI version.
#### attachments
Attachments to this statement.
## Float.xAPI.IStatement.Version
The Statement’s associated xAPI version, formatted according to Semantic Versioning 1.0.0.
### Parameters

## Float.xAPI.IStatement.Stored
Timestamp of when this Statement was recorded. Set by LRS.
### Parameters

## Float.xAPI.IStatement.Id
UUID assigned by LRS if not set by the Learning Record Provider.
### Parameters

## Float.xAPI.IStatement.Authority
Agent or Group who is asserting this Statement is true.
 Verified by the LRS based on authentication.
 Set by LRS if not provided or if a strong trust relationship between the Learning Record Provider and LRS has not been established.
### Parameters

## Float.xAPI.IStatement.Attachments
Attachments to this statement.
### Parameters

## Float.xAPI.IStatement
Statements are the evidence for any sort of experience or event which is to be tracked in xAPI.
 While Statements follow a machine readable JSON format, they can also easily be described using natural language.
 This can be extremely useful for the design process.
 Statements are meant to be aggregated and analyzed to provide larger meaning for the overall experience than just the sum of its parts.
### Parameters

## Float.xAPI.InMemoryLRS.PutStatement
No summary.
### Parameters

## Float.xAPI.InMemoryLRS.PostStatements
No summary.
### Parameters

## Float.xAPI.InMemoryLRS.GetVoidedStatement
No summary.
### Parameters

## Float.xAPI.InMemoryLRS.GetStatements
No summary.
### Parameters

## Float.xAPI.InMemoryLRS.GetStatement
No summary.
### Parameters

## Float.xAPI.InMemoryLRS.#ctor
Initializes a new instance of the  object.
### Parameters

## Float.xAPI.InMemoryLRS
The "in memory" LRS only stores provided objects for the duration of this instance.
### Parameters

## Float.xAPI.Languages.Language.ToString
No summary.
### Parameters

## Float.xAPI.Languages.Language.FromString
Convert a string to a Language object.
### Parameters

## Float.xAPI.Languages.Language
ISO 639-1 Language Codes
 see: https://www.loc.gov/standards/iso639-2/php/English_list.php
 This type was auto-generated; please report issues at https://github.com/gowithfloat/xapi/issues
### Parameters

## Float.xAPI.Languages.ExtendedLanguage.ToString
No summary.
### Parameters

## Float.xAPI.Languages.ExtendedLanguage.FromString
Convert a string to an ExtendedLanguageTag object.
### Parameters

## Float.xAPI.Languages.ExtendedLanguage
Extended language subtags specify a dialect within a language.
 see: https://www.iana.org/assignments/language-subtag-registry/language-subtag-registry
### Parameters

## Float.xAPI.Languages.Region.ToString
No summary.
### Parameters

## Float.xAPI.Languages.Region.FromString
Convert a string to a Region object.
### Parameters

## Float.xAPI.Languages.Region
ISO 3166-1 region codes.
 see: https://www.iso.org/obp/ui/#search/code/
 also: http://www.fedex.com/cg/tracking/codes.html
 This type was auto-generated; please report issues at https://github.com/gowithfloat/xapi/issues
### Parameters

## Float.xAPI.Languages.LanguageTag.Region
No summary.
### Parameters

## Float.xAPI.Languages.LanguageTag.ExtendedLanguage
No summary.
### Parameters

## Float.xAPI.Languages.LanguageTag.PrimaryLanguage
No summary.
### Parameters

## Float.xAPI.Languages.LanguageTag.EnglishUS
As United States English is the most common language tag in examples, it is provided here for convenience.
### Parameters

## Float.xAPI.Languages.LanguageTag.ToString
No summary.
### Parameters

## Float.xAPI.Languages.LanguageTag.ToCultureInfo
No summary.
### Parameters

## Float.xAPI.Languages.LanguageTag.GetHashCode
No summary.
### Parameters

## Float.xAPI.Languages.LanguageTag.Equals
No summary.
### Parameters

## Float.xAPI.Languages.LanguageTag.#ctor
Initializes a new instance of the  struct.
### Parameters
#### primary
The primary language associated with this tag.
#### region
The region associated with this tag.
#### extended
An optional extended language to disambiguate dialects.
## Float.xAPI.Languages.ILanguageTag.Region
Region subtags are used to indicate linguistic variations associated with or appropriate to a specific country, territory, or region.
 Typically, a region subtag is used to indicate variations such as regional dialects or usage, or region-specific spelling conventions.
 It can also be used to indicate that content is expressed in a way that is appropriate for use throughout a region, for instance, Spanish content tailored to be useful throughout Latin America.
### Parameters

## Float.xAPI.Languages.ILanguageTag.PrimaryLanguage
The primary language subtag is the first subtag in a language tag and cannot be omitted.
### Parameters

## Float.xAPI.Languages.ILanguageTag.ExtendedLanguage
Extended language subtags are used to identify certain specially selected languages that, for various historical and compatibility reasons, are closely identified with or tagged using an existing primary language subtag.
 Extended language subtags are always used with their enclosing primary language subtag (indicated with a 'Prefix' field in the registry) when used to form the language tag.
 All languages that have an extended language subtag in the registry also have an identical primary language subtag record in the registry.
### Parameters

## Float.xAPI.Languages.ILanguageTag.ToCultureInfo
Convert this language tag to a system culture info object.
### Parameters

## Float.xAPI.Languages.ILanguageTag
A language tag is composed from a sequence of one or more "subtags", each of which refines or narrows the range of language identified by the overall tag.
 Subtags, in turn, are a sequence of alphanumeric characters (letters and digits), distinguished and separated from other subtags in a tag by a hyphen ("-", [Unicode] U+002D).
 see: https://tools.ietf.org/html/rfc5646
### Parameters

## Float.xAPI.Languages.LanguageMap.map
Internal storage of key/value pairs.
 Language maps could be a type abbreviation instead, but that prevents us from creating constructors or adding members.
### Parameters

## Float.xAPI.Languages.LanguageMap.GetHashCode
No summary.
### Parameters

## Float.xAPI.Languages.LanguageMap.Equals
No summary.
### Parameters

## Float.xAPI.Languages.LanguageMap.#ctor
Initializes a new instance of the  struct with one language, region, and value.
### Parameters
#### language
The language for the given value. Will be used to construct a LanguageTag object.
#### region
The region for the given value. Will be used to construct a LanguageTag object.
#### value
The value for the given tag.
## Float.xAPI.Languages.LanguageMap.#ctor
Initializes a new instance of the  struct with one tag/value pair.
### Parameters
#### languageTag
The language tag for the given value.
#### value
The value for the given tag.
## Float.xAPI.Languages.LanguageMap.#ctor
Initializes a new instance of the  struct with a readonly dictionary of tag/value pairs.
### Parameters
#### dict
The dictionary from which to construct this map.
## Float.xAPI.Languages.LanguageMap.#ctor
Initializes a new instance of the  struct with an enumerable of tag/value pairs.
### Parameters
#### dict
The dictionary from which to construct this map.
## Float.xAPI.Languages.LanguageMap.#ctor
Initializes a new instance of the  struct with an enumerable of tag/value tuples.
### Parameters
#### tuples
The language tag and value tuples.
## Float.xAPI.Languages.LanguageMap.#ctor
Initializes a new instance of the  struct with a map of tag/value pairs.
### Parameters
#### pairs
The language tag and value pairs.
## Float.xAPI.Languages.LanguageTuple
Another way of representing a tag and value as a tuple.
### Parameters

## Float.xAPI.Languages.LanguagePair
A shorthand type for one element of a language map.
### Parameters

## Float.xAPI.Languages.ILanguageMap
A language map is a dictionary where the key is a RFC 5646 Language Tag, and the value is a string in the language specified in the tag.
 This map SHOULD be populated as fully as possible based on the knowledge of the string in question in different languages.
### Parameters

## Float.xAPI.Actor.IActor.Name
Name of the actor.
### Parameters

## Float.xAPI.Actor.IActor
The Actor defines who performed the action. The Actor of a Statement can be an Agent or a Group.
### Parameters

## Float.xAPI.Actor.IIdentifiedActor.IFI
An Inverse Functional Identifier unique to the Agent.
### Parameters

## Float.xAPI.Actor.IIdentifiedActor
Agents and identified groups have unique identifiers and can be checked for equality.
### Parameters

## Float.xAPI.Actor.Agent.IFI
No summary.
### Parameters

## Float.xAPI.Actor.Agent.Name
No summary.
### Parameters

## Float.xAPI.Actor.Agent.ObjectType
No summary.
### Parameters

## Float.xAPI.Actor.Agent.GetHashCode
No summary.
### Parameters

## Float.xAPI.Actor.Agent.Equals
No summary.
### Parameters

## Float.xAPI.Actor.Agent.#ctor
Initializes a new instance of the  class.
### Parameters
#### ifi
An Inverse Functional Identifier unique to the Agent. Required.
#### display
Name of the Agent. Optional.
## Float.xAPI.Actor.IAgent
An Agent (an individual) is a persona or system.
### Parameters

## Float.xAPI.Actor.IGroup.Member
The members of this Group.
### Parameters

## Float.xAPI.Actor.IGroup
A Group represents a collection of Agents and can be used in most of the same situations an Agent can be used.
 There are two types of Groups: Anonymous Groups and Identified Groups.
### Parameters

## Float.xAPI.Actor.AnonymousGroup.Member
No summary.
### Parameters

## Float.xAPI.Actor.AnonymousGroup.Name
No summary.
### Parameters

## Float.xAPI.Actor.AnonymousGroup.ObjectType
No summary.
### Parameters

## Float.xAPI.Actor.AnonymousGroup.#ctor
Initializes a new instance of the  class.
### Parameters
#### members
The members of this Group. Required.
#### display
Name of the Group. Optional.
## Float.xAPI.Actor.IAnonymousGroup
An Anonymous Group is used to describe a cluster of people where there is no ready identifier for this cluster, e.g. an ad hoc team.
### Parameters

## Float.xAPI.Actor.IdentifiedGroup.IFI
No summary.
### Parameters

## Float.xAPI.Actor.IdentifiedGroup.Member
No summary.
### Parameters

## Float.xAPI.Actor.IdentifiedGroup.Name
No summary.
### Parameters

## Float.xAPI.Actor.IdentifiedGroup.ObjectType
No summary.
### Parameters

## Float.xAPI.Actor.IdentifiedGroup.GetHashCode
No summary.
### Parameters

## Float.xAPI.Actor.IdentifiedGroup.Equals
No summary.
### Parameters

## Float.xAPI.Actor.IdentifiedGroup.#ctor
Initializes a new instance of the  class.
### Parameters
#### ifi
An Inverse Functional Identifier unique to the Group. Required.
#### members
The members of this Group. Optional.
#### display
Name of the Group. Optional.
## Float.xAPI.Actor.IIdentifiedGroup
An Identified Group is used to uniquely identify a cluster of Agents.
### Parameters

## Float.xAPI.Actor.Identifier.IInverseFunctionalIdentifier
An Inverse Functional Identifier (IFI) is a value of an Agent or Identified Group that is guaranteed to only ever refer to that Agent or Identified Group.
### Parameters

## Float.xAPI.Actor.Identifier.Mailbox.Address
No summary.
### Parameters

## Float.xAPI.Actor.Identifier.Mailbox.ToString
No summary.
### Parameters

## Float.xAPI.Actor.Identifier.Mailbox.GetHashCode
No summary.
### Parameters

## Float.xAPI.Actor.Identifier.Mailbox.Equals
No summary.
### Parameters

## Float.xAPI.Actor.Identifier.Mailbox.#ctor
Initializes a new instance of the  class.
### Parameters
#### address
The address associated with this mailbox.
## Float.xAPI.Actor.Identifier.IMailbox.Address
Only email addresses that have only ever been and will ever be assigned to this Agent, but no others, SHOULD be used for this property and mbox_sha1sum.
### Parameters

## Float.xAPI.Actor.Identifier.IMailbox
A personal mailbox, ie. an Internet mailbox associated with exactly one owner, the first owner of this mailbox.
 This is a 'static inverse functional property', in that there is (across time and change) at most one individual that ever has any particular value for foaf:mbox.
### Parameters

## Float.xAPI.Actor.Identifier.MailboxSha1Sum.MboxSha1Sum
No summary.
### Parameters

## Float.xAPI.Actor.Identifier.MailboxSha1Sum.ToString
No summary.
### Parameters

## Float.xAPI.Actor.Identifier.MailboxSha1Sum.GetHashCode
No summary.
### Parameters

## Float.xAPI.Actor.Identifier.MailboxSha1Sum.Equals
No summary.
### Parameters

## Float.xAPI.Actor.Identifier.MailboxSha1Sum.#ctor
Initializes a new instance of the  struct.
### Parameters
#### mboxSha1Sum
The hex-encoded SHA1 hash of a mailto IRI.
## Float.xAPI.Actor.Identifier.IMailboxSha1Sum.MboxSha1Sum
The hex-encoded SHA1 hash of a mailto IRI (i.e. the value of an mbox property).
 An LRS MAY include Agents with a matching hash when a request is based on an mbox.
### Parameters

## Float.xAPI.Actor.Identifier.IMailboxSha1Sum
The sha1sum of the URI of an Internet mailbox associated with exactly one owner, the first owner of the mailbox.
### Parameters

## Float.xAPI.Actor.Identifier.OpenID.OpenID
No summary.
### Parameters

## Float.xAPI.Actor.Identifier.OpenID.GetHashCode
No summary.
### Parameters

## Float.xAPI.Actor.Identifier.OpenID.Equals
No summary.
### Parameters

## Float.xAPI.Actor.Identifier.OpenID.#ctor
Initializes a new instance of the  class.
### Parameters
#### openID
An openID that uniquely identifies the Agent.
## Float.xAPI.Actor.Identifier.IOpenID.OpenID
An openID that uniquely identifies the Agent.
### Parameters

## Float.xAPI.Actor.Identifier.IOpenID
An openID that uniquely identifies the Agent.
### Parameters

## Float.xAPI.Actor.Identifier.Account.HomePage
No summary.
### Parameters

## Float.xAPI.Actor.Identifier.Account.Name
No summary.
### Parameters

## Float.xAPI.Actor.Identifier.Account.GetHashCode
No summary.
### Parameters

## Float.xAPI.Actor.Identifier.Account.Equals
No summary.
### Parameters

## Float.xAPI.Actor.Identifier.Account.#ctor
Initializes a new instance of the  class.
### Parameters
#### name
The unique id or name used to log in to this account.
#### homePage
The canonical home page for the system the account is on.
## Float.xAPI.Actor.Identifier.IAccount.Name
The unique id or name used to log in to this account.
 This is based on FOAF's accountName.
### Parameters

## Float.xAPI.Actor.Identifier.IAccount.HomePage
The canonical home page for the system the account is on.
 This is based on FOAF's accountServiceHomePage.
### Parameters

## Float.xAPI.Actor.Identifier.IAccount
A user account on an existing system, such as a private system (LMS or intranet) or a public system (social networking site).
### Parameters

## Float.xAPI.Activities.Interaction.Other
Another type of interaction that does not fit into those defined above.
### Parameters

## Float.xAPI.Activities.Interaction.Numeric
Any interaction which requires a numeric response from the learner.
### Parameters

## Float.xAPI.Activities.Interaction.Likert
An interaction which asks the learner to select from a discrete set of choices on a scale.
### Parameters

## Float.xAPI.Activities.Interaction.Sequencing
An interaction where the learner is asked to order items in a set.
### Parameters

## Float.xAPI.Activities.Interaction.Performance
An interaction that requires the learner to perform a task that requires multiple steps.
### Parameters

## Float.xAPI.Activities.Interaction.Matching
An interaction where the learner is asked to match items in one set (the source set) to items in another set (the target set).
 Items do not have to pair off exactly and it is possible for multiple or zero source items to be matched to a given target and vice versa.
### Parameters

## Float.xAPI.Activities.Interaction.LongFillIn
An interaction which requires the learner to supply a response in the form of a long string of characters.
 "Long" means that the correct responses pattern and learner response strings will normally be more than 250 characters.
### Parameters

## Float.xAPI.Activities.Interaction.FillIn
An interaction which requires the learner to supply a short response in the form of one or more strings of characters.
 Typically, the correct response consists of part of a word, one word or a few words.
 "Short" means that the correct responses pattern and learner response strings will normally be 250 characters or less.
### Parameters

## Float.xAPI.Activities.Interaction.Choice
An interaction with a number of possible choices from which the learner can select.
 This includes interactions in which the learner can select only one answer from the list and those where the learner can select multiple items.
### Parameters

## Float.xAPI.Activities.Interaction.TrueFalse
An interaction with two possible responses: true or false.
### Parameters

## Float.xAPI.Activities.Interaction
These types of interactions were originally based on the types of interactions allowed for "cmi.interactions.n.type" in the SCORM 2004 4th Edition Run-Time Environment.
### Parameters

## Float.xAPI.Activities.Activity.Definition
No summary.
### Parameters

## Float.xAPI.Activities.Activity.Id
No summary.
### Parameters

## Float.xAPI.Activities.Activity.ObjectType
No summary.
### Parameters

## Float.xAPI.Activities.Activity.GetHashCode
No summary.
### Parameters

## Float.xAPI.Activities.Activity.Equals
No summary.
### Parameters

## Float.xAPI.Activities.Activity.#ctor
Initializes a new instance of the  struct.
### Parameters
#### id
An identifier for a single unique Activity.
#### definition
Metadata related to the activity.
## Float.xAPI.Activities.IActivity.Id
An identifier for a single unique Activity.
### Parameters

## Float.xAPI.Activities.IActivity.Definition
Metadata related to this activity.
### Parameters

## Float.xAPI.Activities.IActivity
A Statement can represent an Activity as the Object of the Statement.
### Parameters

## Float.xAPI.Activities.ContextActivities.Other
No summary.
### Parameters

## Float.xAPI.Activities.ContextActivities.Category
No summary.
### Parameters

## Float.xAPI.Activities.ContextActivities.Grouping
No summary.
### Parameters

## Float.xAPI.Activities.ContextActivities.Parent
No summary.
### Parameters

## Float.xAPI.Activities.ContextActivities.#ctor
Initializes a new instance of the  struct.
### Parameters
#### parent
An Activity with a direct relation to the Activity which is the Object of the Statement.
#### grouping
An Activity with an indirect relation to the Activity which is the Object of the Statement.
#### category
An Activity used to categorize the Statement.
#### other
A contextActivity that doesn't fit one of the other properties.
## Float.xAPI.Activities.IContextActivities.Parent
An Activity with a direct relation to the Activity which is the Object of the Statement.
 In almost all cases there is only one sensible parent or none, not multiple.
 For example: a Statement about a quiz question would have the quiz as its parent Activity.
### Parameters

## Float.xAPI.Activities.IContextActivities.Other
A contextActivity that doesn't fit one of the other properties.
 For example: Anna studies a textbook for a biology exam. The Statement's Activity refers to the textbook, and the exam is a contextActivity of type other.
### Parameters

## Float.xAPI.Activities.IContextActivities.Grouping
An Activity with an indirect relation to the Activity which is the Object of the Statement.
 For example: a course that is part of a qualification. The course has several classes. The course relates to a class as the parent, the qualification relates to the class as the grouping.
### Parameters

## Float.xAPI.Activities.IContextActivities.Category
An Activity used to categorize the Statement. "Tags" would be a synonym. 
 Category SHOULD be used to indicate a profile of xAPI behaviors, as well as other categorizations.
 For example: Anna attempts a biology exam, and the Statement is tracked using the cmi5 profile. The Statement's Activity refers to the exam, and the category is the cmi5 profile.
### Parameters

## Float.xAPI.Activities.IContextActivities
A map of the types of learning activity context that this Statement is related to.
### Parameters

## Float.xAPI.Activities.Definitions.ICharacterStringNumeric.Min
The minimum acceptable response value.
### Parameters

## Float.xAPI.Activities.Definitions.ICharacterStringNumeric.Max
The maximum acceptable response value.
### Parameters

## Float.xAPI.Activities.Definitions.ICharacterStringNumeric
A numeric character string is used for numeric activity definitions.
### Parameters

## Float.xAPI.Activities.Definitions.ICharacterStringPair.Items
Characterstring parameters are not validated by the LRS.
 Systems interpreting Statement data can use their best judgement in interpreting (or ignoring) invalid characterstring parameters and values.
### Parameters

## Float.xAPI.Activities.Definitions.ICharacterStringPair
A character string pair is used for matching or performance activity definitions.
### Parameters

## Float.xAPI.Activities.Definitions.ICharacterStringSingle.Items
Characterstring parameters are not validated by the LRS.
 Systems interpreting Statement data can use their best judgement in interpreting (or ignoring) invalid characterstring parameters and values.
### Parameters

## Float.xAPI.Activities.Definitions.ICharacterStringSingle
A "single" character string is used for matching or performance activity definitions.
### Parameters

## Float.xAPI.Activities.Definitions.ICharacterStringMatchResponses.Match
Returns true if all of the given responses are correct for this character string.
### Parameters

## Float.xAPI.Activities.Definitions.ICharacterStringMatchResponses
A character string that can match a dictionary of responses.
### Parameters

## Float.xAPI.Activities.Definitions.ICharacterStringMatchResponse.Match
Returns a value for a response, or None if not found.
### Parameters

## Float.xAPI.Activities.Definitions.ICharacterStringMatchResponse
A character string that can look up a response for a given input.
### Parameters

## Float.xAPI.Activities.Definitions.ICharacterStringMatchNumber.Match
Returns true if the given number is within the bounds of this numeric character string.
### Parameters

## Float.xAPI.Activities.Definitions.ICharacterStringMatchNumber
A character string that can match a number.
### Parameters

## Float.xAPI.Activities.Definitions.ICharacterStringMatchSequence.Match
Returns true if the given strings match this character string.
### Parameters

## Float.xAPI.Activities.Definitions.ICharacterStringMatchSequence
A character string that can match a sequence of strings.
### Parameters

## Float.xAPI.Activities.Definitions.ICharacterStringMatchString.Match
Returns true if the given string matches this character string.
### Parameters

## Float.xAPI.Activities.Definitions.ICharacterStringMatchString
A character string that can match a string.
### Parameters

## Float.xAPI.Activities.Definitions.ICharacterStringLanguage.Language
The language used within the item.
### Parameters

## Float.xAPI.Activities.Definitions.ICharacterStringLanguage
A character string with a language property.
### Parameters

## Float.xAPI.Activities.Definitions.ICharacterString
Some of the values within the responses described in the xAPI specification can be prepended with certain additional parameters.
 These were originally based on the characterstring delimiters defined in the SCORM 2004 4th Edition Run-Time Environment.
### Parameters

## Float.xAPI.Activities.Definitions.CharacterString.Language
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.CharacterString.Items
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.CharacterString.ToString
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.CharacterString.Match
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.CharacterString.Match
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.CharacterString.#ctor
Initializes a new instance of the  struct.
### Parameters
#### item
A single string item.
#### language
The language used within the item.
## Float.xAPI.Activities.Definitions.CharacterString.#ctor
Initializes a new instance of the  struct.
### Parameters
#### items
A list of string items.
#### language
The language used within the item.
## Float.xAPI.Activities.Definitions.CharacterString
The basic character string is a list of item identifiers.
 This is used for true-false, choice, fill-in, long-fill-in, sequencing, likert, and "other" interaction types.
### Parameters

## Float.xAPI.Activities.Definitions.CharacterStringPair.Language
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.CharacterStringPair.Items
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.CharacterStringPair.ToString
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.CharacterStringPair.Match
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.CharacterStringPair.Match
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.CharacterStringPair.Match
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.CharacterStringPair.#ctor
Initializes a new instance of the  struct.
### Parameters
#### itemPairs
A sequence of string item and response pairs.
#### language
The language used within the item.
## Float.xAPI.Activities.Definitions.CharacterStringPair.#ctor
Initializes a new instance of the  struct.
### Parameters
#### itemSeq
A sequence of string item and response tuples.
#### language
The language used within the item.
## Float.xAPI.Activities.Definitions.CharacterStringPair
A list of matching pairs.
 For matching interaction types, each pair consists of a source item ID followed by a target item ID.
 For performance interaction types, this is a list of steps containing a step ID and the response to that step.
### Parameters

## Float.xAPI.Activities.Definitions.CharacterStringNumeric.Max
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.CharacterStringNumeric.Min
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.CharacterStringNumeric.ToString
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.CharacterStringNumeric.Match
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.CharacterStringNumeric.#ctor
Initializes a new instance of the  struct.
 Use this for numeric interactions.
### Parameters
#### min
The minimum acceptable response value.
#### max
The maximum acceptable response value.
## Float.xAPI.Activities.Definitions.CharacterStringNumeric
A range of numbers represented by a minimum and maximum.
 Where the range does not have a minimum or maximum, that number is omitted.
### Parameters

## Float.xAPI.Activities.Definitions.ResponsePattern.OrderMatters
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.ResponsePattern.CaseMatters
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.ResponsePattern.CharacterStrings
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.ResponsePattern.ToString
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.ResponsePattern.Match
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.ResponsePattern.Match
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.ResponsePattern.#ctor
Initializes a new instance of the  struct.
 Use this to create a simple true/false character string.
### Parameters
#### characterString
A single correct response.
#### caseMatters
Whether or not the case of items in the list matters.
#### orderMatters
Whether or not the order of items in the list matters.
## Float.xAPI.Activities.Definitions.ResponsePattern.#ctor
Initializes a new instance of the  struct.
### Parameters
#### characterStrings
An exhaustive list of possible correct responses.
#### caseMatters
Whether or not the case of items in the list matters.
#### orderMatters
Whether or not the order of items in the list matters.
## Float.xAPI.Activities.Definitions.ResponsePattern.#ctor
Initializes a new instance of the  struct.
 Use this to create a response pattern with a single character string item.
### Parameters
#### item
A single character string item.
#### caseMatters
Whether or not the case of items in the list matters.
#### orderMatters
Whether or not the order of items in the list matters.
## Float.xAPI.Activities.Definitions.ResponsePattern.#ctor
Initializes a new instance of the  struct.
 Use this to create a simple true/false character string.
### Parameters
#### correct
The correct response.
## Float.xAPI.Activities.Definitions.IResponsePattern.OrderMatters
Whether or not the order of items in the list matters.
### Parameters

## Float.xAPI.Activities.Definitions.IResponsePattern.CharacterStrings
An exhaustive list of possible correct responses.
### Parameters

## Float.xAPI.Activities.Definitions.IResponsePattern.CaseMatters
Whether or not the case of items in the list matters.
### Parameters

## Float.xAPI.Activities.Definitions.IResponsePattern.Match
Returns true if the given strings match this response pattern.
### Parameters

## Float.xAPI.Activities.Definitions.IResponsePattern.Match
Returns true if the given string matches this response pattern.
### Parameters

## Float.xAPI.Activities.Definitions.IResponsePattern
The Correct Responses Pattern contains an array of response patterns.
 A learner's response will be considered correct if it matches any of the response patterns in that array.
 Where a response pattern is a delimited list, the learner's response is only considered correct if all of the items in that list match the learner's response.
### Parameters

## Float.xAPI.Activities.Definitions.ActivityDefinition.Extensions
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.ActivityDefinition.MoreInfo
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.ActivityDefinition.Type
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.ActivityDefinition.Description
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.ActivityDefinition.Name
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.ActivityDefinition.#ctor
Initializes a new instance of the  struct.
### Parameters
#### name
The human readable/visual name of the Activity.
#### description
A description of the Activity.
#### thetype
The type of Activity.
#### moreInfo
Resolves to a document with human-readable information about the Activity.
#### extensions
A map of other properties as needed.
## Float.xAPI.Activities.Definitions.IActivityDefinition.Type
The type of Activity.
### Parameters

## Float.xAPI.Activities.Definitions.IActivityDefinition.Name
The human readable/visual name of the Activity.
### Parameters

## Float.xAPI.Activities.Definitions.IActivityDefinition.MoreInfo
Resolves to a document with human-readable information about the Activity, which could include a way to launch the activity.
### Parameters

## Float.xAPI.Activities.Definitions.IActivityDefinition.Extensions
A map of other properties as needed.
### Parameters

## Float.xAPI.Activities.Definitions.IActivityDefinition.Description
A description of the Activity.
### Parameters

## Float.xAPI.Activities.Definitions.IActivityDefinition
Metadata associated with an activity.
### Parameters

## Float.xAPI.Activities.Definitions.IInteractionActivityDefinition.InteractionType
The type of interaction.
### Parameters

## Float.xAPI.Activities.Definitions.IInteractionActivityDefinition.CorrectResponsesPattern
A pattern representing the correct response to the interaction.
 The structure of this pattern varies depending on the InteractionType.
### Parameters

## Float.xAPI.Activities.Definitions.IInteractionActivityDefinition
Traditional e-learning has included structures for interactions or assessments.
 As a way to allow these practices and structures to extend Experience API's utility, this specification includes built-in definitions for interactions, which borrows from the SCORM 2004 4th Edition Data Model.
 These definitions are intended to provide a simple and familiar utility for recording interaction data.
### Parameters

## Float.xAPI.Activities.Definitions.InteractionComponent.Description
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.InteractionComponent.Id
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.InteractionComponent.GetHashCode
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.InteractionComponent.Equals
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.InteractionComponent.#ctor
Initializes a new instance of the  struct.
### Parameters
#### id
Identifies the interaction component within the list.
#### description
A description of the interaction component.
## Float.xAPI.Activities.Definitions.IInteractionComponent.Id
Identifies the interaction component within the list.
### Parameters

## Float.xAPI.Activities.Definitions.IInteractionComponent.Description
A description of the interaction component (for example, the text for a given choice in a multiple-choice interaction).
### Parameters

## Float.xAPI.Activities.Definitions.IInteractionComponent
A choice within an interaction component.
### Parameters

## Float.xAPI.Activities.Definitions.TrueFalseInteractionActivityDefinition.CorrectResponsesPattern
Either true or false.
### Parameters

## Float.xAPI.Activities.Definitions.TrueFalseInteractionActivityDefinition.Extensions
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.TrueFalseInteractionActivityDefinition.MoreInfo
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.TrueFalseInteractionActivityDefinition.Description
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.TrueFalseInteractionActivityDefinition.Name
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.TrueFalseInteractionActivityDefinition.Type
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.TrueFalseInteractionActivityDefinition.InteractionType
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.TrueFalseInteractionActivityDefinition.#ctor
Initializes a new instance of the  struct.
### Parameters
#### name
The human readable/visual name of the Activity.
#### description
A description of the Activity.
#### correctAnswer
The correct answer for this interaction.
#### moreInfo
Resolves to a document with human-readable information about the Activity.
#### extensions
A map of other properties as needed.
## Float.xAPI.Activities.Definitions.TrueFalseInteractionActivityDefinition
An interaction with two possible responses: true or false.
### Parameters

## Float.xAPI.Activities.Definitions.ChoiceInteractionActivityDefinition.Choices
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.ChoiceInteractionActivityDefinition.CorrectResponsesPattern
A list of item ids delimited by [,]. If the response contains only one item, the delimiter MUST not be used.
### Parameters

## Float.xAPI.Activities.Definitions.ChoiceInteractionActivityDefinition.Extensions
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.ChoiceInteractionActivityDefinition.MoreInfo
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.ChoiceInteractionActivityDefinition.Description
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.ChoiceInteractionActivityDefinition.Name
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.ChoiceInteractionActivityDefinition.Type
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.ChoiceInteractionActivityDefinition.InteractionType
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.ChoiceInteractionActivityDefinition.#ctor
Initializes a new instance of the  struct.
### Parameters
#### name
The human readable/visual name of the Activity.
#### description
A description of the Activity.
#### correctResponsesPattern
A pattern representing the correct response to the interaction.
#### choices
A list of choices.
#### moreInfo
Resolves to a document with human-readable information about the Activity.
#### extensions
A map of other properties as needed.
## Float.xAPI.Activities.Definitions.IChoiceInteractionActivityDefinition.Choices
Choices associated with this interaction.
### Parameters

## Float.xAPI.Activities.Definitions.IChoiceInteractionActivityDefinition
An interaction with a number of possible choices from which the learner can select.
 This includes interactions in which the learner can select only one answer from the list and those where the learner can select multiple items.
### Parameters

## Float.xAPI.Activities.Definitions.FillInInteractionActivityDefinition.CorrectResponsesPattern
A list of responses delimited by [,]. If the response contains only one item, the delimiter MUST not be used.
### Parameters

## Float.xAPI.Activities.Definitions.FillInInteractionActivityDefinition.Extensions
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.FillInInteractionActivityDefinition.MoreInfo
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.FillInInteractionActivityDefinition.Description
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.FillInInteractionActivityDefinition.Name
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.FillInInteractionActivityDefinition.Type
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.FillInInteractionActivityDefinition.InteractionType
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.FillInInteractionActivityDefinition.#ctor
Initializes a new instance of the  struct.
### Parameters
#### name
The human readable/visual name of the Activity.
#### description
A description of the Activity.
#### correctResponsesPattern
A pattern representing the correct response to the interaction.
#### moreInfo
Resolves to a document with human-readable information about the Activity.
#### extensions
A map of other properties as needed.
## Float.xAPI.Activities.Definitions.FillInInteractionActivityDefinition
An interaction which requires the learner to supply a short response in the form of one or more strings of characters.
 Typically, the correct response consists of part of a word, one word or a few words.
 "Short" means that the correct responses pattern and learner response strings will normally be 250 characters or less.
### Parameters

## Float.xAPI.Activities.Definitions.LongFillInInteractionActivityDefinition.CorrectResponsesPattern
A list of responses delimited by [,]. If the response contains only one item, the delimiter MUST not be used.
### Parameters

## Float.xAPI.Activities.Definitions.LongFillInInteractionActivityDefinition.Extensions
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.LongFillInInteractionActivityDefinition.MoreInfo
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.LongFillInInteractionActivityDefinition.Description
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.LongFillInInteractionActivityDefinition.Name
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.LongFillInInteractionActivityDefinition.Type
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.LongFillInInteractionActivityDefinition.InteractionType
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.LongFillInInteractionActivityDefinition.#ctor
Initializes a new instance of the  struct.
### Parameters
#### name
The human readable/visual name of the Activity.
#### description
A description of the Activity.
#### correctResponsesPattern
A pattern representing the correct response to the interaction.
#### moreInfo
Resolves to a document with human-readable information about the Activity.
#### extensions
A map of other properties as needed.
## Float.xAPI.Activities.Definitions.LongFillInInteractionActivityDefinition
An interaction which requires the learner to supply a response in the form of a long string of characters.
 "Long" means that the correct responses pattern and learner response strings will normally be more than 250 characters.
### Parameters

## Float.xAPI.Activities.Definitions.MatchingInteractionActivityDefinition.Target
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.MatchingInteractionActivityDefinition.Source
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.MatchingInteractionActivityDefinition.CorrectResponsesPattern
A list of matching pairs, where each pair consists of a source item id followed by a target item id.
 Items can appear in multiple (or zero) pairs. Items within a pair are delimited by [.].
 Pairs are delimited by [,].
### Parameters

## Float.xAPI.Activities.Definitions.MatchingInteractionActivityDefinition.Extensions
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.MatchingInteractionActivityDefinition.MoreInfo
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.MatchingInteractionActivityDefinition.Description
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.MatchingInteractionActivityDefinition.Name
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.MatchingInteractionActivityDefinition.Type
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.MatchingInteractionActivityDefinition.InteractionType
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.MatchingInteractionActivityDefinition.#ctor
Initializes a new instance of the  struct.
### Parameters
#### name
The human readable/visual name of the Activity.
#### description
A description of the Activity.
#### correctResponsesPattern
A pattern representing the correct response to the interaction.
#### source
Items in the first set to match.
#### target
Items in the second set to match.
#### moreInfo
Resolves to a document with human-readable information about the Activity.
#### extensions
A map of other properties as needed.
## Float.xAPI.Activities.Definitions.IMatchingInteractionActivityDefinition.Target
Items in the second set to match.
### Parameters

## Float.xAPI.Activities.Definitions.IMatchingInteractionActivityDefinition.Source
Items in the first set to match.
### Parameters

## Float.xAPI.Activities.Definitions.IMatchingInteractionActivityDefinition
An interaction where the learner is asked to match items in one set (the source set) to items in another set (the target set).
 Items do not have to pair off exactly and it is possible for multiple or zero source items to be matched to a given target and vice versa.
### Parameters

## Float.xAPI.Activities.Definitions.PerformanceInteractionActivityDefinition.Steps
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.PerformanceInteractionActivityDefinition.CorrectResponsesPattern
A list of steps containing a step ids and the response to that step.
 Step ids are separated from responses by [.]. Steps are delimited by [,].
 The response can be a String as in a fill-in interaction or a number range as in a numeric interaction.
### Parameters

## Float.xAPI.Activities.Definitions.PerformanceInteractionActivityDefinition.Extensions
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.PerformanceInteractionActivityDefinition.MoreInfo
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.PerformanceInteractionActivityDefinition.Description
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.PerformanceInteractionActivityDefinition.Name
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.PerformanceInteractionActivityDefinition.Type
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.PerformanceInteractionActivityDefinition.InteractionType
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.PerformanceInteractionActivityDefinition.#ctor
Initializes a new instance of the  struct.
### Parameters
#### name
The human readable/visual name of the Activity.
#### description
A description of the Activity.
#### correctResponsesPattern
A pattern representing the correct response to the interaction.
#### steps
Steps within the task.
#### moreInfo
Resolves to a document with human-readable information about the Activity.
#### extensions
A map of other properties as needed.
## Float.xAPI.Activities.Definitions.IPerformanceInteractionActivityDefinition.Steps
Steps within the task.
### Parameters

## Float.xAPI.Activities.Definitions.IPerformanceInteractionActivityDefinition
An interaction that requires the learner to perform a task that requires multiple steps.
### Parameters

## Float.xAPI.Activities.Definitions.SequencingInteractionActivityDefinition.Choices
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.SequencingInteractionActivityDefinition.CorrectResponsesPattern
An ordered list of item ids delimited by [,].
### Parameters

## Float.xAPI.Activities.Definitions.SequencingInteractionActivityDefinition.Extensions
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.SequencingInteractionActivityDefinition.MoreInfo
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.SequencingInteractionActivityDefinition.Description
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.SequencingInteractionActivityDefinition.Name
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.SequencingInteractionActivityDefinition.Type
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.SequencingInteractionActivityDefinition.InteractionType
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.SequencingInteractionActivityDefinition.#ctor
Initializes a new instance of the  struct.
### Parameters
#### name
The human readable/visual name of the Activity.
#### description
A description of the Activity.
#### correctResponsesPattern
A pattern representing the correct response to the interaction.
#### choices
Items in a set that must be ordered.
#### moreInfo
Resolves to a document with human-readable information about the Activity.
#### extensions
A map of other properties as needed.
## Float.xAPI.Activities.Definitions.ISequencingInteractionActivityDefinition.Choices
Items in a set that must be ordered.
### Parameters

## Float.xAPI.Activities.Definitions.ISequencingInteractionActivityDefinition
An interaction where the learner is asked to order items in a set.
### Parameters

## Float.xAPI.Activities.Definitions.LikertInteractionActivityDefinition.Scale
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.LikertInteractionActivityDefinition.CorrectResponsesPattern
A single item id.
### Parameters

## Float.xAPI.Activities.Definitions.LikertInteractionActivityDefinition.Extensions
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.LikertInteractionActivityDefinition.MoreInfo
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.LikertInteractionActivityDefinition.Description
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.LikertInteractionActivityDefinition.Name
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.LikertInteractionActivityDefinition.Type
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.LikertInteractionActivityDefinition.InteractionType
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.LikertInteractionActivityDefinition.#ctor
Initializes a new instance of the  struct.
### Parameters
#### name
The human readable/visual name of the Activity.
#### description
A description of the Activity.
#### correctResponsesPattern
A pattern representing the correct response to the interaction.
#### scale
A list of discrete choices on a scale.
#### moreInfo
Resolves to a document with human-readable information about the Activity.
#### extensions
A map of other properties as needed.
## Float.xAPI.Activities.Definitions.ILikertInteractionActivityDefinition.Scale
A list of discrete choices on a scale.
### Parameters

## Float.xAPI.Activities.Definitions.ILikertInteractionActivityDefinition
An interaction which asks the learner to select from a discrete set of choices on a scale.
### Parameters

## Float.xAPI.Activities.Definitions.NumericInteractionActivityDefinition.CorrectResponsesPattern
A range of numbers represented by a minimum and a maximum delimited by [:].
 Where the range does not have a maximum or does not have a minimum, that number is omitted but the delimiter is still used. 
 E.g. [:]4 indicates a maximum for 4 and no minimum.
 Where the correct response or learner's response is a single number rather than a range, the single number with no delimiter MAY be used.
### Parameters

## Float.xAPI.Activities.Definitions.NumericInteractionActivityDefinition.Extensions
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.NumericInteractionActivityDefinition.MoreInfo
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.NumericInteractionActivityDefinition.Description
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.NumericInteractionActivityDefinition.Name
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.NumericInteractionActivityDefinition.Type
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.NumericInteractionActivityDefinition.InteractionType
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.NumericInteractionActivityDefinition.#ctor
Initializes a new instance of the  struct.
### Parameters
#### name
The human readable/visual name of the Activity.
#### description
A description of the Activity.
#### correctResponsesPattern
A pattern representing the correct response to the interaction.
#### moreInfo
Resolves to a document with human-readable information about the Activity.
#### extensions
A map of other properties as needed.
## Float.xAPI.Activities.Definitions.NumericInteractionActivityDefinition
Any interaction which requires a numeric response from the learner.
### Parameters

## Float.xAPI.Activities.Definitions.OtherInteractionActivityDefinition.CorrectResponsesPattern
Any format is valid within this string as appropriate for the type of interaction.
### Parameters

## Float.xAPI.Activities.Definitions.OtherInteractionActivityDefinition.Extensions
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.OtherInteractionActivityDefinition.MoreInfo
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.OtherInteractionActivityDefinition.Description
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.OtherInteractionActivityDefinition.Name
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.OtherInteractionActivityDefinition.Type
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.OtherInteractionActivityDefinition.InteractionType
No summary.
### Parameters

## Float.xAPI.Activities.Definitions.OtherInteractionActivityDefinition.#ctor
Initializes a new instance of the  struct.
### Parameters
#### name
The human readable/visual name of the Activity.
#### description
A description of the Activity.
#### correctResponsesPattern
A pattern representing the correct response to the interaction.
#### moreInfo
Resolves to a document with human-readable information about the Activity.
#### extensions
A map of other properties as needed.
## Float.xAPI.Activities.Definitions.OtherInteractionActivityDefinition
Another type of interaction that does not fit into those defined above.
### Parameters

## Float.xAPI.Activities.Definitions.Definition.InteractionUri
Interaction Activities SHOULD have this Activity type.
### Parameters

## Float.xAPI.Resources.Person
The Person Object is very similar to an Agent Object, but instead of each attribute having a single value, each attribute has an array value, and it is legal to include multiple identifying properties.
 This is different from the FOAF concept of person, person is being used here to indicate a person-centric view of the LRS Agent data, but Agents just refer to one persona (a person in one context).
### Parameters

## Float.xAPI.Resources.StatementResultFormat.Canonical
Return Activity Objects and Verbs populated with the canonical definition of the Activity Objects and Display of the Verbs as determined by the LRS, after applying the language filtering process defined below, and return the original Agent and Group Objects as in "exact" mode.
### Parameters

## Float.xAPI.Resources.StatementResultFormat.Exact
Return Agent, Activity, Verb and Group Objects populated exactly as they were when the Statement was received.
 An LRS requesting Statements for the purpose of importing them would use a format of "exact" in order to maintain Statement Immutability.
### Parameters

## Float.xAPI.Resources.StatementResultFormat.Ids
Only include minimum information necessary in Agent, Activity, Verb and Group Objects to identify them.
 For Anonymous Groups this means including the minimum information needed to identify each member.
### Parameters

## Float.xAPI.Resources.StatementResultFormat
An optional formatting requirement on statement resource requests.
### Parameters

## Float.xAPI.Resources.StatementResult.More
No summary.
### Parameters

## Float.xAPI.Resources.StatementResult.Statements
No summary.
### Parameters

## Float.xAPI.Resources.StatementResult.#ctor
Initializes a new instance of the  struct.
### Parameters
#### statements
List of statements.
#### more
Relative IRL that can be used to fetch more results.
## Float.xAPI.Resources.IStatementResult.Statements
List of Statements.
 If the list returned has been limited (due to pagination), and there are more results, they will be located at the "statements" property within the container located at the IRL provided by the "more" property of this Statement result Object.
 Where no matching Statements are found, this property will contain an empty array.
### Parameters

## Float.xAPI.Resources.IStatementResult.More
Relative IRL that can be used to fetch more results, including the full path and optionally a query string but excluding scheme, host, and port.
 Empty string if there are no more results to fetch.
### Parameters

## Float.xAPI.Resources.IStatementResult
A collection of Statements can be retrieved by performing a query on the Statement Resource.
### Parameters

## Float.xAPI.Resources.IStatementResource.PutStatement
Stores a single Statement with the given id. POST can also be used to store single Statements.
### Parameters
#### statement
The Statement object to be stored.
## Float.xAPI.Resources.IStatementResource.PostStatements
Stores a Statement, or a set of Statements.
### Parameters
#### statements
An array of Statements or a single Statement to be stored.
## Float.xAPI.Resources.IStatementResource.GetVoidedStatement
Get only voided statement that matches the given statement ID.
### Parameters
#### voidedStatementId
ID of voided statement to fetch.
#### format
The statement formatting to use for the returned object.
#### attachments
If true, the LRS uses the multipart response format and includes all attachments as described previously. If false, the LRS sends the prescribed response with Content-Type application/json and does not send attachment data.
## Float.xAPI.Resources.IStatementResource.GetStatements
This method is called to fetch a single Statement or multiple Statements.
### Parameters
#### actor
Filter, only return Statements for which the specified Agent or Group is the Actor or Object of the Statement.
#### verb
Filter, only return Statements matching the specified Verb id.
#### activity
Filter, only return Statements for which the Object of the Statement is an Activity with the specified id.
#### registration
Filter, only return Statements matching the specified registration id. Note that although frequently a unique registration will be used for one Actor assigned to one Activity, this cannot be assumed. If only Statements for a certain Actor or Activity are required, those parameters also need to be specified.
#### relatedActivities
Apply the Activity filter broadly. Include Statements for which the Object, any of the context Activities, or any of those properties in a contained SubStatement match the Activity parameter, instead of that parameter's normal behavior. Matching is defined in the same way it is for the "activity" parameter.
#### relatedAgents
Apply the Agent filter broadly. Include Statements for which the Actor, Object, Authority, Instructor, Team, or any of these properties in a contained SubStatement match the Agent parameter, instead of that parameter's normal behavior. Matching is defined in the same way it is for the "agent" parameter.
#### since
Only Statements stored since the specified Timestamp (exclusive) are returned.
#### until
Only Statements stored at or before the specified Timestamp are returned.
#### limit
Maximum number of Statements to return. 0 indicates return the maximum the server will allow. 
#### format
Statement result format option.
#### attachments
If true, the LRS uses the multipart response format and includes all attachments as described previously. If false, the LRS sends the prescribed response with Content-Type application/json and does not send attachment data.
#### ascending
If true, return results in ascending order of stored time.
## Float.xAPI.Resources.IStatementResource.GetStatement
Get only non-voided statement that matches the given statement ID.
### Parameters
#### statementId
ID of statement to fetch.
#### format
The statement formatting to use for the returned object.
#### attachments
If true, the LRS uses the multipart response format and includes all attachments as described previously. If false, the LRS sends the prescribed response with Content-Type application/json and does not send attachment data.
## Float.xAPI.Resources.IStatementResource
The basic communication mechanism of the Experience API.
### Parameters

## Float.xAPI.Resources.IActivitiesResource.GetActivity
Loads the complete Activity Object specified.
### Parameters
#### activityId
The id associated with the Activities to load.
## Float.xAPI.Resources.IActivitiesResource
The Activities Resource provides a method to retrieve a full description of an Activity from the LRS.
### Parameters

## Float.xAPI.Resources.IAgentsResource.GetPerson
Return a special, Person Object for a specified Agent.
 The Person Object is very similar to an Agent Object, but instead of each attribute having a single value, each attribute has an array value, and it is legal to include multiple identifying properties.
 This is different from the FOAF concept of person, person is being used here to indicate a person-centric view of the LRS Agent data, but Agents just refer to one persona (a person in one context).
### Parameters
#### agent
The Agent representation to use in fetching expanded Agent information.
## Float.xAPI.Resources.IAgentsResource
The Agents Resource provides a method to retrieve a special Object with combined information about an Agent derived from an outside service, such as a directory service.
### Parameters

## Float.xAPI.Resources.Documents.StateId
Set by Learning Record Provider, unique within the scope of the Agent or Activity.
### Parameters

## Float.xAPI.Resources.Documents.ActivityId
The Activity id associated with a state.
### Parameters

## Float.xAPI.Resources.Documents.ProfileId
The profile id associated with a Profile document.
### Parameters

## Float.xAPI.Resources.Documents.Document.Contents
No summary.
### Parameters

## Float.xAPI.Resources.Documents.Document.Updated
No summary.
### Parameters

## Float.xAPI.Resources.Documents.Document.Id
No summary.
### Parameters

## Float.xAPI.Resources.Documents.Document.ToString
No summary.
### Parameters

## Float.xAPI.Resources.Documents.Document.GetHashCode
No summary.
### Parameters

## Float.xAPI.Resources.Documents.Document.Equals
No summary.
### Parameters

## Float.xAPI.Resources.Documents.Document.#ctor
Initializes a new instance of the  struct.
### Parameters
#### id
Unique within the scope of the Agent or Activity.
#### updated
When the document was most recently modified.
#### contents
The contents of the document.
## Float.xAPI.Resources.Documents.IDocument.Updated
When the document was most recently modified.
### Parameters

## Float.xAPI.Resources.Documents.IDocument.Id
Set by Learning Record Provider, unique within the scope of the Agent or Activity.
### Parameters

## Float.xAPI.Resources.Documents.IDocument.Contents
The contents of the document.
### Parameters

## Float.xAPI.Resources.Documents.IDocument
The Experience API provides a facility for Learning Record Providers to save arbitrary data in the form of documents, perhaps related to an Activity, Agent, or combination of both.
### Parameters

## Float.xAPI.Resources.Documents.IStateResource.PutStateDocument
Stores the document specified.
### Parameters
#### stateDocument
The document to be stored or updated.
## Float.xAPI.Resources.Documents.IStateResource.GetStateDocuments
Fetches State ids of all state data for this context (Activity + Agent [ + registration if specified]).
 If "since" parameter is specified, this is limited to entries that have been stored or updated since the specified timestamp (exclusive).
### Parameters
#### activityId
The Activity id associated with these states.
#### agent
The Agent associated with these states.
#### registration
The Registration associated with these states.
#### since
Only ids of states stored since the specified Timestamp (exclusive) are returned.
## Float.xAPI.Resources.Documents.IStateResource.GetStateDocument
Fetches the document specified by the given "stateId" that exists in the context of the specified Activity, Agent, and registration (if specified).
### Parameters
#### stateId
The id for this state, within the given context.
#### activityId
The Activity id associated with this state.
#### agent
The Agent associated with this state.
#### registration
The registration associated with this state.
## Float.xAPI.Resources.Documents.IStateResource.DeleteStateDocuments
Deletes all state data for this context (Activity + Agent [+ registration if specified]).
### Parameters
#### activityId
The Activity id associated with these states.
#### agent
The Agent associated with these states.
#### registration
The Registration associated with these states.
## Float.xAPI.Resources.Documents.IStateResource.DeleteStateDocument
Deletes the document specified by the given "stateId" that exists in the context of the specified Activity, Agent, and registration (if specified).
### Parameters
#### stateId
The id for this state, within the given context.
#### activityId
The Activity id associated with this state.
#### agent
The Agent associated with this state.
#### registration
The registration associated with this state.
## Float.xAPI.Resources.Documents.IStateResource
Generally, this is a scratch area for Learning Record Providers that do not have their own internal storage, or need to persist state across devices.
### Parameters

## Float.xAPI.Resources.Documents.IActivityProfileResource.PutActivityProfileDocument
Stores or changes the specified Profile document in the context of the specified Activity.
### Parameters
#### document
The document to be stored or updated.
## Float.xAPI.Resources.Documents.IActivityProfileResource.GetActivityProfileDocuments
Fetches the specified Profile document in the context of the specified Activity.
 If "since" parameter is specified, this is limited to entries that have been stored or updated since the specified Timestamp (exclusive).
### Parameters
#### activityId
The Activity id associated with these Profile documents.
#### since
Only ids of Profile documents stored since the specified Timestamp (exclusive) are returned.
## Float.xAPI.Resources.Documents.IActivityProfileResource.GetActivityProfileDocument
Fetches the specified Profile document in the context of the specified Activity.
### Parameters
#### activityId
The Activity id associated with this Profile document.
#### profileId
The profile id associated with this Profile document.
## Float.xAPI.Resources.Documents.IActivityProfileResource.DeleteActivityProfileDocument
Deletes the specified Profile document in the context of the specified Activity.
### Parameters
#### activityId
The Activity id associated with this Profile document.
#### profileId
The profile id associated with this Profile document.
## Float.xAPI.Resources.Documents.IActivityProfileResource
The Activity Profile Resource is much like the State Resource, allowing for arbitrary key / document pairs to be saved which are related to an Activity.
### Parameters

## Float.xAPI.Resources.Documents.IAgentProfileResource.PutProfileDocument
Stores or changes the specified Profile document in the context of the specified Agent.
### Parameters
#### document
The document to be stored or updated.
## Float.xAPI.Resources.Documents.IAgentProfileResource.GetProfileDocuments
Fetches Profile ids of all Profile documents for an Agent.
 If "since" parameter is specified, this is limited to entries that have been stored or updated since the specified Timestamp (exclusive).
### Parameters
#### agent
The Agent associated with these Profile documents.
#### since
Only ids of Profiles stored since the specified Timestamp (exclusive) are returned.
## Float.xAPI.Resources.Documents.IAgentProfileResource.GetProfileDocument
Fetches the specified Profile document in the context of the specified Agent.
### Parameters
#### agent
The Agent associated with this Profile document.
#### profileId
The profile id associated with this Profile document.
## Float.xAPI.Resources.Documents.IAgentProfileResource.DeleteProfileDocument
Deletes the specified Profile document in the context of the specified Agent.
### Parameters
#### agent
The Agent associated with this Profile document.
#### profileId
The profile id associated with this Profile document.
## Float.xAPI.Resources.Documents.IAgentProfileResource
The Agent Profile Resource is much like the State Resource, allowing for arbitrary key / document pairs to be saved which are related to an Agent.
### Parameters

## Float.xAPI.Filters.statementUntilMatch
Returns false if the statement has a timestamp that is after the given time.
### Parameters

## Float.xAPI.Filters.statementSinceMatch
Returns false if the statement has a timestamp that is before the given time.
### Parameters

## Float.xAPI.Filters.statementRegistrationMatch
Returns false if the statement has a context object with a registration property, and the given registration doesn't match that property.
### Parameters

## Float.xAPI.Filters.statementActivityMatch
Returns false if the statement has an activity as the object, and the activity ID doesn't match the given ID.
### Parameters

## Float.xAPI.Filters.statementVerbMismatch
Returns true if the statement's verb ID doesn't match the given verb ID.
### Parameters

## Float.xAPI.Filters.statementVerbMatch
Returns false if the statement's verb ID doesn't match the given verb ID.
### Parameters

## Float.xAPI.Filters.statementActorMatch
Returns false if the statement has an identified actor and it doesn't match the given identified actor.
### Parameters

## Float.xAPI.Filters.statementIdMatch
Returns true if the given ID matches the given statement's ID.
### Parameters

## Float.xAPI.Filters
Functions that can be used to filter statements by LRS implementations.
### Parameters

