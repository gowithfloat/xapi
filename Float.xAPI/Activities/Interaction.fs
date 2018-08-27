// <copyright file="Interaction.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Activities

/// <summary>
/// These types of interactions were originally based on the types of interactions allowed for "cmi.interactions.n.type" in the SCORM 2004 4th Edition Run-Time Environment.
/// </summary>
type Interaction = 
    /// <summary>
    /// An interaction with two possible responses: true or false.
    /// </summary>
    | TrueFalse

    /// <summary>
    /// An interaction with a number of possible choices from which the learner can select.
    /// This includes interactions in which the learner can select only one answer from the list and those where the learner can select multiple items.
    /// </summary>
    | Choice 

    /// <summary>
    /// An interaction which requires the learner to supply a short response in the form of one or more strings of characters.
    /// Typically, the correct response consists of part of a word, one word or a few words.
    /// "Short" means that the correct responses pattern and learner response strings will normally be 250 characters or less. 
    /// </summary>
    | FillIn 

    /// <summary>
    /// An interaction which requires the learner to supply a response in the form of a long string of characters.
    /// "Long" means that the correct responses pattern and learner response strings will normally be more than 250 characters. 
    /// </summary>
    | LongFillIn 

    /// <summary>
    /// An interaction where the learner is asked to match items in one set (the source set) to items in another set (the target set).
    /// Items do not have to pair off exactly and it is possible for multiple or zero source items to be matched to a given target and vice versa.
    /// </summary>
    | Matching 

    /// <summary>
    /// An interaction that requires the learner to perform a task that requires multiple steps.
    /// </summary>
    | Performance 

    /// <summary>
    /// An interaction where the learner is asked to order items in a set.
    /// </summary>
    | Sequencing 

    /// <summary>
    /// An interaction which asks the learner to select from a discrete set of choices on a scale.
    /// </summary>
    | Likert 

    /// <summary>
    /// Any interaction which requires a numeric response from the learner.
    /// </summary>
    | Numeric 

    /// <summary>
    /// Another type of interaction that does not fit into those defined above.
    /// </summary>
    | Other
