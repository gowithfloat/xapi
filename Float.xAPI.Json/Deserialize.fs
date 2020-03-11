// <copyright file="Deserialize.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Json

open System
open System.Collections.Generic
open System.Xml
open FSharp.Data
open Float.xAPI
open Float.xAPI.Activities
open Float.xAPI.Activities.Definitions
open Float.xAPI.Actor
open Float.xAPI.Actor.Identifier
open Float.xAPI.Languages
open Float.xAPI.Statements

type JsonStatement = JsonProvider<"""
[
    {
        "id": "2a41c918-b88b-4220-20a5-a4c32391a240",
        "actor": {
            "objectType": "Agent",
            "name": "Gert Frobe",
            "account": {
                "homePage": "http://example.adlnet.gov/",
                "name": "1625378"
            }
        },
        "verb": {
            "id": "http://adlnet.gov/expapi/verbs/failed",
            "display": {
                "en-US": "failed"
            }
        },
        "object": {
            "id": "https://example.adlnet.gov/AUidentifier",
            "objectType": "Activity"
        },
        "result": {
          "score": {
            "scaled": 0.65,
            "raw": 65.00,
            "min": 0.00,
            "max": 100.00
          },
            "success": false,
            "duration": "PT30M",
            "extensions": {
                "https://w3id.org/xapi/cmi5/result/extensions/progress": 100
            }
        },
        "context": {
            "registration": "ec231277-b27b-4c15-8291-d29225b2b8f7",
            "contextActivities": {
                "category": [
                    {
                        "id": "https://w3id.org/xapi/cmi5/context/categories/moveon"
                    },
                    {
                        "id": "https://w3id.org/xapi/cmi5/context/categories/cmi5"
                    }
                ]
            },
            "extensions": {
                "https://w3id.org/xapi/cmi5/context/extensions/sessionid": "458240298378231"
            }
        },
        "timestamp": "2012-06-01T19:09:13.245+00:00"
    },
    {
        "id": "fd41c918-b88b-4b20-a0a5-a4c32391aaa0",
        "timestamp": "2015-11-18T12:17:00+00:00",
        "actor": {
            "objectType": "Agent",
            "name": "Project Tin Can API",
            "mbox": "mailto:user@example.com"
        },
        "verb": {
            "id": "http://example.com/xapi/verbs#sent-a-statement",
            "display": {
                "en-US": "sent"
            }
        },
        "object": {
            "id": "http://example.com/xapi/activity/simplestatement",
            "definition": {
                "name": {
                    "en-US": "simple statement"
                },
                "description": {
                    "en-US": "A simple Experience API statement. Note that the LRS does not need to have any prior information about the Actor (learner), the verb, or the Activity/object."
                }
            }
        }
    }
]
""", SampleIsList=true>

type JsonVerb = JsonProvider<"""
{
    "id": "http://adlnet.gov/expapi/verbs/failed",
    "display": {
        "en-US": "failed"
    }
}
""">

type JsonIfi = JsonProvider<"""
[
    {
        "account": {
            "homePage": "http://example.adlnet.gov/",
            "name": "some name"
        }
    },
    {
        "mbox": "mailto:example@example.com"
    },
    {
        "mbox_sha1sum": "ebd31e95054c018b10727ccffd2ef2ec3a016ee9"
    },
    {
        "openid": "http://example.com"
    }
]
""", SampleIsList=true>

type JsonLanguageMap = JsonProvider<"""
{
    "en-US": "failed"
}
""">

type JsonAgent = JsonProvider<"""
[
    {
        "objectType": "Agent",
        "name": "Gert Frobe",
        "account": {
            "homePage": "http://example.adlnet.gov/",
            "name": "Gert"
        }
    },
    {
        "name": "Toby Nichols",
        "openid": "http://toby.openid.example.org/",
        "objectType": "Agent"
    },
    {
        "mbox_sha1sum": "ebd31e95054c018b10727ccffd2ef2ec3a016ee9",
        "objectType": "Agent"
    }
]
""", SampleIsList=true>

