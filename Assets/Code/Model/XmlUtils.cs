using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Assets.Code.Model
{
    public static class XmlUtils
    {
        public static ScenarioDao LoadScenario(string path)
        {
            StreamReader reader = new StreamReader(path);
            XmlSerializer xmlReader = new XmlSerializer(typeof(ScenarioDao));
            return (ScenarioDao)xmlReader.Deserialize(reader);
        }
    }
}
