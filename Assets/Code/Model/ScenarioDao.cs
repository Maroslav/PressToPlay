using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Assets.Code.PressEvents;

namespace Assets.Code.Model
{
    [XmlRoot("Scenario")]
    public class ScenarioDao
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlArray]
        [XmlArrayItem(ElementName = "MultipleChoiceEvent", Type = typeof(MultipleChoiceEventDao)),
    XmlArrayItem(ElementName = "CutsceneEvent", Type = typeof(CutsceneEventDao))]
        public PressEventDao[] Events { get; set; }
    }
}