type JsonActor = JsonProvider<"""
[
    {
        "objectType": "Agent",
        "name": "Gert Frobe",
        "account": {
            "homePage": "http://example.adlnet.gov/",
            "name": "Gert"
        }
    },
    {
        "name": "Toby Nichols",
        "openid": "http://toby.openid.example.org/",
        "objectType": "Agent"
    },
    {
        "mbox_sha1sum": "ebd31e95054c018b10727ccffd2ef2ec3a016ee9",
        "objectType": "Agent"
    },
    {
        "name": "Team PB",
        "mbox": "mailto:teampb@example.com",
        "objectType": "Group"
    },
    {
        "name": "Example Group",
        "account" : {
            "homePage" : "http://example.com/homePage",
            "name" : "GroupAccount"
        },
        "objectType": "Group",
        "member": [
            {
                "name": "Andrew Downes",
                "mbox": "mailto:andrew@example.com",
                "objectType": "Agent"
            },
            {
                "name": "Aaron Silvers",
                "openid": "http://aaron.openid.example.org",
                "objectType": "Agent"
            }
        ]
    }
]
""", SampleIsList=true>

type JsonResult = JsonProvider<"""
[
    {
        "score": {
            "scaled": 0.65,
            "raw": 65.00,
            "min": 0.00,
            "max": 100.00
        },
        "success": false,
        "duration": "PT30M",
        "extensions": {
            "https://w3id.org/xapi/cmi5/result/extensions/progress": 100
        }
    },
    {
        "score": {
            "scaled": 0.65
        }
    },
    {
        "extensions": {
            "http://example.com/profiles/meetings/resultextensions/minuteslocation": "X:\\meetings\\minutes\\examplemeeting.one"
        },
        "success": true,
        "completion": true,
        "response": "We agreed on some example actions.",
        "duration": "PT1H0M0S"
    }
]
""", SampleIsList=true>

type JsonScore = JsonProvider<"""
[
    {
        "scaled": 0.65,
        "raw": 65.02,
        "min": 0.02,
        "max": 100.02
    },
    {
        "scaled": 0.65
    },
    {
        "raw": 65.01
    }
]
""", SampleIsList=true>

type JsonExtensions = JsonProvider<"""
[
    {
        "http://example.com/profiles/meetings/resultextensions/minuteslocation": "X:\\meetings\\minutes\\examplemeeting.one"
    },
    {
        "https://w3id.org/xapi/cmi5/result/extensions/progress": 100
    }
]
""", SampleIsList=true>

type JsonObject = JsonProvider<"""
[
    {
        "id": "http://example.com/xapi/activity/simplestatement",
        "definition": {
            "name": {
                "en-US": "simple statement"
            },
            "description": {
                "en-US": "A simple Experience API statement. Note that the LRS does not need to have any prior information about the Actor (learner), the verb, or the Activity/object."
            }
        }
    },
    {
        "id": "https://example.adlnet.gov/AUidentifier",
        "objectType": "Activity"
    },
    {
        "id": "http://example.adlnet.gov/xapi/example/simpleCBT",
        "definition": {
            "name": {
                "en-US": "simple CBT course"
            },
            "description": {
                "en-US": "A fictitious example CBT course."
            }
        }
    },
    {
        "id": "http://www.example.com/meetings/occurances/34534",
        "definition": {
            "extensions": {
                "http://example.com/profiles/meetings/activitydefinitionextensions/room": {
                    "name": "Kilby",
                    "id": "http://example.com/rooms/342"
                }
            },
            "name": {
                "en-GB": "example meeting",
                "en-US": "example meeting"
            },
            "description": {
                "en-GB": "An example meeting that happened on a specific occasion with certain people present.",
                "en-US": "An example meeting that happened on a specific occasion with certain people present."
            },
            "type": "http://adlnet.gov/expapi/activities/meeting",
            "moreInfo": "http://virtualmeeting.example.com/345256"
        },
        "objectType": "Activity"
    },
    {
        "id": "http://www.example.co.uk/exampleactivity",
        "definition": {
            "name": {
                "en-GB": "example activity",
                "en-US": "example activity"
            },
            "description": {
                "en-GB": "An example of an activity",
                "en-US": "An example of an activity"
            },
            "type": "http://www.example.co.uk/types/exampleactivitytype"
        },
        "objectType": "Activity"
    }
]
""", SampleIsList=true>

