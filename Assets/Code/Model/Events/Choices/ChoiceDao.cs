using System.Xml.Serialization;

namespace Assets.Code.Model.Events.Choices
{
    public class ChoiceDao
    {
        [XmlArray("Effects")]
        [XmlArrayItem("Effect", typeof(AttributeDao))]
        public AttributeDao[] Attribs { get; set; }
    }
}