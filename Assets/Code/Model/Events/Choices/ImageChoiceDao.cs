using System.Xml.Serialization;

namespace Assets.Code.Model.Events.Choices
{
    public class ImageChoiceDao:ChoiceDao
    {
        [XmlElement("ImagePath")]
        public string Path { get; set; }
    }
}