type JsonActivity = JsonProvider<"""
[
    {
        "id": "http://example.com/xapi/activity/simplestatement",
        "definition": {
            "name": {
                "en-US": "simple statement"
            },
            "description": {
                "en-US": "A simple Experience API statement. Note that the LRS does not need to have any prior information about the Actor (learner), the verb, or the Activity/object."
            }
        }
    },
    {
        "id": "https://example.adlnet.gov/AUidentifier",
        "objectType": "Activity"
    },
    {
        "id": "http://example.adlnet.gov/xapi/example/simpleCBT",
        "definition": {
            "name": {
                "en-US": "simple CBT course"
            },
            "description": {
                "en-US": "A fictitious example CBT course."
            }
        }
    },
    {
        "id": "http://www.example.com/meetings/occurances/34534",
        "definition": {
            "extensions": {
                "http://example.com/profiles/meetings/activitydefinitionextensions/room": {
                    "name": "Kilby",
                    "id": "http://example.com/rooms/342"
                }
            },
            "name": {
                "en-GB": "example meeting",
                "en-US": "example meeting"
            },
            "description": {
                "en-GB": "An example meeting that happened on a specific occasion with certain people present.",
                "en-US": "An example meeting that happened on a specific occasion with certain people present."
            },
            "type": "http://adlnet.gov/expapi/activities/meeting",
            "moreInfo": "http://virtualmeeting.example.com/345256"
        },
        "objectType": "Activity"
    },
    {
        "id": "http://www.example.co.uk/exampleactivity",
        "definition": {
            "name": {
                "en-GB": "example activity",
                "en-US": "example activity"
            },
            "description": {
                "en-GB": "An example of an activity",
                "en-US": "An example of an activity"
            },
            "type": "http://www.example.co.uk/types/exampleactivitytype"
        },
        "objectType": "Activity"
    }
]
""", SampleIsList=true>

type JsonDefinition = JsonProvider<"""
[
    {
        "name": {
            "en-US": "simple statement"
        }
    },
    {
        "description": {
            "en-US": "A simple Experience API statement. Note that the LRS does not need to have any prior information about the Actor (learner), the verb, or the Activity/object."
        }
    },
    {
        "name": {
            "en-GB": "simple CBT course"
        },
        "description": {
            "en-GB": "A fictitious example CBT course."
        }
    },
    {
        "extensions": {
            "http://example.com/profiles/meetings/activitydefinitionextensions/room": {
                "name": "Kilby",
                "id": "http://example.com/rooms/342"
            }
        },
        "name": {
            "en-GB": "example meeting",
            "en-US": "example meeting"
        },
        "description": {
            "en-GB": "An example meeting that happened on a specific occasion with certain people present.",
            "en-US": "An example meeting that happened on a specific occasion with certain people present."
        },
        "type": "http://adlnet.gov/expapi/activities/meeting",
        "moreInfo": "http://virtualmeeting.example.com/345256"
    }
]
""", SampleIsList=true>

