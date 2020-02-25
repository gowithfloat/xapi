// <copyright file="Verbs.fs" company="Float">
// Copyright (c) 2019 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Registry

open Float.xAPI
open Float.xAPI.Languages

// todo: https://registry.tincanapi.com/#home/verbs

module Verbs =
    let Accepted = Verb(VerbId("http://activitystrea.ms/schema/1.0/accept"), LanguageMap.EnglishUS("accepted"))
    let Accessed = Verb(VerbId("http://activitystrea.ms/schema/1.0/access"), LanguageMap.EnglishUS("accessed"))
