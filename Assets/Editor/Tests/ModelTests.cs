﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.Gameplay;
using Assets.Code.GameState;
using Assets.Code.Planning;
using Assets.Code.PressEvents;
using NUnit.Framework;

namespace Assets.Editor.Tests
{
    [TestFixture]
    class ModelTests
    {
        [SetUp]
        public void Init()
        {
            Attribs.MinValue = 0;
            Attribs.MaxValue = 1000;
            Attribs.MidValue = 500;
        }
        [Test]
        public void TestAttributesAndTermination()
        {
            var worldState = GameInit.CreateWorldState("Attributes/credibility_only");
            var storyEventsScenario = new StoryEventsScenario("Attributes/test_story_effects");
            var cred = Attribs.GetAttribByName("Credibility");
            var scheduler = new PressEventScheduler(worldState, new DateTime(2016, 1, 1), new DateTime(2017, 2, 2), storyEventsScenario);
            var evt = NextAsMultipleChoice(scheduler);
            Assert.AreEqual(500,worldState.JournalistState[cred]);
            evt.Apply(evt.Choices[0],worldState);
            Assert.AreEqual(125,worldState.JournalistState[cred]);
            evt = NextAsMultipleChoice(scheduler);
            evt.Apply(evt.Choices[0], worldState);
            Assert.AreEqual(150, worldState.JournalistState[cred]);
            Assert.IsNull(scheduler.PopNextEvent());
        }

        [Test]
        public void TestAttributesAndTermination2()
        {
            var worldState = GameInit.CreateWorldState("Attributes/credibility_only");
            var storyEventsScenario = new StoryEventsScenario("Attributes/test_story_effects");
            var cred = Attribs.GetAttribByName("Credibility");
            worldState.JournalistState[cred] = 0;
            var scheduler = new PressEventScheduler(worldState, new DateTime(2016, 1, 1), new DateTime(2017, 2, 2), storyEventsScenario);
            var evt = NextAsMultipleChoice(scheduler);
            evt.Apply(evt.Choices[1], worldState);
            Assert.AreEqual(250, worldState.JournalistState[cred]);
            evt = NextAsMultipleChoice(scheduler);
            evt.Apply(evt.Choices[0], worldState);
            Assert.AreEqual(275, worldState.JournalistState[cred]);
            Assert.IsNull(scheduler.PopNextEvent());
        }

