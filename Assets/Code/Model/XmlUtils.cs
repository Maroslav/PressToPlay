using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

namespace Assets.Code.Model
{
    public static class XmlUtils
    {
        public static ScenarioDao LoadScenario(string path)
        {
            //StreamReader reader = new StreamReader(path);
            XmlSerializer xmlReader = new XmlSerializer(typeof(ScenarioDao));
            TextAsset xmlFile = Resources.Load(path) as TextAsset;
            using (var reader = new StringReader(xmlFile.text))
            {
                return xmlReader.Deserialize(reader) as ScenarioDao;
            }
        }
    }
}
