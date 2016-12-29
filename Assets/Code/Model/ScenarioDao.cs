using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Assets.Code.Model.Events;
using Assets.Code.PressEvents;

namespace Assets.Code.Model
{
    [XmlRoot(elementName:"Scenario", Namespace = "http://presstoplaygame.com/scenario")]
    public class ScenarioDao
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlArray]
        [XmlArrayItem(ElementName = "MultipleChoiceEvent", Type = typeof(MultipleChoiceEventDao)),
    XmlArrayItem(ElementName = "CutsceneEvent", Type = typeof(CutsceneEventDao)),
             XmlArrayItem(ElementName = "ImageChoiceEvent", Type = typeof(ImageChoiceEventDao))]
        public PressEventDao[] Events { get; set; }
    }
}
