using System;
using System.Collections.Generic;
using Assets.Code.GameState;
using Assets.Code.Planning;
using Assets.Code.PressEvents;
using NUnit.Framework;

namespace Assets.Editor.Tests
{
    [TestFixture]
    class SchedulerTests
    {
        [Test]
        public void TestBasic()
        {
            WorldState state = new WorldState();
            state.JournalistState=new Attribs();
            state.JournalistState[Attribs.Credibility] = 450;
            Attribs.SetGameAttribsCollection(new Dictionary<string, Attrib>() { {"Credibility",Attribs.Credibility} });
            StoryEventsScenario scenario = new StoryEventsScenario("Scenarios/test_story");
            IPressEventScheduler scheduler = new PressEventScheduler(state, new DateTime(1989, 11, 17), new DateTime(1990, 1, 1), scenario);
            var evt = scheduler.PopNextEvent();
            Assert.AreEqual(new DateTime(1989,11,17), evt.Date);
            Assert.AreEqual(0,evt.Preconditions.Count);
            Assert.AreEqual(typeof(CutsceneEvent),evt.GetType());
            Assert.AreEqual(evt.Date,new DateTime(1989,11,17));
            evt = scheduler.PopNextEvent();
            Assert.AreEqual("EventLowCredibility",((CutsceneEvent) evt).Description);
            evt = scheduler.PopNextEvent();
            Assert.AreEqual(null,evt);

        }
        [Test]
        public void TestChangeOfCredibility()
        {
            WorldState state = new WorldState();
            state.AllStates=new Dictionary<AttribsCategory, Attribs>();
            state.JournalistState=new Attribs();
            state.JournalistState[Attribs.Credibility] = 450;
            Attribs.SetGameAttribsCollection(new Dictionary<string, Attrib>() { { "Credibility", Attribs.Credibility } });

            StoryEventsScenario scenario = new StoryEventsScenario("Scenarios/test_story");
            IPressEventScheduler scheduler = new PressEventScheduler(state, new DateTime(1989, 11, 17), new DateTime(1990, 1, 1), scenario);
            var evt = scheduler.PopNextEvent();
            Assert.AreEqual(new DateTime(1989, 11, 17), evt.Date);
            Assert.AreEqual(0, evt.Preconditions.Count);
            Assert.AreEqual(typeof(CutsceneEvent), evt.GetType());
            Assert.AreEqual(evt.Date, new DateTime(1989, 11, 17));
            evt = scheduler.PopNextEvent();
            Assert.AreEqual("EventLowCredibility", ((CutsceneEvent)evt).Description);
            state.JournalistState[Attribs.Credibility] = 850;
            evt = scheduler.PopNextEvent();
            Assert.AreNotEqual(null,evt);
            Assert.AreEqual("EventHighCredibility", ((CutsceneEvent)evt).Description);
            Assert.AreEqual(new DateTime(1989,11,22),evt.Date);
            Assert.AreEqual(null,scenario.PeekNextEvent());
            Assert.AreEqual(null,scenario.PopNextEvent());
        }
        [Test]
        public void TestMultipleScenarios()
        {
            WorldState state = new WorldState();
            state.JournalistState=new Attribs();
            state.JournalistState[Attribs.Credibility] = 450;
            Attribs.SetGameAttribsCollection(new Dictionary<string, Attrib>() { { "Credibility", Attribs.Credibility } });

            StoryEventsScenario scenario = new StoryEventsScenario("Scenarios/test_story");
            StoryEventsScenario scenario2 = new StoryEventsScenario("Scenarios/test_story2");
            IPressEventScheduler scheduler = new PressEventScheduler(state, new DateTime(1989, 11, 17), new DateTime(1990, 1, 1), scenario,scenario2);
            var evt = scheduler.PopNextEvent();
            Assert.AreEqual(new DateTime(1989, 11, 17), evt.Date);
            Assert.AreEqual(0, evt.Preconditions.Count);
            Assert.AreEqual(typeof(CutsceneEvent), evt.GetType());
            Assert.AreEqual(evt.Date, new DateTime(1989, 11, 17));
            evt = scheduler.PopNextEvent();
            Assert.AreEqual(evt.Date, new DateTime(1989, 11, 19));
            Assert.AreEqual("InsertedNotHigh",((CutsceneEvent)evt).Description);
            evt = scheduler.PopNextEvent();
            Assert.AreEqual("EventLowCredibility", ((CutsceneEvent)evt).Description);
            state.JournalistState[Attribs.Credibility] = 522;
            evt = scheduler.PopNextEvent();
            Assert.AreEqual("InsertedEqual", ((CutsceneEvent)evt).Description);
            evt = scheduler.PopNextEvent();
            Assert.AreNotEqual(null, evt);
            Assert.AreEqual("EventHighCredibility", ((CutsceneEvent)evt).Description);
            Assert.AreEqual(new DateTime(1989, 11, 22), evt.Date);
            evt = scheduler.PopNextEvent();
            Assert.AreEqual(new DateTime(1989, 11, 25), evt.Date);
            Assert.AreEqual("InsertedLast", ((CutsceneEvent)evt).Description);
        }
    }
}
