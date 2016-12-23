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
    }
}