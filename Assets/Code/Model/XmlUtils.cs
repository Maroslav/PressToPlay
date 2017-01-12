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
            Debug.Assert(xmlFile!=null, "Unable to load resource from path: "+path);
            using (var reader = new StringReader(xmlFile.text))
            {
                return (T)xmlReader.Deserialize(reader);
            }
        }
        public static Color ColorFromHtml(string htmlColor)
        {
            Color c = new Color();

            if (string.IsNullOrEmpty(htmlColor))
                return c;

            if ((htmlColor[0] == '#') &&
                ((htmlColor.Length == 7)))
            {
                c = new Color((float) (Convert.ToInt32(htmlColor.Substring(1, 2), 16)/255.0),
                    (float) (Convert.ToInt32(htmlColor.Substring(3, 2), 16) / 255.0),
                    Convert.ToInt32(htmlColor.Substring(5, 2), 16) / (float)255.0) ;
            }
            else System.Diagnostics.Debug.Assert(false, "Wrong color format, expected #xxxxxx");
            return c;
        }
    }
}
