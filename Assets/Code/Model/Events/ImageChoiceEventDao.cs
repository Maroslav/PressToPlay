using System.Xml.Serialization;
using Assets.Code.Model.Events.Choices;

namespace Assets.Code.Model.Events
{
    public class ImageChoiceEventDao : PressEventDao
    {
        [XmlElement("Description")]
        public string Description { get; private set; }

        public override T Process<T>(IPressEventDaoProcessor<T> processor)
        {
            return processor.Process(this);
        }
        [XmlArray("Choices")]
        [XmlArrayItem("Choice", typeof(ImageChoiceDao))]
        public ImageChoiceDao[] Choices { get; private set; }
    }
}