        [Test]
        public void TestAttributesAndTermination3()
        {
            var worldState = GameInit.CreateWorldState("Attributes/credibility_only");
            var storyEventsScenario = new StoryEventsScenario("Attributes/test_story_effects");
            var cred = Attribs.GetAttribByName("Credibility");
            worldState.JournalistState[cred] = 0;
            var scheduler = new PressEventScheduler(worldState, new DateTime(2016, 1, 1), new DateTime(2017, 2, 2), storyEventsScenario);
            var evt = NextAsMultipleChoice(scheduler);
            evt.Apply(evt.Choices[1], worldState);
            Assert.AreEqual(250, worldState.JournalistState[cred]);
            evt = NextAsMultipleChoice(scheduler);
            evt.Apply(evt.Choices[1], worldState);
            Assert.AreEqual(400, worldState.JournalistState[cred]);
            Assert.IsNull(scheduler.PopNextEvent());
        }
        [Test]
        public void TestConditional1()
        {
            var worldState = GameInit.CreateWorldState("Attributes/credibility_and_money");
            var storyEventsScenario = new StoryEventsScenario("Attributes/test_story_effects");
            var condScenario = new ConditionalEventsScenario("Scenarios/test_conditional", worldState);
            var cred = Attribs.GetAttribByName("Credibility");
            var money = Attribs.GetAttribByName("Money");
            worldState.JournalistState[cred] = 0;
            var scheduler = new PressEventScheduler(worldState, new DateTime(2016, 1, 1), new DateTime(2017, 2, 2), storyEventsScenario,condScenario);
            Assert.AreEqual(500, worldState.JournalistState[money]);
            var cond = scheduler.PopNextEvent();
            Assert.IsNotNull(cond as CutsceneEvent);
            Assert.AreEqual("Unconditional conditional!",(cond as CutsceneEvent).Description);
            var evt = NextAsMultipleChoice(scheduler);
            evt.Apply(evt.Choices[1], worldState);
            Assert.AreEqual(250, worldState.JournalistState[cred]);
            evt = NextAsMultipleChoice(scheduler);
            Assert.AreEqual("Credibility is 250.", evt.Description);
            evt.Apply(evt.Choices[0], worldState);
            Assert.AreEqual(0, worldState.JournalistState[money]);
            evt = NextAsMultipleChoice(scheduler);
            evt.Apply(evt.Choices[0], worldState);
            Assert.AreEqual(275, worldState.JournalistState[cred]);
            Assert.IsNull(scheduler.PopNextEvent());
        }
        [Test]
        public void TestConditional2()
        {
            var worldState = GameInit.CreateWorldState("Attributes/credibility_and_money");
            var storyEventsScenario = new StoryEventsScenario("Attributes/test_story_effects");
            var condScenario = new ConditionalEventsScenario("Scenarios/test_conditional", worldState);
            var cred = Attribs.GetAttribByName("Credibility");
            var money = Attribs.GetAttribByName("Money");
            worldState.JournalistState[cred] = 500;
            var scheduler = new PressEventScheduler(worldState, new DateTime(2016, 1, 1), new DateTime(2017, 2, 2), storyEventsScenario, condScenario);
            Assert.AreEqual(500, worldState.JournalistState[money]);
            var cond = scheduler.PopNextEvent();
            Assert.IsNotNull(cond as CutsceneEvent);
            Assert.AreEqual("Unconditional conditional!", (cond as CutsceneEvent).Description);
            var evt = NextAsMultipleChoice(scheduler);
            evt.Apply(evt.Choices[1], worldState);
            Assert.AreEqual(550, worldState.JournalistState[cred]);
            evt = NextAsMultipleChoice(scheduler);
            evt.Apply(evt.Choices[1], worldState);
            Assert.AreEqual(650, worldState.JournalistState[money]);
            evt = NextAsMultipleChoice(scheduler);
            evt.Apply(evt.Choices[1], worldState);
            Assert.AreEqual(700, worldState.JournalistState[cred]);
            Assert.IsNull(scheduler.PopNextEvent());
        }
        [Test]
        public void TestNotMatchingDates()
        {
            var worldState = GameInit.CreateWorldState("Attributes/credibility_and_money");
            var storyEventsScenario = new StoryEventsScenario("Attributes/test_story_effects");
            var condScenario = new ConditionalEventsScenario("Scenarios/test_conditional", worldState);
            var cred = Attribs.GetAttribByName("Credibility");
            var money = Attribs.GetAttribByName("Money");
            worldState.JournalistState[cred] = 500;
            var scheduler = new PressEventScheduler(worldState, new DateTime(1605, 1, 1), new DateTime(1606, 2, 2), storyEventsScenario, condScenario);
            Assert.AreEqual(500, worldState.JournalistState[money]);
            var cond = scheduler.PopNextEvent();
            Assert.IsNotNull(cond as CutsceneEvent);
            Assert.AreEqual("Unconditional conditional!", (cond as CutsceneEvent).Description);
            Assert.IsNull(scheduler.PopNextEvent());
        }

        [Test]
        public void TestConditionalAttribsCompare()
        {
            var worldState = GameInit.CreateWorldState("Attributes/credibility_and_money");
            var condScenario = new ConditionalEventsScenario("Scenarios/test_conditional_attribcmp", worldState);
            var cred = Attribs.GetAttribByName("Credibility");
            var money = Attribs.GetAttribByName("Money");
            worldState.JournalistState[cred] = 500;
            worldState.SetValue(money,500);
            var scheduler = new PressEventScheduler(worldState, new DateTime(1605, 1, 1), new DateTime(2020, 2, 2), condScenario);

            Assert.IsNull(scheduler.PopNextEvent());
            worldState.SetValue(money,499);
            Assert.AreEqual("More credibility",scheduler.PopNextEvent().Name);
            Assert.IsNull(scheduler.PopNextEvent());
            worldState.SetValue(money,501);
            Assert.AreEqual("More money",scheduler.PopNextEvent().Name);
            Assert.IsNull(scheduler.PopNextEvent());
            worldState.SetValue(cred,100);
            worldState.SetValue(money,101);
            Assert.IsNull(scheduler.PopNextEvent());
            worldState.SetValue(money,100);
            Assert.AreEqual("Little of both", scheduler.PopNextEvent().Name);
            Assert.IsNull(scheduler.PopNextEvent());
            worldState.Date=new DateTime(2016,12,12);
            Assert.AreEqual("Late", scheduler.PopNextEvent().Name);
            Assert.IsNull(scheduler.PopNextEvent());
            Assert.IsTrue(condScenario.IsTerminated);


            
            

        }
        private static MultipleChoiceEvent NextAsMultipleChoice(PressEventScheduler scheduler)
        {
            var evt = scheduler.PopNextEvent() as MultipleChoiceEvent;
            Assert.IsNotNull(evt);
            return evt;
        }
    }
}
