// <copyright file="IStatementResource.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Resources

open System
open System.Runtime.InteropServices
open Float.xAPI
open Float.xAPI.Actor

/// <summary>
/// The basic communication mechanism of the Experience API.
/// </summary>
type IStatementResource =
    /// <summary>
    /// Stores a single Statement with the given id. POST can also be used to store single Statements.
    /// </summary>
    /// <param name="statement">The Statement object to be stored.</param>
    abstract member PutStatement: IStatement -> unit

    /// <summary>
    /// Stores a Statement, or a set of Statements.
    /// </summary>
    /// <returns>Array of Statement id(s) (UUID) in the same order as the corresponding stored Statements.</returns>
    /// <param name="statements">An array of Statements or a single Statement to be stored.</param>
    abstract member PostStatements: IStatement seq -> Guid seq
        
    /// <summary>
    /// Get only non-voided statement that matches the given statement ID.
    /// </summary>
    /// <returns>A statement result.</returns>
    /// <param name="statementId">ID of statement to fetch.</param>
    /// <param name="format">The statement formatting to use for the returned object.</param>
    /// <param name="attachments">If true, the LRS uses the multipart response format and includes all attachments as described previously. If false, the LRS sends the prescribed response with Content-Type application/json and does not send attachment data.</param>
    abstract member GetStatement: 
        statementId: Guid * 
        [<Optional;DefaultParameterValue(StatementResultFormat.Exact)>] format: StatementResultFormat * 
        [<Optional;DefaultParameterValue(false)>] attachments: bool -> IStatement option

    /// <summary>
    /// Get only voided statement that matches the given statement ID.
    /// </summary>
    /// <returns>A statement result.</returns>
    /// <param name="voidedStatementId">ID of voided statement to fetch.</param>
    /// <param name="format">The statement formatting to use for the returned object.</param>
    /// <param name="attachments">If true, the LRS uses the multipart response format and includes all attachments as described previously. If false, the LRS sends the prescribed response with Content-Type application/json and does not send attachment data.</param>
    abstract member GetVoidedStatement: 
        voidedStatementId: Guid * 
        [<Optional;DefaultParameterValue(StatementResultFormat.Exact)>] format: StatementResultFormat * 
        [<Optional;DefaultParameterValue(false)>] attachments: bool -> IStatement option
    
    /// <summary>
    /// This method is called to fetch a single Statement or multiple Statements.
    /// </summary>
    /// <returns>A statement result.</returns>
    /// <param name="actor">Filter, only return Statements for which the specified Agent or Group is the Actor or Object of the Statement.</param>
    /// <param name="verb">Filter, only return Statements matching the specified Verb id.</param>
    /// <param name="activity">Filter, only return Statements for which the Object of the Statement is an Activity with the specified id.</param>
    /// <param name="registration">Filter, only return Statements matching the specified registration id. Note that although frequently a unique registration will be used for one Actor assigned to one Activity, this cannot be assumed. If only Statements for a certain Actor or Activity are required, those parameters also need to be specified.</param>
    /// <param name="relatedActivities">Apply the Activity filter broadly. Include Statements for which the Object, any of the context Activities, or any of those properties in a contained SubStatement match the Activity parameter, instead of that parameter's normal behavior. Matching is defined in the same way it is for the "activity" parameter.</param>
    /// <param name="relatedAgents">Apply the Agent filter broadly. Include Statements for which the Actor, Object, Authority, Instructor, Team, or any of these properties in a contained SubStatement match the Agent parameter, instead of that parameter's normal behavior. Matching is defined in the same way it is for the "agent" parameter.</param>
    /// <param name="since">Only Statements stored since the specified Timestamp (exclusive) are returned.</param>
    /// <param name="until">Only Statements stored at or before the specified Timestamp are returned.</param>
    /// <param name="limit">Maximum number of Statements to return. 0 indicates return the maximum the server will allow. </param>
    /// <param name="format">Statement result format option.</param>
    /// <param name="attachments">If true, the LRS uses the multipart response format and includes all attachments as described previously. If false, the LRS sends the prescribed response with Content-Type application/json and does not send attachment data.</param>
    /// <param name="ascending">If true, return results in ascending order of stored time.</param>
    abstract member GetStatements: 
        [<Optional>] actor: IIdentifiedActor option * 
        [<Optional>] verbId: Uri option * 
        [<Optional>] activityId: Uri option * 
        [<Optional>] registration: Guid option * 
        [<Optional;DefaultParameterValue(false)>] relatedActivities: bool * 
        [<Optional;DefaultParameterValue(false)>] relatedAgents: bool * 
        [<Optional>] since: DateTime option * 
        [<Optional>] until: DateTime option * 
        [<Optional;DefaultParameterValue(0)>] limit: int * 
        [<Optional;DefaultParameterValue(StatementResultFormat.Exact)>] format: StatementResultFormat * 
        [<Optional;DefaultParameterValue(false)>] attachments: bool * 
        [<Optional;DefaultParameterValue(false)>] ascending: bool -> IStatementResult
