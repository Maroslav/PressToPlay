using System.Xml.Serialization;
using Assets.Code.Model.Events.Effects;

namespace Assets.Code.Model.Events.Choices
{
    public class ChoiceDao
    {
        [XmlArray("Effects")]
        [XmlArrayItem("SetEffect", typeof(SetEffectDao)),
            XmlArrayItem("MoveTowardsEffect", typeof(MoveTowardsEffectDao)),
            XmlArrayItem("ModifyEffect", typeof(ModifyEffectDao))
            ]
        public EffectDao[] Effects { get; set; }

        [XmlElement("ImagePath")]
        public string ImagePath { get; set; }
        [XmlElement("ImageLabel")]
        public string ImageLabel { get; set; }

        [XmlElement("Description")]
        public string Description { get; protected set; }
        [XmlElement("Title")]
        public string Title { get; private set; }
        [XmlElement("ArticleText")]
        public string ArticleText { get; set; }
    }
}