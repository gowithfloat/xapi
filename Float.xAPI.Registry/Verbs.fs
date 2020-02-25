﻿// <copyright file="Verbs.fs" company="Float">
// Copyright (c) 2019 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Registry

open Float.xAPI
open Float.xAPI.Languages

module Verbs =
    let Accepted = Verb(VerbId("http://activitystrea.ms/schema/1.0/accept"), LanguageMap(LanguageTag.EnglishUS, "accepted"))
    let Accessed = Verb(VerbId("http://activitystrea.ms/schema/1.0/access"), LanguageMap(LanguageTag.EnglishUS, "accessed"))
    let Acknowledged = Verb(VerbId("http://activitystrea.ms/schema/1.0/acknowledge"), LanguageMap(LanguageTag.EnglishUS, "acknowledged"))
    let Added = Verb(VerbId("http://activitystrea.ms/schema/1.0/add"), LanguageMap(LanguageTag.EnglishUS, "added"))
    let Adjourned = Verb(VerbId("http://id.tincanapi.com/verb/adjourned"), LanguageMap(LanguageTag.EnglishUS, "adjourned"))
    let Agreed = Verb(VerbId("http://activitystrea.ms/schema/1.0/agree"), LanguageMap(LanguageTag.EnglishUS, "agreed"))
    let Annotated = Verb(VerbId("http://risc-inc.com/annotator/verbs/annotated"), LanguageMap(LanguageTag.EnglishUS, "Annotated"))
    let Answered = Verb(VerbId("http://adlnet.gov/expapi/verbs/answered"), LanguageMap(LanguageTag.EnglishUS, "answered"))
    let Appended = Verb(VerbId("http://activitystrea.ms/schema/1.0/append"), LanguageMap(LanguageTag.EnglishUS, "appended"))
    let Applauded = Verb(VerbId("http://id.tincanapi.com/verb/applauded"), LanguageMap(LanguageTag.EnglishUS, "Applauded"))
    let Approved = Verb(VerbId("http://activitystrea.ms/schema/1.0/approve"), LanguageMap(LanguageTag.EnglishUS, "approved"))
    let Archived = Verb(VerbId("http://activitystrea.ms/schema/1.0/archive"), LanguageMap(LanguageTag.EnglishUS, "archived"))
    let Arranged = Verb(VerbId("http://id.tincanapi.com/verb/arranged"), LanguageMap(LanguageTag.EnglishUS, "arranged"))
    let Asked = Verb(VerbId("http://adlnet.gov/expapi/verbs/asked"), LanguageMap(LanguageTag.EnglishUS, "asked"))
    let Assigned = Verb(VerbId("http://activitystrea.ms/schema/1.0/assign"), LanguageMap(LanguageTag.EnglishUS, "assigned"))
    let Attached = Verb(VerbId("http://activitystrea.ms/schema/1.0/attach"), LanguageMap(LanguageTag.EnglishUS, "attached"))
    let Attempted = Verb(VerbId("http://adlnet.gov/expapi/verbs/attempted"), LanguageMap(LanguageTag.EnglishUS, "attempted"))
    let Attended = Verb(VerbId("http://adlnet.gov/expapi/verbs/attended"), LanguageMap(LanguageTag.EnglishUS, "attended"))
    let Authored = Verb(VerbId("http://activitystrea.ms/schema/1.0/author"), LanguageMap(LanguageTag.EnglishUS, "authored"))
    let Authorized = Verb(VerbId("http://activitystrea.ms/schema/1.0/authorize"), LanguageMap(LanguageTag.EnglishUS, "authorized"))
    let Bookmarked = Verb(VerbId("http://id.tincanapi.com/verb/bookmarked"), LanguageMap(LanguageTag.EnglishUS, "bookmarked"))
    let Borrowed = Verb(VerbId("http://activitystrea.ms/schema/1.0/borrow"), LanguageMap(LanguageTag.EnglishUS, "borrowed"))
    let Built = Verb(VerbId("http://activitystrea.ms/schema/1.0/build"), LanguageMap(LanguageTag.EnglishUS, "built"))
    let Called = Verb(VerbId("http://id.tincanapi.com/verb/called"), LanguageMap(LanguageTag.EnglishUS, "called"))
    let Canceled = Verb(VerbId("http://activitystrea.ms/schema/1.0/cancel"), LanguageMap(LanguageTag.EnglishUS, "canceled"))
    let CancelledPlannedLearning = Verb(VerbId("http://www.tincanapi.co.uk/pages/verbs.html#cancelled_planned_learning"), LanguageMap(LanguageTag.EnglishUS, "cancelled planned learning"))
    let CheckedIn = Verb(VerbId("http://activitystrea.ms/schema/1.0/checkin"), LanguageMap(LanguageTag.EnglishUS, "checked in"))
    let Closed = Verb(VerbId("http://activitystrea.ms/schema/1.0/close"), LanguageMap(LanguageTag.EnglishUS, "closed"))
    let ClosedSale = Verb(VerbId("http://id.tincanapi.com/verb/closed-sale"), LanguageMap(LanguageTag.EnglishUS, "closed sale"))
    let Commented = Verb(VerbId("http://adlnet.gov/expapi/verbs/commented"), LanguageMap(LanguageTag.EnglishUS, "commented"))
    let Completed = Verb(VerbId("http://adlnet.gov/expapi/verbs/completed"), LanguageMap(LanguageTag.EnglishUS, "completed"))
    let Confirmed = Verb(VerbId("http://activitystrea.ms/schema/1.0/confirm"), LanguageMap(LanguageTag.EnglishUS, "confirmed"))
    let Consumed = Verb(VerbId("http://activitystrea.ms/schema/1.0/consume"), LanguageMap(LanguageTag.EnglishUS, "consumed"))
    let Created = Verb(VerbId("http://activitystrea.ms/schema/1.0/create"), LanguageMap(LanguageTag.EnglishUS, "created"))
    let CreatedOpportunity = Verb(VerbId("http://id.tincanapi.com/verb/created-opportunity"), LanguageMap(LanguageTag.EnglishUS, "created opportunity"))
    let Defined = Verb(VerbId("http://id.tincanapi.com/verb/defined"), LanguageMap(LanguageTag.EnglishUS, "defined"))
    let Deleted = Verb(VerbId("http://activitystrea.ms/schema/1.0/delete"), LanguageMap(LanguageTag.EnglishUS, "deleted"))
    let Delivered = Verb(VerbId("http://activitystrea.ms/schema/1.0/deliver"), LanguageMap(LanguageTag.EnglishUS, "delivered"))
    let Denied = Verb(VerbId("http://activitystrea.ms/schema/1.0/deny"), LanguageMap(LanguageTag.EnglishUS, "denied"))
    let Disabled = Verb(VerbId("http://id.tincanapi.com/verb/disabled"), LanguageMap(LanguageTag.EnglishUS, "disabled"))
    let Disagreed = Verb(VerbId("http://activitystrea.ms/schema/1.0/disagree"), LanguageMap(LanguageTag.EnglishUS, "disagreed"))
    let Discarded = Verb(VerbId("http://id.tincanapi.com/verb/discarded"), LanguageMap(LanguageTag.EnglishUS, "discarded"))
    let Disliked = Verb(VerbId("http://activitystrea.ms/schema/1.0/dislike"), LanguageMap(LanguageTag.EnglishUS, "disliked"))
    let DownVoted = Verb(VerbId("http://id.tincanapi.com/verb/voted-down"), LanguageMap(LanguageTag.EnglishUS, "down voted"))
    let Downloaded = Verb(VerbId("http://id.tincanapi.com/verb/downloaded"), LanguageMap(LanguageTag.EnglishUS, "Downloaded"))
    let Drew = Verb(VerbId("http://www.digital-knowledge.co.jp/tincanapi/verbs/drew"), LanguageMap(LanguageTag.EnglishUS, "drew"))
    let Earned = Verb(VerbId("http://id.tincanapi.com/verb/earned"), LanguageMap(LanguageTag.EnglishUS, "earned"))
    let EarnedAnOpenBadge = Verb(VerbId("http://specification.openbadges.org/xapi/verbs/earned"), LanguageMap(LanguageTag.EnglishUS, "Earned an Open Badge"))
    let Edited = Verb(VerbId("http://curatr3.com/define/verb/edited"), LanguageMap(LanguageTag.EnglishUS, "Edited"))
    let Enabled = Verb(VerbId("http://id.tincanapi.com/verb/enabled"), LanguageMap(LanguageTag.EnglishUS, "enabled"))
    let EnrolledOntoLearningPlan = Verb(VerbId("http://www.tincanapi.co.uk/verbs/enrolled_onto_learning_plan"), LanguageMap(LanguageTag.EnglishUS, "enrolled onto learning plan"))
    let EnteredFrame = Verb(VerbId("http://id.tincanapi.com/verb/frame/entered"), LanguageMap(LanguageTag.EnglishUS, "entered frame"))
    let EstimatedTheDuration = Verb(VerbId("http://id.tincanapi.com/verb/estimated-duration"), LanguageMap(LanguageTag.EnglishUS, "estimated the duration"))
    let Evaluated = Verb(VerbId("http://www.tincanapi.co.uk/verbs/evaluated"), LanguageMap(LanguageTag.EnglishUS, "evaluated"))
    let Exited = Verb(VerbId("http://adlnet.gov/expapi/verbs/exited"), LanguageMap(LanguageTag.EnglishUS, "exited"))
    let ExitedFrame = Verb(VerbId("http://id.tincanapi.com/verb/frame/exited"), LanguageMap(LanguageTag.EnglishUS, "exited frame"))
    let Expected = Verb(VerbId("http://id.tincanapi.com/verb/expected"), LanguageMap(LanguageTag.EnglishUS, "expected"))
    let Experienced = Verb(VerbId("http://adlnet.gov/expapi/verbs/experienced"), LanguageMap(LanguageTag.EnglishUS, "experienced"))
    let Expired = Verb(VerbId("http://id.tincanapi.com/verb/expired"), LanguageMap(LanguageTag.EnglishUS, "Expired"))
    let Failed = Verb(VerbId("http://adlnet.gov/expapi/verbs/failed"), LanguageMap(LanguageTag.EnglishUS, "failed"))
    let Favorited = Verb(VerbId("http://activitystrea.ms/schema/1.0/favorite"), LanguageMap(LanguageTag.EnglishUS, "favorited"))
    let FlaggedAsInappropriate = Verb(VerbId("http://activitystrea.ms/schema/1.0/flag-as-inappropriate"), LanguageMap(LanguageTag.EnglishUS, "flagged as inappropriate"))
    let Focused = Verb(VerbId("http://id.tincanapi.com/verb/focused"), LanguageMap(LanguageTag.EnglishUS, "focused"))
    let Followed = Verb(VerbId("http://activitystrea.ms/schema/1.0/follow"), LanguageMap(LanguageTag.EnglishUS, "followed"))
    let Found = Verb(VerbId("http://activitystrea.ms/schema/1.0/find"), LanguageMap(LanguageTag.EnglishUS, "found"))
    let Gave = Verb(VerbId("http://activitystrea.ms/schema/1.0/give"), LanguageMap(LanguageTag.EnglishUS, "gave"))
    let Hired = Verb(VerbId("http://id.tincanapi.com/verb/hired"), LanguageMap(LanguageTag.EnglishUS, "Hired"))
    let Hosted = Verb(VerbId("http://activitystrea.ms/schema/1.0/host"), LanguageMap(LanguageTag.EnglishUS, "hosted"))
    let Ignored = Verb(VerbId("http://activitystrea.ms/schema/1.0/ignore"), LanguageMap(LanguageTag.EnglishUS, "ignored"))
    let Imported = Verb(VerbId("http://adlnet.gov/expapi/verbs/imported"), LanguageMap(LanguageTag.EnglishUS, "imported"))
    let Initialized = Verb(VerbId("http://adlnet.gov/expapi/verbs/initialized"), LanguageMap(LanguageTag.EnglishUS, "initialized"))
    let Inserted = Verb(VerbId("http://activitystrea.ms/schema/1.0/insert"), LanguageMap(LanguageTag.EnglishUS, "inserted"))
    let Installed = Verb(VerbId("http://activitystrea.ms/schema/1.0/install"), LanguageMap(LanguageTag.EnglishUS, "installed"))
    let Interacted = Verb(VerbId("http://adlnet.gov/expapi/verbs/interacted"), LanguageMap(LanguageTag.EnglishUS, "interacted"))
    let Interviewed = Verb(VerbId("http://id.tincanapi.com/verb/interviewed"), LanguageMap(LanguageTag.EnglishUS, "Interviewed"))
    let Invited = Verb(VerbId("http://activitystrea.ms/schema/1.0/invite"), LanguageMap(LanguageTag.EnglishUS, "invited"))
    let Joined = Verb(VerbId("http://activitystrea.ms/schema/1.0/join"), LanguageMap(LanguageTag.EnglishUS, "joined"))
    let Laughed = Verb(VerbId("http://id.tincanapi.com/verb/laughed"), LanguageMap(LanguageTag.EnglishUS, "Laughed"))
    let Launched = Verb(VerbId("http://adlnet.gov/expapi/verbs/launched"), LanguageMap(LanguageTag.EnglishUS, "launched"))
    let Left = Verb(VerbId("http://activitystrea.ms/schema/1.0/leave"), LanguageMap(LanguageTag.EnglishUS, "left"))
    let Liked = Verb(VerbId("http://activitystrea.ms/schema/1.0/like"), LanguageMap(LanguageTag.EnglishUS, "liked"))
    let Listened = Verb(VerbId("http://activitystrea.ms/schema/1.0/listen"), LanguageMap(LanguageTag.EnglishUS, "listened"))
    let LogIn = Verb(VerbId("https://brindlewaye.com/xAPITerms/verbs/loggedin/"), LanguageMap(LanguageTag.EnglishUS, "Log In"))
    let LogOut = Verb(VerbId("https://brindlewaye.com/xAPITerms/verbs/loggedout/"), LanguageMap(LanguageTag.EnglishUS, "Log Out"))
    let Lost = Verb(VerbId("http://activitystrea.ms/schema/1.0/lose"), LanguageMap(LanguageTag.EnglishUS, "lost"))
    let MadeFriend = Verb(VerbId("http://activitystrea.ms/schema/1.0/make-friend"), LanguageMap(LanguageTag.EnglishUS, "made friend"))
    let Mastered = Verb(VerbId("http://adlnet.gov/expapi/verbs/mastered"), LanguageMap(LanguageTag.EnglishUS, "mastered"))
    let Mentioned = Verb(VerbId("http://id.tincanapi.com/verb/mentioned"), LanguageMap(LanguageTag.EnglishUS, "Mentioned"))
    let Mentored = Verb(VerbId("http://id.tincanapi.com/verb/mentored"), LanguageMap(LanguageTag.EnglishUS, "mentored"))
    let ModifiedAnnotation = Verb(VerbId("http://risc-inc.com/annotator/verbs/modified"), LanguageMap(LanguageTag.EnglishUS, "Modified annotation"))
    let Opened = Verb(VerbId("http://activitystrea.ms/schema/1.0/open"), LanguageMap(LanguageTag.EnglishUS, "opened"))
    let Passed = Verb(VerbId("http://adlnet.gov/expapi/verbs/passed"), LanguageMap(LanguageTag.EnglishUS, "passed"))
    let Paused = Verb(VerbId("http://id.tincanapi.com/verb/paused"), LanguageMap(LanguageTag.EnglishUS, "paused"))
    let Performed = Verb(VerbId("http://id.tincanapi.com/verb/performed-offline"), LanguageMap(LanguageTag.EnglishUS, "performed"))
    let Personalized = Verb(VerbId("http://id.tincanapi.com/verb/personalized"), LanguageMap(LanguageTag.EnglishUS, "personalized"))
    let Planned = Verb(VerbId("http://www.tincanapi.co.uk/pages/verbs.html#planned_learning"), LanguageMap(LanguageTag.EnglishUS, "Planned"))
    let Played = Verb(VerbId("http://activitystrea.ms/schema/1.0/play"), LanguageMap(LanguageTag.EnglishUS, "Played"))
    let Preferred = Verb(VerbId("http://adlnet.gov/expapi/verbs/preferred"), LanguageMap(LanguageTag.EnglishUS, "preferred"))
    let Presented = Verb(VerbId("http://activitystrea.ms/schema/1.0/present"), LanguageMap(LanguageTag.EnglishUS, "presented"))
    let Pressed = Verb(VerbId("http://future-learning.info/xAPI/verb/pressed"), LanguageMap(LanguageTag.EnglishUS, "pressed"))
    let Previewed = Verb(VerbId("http://id.tincanapi.com/verb/previewed"), LanguageMap(LanguageTag.EnglishUS, "previewed"))
    let Progressed = Verb(VerbId("http://adlnet.gov/expapi/verbs/progressed"), LanguageMap(LanguageTag.EnglishUS, "progressed"))
    let Promoted = Verb(VerbId("http://id.tincanapi.com/verb/promoted"), LanguageMap(LanguageTag.EnglishUS, "Promoted"))
    let Purchased = Verb(VerbId("http://activitystrea.ms/schema/1.0/purchase"), LanguageMap(LanguageTag.EnglishUS, "purchased"))
    let Qualified = Verb(VerbId("http://activitystrea.ms/schema/1.0/qualify"), LanguageMap(LanguageTag.EnglishUS, "qualified"))
    let Ran = Verb(VerbId("https://brindlewaye.com/xAPITerms/verbs/ran/"), LanguageMap(LanguageTag.EnglishUS, "ran"))
    let Rated = Verb(VerbId("http://id.tincanapi.com/verb/rated"), LanguageMap(LanguageTag.EnglishUS, "rated"))
    let Read = Verb(VerbId("http://activitystrea.ms/schema/1.0/read"), LanguageMap(LanguageTag.EnglishUS, "read"))
    let Received = Verb(VerbId("http://activitystrea.ms/schema/1.0/receive"), LanguageMap(LanguageTag.EnglishUS, "received"))
    let Registered = Verb(VerbId("http://adlnet.gov/expapi/verbs/registered"), LanguageMap(LanguageTag.EnglishUS, "registered"))
    let Rejected = Verb(VerbId("http://activitystrea.ms/schema/1.0/reject"), LanguageMap(LanguageTag.EnglishUS, "rejected"))
    let Released = Verb(VerbId("http://future-learning.info/xAPI/verb/released"), LanguageMap(LanguageTag.EnglishUS, "released"))
    let Removed = Verb(VerbId("http://activitystrea.ms/schema/1.0/remove"), LanguageMap(LanguageTag.EnglishUS, "removed"))
    let RemovedFriend = Verb(VerbId("http://activitystrea.ms/schema/1.0/remove-friend"), LanguageMap(LanguageTag.EnglishUS, "removed friend"))
    let Replaced = Verb(VerbId("http://activitystrea.ms/schema/1.0/replace"), LanguageMap(LanguageTag.EnglishUS, "replaced"))
    let Replied = Verb(VerbId("http://id.tincanapi.com/verb/replied"), LanguageMap(LanguageTag.EnglishUS, "Replied"))
    let RepliedToTweet = Verb(VerbId("http://id.tincanapi.com/verb/replied-to-tweet"), LanguageMap(LanguageTag.EnglishUS, "replied to tweet"))
    let Requested = Verb(VerbId("http://activitystrea.ms/schema/1.0/request"), LanguageMap(LanguageTag.EnglishUS, "requested"))
    let RequestedAttention = Verb(VerbId("http://id.tincanapi.com/verb/requested-attention"), LanguageMap(LanguageTag.EnglishUS, "requested attention"))
    let RequestedFriend = Verb(VerbId("http://activitystrea.ms/schema/1.0/request-friend"), LanguageMap(LanguageTag.EnglishUS, "requested friend"))
    let Resolved = Verb(VerbId("http://activitystrea.ms/schema/1.0/resolve"), LanguageMap(LanguageTag.EnglishUS, "resolved"))
    let Responded = Verb(VerbId("http://adlnet.gov/expapi/verbs/responded"), LanguageMap(LanguageTag.EnglishUS, "responded"))
    let Resumed = Verb(VerbId("http://adlnet.gov/expapi/verbs/resumed"), LanguageMap(LanguageTag.EnglishUS, "resumed"))
    let Retracted = Verb(VerbId("http://activitystrea.ms/schema/1.0/retract"), LanguageMap(LanguageTag.EnglishUS, "retracted"))
    let Returned = Verb(VerbId("http://activitystrea.ms/schema/1.0/return"), LanguageMap(LanguageTag.EnglishUS, "returned"))
    let Retweeted = Verb(VerbId("http://id.tincanapi.com/verb/retweeted"), LanguageMap(LanguageTag.EnglishUS, "retweeted"))
    let Reviewed = Verb(VerbId("http://id.tincanapi.com/verb/reviewed"), LanguageMap(LanguageTag.EnglishUS, "reviewed"))
    let RsvpedMaybe = Verb(VerbId("http://activitystrea.ms/schema/1.0/rsvp-maybe"), LanguageMap(LanguageTag.EnglishUS, "RSVPed maybe"))
    let RsvpedNo = Verb(VerbId("http://activitystrea.ms/schema/1.0/rsvp-no"), LanguageMap(LanguageTag.EnglishUS, "rsvped no"))
    let RsvpedYes = Verb(VerbId("http://activitystrea.ms/schema/1.0/rsvp-yes"), LanguageMap(LanguageTag.EnglishUS, "rsvped yes"))
    let Satisfied = Verb(VerbId("http://activitystrea.ms/schema/1.0/satisfy"), LanguageMap(LanguageTag.EnglishUS, "satisfied"))
    let Saved = Verb(VerbId("http://activitystrea.ms/schema/1.0/save"), LanguageMap(LanguageTag.EnglishUS, "saved"))
    let Scheduled = Verb(VerbId("http://activitystrea.ms/schema/1.0/schedule"), LanguageMap(LanguageTag.EnglishUS, "scheduled"))
    let Scored = Verb(VerbId("http://adlnet.gov/expapi/verbs/scored"), LanguageMap(LanguageTag.EnglishUS, "scored"))
    let Searched = Verb(VerbId("http://activitystrea.ms/schema/1.0/search"), LanguageMap(LanguageTag.EnglishUS, "searched"))
    let Secured = Verb(VerbId("http://id.tincanapi.com/verb/secured"), LanguageMap(LanguageTag.EnglishUS, "Secured"))
    let Selected = Verb(VerbId("http://id.tincanapi.com/verb/selected"), LanguageMap(LanguageTag.EnglishUS, "selected"))
    let Sent = Verb(VerbId("http://activitystrea.ms/schema/1.0/send"), LanguageMap(LanguageTag.EnglishUS, "sent"))
    let Shared = Verb(VerbId("http://adlnet.gov/expapi/verbs/shared"), LanguageMap(LanguageTag.EnglishUS, "shared"))
    let Skipped = Verb(VerbId("http://id.tincanapi.com/verb/skipped"), LanguageMap(LanguageTag.EnglishUS, "skipped"))
    let Sold = Verb(VerbId("http://activitystrea.ms/schema/1.0/sell"), LanguageMap(LanguageTag.EnglishUS, "sold"))
    let Sponsored = Verb(VerbId("http://activitystrea.ms/schema/1.0/sponsor"), LanguageMap(LanguageTag.EnglishUS, "sponsored"))
    let Started = Verb(VerbId("http://activitystrea.ms/schema/1.0/start"), LanguageMap(LanguageTag.EnglishUS, "started"))
    let StoppedFollowing = Verb(VerbId("http://activitystrea.ms/schema/1.0/stop-following"), LanguageMap(LanguageTag.EnglishUS, "stopped following"))
    let Submitted = Verb(VerbId("http://activitystrea.ms/schema/1.0/submit"), LanguageMap(LanguageTag.EnglishUS, "submitted"))
    let Suspended = Verb(VerbId("http://adlnet.gov/expapi/verbs/suspended"), LanguageMap(LanguageTag.EnglishUS, "suspended"))
    let Tagged = Verb(VerbId("http://activitystrea.ms/schema/1.0/tag"), LanguageMap(LanguageTag.EnglishUS, "tagged"))
    let Talked = Verb(VerbId("http://id.tincanapi.com/verb/talked-with"), LanguageMap(LanguageTag.EnglishUS, "talked"))
    let Terminated = Verb(VerbId("http://adlnet.gov/expapi/verbs/terminated"), LanguageMap(LanguageTag.EnglishUS, "terminated"))
    let TerminatedEmploymentWith = Verb(VerbId("http://id.tincanapi.com/verb/terminated-employment-with"), LanguageMap(LanguageTag.EnglishUS, "Terminated employment with"))
    let Tied = Verb(VerbId("http://activitystrea.ms/schema/1.0/tie"), LanguageMap(LanguageTag.EnglishUS, "tied"))
    let Tweeted = Verb(VerbId("http://id.tincanapi.com/verb/tweeted"), LanguageMap(LanguageTag.EnglishUS, "tweeted"))
    let Unfavorited = Verb(VerbId("http://activitystrea.ms/schema/1.0/unfavorite"), LanguageMap(LanguageTag.EnglishUS, "unfavorited"))
    let Unfocused = Verb(VerbId("http://id.tincanapi.com/verb/unfocused"), LanguageMap(LanguageTag.EnglishUS, "unfocused"))
    let Unliked = Verb(VerbId("http://activitystrea.ms/schema/1.0/unlike"), LanguageMap(LanguageTag.EnglishUS, "unliked"))
    let Unread = Verb(VerbId("http://id.tincanapi.com/verb/marked-unread"), LanguageMap(LanguageTag.EnglishUS, "Unread"))
    let Unregistered = Verb(VerbId("http://id.tincanapi.com/verb/unregistered"), LanguageMap(LanguageTag.EnglishUS, "unregistered"))
    let Unsatisfied = Verb(VerbId("http://activitystrea.ms/schema/1.0/unsatisfy"), LanguageMap(LanguageTag.EnglishUS, "unsatisfied"))
    let Unsaved = Verb(VerbId("http://activitystrea.ms/schema/1.0/unsave"), LanguageMap(LanguageTag.EnglishUS, "unsaved"))
    let Unshared = Verb(VerbId("http://activitystrea.ms/schema/1.0/unshare"), LanguageMap(LanguageTag.EnglishUS, "unshared"))
    let UpVoted = Verb(VerbId("http://id.tincanapi.com/verb/voted-up"), LanguageMap(LanguageTag.EnglishUS, "up voted"))
    let Updated = Verb(VerbId("http://activitystrea.ms/schema/1.0/update"), LanguageMap(LanguageTag.EnglishUS, "updated"))
    let Used = Verb(VerbId("http://activitystrea.ms/schema/1.0/use"), LanguageMap(LanguageTag.EnglishUS, "used"))
    let Viewed = Verb(VerbId("http://id.tincanapi.com/verb/viewed"), LanguageMap(LanguageTag.EnglishUS, "viewed"))
    let Voided = Verb(VerbId("http://adlnet.gov/expapi/verbs/voided"), LanguageMap(LanguageTag.EnglishUS, "voided"))
    let VotedDown = Verb(VerbId("http://curatr3.com/define/verb/voted-down"), LanguageMap(LanguageTag.EnglishUS, "Voted down (with reason)"))
    let VotedUp = Verb(VerbId("http://curatr3.com/define/verb/voted-up"), LanguageMap(LanguageTag.EnglishUS, "Voted up (with reason)"))
    let Walked = Verb(VerbId("https://brindlewaye.com/xAPITerms/verbs/walked/"), LanguageMap(LanguageTag.EnglishUS, "walked"))
    let WasAssignedJobTitle = Verb(VerbId("http://id.tincanapi.com/verb/was-assigned-job-title"), LanguageMap(LanguageTag.EnglishUS, "Was assigned job title"))
    let WasAt = Verb(VerbId("http://activitystrea.ms/schema/1.0/at"), LanguageMap(LanguageTag.EnglishUS, "was at"))
    let WasHiredBy = Verb(VerbId("http://id.tincanapi.com/verb/was-hired-by"), LanguageMap(LanguageTag.EnglishUS, "was hired by"))
    let Watched = Verb(VerbId("http://activitystrea.ms/schema/1.0/watch"), LanguageMap(LanguageTag.EnglishUS, "Watched"))
    let Won = Verb(VerbId("http://activitystrea.ms/schema/1.0/win"), LanguageMap(LanguageTag.EnglishUS, "won"))
