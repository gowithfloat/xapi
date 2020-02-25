// <copyright file="Verbs.fs" company="Float">
// Copyright (c) 2019 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Registry

open Float.xAPI
open Float.xAPI.Languages

module Verbs =
    /// <summary>
    /// Indicates that that the actor has accepted the object. For instance, a person accepting an award, or accepting an
    /// assignment.
    /// </summary>
    let Accepted = Verb(VerbId("http://activitystrea.ms/schema/1.0/accept"), LanguageMap(LanguageTag.EnglishUS, "accepted"))

    /// <summary>
    /// Indicates that the actor has accessed the object. For instance, a person accessing a room, or accessing a file.
    /// </summary>
    let Accessed = Verb(VerbId("http://activitystrea.ms/schema/1.0/access"), LanguageMap(LanguageTag.EnglishUS, "accessed"))

    /// <summary>
    /// Indicates that the actor has acknowledged the object. This effectively signals that the actor is aware of the object's
    /// existence.
    /// </summary>
    let Acknowledged = Verb(VerbId("http://activitystrea.ms/schema/1.0/acknowledge"), LanguageMap(LanguageTag.EnglishUS, "acknowledged"))

    /// <summary>
    /// Indicates that the actor has added the object to the target. For instance, adding a photo to an album.
    /// </summary>
    let Added = Verb(VerbId("http://activitystrea.ms/schema/1.0/add"), LanguageMap(LanguageTag.EnglishUS, "added"))

    /// <summary>
    /// Indicates the actor temporarily ended an event (e.g. a meeting). It is expected (but not required) that the event will
    /// be resumed at a future point in time. The actor of the statement should be somebody who has authority to adjourn the
    /// event, for example the event organizer.
    /// </summary>
    let Adjourned = Verb(VerbId("http://id.tincanapi.com/verb/adjourned"), LanguageMap(LanguageTag.EnglishUS, "adjourned"))

    /// <summary>
    /// Indicates that the actor agrees with the object. For example, a person agreeing with an argument, or expressing
    /// agreement with a particular issue.
    /// </summary>
    let Agreed = Verb(VerbId("http://activitystrea.ms/schema/1.0/agree"), LanguageMap(LanguageTag.EnglishUS, "agreed"))

    /// <summary>
    /// Indicates a new annotation has been added to a document. This verb may be used with PDFs, images, assignment
    /// submissions or any other type of document which may be annotated. 
    /// </summary>
    let Annotated = Verb(VerbId("http://risc-inc.com/annotator/verbs/annotated"), LanguageMap(LanguageTag.EnglishUS, "Annotated"))

    /// <summary>
    /// Indicates the actor responded to a Question
    /// </summary>
    let Answered = Verb(VerbId("http://adlnet.gov/expapi/verbs/answered"), LanguageMap(LanguageTag.EnglishUS, "answered"))

    /// <summary>
    /// Indicates that the actor has appended the object to the target. For instance, a person appending a new record to a
    /// database.
    /// </summary>
    let Appended = Verb(VerbId("http://activitystrea.ms/schema/1.0/append"), LanguageMap(LanguageTag.EnglishUS, "appended"))

    /// <summary>
    /// indicates that the actor approves of the content or message. Analogous to praising.
    /// </summary>
    let Applauded = Verb(VerbId("http://id.tincanapi.com/verb/applauded"), LanguageMap(LanguageTag.EnglishUS, "Applauded"))

    /// <summary>
    /// Indicates that the actor has approved the object. For instance, a manager might approve a travel request.
    /// </summary>
    let Approved = Verb(VerbId("http://activitystrea.ms/schema/1.0/approve"), LanguageMap(LanguageTag.EnglishUS, "approved"))

    /// <summary>
    /// Indicates that the actor has archived the object.
    /// </summary>
    let Archived = Verb(VerbId("http://activitystrea.ms/schema/1.0/archive"), LanguageMap(LanguageTag.EnglishUS, "archived"))

    /// <summary>
    /// Indicates that the actor arranged the object within a collection or set of elements. The extension
    /// http://id.tincanapi.com/extension/position should be used to indicate the new position.
    /// </summary>
    let Arranged = Verb(VerbId("http://id.tincanapi.com/verb/arranged"), LanguageMap(LanguageTag.EnglishUS, "arranged"))

    /// <summary>
    /// Used to make an inquiry of an actor with the expectation of a response. May be used to ask a question, typically the
    /// system would be the primary actor, with the learner being the recipient of the question.    The question could also be
    /// asked into a vacuum, with the eventual response (statement with verb responded) providing the actual context of the
    /// recipient.  For example "System asked Math quiz question 1 with result "What is 2+2"" followed by "Andy responded to
    /// quiz question 1 with result "response="4"" would alleviate the need to identify the second actor.
    /// </summary>
    let Asked = Verb(VerbId("http://adlnet.gov/expapi/verbs/asked"), LanguageMap(LanguageTag.EnglishUS, "asked"))

    /// <summary>
    /// Indicates that the actor has assigned the object to the target.
    /// </summary>
    let Assigned = Verb(VerbId("http://activitystrea.ms/schema/1.0/assign"), LanguageMap(LanguageTag.EnglishUS, "assigned"))

    /// <summary>
    /// Indicates that the actor has attached the object to the target. For instance, a person attaching a file to a wiki page
    /// or an email.
    /// </summary>
    let Attached = Verb(VerbId("http://activitystrea.ms/schema/1.0/attach"), LanguageMap(LanguageTag.EnglishUS, "attached"))

    /// <summary>
    /// Used at the initiation of many "experienced" activities to mark the entry. Attempts without further verbs could be
    /// incomplete in some cases.
    /// </summary>
    let Attempted = Verb(VerbId("http://adlnet.gov/expapi/verbs/attempted"), LanguageMap(LanguageTag.EnglishUS, "attempted"))

    /// <summary>
    /// Indicates that the actor has attended the object. For instance, a person attending a meeting.
    /// </summary>
    let Attended = Verb(VerbId("http://activitystrea.ms/schema/1.0/attend"), LanguageMap(LanguageTag.EnglishUS, "attended"))

    /// <summary>
    /// Indicates that the actor has authored the object. Note that this is a more specific form of the verb "create".
    /// </summary>
    let Authored = Verb(VerbId("http://activitystrea.ms/schema/1.0/author"), LanguageMap(LanguageTag.EnglishUS, "authored"))

    /// <summary>
    /// Indicates that the actor has authorized the object. If a target is specified, it means that the authorization is
    /// specifically in regards to the target. For instance, a service can authorize a person to access a given application; in
    /// which case the actor is the service, the object is the person, and the target is the application. In contrast, a person
    /// can authorize a request; in which case the actor is the person and the object is the request and there might be no
    /// explicit target.
    /// </summary>
    let Authorized = Verb(VerbId("http://activitystrea.ms/schema/1.0/authorize"), LanguageMap(LanguageTag.EnglishUS, "authorized"))

    /// <summary>
    /// Indicates the user determined the content was important enough to keep a reference to it for later. A different verb
    /// should be used for tracking the location in a set of text that a reader has reached, as in a physical bookmark.
    /// </summary>
    let Bookmarked = Verb(VerbId("http://id.tincanapi.com/verb/bookmarked"), LanguageMap(LanguageTag.EnglishUS, "bookmarked"))

    /// <summary>
    /// Indicates that the actor has borrowed the object. If a target is specified, it identifies the entity from which the
    /// object was borrowed. For instance, if a person borrows a book from a library, the person is the actor, the book is the
    /// object and the library is the target.
    /// </summary>
    let Borrowed = Verb(VerbId("http://activitystrea.ms/schema/1.0/borrow"), LanguageMap(LanguageTag.EnglishUS, "borrowed"))

    /// <summary>
    /// Indicates that the actor has built the object. For example, if a person builds a model or compiles code.
    /// </summary>
    let Built = Verb(VerbId("http://activitystrea.ms/schema/1.0/build"), LanguageMap(LanguageTag.EnglishUS, "built"))

    /// <summary>
    /// Indicates that the actor placed a phone call to the object.
    /// </summary>
    let Called = Verb(VerbId("http://id.tincanapi.com/verb/called"), LanguageMap(LanguageTag.EnglishUS, "called"))

    /// <summary>
    /// Indicates that the actor has canceled the object. For instance, canceling a calendar event.
    /// </summary>
    let Canceled = Verb(VerbId("http://activitystrea.ms/schema/1.0/cancel"), LanguageMap(LanguageTag.EnglishUS, "canceled"))

    /// <summary>
    /// This verb is a weaker version of "http://adlnet.gov/expapi/verbs/voided" and is used to let a Learning Planning System
    /// know that this particular plan has been superseded and is no longer relevant. It implies a change of plans, whereas
    /// voiding the statement would indicate that the plan had never actually been made in the first place. The object of this
    /// verb should always be a statement reference pointed to the id of statement using either the
    /// "http://www.tincanapi.co.uk/verbs/planned_learning" or "http://www.tincanapi.co.uk/verbs/enrolled_onto_learning_plan"
    /// verbs.Where a whole learning plan is cancelled, every item in that plan is considered to be cancelled.
    /// "http://adlnet.gov/expapi/verbs/voided" would suggest that the plan was never made in the first place.
    /// </summary>
    let CancelledPlannedLearning = Verb(VerbId("http://www.tincanapi.co.uk/pages/verbs.html#cancelled_planned_learning"), LanguageMap(LanguageTag.EnglishUS, "cancelled planned learning"))

    /// <summary>
    /// Indicates that the actor has checked-in to the object. For instance, a person checking-in to a place.
    /// </summary>
    let CheckedIn = Verb(VerbId("http://activitystrea.ms/schema/1.0/checkin"), LanguageMap(LanguageTag.EnglishUS, "checked in"))

    /// <summary>
    /// Indicates that the actor has closed the object. For instance, the object could represent a ticket being tracked in an
    /// issue management system.
    /// </summary>
    let Closed = Verb(VerbId("http://activitystrea.ms/schema/1.0/close"), LanguageMap(LanguageTag.EnglishUS, "closed"))

    /// <summary>
    /// Indicates that the actor has closed a sale.
    /// </summary>
    let ClosedSale = Verb(VerbId("http://id.tincanapi.com/verb/closed-sale"), LanguageMap(LanguageTag.EnglishUS, "closed sale"))

    /// <summary>
    /// Offered an opinion or written experience of the activity. Can be used with the learner as the actor or a system as an
    /// actor.  Comments can be sent from either party with the idea that the other will read and react to the content.
    /// </summary>
    let Commented = Verb(VerbId("http://adlnet.gov/expapi/verbs/commented"), LanguageMap(LanguageTag.EnglishUS, "commented"))

    /// <summary>
    /// Indicates that the actor has completed the object.
    /// </summary>
    let Completed = Verb(VerbId("http://activitystrea.ms/schema/1.0/complete"), LanguageMap(LanguageTag.EnglishUS, "completed"))

    /// <summary>
    /// Indicates that the actor has confirmed or agrees with the object. For instance, a software developer might confirm an
    /// issue reported against a product.
    /// </summary>
    let Confirmed = Verb(VerbId("http://activitystrea.ms/schema/1.0/confirm"), LanguageMap(LanguageTag.EnglishUS, "confirmed"))

    /// <summary>
    /// Indicates that the actor has consumed the object. The specific meaning is dependent largely on the object's type. For
    /// instance, an actor may "consume" an audio object, indicating that the actor has listened to it; or an actor may
    /// "consume" a book, indicating that the book has been read. As such, the "consume" verb is a more generic form of other
    /// more specific verbs such as "read" and "play".
    /// </summary>
    let Consumed = Verb(VerbId("http://activitystrea.ms/schema/1.0/consume"), LanguageMap(LanguageTag.EnglishUS, "consumed"))

    /// <summary>
    /// Indicates that the actor has created the object.
    /// </summary>
    let Created = Verb(VerbId("http://activitystrea.ms/schema/1.0/create"), LanguageMap(LanguageTag.EnglishUS, "created"))

    /// <summary>
    /// Indicates that the actor has created a new opportunity, such as one might do in a CRM tool. 
    /// </summary>
    let CreatedOpportunity = Verb(VerbId("http://id.tincanapi.com/verb/created-opportunity"), LanguageMap(LanguageTag.EnglishUS, "created opportunity"))

    /// <summary>
    /// Indicates that the actor has defined the object. Note that this is a more specific form of the verb “create”. For
    /// instance, a learner defining a goal.
    /// </summary>
    let Defined = Verb(VerbId("http://id.tincanapi.com/verb/defined"), LanguageMap(LanguageTag.EnglishUS, "defined"))

    /// <summary>
    /// Indicates that the actor has deleted the object. This implies, but does not require, the permanent destruction of the
    /// object.
    /// </summary>
    let Deleted = Verb(VerbId("http://activitystrea.ms/schema/1.0/delete"), LanguageMap(LanguageTag.EnglishUS, "deleted"))

    /// <summary>
    /// Indicates that the actor has delivered the object. For example, delivering a package.
    /// </summary>
    let Delivered = Verb(VerbId("http://activitystrea.ms/schema/1.0/deliver"), LanguageMap(LanguageTag.EnglishUS, "delivered"))

    /// <summary>
    /// Indicates that the actor has denied the object. For example, a manager may deny a travel request.
    /// </summary>
    let Denied = Verb(VerbId("http://activitystrea.ms/schema/1.0/deny"), LanguageMap(LanguageTag.EnglishUS, "denied"))

    /// <summary>
    /// Indicates that the actor turned off a particular part or feature of the system.
    /// </summary>
    let Disabled = Verb(VerbId("http://id.tincanapi.com/verb/disabled"), LanguageMap(LanguageTag.EnglishUS, "disabled"))

    /// <summary>
    /// Indicates that the actor disagrees with the object.
    /// </summary>
    let Disagreed = Verb(VerbId("http://activitystrea.ms/schema/1.0/disagree"), LanguageMap(LanguageTag.EnglishUS, "disagreed"))

    /// <summary>
    /// Indicates that the actor discarded a previous selection. This verb works with the verb 'selected'. 
    /// </summary>
    let Discarded = Verb(VerbId("http://id.tincanapi.com/verb/discarded"), LanguageMap(LanguageTag.EnglishUS, "discarded"))

    /// <summary>
    /// Indicates that the actor dislikes the object. Note that the "dislike" verb is distinct from the "unlike" verb which
    /// assumes that the object had been previously "liked".
    /// </summary>
    let Disliked = Verb(VerbId("http://activitystrea.ms/schema/1.0/dislike"), LanguageMap(LanguageTag.EnglishUS, "disliked"))

    /// <summary>
    /// Indicates that the actor has voted down for a specific object. This is analogous to giving a thumbs down.
    /// </summary>
    let DownVoted = Verb(VerbId("http://id.tincanapi.com/verb/voted-down"), LanguageMap(LanguageTag.EnglishUS, "down voted"))

    /// <summary>
    /// Indicates that the actor downloaded (rather than accessed or opened) a file or document. 
    /// </summary>
    let Downloaded = Verb(VerbId("http://id.tincanapi.com/verb/downloaded"), LanguageMap(LanguageTag.EnglishUS, "Downloaded"))

    /// <summary>
    /// Indicates that the actor has created a picture of something using a physical drawing utensil or a digital input device.
    /// </summary>
    let Drew = Verb(VerbId("http://www.digital-knowledge.co.jp/tincanapi/verbs/drew"), LanguageMap(LanguageTag.EnglishUS, "drew"))

    /// <summary>
    /// Indicates that the actor has earned or has been awarded the object.
    /// </summary>
    let Earned = Verb(VerbId("http://id.tincanapi.com/verb/earned"), LanguageMap(LanguageTag.EnglishUS, "earned"))

    /// <summary>
    /// Indicates that the actor has been recognized by an Open Badge issuer for an achievement. The actor may claim the badge
    /// referenced as the object and use it as a verifiable credential, wherever Open Badges are accepted.
    /// </summary>
    let EarnedAnOpenBadge = Verb(VerbId("http://specification.openbadges.org/xapi/verbs/earned"), LanguageMap(LanguageTag.EnglishUS, "Earned an Open Badge"))

    /// <summary>
    /// Indicates that the actor edited an object, for example a user editing their account profile. 
    /// </summary>
    let Edited = Verb(VerbId("http://curatr3.com/define/verb/edited"), LanguageMap(LanguageTag.EnglishUS, "Edited"))

    /// <summary>
    /// Indicates that the actor turned on a particular part or feature of the system. It works with the verb disabled.
    /// </summary>
    let Enabled = Verb(VerbId("http://id.tincanapi.com/verb/enabled"), LanguageMap(LanguageTag.EnglishUS, "enabled"))

    /// <summary>
    /// This verb is used to add additional learners to an existing learning plan, or a new plan if one does not exist. The
    /// actor of this statement is the person who is being enrolled onto the plan. Where the enrolment is being assigned by a
    /// 3rd party (or the plan was created by a 3rd party), the context instructor property may be used. The object of
    /// statements using this verb will always be an activity representing the learning plan. See
    /// http://tincanapi.co.uk/pages/The_Learning_Plan_Framework.html for more details.
    /// </summary>
    let EnrolledOntoLearningPlan = Verb(VerbId("http://www.tincanapi.co.uk/verbs/enrolled_onto_learning_plan"), LanguageMap(LanguageTag.EnglishUS, "enrolled onto learning plan"))

    /// <summary>
    /// Indicates that the actor has entered the frame of a camera or viewing device.
    /// </summary>
    let EnteredFrame = Verb(VerbId("http://id.tincanapi.com/verb/frame/entered"), LanguageMap(LanguageTag.EnglishUS, "entered frame"))

    /// <summary>
    /// Indicates that the actor has estimated the duration of the object. For instance, a learner estimating the duration of a
    /// task. 
    /// </summary>
    let EstimatedTheDuration = Verb(VerbId("http://id.tincanapi.com/verb/estimated-duration"), LanguageMap(LanguageTag.EnglishUS, "estimated the duration"))

    /// <summary>
    /// Verb used for evaluating a previous learning experience. The object of the statement should normally be a StatementRef
    /// pointing to an existing statement about the experience being evaluated. The actual evaluation should be provided in the
    /// result as either a score, response or both. See
    /// http://tincanapi.co.uk/pages/Tin_Can_Learning_Evaluator.html#Evaluating_and_Reflecting for further details and examples.
    /// 
    /// </summary>
    let Evaluated = Verb(VerbId("http://www.tincanapi.co.uk/verbs/evaluated"), LanguageMap(LanguageTag.EnglishUS, "evaluated"))

    /// <summary>
    /// Used to leave an activity attempt with no intention of returning with the learner progress intact.  The expectation is
    /// learner progress will be cleared.  Should appear immediately before a statement with terminated.  A statement with
    /// EITHER exited OR suspended should be used before one with terminated.  Lack of the two implies the same as exited.
    /// </summary>
    let Exited = Verb(VerbId("http://adlnet.gov/expapi/verbs/exited"), LanguageMap(LanguageTag.EnglishUS, "exited"))

    /// <summary>
    /// Indicates that the actor has exited the frame of a camera or viewing device.
    /// </summary>
    let ExitedFrame = Verb(VerbId("http://id.tincanapi.com/verb/frame/exited"), LanguageMap(LanguageTag.EnglishUS, "exited frame"))

    /// <summary>
    /// Indicates that the actor expected particular results from the object. The expected results should be recorded in the
    /// results field.
    /// </summary>
    let Expected = Verb(VerbId("http://id.tincanapi.com/verb/expected"), LanguageMap(LanguageTag.EnglishUS, "expected"))

    /// <summary>
    /// Indicates that the actor has experienced the object in some manner. Note that, depending on the specific object types
    /// used for both the actor and object, the meaning of this verb can overlap that of the "consume" and "play" verbs. For
    /// instance, a person might "experience" a movie; or "play" the movie; or "consume" the movie. The "experience" verb can be
    /// considered a more generic form of other more specific verbs as "consume", "play", "watch", "listen", and "read"
    /// </summary>
    let Experienced = Verb(VerbId("http://activitystrea.ms/schema/1.0/experience"), LanguageMap(LanguageTag.EnglishUS, "experienced"))

    /// <summary>
    /// Indicates that the object (a competency or certification) has expired for the actor. 
    /// </summary>
    let Expired = Verb(VerbId("http://id.tincanapi.com/verb/expired"), LanguageMap(LanguageTag.EnglishUS, "Expired"))

    /// <summary>
    /// Learner did not perform the activity to a level of pre-determined satisfaction. Used to affirm the lack of success a
    /// learner experienced within the learning content in relation to a threshold.  If the user performed below the minimum to
    /// the level of this threshold, the content is 'failed'.  The opposite of 'passed'.
    /// </summary>
    let Failed = Verb(VerbId("http://adlnet.gov/expapi/verbs/failed"), LanguageMap(LanguageTag.EnglishUS, "failed"))

    /// <summary>
    /// Indicates that the actor marked the object as an item of special interest.
    /// </summary>
    let Favorited = Verb(VerbId("http://activitystrea.ms/schema/1.0/favorite"), LanguageMap(LanguageTag.EnglishUS, "favorited"))

    /// <summary>
    /// Indicates that the actor has flagged the object as being inappropriate for some reason. When using this verb, the
    /// context property, as specified within Section 4.1 can be used to provide additional detail about why the object has been
    /// flagged.
    /// </summary>
    let FlaggedAsInappropriate = Verb(VerbId("http://activitystrea.ms/schema/1.0/flag-as-inappropriate"), LanguageMap(LanguageTag.EnglishUS, "flagged as inappropriate"))

    /// <summary>
    /// Indicates that a user has focused on a target object. This is the opposite of 'unfocused'. For example, it indicates
    /// that the user has clicked to focus or regain focus on the application, content or activity.
    /// </summary>
    let Focused = Verb(VerbId("http://id.tincanapi.com/verb/focused"), LanguageMap(LanguageTag.EnglishUS, "focused"))

    /// <summary>
    /// Indicates that the actor began following the activity of the object. In most cases, the objectType will be a "person",
    /// but it can potentially be of any type that can sensibly generate activity. Processors MAY ignore (silently drop)
    /// successive identical "follow" activities.
    /// </summary>
    let Followed = Verb(VerbId("http://activitystrea.ms/schema/1.0/follow"), LanguageMap(LanguageTag.EnglishUS, "followed"))

    /// <summary>
    /// Indicates that the actor has found the object.
    /// </summary>
    let Found = Verb(VerbId("http://activitystrea.ms/schema/1.0/find"), LanguageMap(LanguageTag.EnglishUS, "found"))

    /// <summary>
    /// Indicates that the actor is giving an object to the target. Examples include one person giving a badge object to
    /// another person. The object identifies the object being given. The target identifies the receiver.
    /// </summary>
    let Gave = Verb(VerbId("http://activitystrea.ms/schema/1.0/give"), LanguageMap(LanguageTag.EnglishUS, "gave"))

    /// <summary>
    /// An offer of employment that has been made by an agent and accepted by another. 
    /// </summary>
    let Hired = Verb(VerbId("http://id.tincanapi.com/verb/hired"), LanguageMap(LanguageTag.EnglishUS, "Hired"))

    /// <summary>
    /// Indicates that the actor is hosting the object. As in hosting an event, or hosting a service.
    /// </summary>
    let Hosted = Verb(VerbId("http://activitystrea.ms/schema/1.0/host"), LanguageMap(LanguageTag.EnglishUS, "hosted"))

    /// <summary>
    /// Indicates that the actor has ignored the object. For instance, this verb may be used when an actor has ignored a friend
    /// request, in which case the object may be the request-friend activity.
    /// </summary>
    let Ignored = Verb(VerbId("http://activitystrea.ms/schema/1.0/ignore"), LanguageMap(LanguageTag.EnglishUS, "ignored"))

    /// <summary>
    /// The act of moving an object into another location or system.
    /// </summary>
    let Imported = Verb(VerbId("http://adlnet.gov/expapi/verbs/imported"), LanguageMap(LanguageTag.EnglishUS, "imported"))

    /// <summary>
    /// Begins the formal tracking of learning content, any statements time stamped before a statement with an initialized verb
    /// are not formally tracked.
    /// </summary>
    let Initialized = Verb(VerbId("http://adlnet.gov/expapi/verbs/initialized"), LanguageMap(LanguageTag.EnglishUS, "initialized"))

    /// <summary>
    /// Indicates that the actor has inserted the object into the target.
    /// </summary>
    let Inserted = Verb(VerbId("http://activitystrea.ms/schema/1.0/insert"), LanguageMap(LanguageTag.EnglishUS, "inserted"))

    /// <summary>
    /// Indicates that the actor has installed the object, as in installing an application.
    /// </summary>
    let Installed = Verb(VerbId("http://activitystrea.ms/schema/1.0/install"), LanguageMap(LanguageTag.EnglishUS, "installed"))

    /// <summary>
    /// Indicates that the actor has interacted with the object. For instance, when one person interacts with another.
    /// </summary>
    let Interacted = Verb(VerbId("http://activitystrea.ms/schema/1.0/interact"), LanguageMap(LanguageTag.EnglishUS, "interacted"))

    /// <summary>
    /// For use when one agent or group interviews another agent or group. It could be used for the purposes of hiring,
    /// creating news articles, shows, research, etc.
    /// </summary>
    let Interviewed = Verb(VerbId("http://id.tincanapi.com/verb/interviewed"), LanguageMap(LanguageTag.EnglishUS, "Interviewed"))

    /// <summary>
    /// Indicates that the actor has invited the object, typically a person object, to join or participate in the object
    /// described by the target. The target could, for instance, be an event, group or a service.
    /// </summary>
    let Invited = Verb(VerbId("http://activitystrea.ms/schema/1.0/invite"), LanguageMap(LanguageTag.EnglishUS, "invited"))

    /// <summary>
    /// Indicates that the actor has become a member of the object. This specification only defines the meaning of this verb
    /// when the object of the Activity has an objectType of group, though implementors need to be prepared to handle other
    /// types of objects.
    /// </summary>
    let Joined = Verb(VerbId("http://activitystrea.ms/schema/1.0/join"), LanguageMap(LanguageTag.EnglishUS, "joined"))

    /// <summary>
    /// Indicates that the actor found the content funny and enjoyable. May be used with an "Ending Point" extension (see
    /// http://id.tincanapi.com/extension/ending-point) value capturing the point in time within the Activity.
    /// </summary>
    let Laughed = Verb(VerbId("http://id.tincanapi.com/verb/laughed"), LanguageMap(LanguageTag.EnglishUS, "Laughed"))

    /// <summary>
    /// Starts the process of launching the next piece of learning content.  There is no expectation if this is done by user or
    /// system and no expectation that the learning content is a "SCO".  It is highly recommended that the display is used to
    /// mirror the behavior.  If an activity is launched from another, then launched from may be better.  If the activity is
    /// launched and then the statement is generated, launched or launched into may be more appropriate.
    /// </summary>
    let Launched = Verb(VerbId("http://adlnet.gov/expapi/verbs/launched"), LanguageMap(LanguageTag.EnglishUS, "launched"))

    /// <summary>
    /// Indicates that the actor has left the object. For instance, a Person leaving a Group or checking-out of a Place.
    /// </summary>
    let Left = Verb(VerbId("http://activitystrea.ms/schema/1.0/leave"), LanguageMap(LanguageTag.EnglishUS, "left"))

    /// <summary>
    /// Indicates that the actor marked the object as an item of special interest. The "like" verb is considered to be an alias
    /// of "favorite". The two verb are semantically identical.
    /// </summary>
    let Liked = Verb(VerbId("http://activitystrea.ms/schema/1.0/like"), LanguageMap(LanguageTag.EnglishUS, "liked"))

    /// <summary>
    /// Indicates that the actor has listened to the object. This is typically only applicable for objects representing audio
    /// content, such as music, an audio-book, or a radio broadcast. The "listen" verb is a more specific form of the "consume",
    /// "experience" and "play" verbs.
    /// </summary>
    let Listened = Verb(VerbId("http://activitystrea.ms/schema/1.0/listen"), LanguageMap(LanguageTag.EnglishUS, "listened"))

    /// <summary>
    /// Logged in to some service
    /// </summary>
    let LogIn = Verb(VerbId("https://brindlewaye.com/xAPITerms/verbs/loggedin/"), LanguageMap(LanguageTag.EnglishUS, "Log In"))

    /// <summary>
    /// Logged out of some service.
    /// </summary>
    let LogOut = Verb(VerbId("https://brindlewaye.com/xAPITerms/verbs/loggedout/"), LanguageMap(LanguageTag.EnglishUS, "Log Out"))

    /// <summary>
    /// Indicates that the actor has lost the object. For instance, if a person loses a game.
    /// </summary>
    let Lost = Verb(VerbId("http://activitystrea.ms/schema/1.0/lose"), LanguageMap(LanguageTag.EnglishUS, "lost"))

    /// <summary>
    /// Indicates the creation of a friendship that is reciprocated by the object. Since this verb implies an activity on the
    /// part of its object, processors MUST NOT accept activities with this verb unless they are able to verify through some
    /// external means that there is in fact a reciprocated connection. For example, a processor may have received a guarantee
    /// from a particular publisher that the publisher will only use this Verb in cases where a reciprocal relationship exists.
    /// </summary>
    let MadeFriend = Verb(VerbId("http://activitystrea.ms/schema/1.0/make-friend"), LanguageMap(LanguageTag.EnglishUS, "made friend"))

    /// <summary>
    /// Used to describe a level of competence achieved in the activity.  The level should be within the range of a defined
    /// scale.  This is not to be confused with "progressed", which shows how much content was experienced, whereas mastery has
    /// to do with level of expertise.
    /// </summary>
    let Mastered = Verb(VerbId("http://adlnet.gov/expapi/verbs/mastered"), LanguageMap(LanguageTag.EnglishUS, "mastered"))

    /// <summary>
    /// Indicates that the actor mentioned the object, for example in a tweet. 
    /// </summary>
    let Mentioned = Verb(VerbId("http://id.tincanapi.com/verb/mentioned"), LanguageMap(LanguageTag.EnglishUS, "Mentioned"))

    /// <summary>
    /// Indicates that that the actor has mentored the object. For instance, a manager mentoring an employee, or a teacher
    /// mentoring a student. 
    /// </summary>
    let Mentored = Verb(VerbId("http://id.tincanapi.com/verb/mentored"), LanguageMap(LanguageTag.EnglishUS, "mentored"))

    /// <summary>
    /// This verb is used on annotations created with the http://risc-inc.com/annotator/verbs/annotated verb. It indicates that
    /// an existing annotation has been modified, for example editing the text of a note annotation or adjusting the position of
    /// a underline or highlight. 
    /// </summary>
    let ModifiedAnnotation = Verb(VerbId("http://risc-inc.com/annotator/verbs/modified"), LanguageMap(LanguageTag.EnglishUS, "Modified annotation"))

    /// <summary>
    /// Indicates that the actor has opened the object. For instance, the object could represent a ticket being tracked in an
    /// issue management system.
    /// </summary>
    let Opened = Verb(VerbId("http://activitystrea.ms/schema/1.0/open"), LanguageMap(LanguageTag.EnglishUS, "opened"))

    /// <summary>
    /// Used to affirm the success a learner experienced within the learning content in relation to a threshold.  If the user
    /// performed at a minimum to the level of this threshold, the content is 'passed'.  The opposite of 'failed'.
    /// </summary>
    let Passed = Verb(VerbId("http://adlnet.gov/expapi/verbs/passed"), LanguageMap(LanguageTag.EnglishUS, "passed"))

    /// <summary>
    /// To indicate an actor has ceased or suspended an activity temporarily.
    /// </summary>
    let Paused = Verb(VerbId("http://id.tincanapi.com/verb/paused"), LanguageMap(LanguageTag.EnglishUS, "paused"))

    /// <summary>
    /// Indicates that the actor has performed the object offline for a period of time (episode). For instance, a learner
    /// performed task X, which is an offline task like reading a book, for 30 minutes. This is used to record the time spent on
    /// offline activities.
    /// </summary>
    let Performed = Verb(VerbId("http://id.tincanapi.com/verb/performed-offline"), LanguageMap(LanguageTag.EnglishUS, "performed"))

    /// <summary>
    /// Indicates that the actor personalized the object. The idea is that the actor personalizes an object created by a third
    /// party to adapt it for his/her personal use. This can be used for personalizing a strategy, method, a cooking recipe,
    /// etc.
    /// </summary>
    let Personalized = Verb(VerbId("http://id.tincanapi.com/verb/personalized"), LanguageMap(LanguageTag.EnglishUS, "personalized"))

    /// <summary>
    /// Used to assert an intention to undertake a learning experience or activity. The object of the statement using this verb
    /// should always be a subStatement. See http://tincanapi.co.uk/pages/I_Want_This.html and
    /// http://tincanapi.co.uk/pages/The_Learning_Plan_Framework.html#Planned for more details. 
    /// </summary>
    let Planned = Verb(VerbId("http://www.tincanapi.co.uk/pages/verbs.html#planned_learning"), LanguageMap(LanguageTag.EnglishUS, "Planned"))

    /// <summary>
    /// Indicates that the actor spent some time enjoying the object. For example, if the object is a video this indicates that
    /// the subject watched all or part of the video. The "play" verb is a more specific form of the "consume" verb.
    /// </summary>
    let Played = Verb(VerbId("http://activitystrea.ms/schema/1.0/play"), LanguageMap(LanguageTag.EnglishUS, "Played"))

    /// <summary>
    /// The user's preference, typically presented to the content or system in the form of a response to a question. A response
    /// to a personal question to the learner, typically resulting in a change in content or system behavior. For example, the
    /// system could ask a question if the learner preferred a voice over text option. The resulting statement could be Andy
    /// preferred on Civil War History with result response = 'no voiceover'. This distinction is made between statements with
    /// responded as the content/system is expected to change as a results of the learner response.
    /// </summary>
    let Preferred = Verb(VerbId("http://adlnet.gov/expapi/verbs/preferred"), LanguageMap(LanguageTag.EnglishUS, "preferred"))

    /// <summary>
    /// Indicates that the actor has presented the object. For instance, when a person gives a presentation at a conference.
    /// </summary>
    let Presented = Verb(VerbId("http://activitystrea.ms/schema/1.0/present"), LanguageMap(LanguageTag.EnglishUS, "presented"))

    /// <summary>
    /// Indicates that the actor has pressed the object. For instance, a person pressing a key of a keyboard.
    /// </summary>
    let Pressed = Verb(VerbId("http://future-learning.info/xAPI/verb/pressed"), LanguageMap(LanguageTag.EnglishUS, "pressed"))

    /// <summary>
    /// Used to indicate that an actor has taken a first glance at a piece of content that they plan to return to for a more in
    /// depth experience later. For instance someone may come across a webpage that they don't have enough time to read at that
    /// time, but plan to come back to and read fully.
    /// </summary>
    let Previewed = Verb(VerbId("http://id.tincanapi.com/verb/previewed"), LanguageMap(LanguageTag.EnglishUS, "previewed"))

    /// <summary>
    /// A value, typically within a scale of progression, to how much of an activity has been accomplished.  This is not to be
    /// confused with 'mastered', as the level of success or competency a user gained is not guaranteed by progress.
    /// </summary>
    let Progressed = Verb(VerbId("http://adlnet.gov/expapi/verbs/progressed"), LanguageMap(LanguageTag.EnglishUS, "progressed"))

    /// <summary>
    /// The act of promoting a content item such that it appears more highly in search results or is promoted to users in some
    /// other way. 
    /// </summary>
    let Promoted = Verb(VerbId("http://id.tincanapi.com/verb/promoted"), LanguageMap(LanguageTag.EnglishUS, "Promoted"))

    /// <summary>
    /// Indicates that the actor has purchased the object. If a target is specified, in indicates the entity from which the
    /// object was purchased.
    /// </summary>
    let Purchased = Verb(VerbId("http://activitystrea.ms/schema/1.0/purchase"), LanguageMap(LanguageTag.EnglishUS, "purchased"))

    /// <summary>
    /// Indicates that the actor has qualified for the object. If a target is specified, it indicates the context within which
    /// the qualification applies.
    /// </summary>
    let Qualified = Verb(VerbId("http://activitystrea.ms/schema/1.0/qualify"), LanguageMap(LanguageTag.EnglishUS, "qualified"))

    /// <summary>
    /// Indicates that the actor ran a distance indicated by the activity
    /// </summary>
    let Ran = Verb(VerbId("https://brindlewaye.com/xAPITerms/verbs/ran/"), LanguageMap(LanguageTag.EnglishUS, "ran"))

    /// <summary>
    /// Action of giving a rating to an object. Should only be used when the action is the rating itself, as opposed to another
    /// action such as "reading" where a rating can be applied to the object as part of that action. In general the rating
    /// should be included in the Result with a Score object.
    /// </summary>
    let Rated = Verb(VerbId("http://id.tincanapi.com/verb/rated"), LanguageMap(LanguageTag.EnglishUS, "rated"))

    /// <summary>
    /// Indicates that the actor read the object. This is typically only applicable for objects representing printed or written
    /// content, such as a book, a message or a comment. The "read" verb is a more specific form of the "consume", "experience"
    /// and "play" verbs.
    /// </summary>
    let Read = Verb(VerbId("http://activitystrea.ms/schema/1.0/read"), LanguageMap(LanguageTag.EnglishUS, "read"))

    /// <summary>
    /// Indicates that the actor is receiving an object. Examples include a person receiving a badge object. The object
    /// identifies the object being received.
    /// </summary>
    let Received = Verb(VerbId("http://activitystrea.ms/schema/1.0/receive"), LanguageMap(LanguageTag.EnglishUS, "received"))

    /// <summary>
    /// Indicates the actor registered for a learning activity
    /// </summary>
    let Registered = Verb(VerbId("http://adlnet.gov/expapi/verbs/registered"), LanguageMap(LanguageTag.EnglishUS, "registered"))

    /// <summary>
    /// Indicates that the actor has rejected the object.
    /// </summary>
    let Rejected = Verb(VerbId("http://activitystrea.ms/schema/1.0/reject"), LanguageMap(LanguageTag.EnglishUS, "rejected"))

    /// <summary>
    /// Indicates that the actor has released the object. For instance, a person releasing a key of a keyboard.
    /// </summary>
    let Released = Verb(VerbId("http://future-learning.info/xAPI/verb/released"), LanguageMap(LanguageTag.EnglishUS, "released"))

    /// <summary>
    /// Indicates that the actor has removed the object from the target.
    /// </summary>
    let Removed = Verb(VerbId("http://activitystrea.ms/schema/1.0/remove"), LanguageMap(LanguageTag.EnglishUS, "removed"))

    /// <summary>
    /// Indicates that the actor has removed the object from the collection of friends.
    /// </summary>
    let RemovedFriend = Verb(VerbId("http://activitystrea.ms/schema/1.0/remove-friend"), LanguageMap(LanguageTag.EnglishUS, "removed friend"))

    /// <summary>
    /// Indicates that the actor has replaced the target with the object.
    /// </summary>
    let Replaced = Verb(VerbId("http://activitystrea.ms/schema/1.0/replace"), LanguageMap(LanguageTag.EnglishUS, "replaced"))

    /// <summary>
    /// The actor posted a reply to a forum, comment thread or discussion. 
    /// </summary>
    let Replied = Verb(VerbId("http://id.tincanapi.com/verb/replied"), LanguageMap(LanguageTag.EnglishUS, "Replied"))

    /// <summary>
    /// This is an extension of the tweeted verb for the specific case of a tweet replying to another. This can be used to
    /// track group discussions experience. As with Retweeted we expect to find the original tweet id in the context as well as
    /// the person's handle to which the reply is addressed using the tweet extension URI
    /// http://id.tincanapi.com/extension/tweet
    /// </summary>
    let RepliedToTweet = Verb(VerbId("http://id.tincanapi.com/verb/replied-to-tweet"), LanguageMap(LanguageTag.EnglishUS, "replied to tweet"))

    /// <summary>
    /// Indicates that the actor has requested the object. If a target is specified, it indicates the entity from which the
    /// object is being requested.
    /// </summary>
    let Requested = Verb(VerbId("http://activitystrea.ms/schema/1.0/request"), LanguageMap(LanguageTag.EnglishUS, "requested"))

    /// <summary>
    /// Indicates that the actor is requesting the attention of an instructor, presenter or moderator. 
    /// </summary>
    let RequestedAttention = Verb(VerbId("http://id.tincanapi.com/verb/requested-attention"), LanguageMap(LanguageTag.EnglishUS, "requested attention"))

    /// <summary>
    /// Indicates the creation of a friendship that has not yet been reciprocated by the object.
    /// </summary>
    let RequestedFriend = Verb(VerbId("http://activitystrea.ms/schema/1.0/request-friend"), LanguageMap(LanguageTag.EnglishUS, "requested friend"))

    /// <summary>
    /// Indicates that the actor has resolved the object. For instance, the object could represent a ticket being tracked in an
    /// issue management system.
    /// </summary>
    let Resolved = Verb(VerbId("http://activitystrea.ms/schema/1.0/resolve"), LanguageMap(LanguageTag.EnglishUS, "resolved"))

    /// <summary>
    /// Used to respond to a question.  It could be either the actual answer to a question asked of the actor OR the
    /// correctness of an answer to a question asked of the actor. Must follow a statement with asked or another statement with
    /// a responded (the top statement with responded) must follow the "asking" statement.  The response to the question can be
    /// the actual text (usually) response or the correctness of that response.  For example, Andy responded to quiz question 1
    /// with result 'response=4' and Andy responded to quiz question 1 with result success=true'.  Typically both types of
    /// responded statements would follow a single question/interacton.
    /// </summary>
    let Responded = Verb(VerbId("http://adlnet.gov/expapi/verbs/responded"), LanguageMap(LanguageTag.EnglishUS, "responded"))

    /// <summary>
    /// Used to resume suspended attempts on an activity.  Should immediately follow a statement with initialized  if the
    /// attempt is indeed to be resumed. The absence of a resumed statement implies a fresh attempt on the activity.  Can only
    /// be used on an activity that used a suspended statement.
    /// </summary>
    let Resumed = Verb(VerbId("http://adlnet.gov/expapi/verbs/resumed"), LanguageMap(LanguageTag.EnglishUS, "resumed"))

    /// <summary>
    /// Indicates that the actor has retracted the object. For instance, if an actor wishes to retract a previously published
    /// activity, the object would be the previously published activity that is being retracted.
    /// </summary>
    let Retracted = Verb(VerbId("http://activitystrea.ms/schema/1.0/retract"), LanguageMap(LanguageTag.EnglishUS, "retracted"))

    /// <summary>
    /// Indicates that the actor has returned the object. If a target is specified, it indicates the entity to which the object
    /// was returned.
    /// </summary>
    let Returned = Verb(VerbId("http://activitystrea.ms/schema/1.0/return"), LanguageMap(LanguageTag.EnglishUS, "returned"))

    /// <summary>
    /// Used when an agent repeats a tweet written by another user. Usage in a statement is similar to tweeted but we expect to
    /// find the URI to the original tweet in the context of the statement, as well as the username of the original author as a
    /// context extension. The extension URI used for this should be http://id.tincanapi.com/extension/tweet
    /// </summary>
    let Retweeted = Verb(VerbId("http://id.tincanapi.com/verb/retweeted"), LanguageMap(LanguageTag.EnglishUS, "retweeted"))

    /// <summary>
    /// Indicates that the actor has reviewed the object. For instance, a person reviewing an employee or a person reviewing an
    /// owner's manual.
    /// </summary>
    let Reviewed = Verb(VerbId("http://id.tincanapi.com/verb/reviewed"), LanguageMap(LanguageTag.EnglishUS, "reviewed"))

    /// <summary>
    /// The "possible RSVP" verb indicates that the actor has made a possible RSVP for the object. This specification only
    /// defines the meaning of this verb when its object is an event (see Section 3.3), though implementors need to be prepared
    /// to handle other object types. The use of this verb is only appropriate when the RSVP was created by an explicit action
    /// by the actor. It is not appropriate to use this verb when a user has been added as an attendee by an event organizer or
    /// administrator.This verb is included for data conversion with Activity Streams, it's not recommended for use in new Tin
    /// Can statements.
    /// </summary>
    let RsvpedMaybe = Verb(VerbId("http://activitystrea.ms/schema/1.0/rsvp-maybe"), LanguageMap(LanguageTag.EnglishUS, "RSVPed maybe"))

    /// <summary>
    /// The "negative RSVP" verb indicates that the actor has made a negative RSVP for the object. This specification only
    /// defines the meaning of this verb when its object is an event (see Section 3.3), though implementors need to be prepared
    /// to handle other object types. The use of this verb is only appropriate when the RSVP was created by an explicit action
    /// by the actor. It is not appropriate to use this verb when a user has been added as an attendee by an event organizer or
    /// administrator.This verb is included for data conversion with Activity Streams, it's not recommended for use in new Tin
    /// Can statements.
    /// </summary>
    let RsvpedNo = Verb(VerbId("http://activitystrea.ms/schema/1.0/rsvp-no"), LanguageMap(LanguageTag.EnglishUS, "rsvped no"))

    /// <summary>
    /// The "positive RSVP" verb indicates that the actor has made a positive RSVP for an object. This specification only
    /// defines the meaning of this verb when its object is an event (see Section 3.3), though implementors need to be prepared
    /// to handle other object types. The use of this verb is only appropriate when the RSVP was created by an explicit action
    /// by the actor. It is not appropriate to use this verb when a user has been added as an attendee by an event organizer or
    /// administrator.This verb is included for data conversion with Activity Streams, it's not recommended for use in new Tin
    /// Can statements.
    /// </summary>
    let RsvpedYes = Verb(VerbId("http://activitystrea.ms/schema/1.0/rsvp-yes"), LanguageMap(LanguageTag.EnglishUS, "rsvped yes"))

    /// <summary>
    /// Indicates that the actor has satisfied the object. If a target is specified, it indicate the context within which the
    /// object was satisfied. For instance, if a person satisfies the requirements for a particular challenge, the person is the
    /// actor; the requirement is the object; and the challenge is the target.
    /// </summary>
    let Satisfied = Verb(VerbId("http://activitystrea.ms/schema/1.0/satisfy"), LanguageMap(LanguageTag.EnglishUS, "satisfied"))

    /// <summary>
    /// Indicates that the actor has called out the object as being of interest primarily to him- or herself. Though this
    /// action MAY be shared publicly, the implication is that the object has been saved primarily for the actor's own benefit
    /// rather than to show it to others as would be indicated by the "share" verb.
    /// </summary>
    let Saved = Verb(VerbId("http://activitystrea.ms/schema/1.0/save"), LanguageMap(LanguageTag.EnglishUS, "saved"))

    /// <summary>
    /// Indicates that the actor has scheduled the object. For instance, scheduling a meeting.
    /// </summary>
    let Scheduled = Verb(VerbId("http://activitystrea.ms/schema/1.0/schedule"), LanguageMap(LanguageTag.EnglishUS, "scheduled"))

    /// <summary>
    /// A measure related to the learnerâ€™s performance, typically between either 0 and 1 or 0 and 100, which corresponds to a
    /// learner's performance on an activity.  It is expected the context property provides guidance to the allowed values of
    /// the result field.
    /// </summary>
    let Scored = Verb(VerbId("http://adlnet.gov/expapi/verbs/scored"), LanguageMap(LanguageTag.EnglishUS, "scored"))

    /// <summary>
    /// Indicates that the actor is or has searched for the object. If a target is specified, it indicates the context within
    /// which the search is or has been conducted.
    /// </summary>
    let Searched = Verb(VerbId("http://activitystrea.ms/schema/1.0/search"), LanguageMap(LanguageTag.EnglishUS, "searched"))

    /// <summary>
    /// Indicates that the actor secured the object. The object used with this verb might be a device, piece of software,
    /// location, etc.
    /// </summary>
    let Secured = Verb(VerbId("http://id.tincanapi.com/verb/secured"), LanguageMap(LanguageTag.EnglishUS, "Secured"))

    /// <summary>
    /// Indicates that the actor selects an object from a collection or set to use it in an activity. The collection would be
    /// the context parent element.
    /// </summary>
    let Selected = Verb(VerbId("http://id.tincanapi.com/verb/selected"), LanguageMap(LanguageTag.EnglishUS, "selected"))

    /// <summary>
    /// Indicates that the actor has sent the object. If a target is specified, it indicates the entity to which the object was
    /// sent.
    /// </summary>
    let Sent = Verb(VerbId("http://activitystrea.ms/schema/1.0/send"), LanguageMap(LanguageTag.EnglishUS, "sent"))

    /// <summary>
    /// Indicates that the actor has called out the object to readers. In most cases, the actor did not create the object being
    /// shared, but is instead drawing attention to it.
    /// </summary>
    let Shared = Verb(VerbId("http://activitystrea.ms/schema/1.0/share"), LanguageMap(LanguageTag.EnglishUS, "shared"))

    /// <summary>
    /// To indicate an actor has passed over or omitted an interval, screen, segment, item, or step.
    /// </summary>
    let Skipped = Verb(VerbId("http://id.tincanapi.com/verb/skipped"), LanguageMap(LanguageTag.EnglishUS, "skipped"))

    /// <summary>
    /// Indicates that the actor has sold the object. If a target is specified, it indicates the entity to which the object was
    /// sold.
    /// </summary>
    let Sold = Verb(VerbId("http://activitystrea.ms/schema/1.0/sell"), LanguageMap(LanguageTag.EnglishUS, "sold"))

    /// <summary>
    /// Indicates that the actor has sponsored the object. If a target is specified, it indicates the context within which the
    /// sponsorship is offered. For instance, a company can sponsor an event; or an individual can sponsor a project; etc.
    /// </summary>
    let Sponsored = Verb(VerbId("http://activitystrea.ms/schema/1.0/sponsor"), LanguageMap(LanguageTag.EnglishUS, "sponsored"))

    /// <summary>
    /// Indicates that the actor has started the object. For instance, when a person starts a project.
    /// </summary>
    let Started = Verb(VerbId("http://activitystrea.ms/schema/1.0/start"), LanguageMap(LanguageTag.EnglishUS, "started"))

    /// <summary>
    /// Indicates that the actor has stopped following the object.
    /// </summary>
    let StoppedFollowing = Verb(VerbId("http://activitystrea.ms/schema/1.0/stop-following"), LanguageMap(LanguageTag.EnglishUS, "stopped following"))

    /// <summary>
    /// Indicates that the actor has submitted the object. If a target is specified, it indicates the entity to which the
    /// object was submitted.
    /// </summary>
    let Submitted = Verb(VerbId("http://activitystrea.ms/schema/1.0/submit"), LanguageMap(LanguageTag.EnglishUS, "submitted"))

    /// <summary>
    /// Used to suspend an activity with the intention of returning to it later, but not losing progress.  Should appear
    /// immediately before a statement with terminated.  A statement with EITHER exited OR suspended should be used before one
    /// with terminated.  Lack of the two implies the same as exited.  Beginning the suspended activity will always result in a
    /// resumed activity.
    /// </summary>
    let Suspended = Verb(VerbId("http://adlnet.gov/expapi/verbs/suspended"), LanguageMap(LanguageTag.EnglishUS, "suspended"))

    /// <summary>
    /// Indicates that the actor has associated the object with the target. For example, if the actor specifies that a
    /// particular user appears in a photo. the object is the user and the target is the photo.
    /// </summary>
    let Tagged = Verb(VerbId("http://activitystrea.ms/schema/1.0/tag"), LanguageMap(LanguageTag.EnglishUS, "tagged"))

    /// <summary>
    /// Indicates that the actor talked to another agent or group. The object of statements using this verb should be an agent
    /// or group, for example a teacher, an NPC in a simulation, a group of colleagues. This verb is intended to be used where
    /// one actor initiates and leads a conversation, rather than an equal discussion between two parties.
    /// </summary>
    let Talked = Verb(VerbId("http://id.tincanapi.com/verb/talked-with"), LanguageMap(LanguageTag.EnglishUS, "talked"))

    /// <summary>
    /// Indicates that the actor has terminated the object.
    /// </summary>
    let Terminated = Verb(VerbId("http://activitystrea.ms/schema/1.0/terminate"), LanguageMap(LanguageTag.EnglishUS, "terminated"))

    /// <summary>
    /// Indicates that the actor's employment with the organization represented by the object of the statement has been
    /// terminated for some reason. Use of this verb does not imply any particular reason for the termination. The actor may
    /// have been fired, quit, died etc.
    /// </summary>
    let TerminatedEmploymentWith = Verb(VerbId("http://id.tincanapi.com/verb/terminated-employment-with"), LanguageMap(LanguageTag.EnglishUS, "Terminated employment with"))

    /// <summary>
    /// Indicates that the actor has neither won or lost the object. This verb is generally only applicable when the object
    /// represents some form of competition, such as a game.
    /// </summary>
    let Tied = Verb(VerbId("http://activitystrea.ms/schema/1.0/tie"), LanguageMap(LanguageTag.EnglishUS, "tied"))

    /// <summary>
    /// Use this verb when an agent tweets on Twitter. It is open for use also for other short messages (microblogging
    /// services) based on the URI as the activityId.We expect activityId to be a URI to the tweet.
    /// </summary>
    let Tweeted = Verb(VerbId("http://id.tincanapi.com/verb/tweeted"), LanguageMap(LanguageTag.EnglishUS, "tweeted"))

    /// <summary>
    /// Indicates that the actor has removed the object from the collection of favorited items.
    /// </summary>
    let Unfavorited = Verb(VerbId("http://activitystrea.ms/schema/1.0/unfavorite"), LanguageMap(LanguageTag.EnglishUS, "unfavorited"))

    /// <summary>
    /// Indicates that the user has lost focus of the target object. For example, this could be used when the user clicks
    /// outside a given application, window or activity.
    /// </summary>
    let Unfocused = Verb(VerbId("http://id.tincanapi.com/verb/unfocused"), LanguageMap(LanguageTag.EnglishUS, "unfocused"))

    /// <summary>
    /// Indicates that the actor has removed the object from the collection of liked items.
    /// </summary>
    let Unliked = Verb(VerbId("http://activitystrea.ms/schema/1.0/unlike"), LanguageMap(LanguageTag.EnglishUS, "unliked"))

    /// <summary>
    /// The object was marked as unread. 
    /// </summary>
    let Unread = Verb(VerbId("http://id.tincanapi.com/verb/marked-unread"), LanguageMap(LanguageTag.EnglishUS, "Unread"))

    /// <summary>
    /// Indicates the actor unregistered for a learning activity. This verb is used in combination with
    /// http://adlnet.gov/expapi/verbs/registered for the registering and unregistering of learners.
    /// </summary>
    let Unregistered = Verb(VerbId("http://id.tincanapi.com/verb/unregistered"), LanguageMap(LanguageTag.EnglishUS, "unregistered"))

    /// <summary>
    /// Indicates that the actor has not satisfied the object. If a target is specified, it indicates the context within which
    /// the object was not satisfied. For instance, if a person fails to satisfy the requirements of some particular challenge,
    /// the person is the actor; the requirement is the object and the challenge is the target.
    /// </summary>
    let Unsatisfied = Verb(VerbId("http://activitystrea.ms/schema/1.0/unsatisfy"), LanguageMap(LanguageTag.EnglishUS, "unsatisfied"))

    /// <summary>
    /// Indicates that the actor has removed the object from the collection of saved items.
    /// </summary>
    let Unsaved = Verb(VerbId("http://activitystrea.ms/schema/1.0/unsave"), LanguageMap(LanguageTag.EnglishUS, "unsaved"))

    /// <summary>
    /// Indicates that the actor is no longer sharing the object. If a target is specified, it indicates the entity with whom
    /// the object is no longer being shared.
    /// </summary>
    let Unshared = Verb(VerbId("http://activitystrea.ms/schema/1.0/unshare"), LanguageMap(LanguageTag.EnglishUS, "unshared"))

    /// <summary>
    /// Indicates that the actor has voted up for a specific object. This is analogous to giving a thumbs up.
    /// </summary>
    let UpVoted = Verb(VerbId("http://id.tincanapi.com/verb/voted-up"), LanguageMap(LanguageTag.EnglishUS, "up voted"))

    /// <summary>
    /// The "update" verb indicates that the actor has modified the object. Use of the "update" verb is generally reserved to
    /// indicate modifications to existing objects or data such as changing an existing user's profile information.
    /// </summary>
    let Updated = Verb(VerbId("http://activitystrea.ms/schema/1.0/update"), LanguageMap(LanguageTag.EnglishUS, "updated"))

    /// <summary>
    /// Indicates that the actor has used the object in some manner.
    /// </summary>
    let Used = Verb(VerbId("http://activitystrea.ms/schema/1.0/use"), LanguageMap(LanguageTag.EnglishUS, "used"))

    /// <summary>
    /// Indicates that the actor has viewed the object.
    /// </summary>
    let Viewed = Verb(VerbId("http://id.tincanapi.com/verb/viewed"), LanguageMap(LanguageTag.EnglishUS, "viewed"))

    /// <summary>
    /// A special LRS-reserved verb. Used by the LRS to declare that an activity statement is to be voided from record.
    /// </summary>
    let Voided = Verb(VerbId("http://adlnet.gov/expapi/verbs/voided"), LanguageMap(LanguageTag.EnglishUS, "voided"))

    /// <summary>
    /// Indicates that the actor has voted down a discussion post and given a reason. The reason is stored in the Result
    /// Response and can be "Rude or Inappropriate" or some other value. Consider using http://id.tincanapi.com/verb/voted-down
    /// for down votes that do not fit this pattern. 
    /// </summary>
    let VotedDownWithReason = Verb(VerbId("http://curatr3.com/define/verb/voted-down"), LanguageMap(LanguageTag.EnglishUS, "Voted down (with reason)"))

    /// <summary>
    /// Indicates that the actor has voted up a discussion post and given a reason. The reason is stored in the Result Response
    /// and can be "Started Discussion", "Developed Discussion", "Resolved Discussion" or some other value. Consider using
    /// http://id.tincanapi.com/verb/voted-up for up votes that do not fit this pattern.
    /// </summary>
    let VotedUpWithReason = Verb(VerbId("http://curatr3.com/define/verb/voted-up"), LanguageMap(LanguageTag.EnglishUS, "Voted up (with reason)"))

    /// <summary>
    /// Indicates that the actor walked a distance indicated by the activity
    /// </summary>
    let Walked = Verb(VerbId("https://brindlewaye.com/xAPITerms/verbs/walked/"), LanguageMap(LanguageTag.EnglishUS, "walked"))

    /// <summary>
    /// Indicates that the actor was assigned the job title represented by the object of the statement. This object should use
    /// the activity type http://id.tincanapi.com/activitytype/job-title. This verb is used any time when the person's job title
    /// changes, for example when they are first hired and any time they are promoted, demoted or otherwise change job. 
    /// </summary>
    let WasAssignedJobTitle = Verb(VerbId("http://id.tincanapi.com/verb/was-assigned-job-title"), LanguageMap(LanguageTag.EnglishUS, "Was assigned job title"))

    /// <summary>
    /// Indicates that the actor was located at the object. For instance, a person being at a specific physical location.
    /// </summary>
    let WasAt = Verb(VerbId("http://activitystrea.ms/schema/1.0/at"), LanguageMap(LanguageTag.EnglishUS, "was at"))

    /// <summary>
    /// Indicates that the actor was hired by the organization represented by the object of the statement. 
    /// </summary>
    let WasHiredBy = Verb(VerbId("http://id.tincanapi.com/verb/was-hired-by"), LanguageMap(LanguageTag.EnglishUS, "was hired by"))

    /// <summary>
    /// Indicates that the actor has watched the object. This verb is typically applicable only when the object represents
    /// dynamic, visible content such as a movie, a television show or a public performance. This verb is a more specific form
    /// of the verbs "experience", "play" and "consume".
    /// </summary>
    let Watched = Verb(VerbId("http://activitystrea.ms/schema/1.0/watch"), LanguageMap(LanguageTag.EnglishUS, "Watched"))

    /// <summary>
    /// Indicates that the actor has won the object. This verb is typically applicable only when the object represents some
    /// form of competition, such as a game.
    /// </summary>
    let Won = Verb(VerbId("http://activitystrea.ms/schema/1.0/win"), LanguageMap(LanguageTag.EnglishUS, "won"))
