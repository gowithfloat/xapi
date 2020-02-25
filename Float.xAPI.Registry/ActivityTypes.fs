// <copyright file="Library.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Registry

open System
open Float.xAPI.Languages
open Float.xAPI.Activities.Definitions

// todo: https://registry.tincanapi.com/#home/activityTypes

// endpoints:
// https://registry.tincanapi.com/api/v1/profile
// https://registry.tincanapi.com/api/v1/uris/activityType
// https://registry.tincanapi.com/api/v1/uris/attachmentUsage
// https://registry.tincanapi.com/api/v1/uris/extension
// https://registry.tincanapi.com/api/v1/uris/verb

module ActivityTypes =
    let Alert = ActivityDefinition(LanguageMap.EnglishUS("alert"), 
                                   LanguageMap.EnglishUS("Represents any kind of significant notificiation."), 
                                   Uri("http://activitystrea.ms/schema/1.0/alert"))
