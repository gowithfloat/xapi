// <copyright file="StateResourceKey.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using Float.xAPI.Actor;
using Float.xAPI.Actor.Identifier;
using Float.xAPI.Resources.Documents;
using Xunit;
using static Float.xAPI.Tests.LRSTestHelper;

namespace Float.xAPI.Tests
{
    public class StateResourceKeyTests : IEqualityTests
    {
        [Fact]
        public void TestEquality()
        {
            var sid1 = GenerateStateId("srk-state-id");
            var aid1 = GenerateActivityId("srk-activity-id");
            var agent1 = new Agent(new OpenID(GenerateUri("srk-agent")));

            var sid2 = GenerateStateId("srk-state-id");
            var aid2 = GenerateActivityId("srk-activity-id");
            var agent2 = new Agent(new OpenID(GenerateUri("srk-agent")));

            AssertHelper.Equality(sid1, sid2, (a, b) => a == b);
            AssertHelper.Equality(aid1, aid2, (a, b) => a == b);
            AssertHelper.Equality<Agent, IAgent, IIdentifiedActor>(agent1, agent2, (a, b) => a == b);

            var srk1 = new StateResourceKey(sid1, aid1, agent1);
            var srk2 = new StateResourceKey(sid2, aid2, agent2);
            AssertHelper.Equality(srk1, srk2, (a, b) => a == b);
        }

        [Fact]
        public void TestInequality()
        {
            var sid1 = GenerateStateId("srk-state-id1");
            var aid1 = GenerateActivityId("srk-activity-id1");
            var agent1 = new Agent(new OpenID(GenerateUri("srk-agent1")));

            var sid2 = GenerateStateId("srk-state-id2");
            var aid2 = GenerateActivityId("srk-activity-id2");
            var agent2 = new Agent(new OpenID(GenerateUri("srk-agent2")));

            AssertHelper.Inequality(sid1, sid2, (a, b) => a != b);
            AssertHelper.Inequality(aid1, aid2, (a, b) => a != b);
            AssertHelper.Inequality<Agent, IAgent, IIdentifiedActor>(agent1, agent2, (a, b) => a != b);

            var srk1 = new StateResourceKey(sid1, aid1, agent1);
            var srk2 = new StateResourceKey(sid2, aid2, agent2);
            AssertHelper.Inequality(srk1, srk2, (a, b) => a != b);
        }
    }
}
