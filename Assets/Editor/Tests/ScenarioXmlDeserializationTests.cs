using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Assets.Code.Model;
using NUnit.Framework;
using UnityEngine;

namespace Assets.Editor.Tests
{
    [TestFixture]
    class ScenarioXmlDeserializationTests
    {
        [Test]
        public void XmlDeserializationTest()
        {
            var scenario = XmlUtils.LoadScenario("Scenarios/template");
            Assert.AreEqual("name, only for the designer", scenario.Name);
            Assert.AreEqual(3,scenario.Events.Length);
        }
    }
}
