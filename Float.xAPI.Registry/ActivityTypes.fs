// <copyright file="Library.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Registry

open System
open Float.xAPI.Languages
open Float.xAPI.Activities.Definitions

// unused endpoints:
// https://registry.tincanapi.com/api/v1/profile
// https://registry.tincanapi.com/api/v1/uris/attachmentUsage
// https://registry.tincanapi.com/api/v1/uris/extension

module ActivityTypes =
    let Alert = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "alert"),
                                   LanguageMap(LanguageTag.EnglishUS, "Represents any kind of significant notification."),
                                   Uri("http://activitystrea.ms/schema/1.0/alert"))
    let Application = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "application"),
                                         LanguageMap(LanguageTag.EnglishUS, "Represents any kind of software application."),
                                         Uri("http://activitystrea.ms/schema/1.0/application"))
    let Article = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "article"),
                                     LanguageMap(LanguageTag.EnglishUS, "Represents objects such as news articles, knowledge base entries, or other similar construct. Such objects generally consist of paragraphs of text, in some cases incorporating embedded media such as photos and inline hyperlinks to other resources."),
                                     Uri("http://activitystrea.ms/schema/1.0/article"))
    let Assessment = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Assessment"),
                                        LanguageMap(LanguageTag.EnglishUS, "An assessment is an activity that determines a learner's mastery of a particular subject area. An assessment typically has one or more questions."),
                                        Uri("http://adlnet.gov/expapi/activities/assessment"))
    let Audio = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "audio"),
                                   LanguageMap(LanguageTag.EnglishUS, "Represents audio content of any kind. Objects of this type MAY contain an additional property as specified in Section 3.1."),
                                   Uri("http://activitystrea.ms/schema/1.0/audio"))
    let Badge = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "badge"),
                                   LanguageMap(LanguageTag.EnglishUS, "Represents a badge or award granted to an object (typically a person object)"),
                                   Uri("http://activitystrea.ms/schema/1.0/badge"))
    let Binary = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "binary"),
                                    LanguageMap(LanguageTag.EnglishUS, "Objects of this type are used to carry arbitrary Base64-encoded binary data within an Activity Stream object. It is primarily intended to attach binary data to other types of objects through the use of the attachments property. Objects of this type will contain the additional properties specified in Section 3.2. This activity type is included for data conversion with Activity Streams, it's not recommended for use in new Tin Can statements."),
                                    Uri("http://activitystrea.ms/schema/1.0/binary"))
    let Blog = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "blog"),
                                  LanguageMap(LanguageTag.EnglishUS, "A regularly updated website or web page, typically one authored by an individual or small group, that is written in an informal or conversational style."),
                                  Uri("http://id.tincanapi.com/activitytype/blog"))
    let Book = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Book"),
                                  LanguageMap(LanguageTag.EnglishUS, "A book, generally paper, but could also be an ebook. The Activity's ID will often include an ISBN though it is not required. The Definition can likely leverage the ISBN extension, 'http://id.tincanapi.com/extension/isbn', if known."),
                                  Uri("http://id.tincanapi.com/activitytype/book"))
    let Bookmark = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "bookmark "),
                                      LanguageMap(LanguageTag.EnglishUS, "Represents a pointer to some URL -- typically a web page. In most cases, bookmarks are specific to a given user and contain metadata chosen by that user. Bookmark Objects are similar in principle to the concept of bookmarks or favorites in a web browser. A bookmark represents a pointer to the URL, not the URL or the associated resource itself. Objects of this type SHOULD contain an additional targetUrl property whose value is a String containing the IRI of the target of the bookmark."),
                                      Uri("http://activitystrea.ms/schema/1.0/bookmark"))
    let Category = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Category"),
                                      LanguageMap(LanguageTag.EnglishUS, "Activity generally used in the \"category\" Context Activities lists to mark a statement as being related to a particular subject area. Distinct from tag in that it is used in conjunction with Subcategory to imply a hierarchy of categorization. "),
                                      Uri("http://id.tincanapi.com/activitytype/category"))
    let Certificate = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Certificate"),
                                         LanguageMap(LanguageTag.EnglishUS, "A document attesting to the fact that a person has completed an educational course."),
                                         Uri("https://www.opigno.org/en/tincan_registry/activity_type/certificate"))
    let ChangedDiaper = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Changed Diaper"),
                                           LanguageMap(LanguageTag.EnglishUS, "Create a Statement to represent that the educator or caretaker had to change the child’s diapers. This action is generally associated to the statement ece:defecated or ece:urinated indicating the cause of the diaper change. Nonetheless, one can record the Statement without indicating the context to keep a record of the number of diaper changes during the day."),
                                           Uri("http://id.tincanapi.com/activitytype/diaper-changed"))
    let Chapter = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "chapter"),
                                     LanguageMap(LanguageTag.EnglishUS, "A chapter of a book or e-book. "),
                                     Uri("http://id.tincanapi.com/activitytype/chapter"))
    let ChatChannel = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Chat Channel"),
                                         LanguageMap(LanguageTag.EnglishUS, "A channel, room or conversation within an instant chat application such as Slack. "),
                                         Uri("http://id.tincanapi.com/activitytype/chat-channel"))
    let ChatMessage = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Chat Message"),
                                         LanguageMap(LanguageTag.EnglishUS, "A message sent or received within the context of an instant chat platform such as Slack. The id of this activity should uniquely identify the particular chat message."),
                                         Uri("http://id.tincanapi.com/activitytype/chat-message"))
    let Checklist = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "checklist"),
                                       LanguageMap(LanguageTag.EnglishUS, "A list of tasks to be completed, names to be consulted, conditions to be verified and similar."),
                                       Uri("http://id.tincanapi.com/activitytype/checklist"))
    let ChecklistItem = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "checklist item"),
                                           LanguageMap(LanguageTag.EnglishUS, "An individual item contained in a checklist."),
                                           Uri("http://id.tincanapi.com/activitytype/checklist-item"))
    let CmiInteractions = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "cmi.interactions"),
                                             LanguageMap(LanguageTag.EnglishUS, "Interaction activities of \"cmi.interaction\" type as defined in the SCORM 2004 4th Edition Run-Time Environment."),
                                             Uri("http://adlnet.gov/expapi/activities/cmi.interaction"))
    let CodeCommit = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Code Commit"),
                                        LanguageMap(LanguageTag.EnglishUS, "A commit to a code repository e.g. Github. "),
                                        Uri("http://id.tincanapi.com/activitytype/code-commit"))
    let Collection = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "collection"),
                                        LanguageMap(LanguageTag.EnglishUS, "Represents a generic collection of objects of any type. This object type can be used, for instance, to represent a collection of files like a folder; a collection of photos like an album; and so forth. Objects of this type MAY contain an additional objectTypes property whose value is an Array of Strings specifying the expected objectType of objects contained within the collection. This activity type is included for data conversion with Activity Streams, it's not recommended for use in new Tin Can statements."),
                                        Uri("http://activitystrea.ms/schema/1.0/collection"))
    let Comment = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "comment"),
                                     LanguageMap(LanguageTag.EnglishUS, "Represents a textual response to another object. Objects of this type MAY contain an additional inReplyTo property whose value is an Array of one or more other Activity Stream Objects for which the object is to be considered a response."),
                                     Uri("http://activitystrea.ms/schema/1.0/comment"))
    let CommunitySite = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Community Site"),
                                           LanguageMap(LanguageTag.EnglishUS, "A space on a social platform (or other platform with social features) for a community to communicate, share and collaborate. For example a Google Plus Community, a Facebook Group, a Jive Space or a Pathgather Gathering. "),
                                           Uri("http://id.tincanapi.com/activitytype/community-site"))
    let Conference = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Conference"),
                                        LanguageMap(LanguageTag.EnglishUS, "A formal meeting which includes presentations or discussions."),
                                        Uri("http://id.tincanapi.com/activitytype/conference"))
    let ConferenceSession = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Conference Session"),
                                               LanguageMap(LanguageTag.EnglishUS, "A single presentation, discussion, gathering, or panel within a conference."),
                                               Uri("http://id.tincanapi.com/activitytype/conference-session"))
    let ConferenceTrack = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Conference Track"),
                                             LanguageMap(LanguageTag.EnglishUS, "A specific field of study within a conference."),
                                             Uri("http://id.tincanapi.com/activitytype/conference-track"))
    let Course = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Course"),
                                    LanguageMap(LanguageTag.EnglishUS, "A course represents an entire \"content package\" worth of material.  The largest level of granularity.  Unless flat, a course consists of multiple modules.  A course is not content."),
                                    Uri("http://adlnet.gov/expapi/activities/course"))
    let CuratrOrganisation = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Curatr Organisation"),
                                                LanguageMap(LanguageTag.EnglishUS, "An organisation within the Curatr platform. This is a collection of learners and courses. "),
                                                Uri("http://curatr3.com/define/type/organisation"))
    let Device = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "device "),
                                    LanguageMap(LanguageTag.EnglishUS, "Represents a device of any sort."),
                                    Uri("http://activitystrea.ms/schema/1.0/device"))
    let Discussion = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "discussion"),
                                        LanguageMap(LanguageTag.EnglishUS, "Represents an ongoing conversation between persons, such as an email thread or a forum topic. "),
                                        Uri("http://id.tincanapi.com/activitytype/discussion"))
    let Document = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Document"),
                                      LanguageMap(LanguageTag.EnglishUS, "An electronic document of the type produced by office productivity software such as a word processing document, spreadsheet, slides etc. "),
                                      Uri("http://id.tincanapi.com/activitytype/document"))
    let Doubt = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "doubt"),
                                   LanguageMap(LanguageTag.EnglishUS, "Refers to something that the actor needs to cast light on, something that can be answered or solved."),
                                   Uri("http://id.tincanapi.com/activitytype/doubt"))
    let Email = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Email"),
                                   LanguageMap(LanguageTag.EnglishUS, "Electronic message sent over a computer network from a sender to one or many recipients."),
                                   Uri("http://id.tincanapi.com/activitytype/email"))
    let EmbeddedStrategy = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "embedded strategy"),
                                              LanguageMap(LanguageTag.EnglishUS, "Refers to a functionality embedded in the software system to facilitate the implementation of a strategy."),
                                              Uri("http://id.tincanapi.com/activitytype/strategy-embedded"))
    let Essay = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Essay"),
                                   LanguageMap(LanguageTag.EnglishUS, "A short literary composition on a single subject, usually presenting the personal view of the author."),
                                   Uri("http://id.tincanapi.com/activitytype/essay"))
    let Event = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "event"),
                                   LanguageMap(LanguageTag.EnglishUS, "Represents an event that occurs at a certain location during a particular period of time. Objects of this type MAY contain the additional properties specified in Section 3.3."),
                                   Uri("http://activitystrea.ms/schema/1.0/event"))
    let File = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "file"),
                                  LanguageMap(LanguageTag.EnglishUS, "Represents any form of document or file. Objects of this type MAY contain an additional fileUrl property whose value a dereferenceable IRI that can be used to retrieve the file; and an additional mimeType property whose value is the MIME type of the file described by the object."),
                                  Uri("http://activitystrea.ms/schema/1.0/file"))
    let ForumReply = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Forum Reply"),
                                        LanguageMap(LanguageTag.EnglishUS, "Any post in a forum or discussion board thread that isn't the first."),
                                        Uri("http://id.tincanapi.com/activitytype/forum-reply"))
    let ForumTopic = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Forum Topic"),
                                        LanguageMap(LanguageTag.EnglishUS, "The first post in a thread on a forum or discussion board."),
                                        Uri("http://id.tincanapi.com/activitytype/forum-topic"))
    let FreetextAnnotation = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Freetext annotation"),
                                                LanguageMap(LanguageTag.EnglishUS, "Indicates an annotation made to a document of the 'freetext' form. This is a string of text written direction onto the document at a specified location. Freetext annotations can be added anywhere on the page. Unlike note annotations, they have no border or background."),
                                                Uri("http://www.risc-inc.com/annotator/activities/freetext"))
    let Game = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "game"),
                                  LanguageMap(LanguageTag.EnglishUS, "Represents a game or competition of any kind."),
                                  Uri("http://activitystrea.ms/schema/1.0/game"))
    let GameLevel = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Game level"),
                                       LanguageMap(LanguageTag.EnglishUS, "A level of a game or gamifed learning platform. "),
                                       Uri("http://curatr3.com/define/type/level"))
    let Goal = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "goal"),
                                  LanguageMap(LanguageTag.EnglishUS, "A goal is something that the actor wants to achieve, the purpose of doing a task or group of tasks. It can have subtasks and subgoals."),
                                  Uri("http://id.tincanapi.com/activitytype/goal"))
    let GradeClassification = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Grade classification"),
                                                 LanguageMap(LanguageTag.EnglishUS, "Represents a grade given or received within a particular context, for example ‘distinction’ within XYZ music test or ‘A’ for ABC qualification."),
                                                 Uri("http://www.tincanapi.co.uk/activitytypes/grade_classification"))
    let Group = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "group"),
                                   LanguageMap(LanguageTag.EnglishUS, "Represents a grouping of objects in which member objects can join or leave."),
                                   Uri("http://activitystrea.ms/schema/1.0/group"))
    let HighlightedTextAnnotation = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Highlighted text annotation"),
                                                       LanguageMap(LanguageTag.EnglishUS, "An annotation of the 'highlight' type. Highlights are used to mark strings of text in a document with a color. This activity type should only be used for highlighted text and not for highlighted images or other elements. "),
                                                       Uri("http://risc-inc.com/annotator/activities/highlight"))
    let Image = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "image"),
                                   LanguageMap(LanguageTag.EnglishUS, "Represents a graphical image. Objects of this type MAY contain an additional fullImage property whose value is an Activity Streams Media Link to a \"full-sized\" representation of the image."),
                                   Uri("http://activitystrea.ms/schema/1.0/image"))
    let Interaction = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Interaction"),
                                         LanguageMap(LanguageTag.EnglishUS, "An interaction is typically a part of a larger activity (such as assessment or simulation) and refers to a control to which a learner provides input.  An interaction can be either an asset or function independently."),
                                         Uri("http://adlnet.gov/expapi/activities/interaction"))
    let Issue = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "issue"),
                                   LanguageMap(LanguageTag.EnglishUS, "Represents a report about a problem or situation that needs to be resolved. For instance, the issue object can be used to represent reports detailing software defects, or reports of acceptable use violations, and so forth. Objects of this type MAY contain the additional properties specified in Section 3.4."),
                                   Uri("http://activitystrea.ms/schema/1.0/issue"))
    let Job = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "job"),
                                 LanguageMap(LanguageTag.EnglishUS, "Represents information about a job or a job posting."),
                                 Uri("http://activitystrea.ms/schema/1.0/job"))
    let JobTitle = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "job title"),
                                      LanguageMap(LanguageTag.EnglishUS, "The title of a person's job. May be used with the http://id.tincanapi.com/verb/was-assigned-job-title verb. "),
                                      Uri("http://id.tincanapi.com/activitytype/job-title"))
    let LegacyLearningStandard = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Legacy Learning Standard"),
                                                    LanguageMap(LanguageTag.EnglishUS, "Activity representing a statement generated by a course originally implemented in a legacy learning standard such as SCORM 1.2, 2004, or AICC."),
                                                    Uri("http://id.tincanapi.com/activitytype/legacy-learning-standard"))
    let Link = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Link"),
                                  LanguageMap(LanguageTag.EnglishUS, "A link is simply a means of expressing a link to another resource within, or external to, an activity.  A link is not synonymous with launching another resource and should be considered external to the current resource.  Links are not learning content, nor SCOs.  If a link is intended for this purpose, it should be re-categorized."),
                                  Uri("http://adlnet.gov/expapi/activities/link"))
    let Lms = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "LMS"),
                                 LanguageMap(LanguageTag.EnglishUS, "Learning Management System. At it's core, a platform used to launch and track learning experiences. Many LMS also have a number of other additional features. "),
                                 Uri("http://id.tincanapi.com/activitytype/lms"))
    let Media = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Media"),
                                   LanguageMap(LanguageTag.EnglishUS, "Media refers to text, audio, or video used to convey information. Media can be consumed (tracked: completed), but doesn't have an interactive component that may result in a score, success, or failure."),
                                   Uri("http://adlnet.gov/expapi/activities/media"))
    let Meeting = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Meeting"),
                                     LanguageMap(LanguageTag.EnglishUS, "A meeting is a gathering of multiple people for a common cause"),
                                     Uri("http://adlnet.gov/expapi/activities/meeting"))
    let Module = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Module"),
                                    LanguageMap(LanguageTag.EnglishUS, "A module represents any \"content aggregation\" at least one level below the course level.  Modules of modules can exist for layering purposes.  Modules are not content.  Modules are one level up from all content."),
                                    Uri("http://adlnet.gov/expapi/activities/module"))
    let Note = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "note "),
                                  LanguageMap(LanguageTag.EnglishUS, "Represents a short-form text message. This object is intended primarily for use in \"micro-blogging\" scenarios and in systems where users are invited to publish short, often plain-text messages whose useful lifespan is generally shorter than that of an article of weblog entry. A note is similar in structure to an article, but typically does not have a title or distinct paragraphs and tends to be much shorter in length."),
                                  Uri("http://activitystrea.ms/schema/1.0/note"))
    let NoteAnnotation = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Note annotation"),
                                            LanguageMap(LanguageTag.EnglishUS, "Indicates an annotation made to a document of the 'note' form. This is a string of text appended to the document at a specified location. Note annotations can be added anywhere on the page. This activity type should not be used for other types of note that are not annotations to a document. "),
                                            Uri("http://risc-inc.com/annotator/activities/note"))
    let Objective = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Objective"),
                                       LanguageMap(LanguageTag.EnglishUS, "An objective determines whether competency has been achieved in a desired area.  Objectives typically are associated with questions and assessments.  Objectives are not learning content and cannot be SCOs."),
                                       Uri("http://adlnet.gov/expapi/activities/objective"))
    let Offer = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "offer"),
                                   LanguageMap(LanguageTag.EnglishUS, "Represents an offer of any kind."),
                                   Uri("http://activitystrea.ms/schema/1.0/offer"))
    let OnDemandLab = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "On Demand Lab"),
                                         LanguageMap(LanguageTag.EnglishUS, "A virtual lab built upon request which is used to prepare for a certification or elevated permissions."),
                                         Uri("http://id.tincanapi.com/activitytype/lab-on-demand"))
    let Organization = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Organization"),
                                          LanguageMap(LanguageTag.EnglishUS, "An organization such as a company, which may hire, fire and promote employees."),
                                          Uri("http://id.tincanapi.com/activitytype/organization"))
    let Page = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "page"),
                                  LanguageMap(LanguageTag.EnglishUS, "Represents an area, typically a web page, that is representative of, and generally managed by a particular entity. Such areas are usually dedicated to displaying descriptive information about the entity and showcasing recent content such as articles, photographs and videos. Most social networking applications, for example, provide individual users with their own dedicated \"profile\" pages. Several allow similar types of pages to be created for commercial entities, organizations or events. While the specific details of how pages are implemented, their characteristics and use may vary, the one unifying property is that they are typically \"owned\" by a single entity that is represented by the content provided by the page itself."),
                                  Uri("http://activitystrea.ms/schema/1.0/page"))
    let Paragraph = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Paragraph"),
                                       LanguageMap(LanguageTag.EnglishUS, "A distinct division of written or printed matter that begins on a new, usually indented line, consists of one or more sentences, and typically deals with a single thought or topic or quotes one speaker's continuous words."),
                                       Uri("http://id.tincanapi.com/activitytype/paragraph"))
    let Performance = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Performance"),
                                         LanguageMap(LanguageTag.EnglishUS, "A performance is an attempted task or series of tasks within a particular context.  Tasks would likely take on the form of interactions, or the performance could be self-contained content."),
                                         Uri("http://adlnet.gov/expapi/activities/performance"))
    let Person = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "person"),
                                    LanguageMap(LanguageTag.EnglishUS, "Represents an individual person. This activity type is included for data conversion with Activity Streams, it's not recommended for use in new Tin Can statements. Agent should be used instead of person."),
                                    Uri("http://activitystrea.ms/schema/1.0/person"))
    let Place = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "place "),
                                   LanguageMap(LanguageTag.EnglishUS, "Represents a physical location. Locations can be represented using geographic coordinates, a physical address, a free-form location name, or any combination of these. Objects of this type MAY contain the additional properties specified in Section 3.5."),
                                   Uri("http://activitystrea.ms/schema/1.0/place"))
    let Playlist = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Playlist"),
                                      LanguageMap(LanguageTag.EnglishUS, "A collection of resources or experiences grouped together as recommended resources by an individual. Generally used for informally curated resources rather than official collections such as an LMS course.  "),
                                      Uri("http://id.tincanapi.com/activitytype/playlist"))
    let Process = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "process "),
                                     LanguageMap(LanguageTag.EnglishUS, "Represents any form of process. For instance, a long-running task that is started and expected to continue operating for a period of time."),
                                     Uri("http://activitystrea.ms/schema/1.0/process"))
    let Product = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "product"),
                                     LanguageMap(LanguageTag.EnglishUS, "Represents a commercial good or service. Objects of this type MAY contain an additional fullImage property whose value is an Activity Streams Media Link to an image resource representative of the product."),
                                     Uri("http://activitystrea.ms/schema/1.0/product"))
    let Project = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "project"),
                                     LanguageMap(LanguageTag.EnglishUS, "A project is a specific plan or set of tasks with a common goal. It can have subtasks and subgoals, resources, etc.."),
                                     Uri("http://id.tincanapi.com/activitytype/project"))
    let Question = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Question"),
                                      LanguageMap(LanguageTag.EnglishUS, "A question is typically part of an assessment and requires a response from the learner, a response that is then evaluated for correctness."),
                                      Uri("http://adlnet.gov/expapi/activities/question"))
    let Recipe = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "recipe"),
                                    LanguageMap(LanguageTag.EnglishUS, "A recipe is an Activity that is used in the Context Activities \"category\" property of a Statement to indicate that the Statement is part of a pre-defined model that can be expected to have certain properties, object identifiers, or structure. Statements adhering to a particular recipe are recognizable by reporting systems for the purposes of testing, interoperability, etc."),
                                    Uri("http://id.tincanapi.com/activitytype/recipe"))
    let RemoteLabExperiment = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Remote Lab Experiment"),
                                                 LanguageMap(LanguageTag.EnglishUS, "A remote lab experimentation is the act of experimenting with a real lab apparatus through the Internet."),
                                                 Uri("http://id.tincanapi.com/activitytype/remote-lab-experiment"))
    let ResearchReport = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "research report"),
                                            LanguageMap(LanguageTag.EnglishUS, "A research report from a government organization or other authoritative body giving information or proposals on an issue."),
                                            Uri("http://id.tincanapi.com/activitytype/research-report"))
    let Resource = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "resource"),
                                      LanguageMap(LanguageTag.EnglishUS, "A resource is a generic item that the actor may use for something. It could be a video, a text article, a device, etc. However, it is recommended to use a more specific activity type like those mentioned."),
                                      Uri("http://id.tincanapi.com/activitytype/resource"))
    let Review = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "review"),
                                    LanguageMap(LanguageTag.EnglishUS, "Represents a primarily prose-based commentary on another object. Objects of this type MAY contain a rating property as specified in Section 4.4."),
                                    Uri("http://activitystrea.ms/schema/1.0/review"))
    let Reward = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "reward"),
                                    LanguageMap(LanguageTag.EnglishUS, "Refers to a compensation that the actor wants to get for achieving something."),
                                    Uri("http://id.tincanapi.com/activitytype/reward"))
    let SalesOpportunity = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "sales opportunity"),
                                              LanguageMap(LanguageTag.EnglishUS, "Represents a sales opportunity, such as one might create in a CRM tool."),
                                              Uri("http://id.tincanapi.com/activitytype/sales-opportunity"))
    let Scenario = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Scenario"),
                                      LanguageMap(LanguageTag.EnglishUS, "Scenario - scenario based learning - is delivering the content embedded within a story or scenario rather than just pushing the content straight out. Usually a story or a situation is presented to ask for learner's action, feedback or branching follow. In this way learners see how the learning is applied to job environments or real world problems. "),
                                      Uri("http://id.tincanapi.com/activitytype/scenario"))
    let SchoolAssignment = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "School Assignment"),
                                              LanguageMap(LanguageTag.EnglishUS, "A school task performed by a student to satisfy the teacher. Examples are assessments, assigned reading, practice exercises, watch video, etc."),
                                              Uri("http://id.tincanapi.com/activitytype/school-assignment"))
    let Section = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Section"),
                                     LanguageMap(LanguageTag.EnglishUS, "A section of an application or platform. For sales performance app might be divided into client demo, learning materials and reference documents sections. "),
                                     Uri("http://id.tincanapi.com/activitytype/section"))
    let SecurityRole = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Security Role"),
                                          LanguageMap(LanguageTag.EnglishUS, "A feature that enables system administrators to restrict system access and manage access on a per-user or per-group basis."),
                                          Uri("http://id.tincanapi.com/activitytype/security-role"))
    let Service = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "service"),
                                     LanguageMap(LanguageTag.EnglishUS, "Represents any form of hosted or consumable service that performs some kind of work or benefit for other entities. Examples of such objects include websites, businesses, etc."),
                                     Uri("http://activitystrea.ms/schema/1.0/service"))
    let SimpleCollection = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "simple collection"),
                                              LanguageMap(LanguageTag.EnglishUS, "It is a collection of items of the same activity type, for example, a collection of games. The collection can be generic, that is, the activity type of the items can be specified using the extension 'collection type', but it is optional."),
                                              Uri("http://id.tincanapi.com/activitytype/collection-simple"))
    let Simulation = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Simulation"),
                                        LanguageMap(LanguageTag.EnglishUS, "A simulation is an attempted task or series of tasks in an artificial context that mimics reality.  Tasks would likely take on the form of interactions, or the simulation could be self-contained content."),
                                        Uri("http://adlnet.gov/expapi/activities/simulation"))
    let Slide = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "slide"),
                                   LanguageMap(LanguageTag.EnglishUS, "Slides are defined as a single page of a presentation or e-learning lesson."),
                                   Uri("http://id.tincanapi.com/activitytype/slide"))
    let SlideDeck = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "slide deck"),
                                       LanguageMap(LanguageTag.EnglishUS, "A deck of slides generally used for a presentation."),
                                       Uri("http://id.tincanapi.com/activitytype/slide-deck"))
    let Solution = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "solution"),
                                      LanguageMap(LanguageTag.EnglishUS, "Refers to the answer for a doubt that provides a solution. If the answer is not a solution, it should be coded as answer, or if it is just a comment, as comment."),
                                      Uri("http://id.tincanapi.com/activitytype/solution"))
    let Source = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Source"),
                                    LanguageMap(LanguageTag.EnglishUS, "Used with activities within the Context Activities \"category\" property of a Statement. Indicates the authoring tool, template or framework used to create the activity provider. This may help reporting tools to recognise that that data has come from a particular origin and handle the data correctly based on that information."),
                                    Uri("http://id.tincanapi.com/activitytype/source"))
    let StatusUpdate = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Status update"),
                                          LanguageMap(LanguageTag.EnglishUS, "A status update e.g. on a social platform. "),
                                          Uri("http://id.tincanapi.com/activitytype/status-update"))
    let Step = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "step"),
                                  LanguageMap(LanguageTag.EnglishUS, "A step is one of several actions that the actor has to do to achieve something, for instance, a goal or the completion of a task. For instance, a method, strategy or task could be divided into smaller steps."),
                                  Uri("http://id.tincanapi.com/activitytype/step"))
    let Strategy = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "strategy"),
                                      LanguageMap(LanguageTag.EnglishUS, "A strategy is a plan or method for achieving any specific goal, and can be formed by a group of steps."),
                                      Uri("http://id.tincanapi.com/activitytype/strategy"))
    let Subcategory = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Subcategory"),
                                         LanguageMap(LanguageTag.EnglishUS, "Activity generally used in the \"category\" Context Activities lists to mark a statement as being related to a particular subject area. Distinct from tag in that it is used in conjunction with Category to imply a hierarchy of categorization. "),
                                         Uri("http://id.tincanapi.com/activitytype/subcategory"))
    let Suggestion = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Suggestion"),
                                        LanguageMap(LanguageTag.EnglishUS, "A posted suggestion or idea. Typically these are things that can be discussed and/or voted on. "),
                                        Uri("http://id.tincanapi.com/activitytype/suggestion"))
    let Survey = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Survey"),
                                    LanguageMap(LanguageTag.EnglishUS, "A survey where the respondent answers questions."),
                                    Uri("http://id.tincanapi.com/activitytype/survey"))
    let Tag = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Tag"),
                                 LanguageMap(LanguageTag.EnglishUS, "Activity generally used in the \"other\" or \"grouping\" Context Activities lists to mark a statement as being related to a particular subject area. Implemented as a one word identifier used for search filtering or tag cloud generation."),
                                 Uri("http://id.tincanapi.com/activitytype/tag"))
    let Task = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "task"),
                                  LanguageMap(LanguageTag.EnglishUS, "Represents an activity that has yet to be completed. Objects of this type can contain additional properties as specified in Section 3.6."),
                                  Uri("http://activitystrea.ms/schema/1.0/task"))
    let TestDataBatch = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Test data batch"),
                                           LanguageMap(LanguageTag.EnglishUS, "A test data batch is an Activity that is used in the Context Activities \"category\" property of a Statement to indicate that the Statement is part of a particular collection of test data. The Id of this Activity represents a single collection of test data e.g. the data generated for a particular test or by a particular tool. "),
                                           Uri("http://id.tincanapi.com/activitytype/test-data-batch"))
    let TutorSession = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "tutor session"),
                                          LanguageMap(LanguageTag.EnglishUS, "This represents a tutoring session."),
                                          Uri("http://id.tincanapi.com/activitytype/tutor-session"))
    let Tweet = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Tweet"),
                                   LanguageMap(LanguageTag.EnglishUS, "A short message sent on Twitter. Used with the 'tweeted' verb. "),
                                   Uri("http://id.tincanapi.com/activitytype/tweet"))
    let UnderlineAnnotation = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Underline annotation"),
                                                 LanguageMap(LanguageTag.EnglishUS, "An annotation of the 'underline' type. Underlines are used to mark strings of text in a document with a line underneath the text. 

    This activity type should only be used for underlined text and not for images or other elements. "),
                                                 Uri("http://risc-inc.com/annotator/activities/underline"))
    let UnitTest = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "unit test"),
                                      LanguageMap(LanguageTag.EnglishUS, "A unit test in a test suite that is part of a programming project."),
                                      Uri("http://id.tincanapi.com/activitytype/unit-test"))
    let UnitTestSuite = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "unit test suite"),
                                           LanguageMap(LanguageTag.EnglishUS, "Suite of unit tests used by a programming project."),
                                           Uri("http://id.tincanapi.com/activitytype/unit-test-suite"))
    let UserProfile = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "User profile"),
                                         LanguageMap(LanguageTag.EnglishUS, "A page displaying information about a user. "),
                                         Uri("http://id.tincanapi.com/activitytype/user-profile"))
    let Video = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "video"),
                                   LanguageMap(LanguageTag.EnglishUS, "Represents video content of any kind. Objects of this type MAY contain additional properties as specified in Section 3.1."),
                                   Uri("http://activitystrea.ms/schema/1.0/video"))
    let VocabularyWord = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "vocabulary word"),
                                            LanguageMap(LanguageTag.EnglishUS, "Refers to a word that the learner defines or translates. The vocabulary word can be part of a collection.  that is part of a vocabulary collection. An actor can use more than one vocabulary collection, for instance, for several languages or several topics. Besides the “name” (the word)  and a “description” (meaning or translation), we recommend the use of moreInfo to link to a definition in an online dictionary. As an option, you can use the extension tags to classify the words."),
                                            Uri("http://id.tincanapi.com/activitytype/vocabulary-word"))
    let Voicemail = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "Voicemail"),
                                       LanguageMap(LanguageTag.EnglishUS, "A recorded audio message left for someone, generally via a phone or similar communication system."),
                                       Uri("http://id.tincanapi.com/activitytype/voicemail"))
    let Webinar = ActivityDefinition(LanguageMap(LanguageTag.EnglishUS, "webinar"),
                                     LanguageMap(LanguageTag.EnglishUS, "A seminar conducted over the Internet which may be live or recorded."),
                                     Uri("http://id.tincanapi.com/activitytype/webinar"))
