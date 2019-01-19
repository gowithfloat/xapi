// <copyright file="StateId.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Resources.Documents

// todo: prohibit empty strings as state IDs; may not be possible with a discriminated union of one
// todo: StateId/ActivityId/ProfileId equality operators seem to use reference equality

/// <summary>
/// Set by Learning Record Provider, unique within the scope of the Agent or Activity.
/// </summary>
type StateId = StateId of string
