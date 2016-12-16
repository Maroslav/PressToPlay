using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Assets.Code.Model.Attribs;
using UnityEngine;

namespace Assets.Code.Model
{
    public static class XmlUtils
    {
        public static ScenarioDao LoadScenario(string path)
        {
            return DeserializeXmlFromPath<ScenarioDao>(path);
        }

        public static AttributesDefinition LoadAttributes(string path)
        {
            return DeserializeXmlFromPath<AttributesDefinition>(path);
        }

        public static  T DeserializeXmlFromPath<T>(string path)
        {
            XmlSerializer xmlReader = new XmlSerializer(typeof(T));
            TextAsset xmlFile = Resources.Load(path) as TextAsset;
            using (var reader = new StringReader(xmlFile.text))
            {
                return (T)xmlReader.Deserialize(reader);
            }
        } 
    }
}