module Deserialize =
    /// <summary>
    /// Convert a JSON string to a language map.
    /// </summary>
    let ParseLanguageMap str = 
        JsonLanguageMap.Parse(str).JsonValue.Properties()
        |> Seq.map (fun (k,v) -> LanguagePair(LanguageTag.FromString(k).Value, v.AsString()))
        |> LanguageMap
        :> ILanguageMap

    /// <summary>
    /// Convert a JSON string to a list of extensions.
    /// </summary>
    let ParseExtensions str =
        JsonExtensions.Parse(str).JsonValue.Properties()
        |> Seq.map(fun (k,v) -> KeyValuePair(Uri(k), v.AsString() :> obj))
        |> Some

    /// <summary>
    /// Convert a JSON string to a verb.
    /// </summary>
    let ParseVerb str =
        let des = JsonVerb.Parse(str)
        let dis = des.Display.JsonValue.ToString() |> ParseLanguageMap
        Verb(VerbId(des.Id), dis) |> Some

    /// <summary>
    /// Convert a JSON string to an inverse functional identifier.
    /// </summary>
    let ParseIFI str = 
        let des = JsonIfi.Parse(str)

        match des.Account, des.Mbox, des.MboxSha1sum, des.Openid with
        | Some acc, None, None, None -> Account(acc.Name, Uri(acc.HomePage)) :> IInverseFunctionalIdentifier |> Some
        | None, Some box, None, None -> Mailbox(Uri(box)) :> IInverseFunctionalIdentifier |> Some
        | None, None, Some sha, None -> MailboxSha1Sum(SHAHash(sha)) :> IInverseFunctionalIdentifier |> Some
        | None, None, None, Some id -> OpenID(Uri(id)) :> IInverseFunctionalIdentifier |> Some
        | _ -> None

    /// <summary>
    /// Convert a JSON string to an agent.
    /// </summary>
    let ParseAgent str =
        let des = JsonAgent.Parse(str)
        match ParseIFI str with
        | Some ifi -> Agent(ifi, ?name=des.Name) :> IAgent |> Some
        | _ -> None

    /// <summary>
    /// Convert a JSON string to an actor.
    /// </summary>
    let ParseActor str =
        let des = JsonActor.Parse(str)

        match ParseIFI str with
        | Some ifi -> match des.ObjectType with
                      | "Agent" -> Agent(ifi, ?name=des.Name) :> IActor |> Some
                      | "Group" -> IdentifiedGroup(ifi, ?name=des.Name) :> IActor |> Some
                      | _ -> None
        | _ -> match des.ObjectType with
               | "Group" -> AnonymousGroup(des.Member |> Seq.map (fun k -> (ParseAgent(k.JsonValue.AsString()))) |> Seq.choose id, ?name=des.Name) :> IActor |> Some
               | _ -> None

    let ParseDefinition str =
        let des = JsonDefinition.Parse(str)
        let name = match des.Name with
                   | Some name -> name.JsonValue.ToString() |> ParseLanguageMap |> Some
                   | _ -> None
        let description = match des.Description with
                          | Some desc -> desc.JsonValue.ToString() |> ParseLanguageMap |> Some
                          | _ -> None
        ActivityDefinition(?name=name, ?description=description)
        :> IActivityDefinition
        |> Some

    let ParseActivity str =
        let des = JsonActivity.Parse(str)
        let definition = match des.Definition with
                         | Some def -> def.JsonValue.ToString() |> ParseDefinition
                         | _ -> None
        Activity(ActivityId(des.Id),
                 ?definition=definition)


    /// <summary>
    /// Convert a JSON string to an object.
    /// </summary>
    let ParseObject str =
        let des = JsonObject.Parse(str)

        match des.ObjectType with
        | Some objectType -> 
            match objectType |> ObjectType.FromString with
            | Some Agent -> invalidArg "todo" "todo"
            | Some Group -> invalidArg "todo" "todo"
            | Some SubStatement -> invalidArg "todo" "todo"
            | Some StatementReference -> invalidArg "todo" "todo"
            | _ -> str |> ParseActivity :> IObject |> Some // default to activity if no object type exists
        | None -> str |> ParseActivity :> IObject |> Some // default to activity if no object type exists

    /// <summary>
    /// Convert a JSON string to a score.
    /// </summary>
    let ParseScore str =
        let des = JsonScore.Parse(str)

        match des.Raw, des.Min, des.Max, des.Scaled with
        | Some a, Some b, Some c, _ -> Score(float a, float b, float c) :> IScore |> Some
        | None, None, None, Some d -> Score(float d) :> IScore |> Some
        | _ -> None

    /// <summary>
    /// Convert a JSON string to a result.
    /// </summary>
    let ParseResult str =
        let des = JsonResult.Parse(str)
        let ext = match des.Extensions with
                  | Some e -> e.JsonValue.ToString() |> ParseExtensions
                  | _ -> None
        let score = match des.Score with
                    | Some e -> e.JsonValue.ToString() |> ParseScore
                    | _ -> None
        let duration = match des.Duration with
                       | Some d -> d |> XmlConvert.ToTimeSpan |> Some
                       | _ -> None
                       
        Result(?score=score, 
               ?success=des.Success, 
               ?completion=des.Completion, 
               ?response=des.Response,
               ?duration=duration,
               ?extensions=ext) :> IResult |> Some

    /// <summary>
    /// Convert a JSON string to a statement.
    /// </summary>
    let ParseStatement str =
        let des = JsonStatement.Parse(str)
        let id = des.Id
        let time = des.Timestamp |> Some
        let actor = des.Actor.JsonValue.ToString() |> ParseActor
        let verb = des.Verb.JsonValue.ToString() |> ParseVerb
        let object = des.Object.JsonValue.ToString() |> ParseObject

        let result = match des.Result with
                     | Some result -> result.JsonValue.ToString() |> ParseResult
                     | None -> None

        match actor, verb, object with
        | Some a, Some v, Some o -> Statement(a, v, o, id, ?result=result, ?timestamp=time) :> IStatement |> Some
        | _ -> None
        