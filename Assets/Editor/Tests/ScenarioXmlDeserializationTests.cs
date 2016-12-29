using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Assets.Code.Model;
using Assets.Code.Model.Events;
using Assets.Code.Model.Events.Effects;
using NUnit.Framework;
using UnityEngine;

namespace Assets.Editor.Tests
{
    [TestFixture]
    class ScenarioXmlDeserializationTests
    {
        private string _scenariosTemplate = "Scenarios/template";

        [Test]
        public void XmlDeserializationTest()
        {
            var scenario = XmlUtils.LoadScenario(_scenariosTemplate);
            Assert.AreEqual("name, only for the designer", scenario.Name);
            var events = scenario.Events;
            Assert.AreEqual(4,events.Length);
            Assert.IsInstanceOf( typeof(MultipleChoiceEventDao),events[0]);
            Assert.IsInstanceOf( typeof(MultipleChoiceEventDao),events[1]);
            Assert.IsInstanceOf( typeof(CutsceneEventDao),events[2]);
            Assert.IsInstanceOf( typeof(ImageChoiceEventDao),events[3]);
        }
        [Test]
        public void XmlDeserializationPreconditions()
        {
            var scenario = XmlUtils.LoadScenario(_scenariosTemplate);
            var events = scenario.Events;
            var e0 = events[0];
            var e1 = events[1];
            var e2 = events[2];
            var e3 = events[3];
            var preconditions = e0.Preconditions;
            Assert.AreEqual(3,preconditions.Length);
            Assert.IsTrue(e1.Preconditions==null || e1.Preconditions.Length==0);
            Assert.AreEqual(1,e2.Preconditions.Length);
            Assert.AreEqual(1,e3.Preconditions.Length);
            Assert.AreEqual(PreconditionOp.GreaterThan,preconditions[0].Operation);
            Assert.AreEqual(PreconditionOp.LessThan,preconditions[1].Operation);
            Assert.AreEqual(PreconditionOp.LessOrEqual,preconditions[2].Operation);

            Assert.AreEqual(150, preconditions[0].Value);
            Assert.AreEqual(400, preconditions[1].Value);
            Assert.AreEqual(210, preconditions[2].Value);

            Assert.AreEqual("Credibility", preconditions[1].AttributeName);
        }
        [Test]
        public void XmlDeserializationEffects()
        {
            var scenario = XmlUtils.LoadScenario(_scenariosTemplate);
            var events = scenario.Events;
            var e0 = events[0] as MultipleChoiceEventDao;
            var e3 = events[3] as ImageChoiceEventDao;
            var effects = e0.Choices[0].Effects;
            Assert.AreEqual(1,effects.Length);
            var ef = effects[0] as MoveTowardsEffectDao;
            Assert.IsNotNull(ef);
            Assert.AreEqual("Credibility",ef.Attribute);
            Assert.AreEqual(250,ef.Value);

            effects = e0.Choices[1].Effects;
            Assert.AreEqual(2, effects.Length);
            ef = effects[0] as MoveTowardsEffectDao;
            Assert.IsNotNull(ef);
            Assert.AreEqual("Credibility", ef.Attribute);
            Assert.AreEqual(50, ef.Amount);

            var ef2 = effects[1] as ModifyEffectDao;
            Assert.AreEqual("Money", ef2.Attribute);
            Assert.AreEqual(-50, ef2.Value);

            effects = e3.Choices[1].Effects;
            Assert.AreEqual(2,effects.Length);
            Assert.IsNotNull(effects[0] as SetEffectDao);
            Assert.IsNotNull(effects[1] as SetEffectDao);
            
            Assert.AreEqual(500,effects[0].Value);
            Assert.AreEqual(500,effects[1].Value);
        }

    }
}
