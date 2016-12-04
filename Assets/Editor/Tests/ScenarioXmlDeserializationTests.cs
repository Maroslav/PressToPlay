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
            StreamReader reader = new StreamReader("Assets/Scenarios/template.xml");
            XmlSerializer xmlReader = new XmlSerializer(typeof(ScenarioDao));
            ScenarioDao scenario= (ScenarioDao) xmlReader.Deserialize(reader);
            Assert.AreEqual("name, only for the designer", scenario.Name);
            Assert.AreEqual(3,scenario.Events.Length);
            reader.Close();
        }
    }
}
