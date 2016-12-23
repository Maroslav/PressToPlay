using System.Xml.Serialization;

namespace Assets.Code.Model.Events.Choices
{
    //Data Access Object, stores raw data loaded from the database.
    public class TextChoiceDao:ChoiceDao
    {
        public TextChoiceDao()
        {
            
        }
        public TextChoiceDao(string description)
        {
            Description = description;
        }

        [XmlElement("Description")]
        public string Description { get; private set; }
        [XmlElement("Title")]
        public string Title { get; private set; }

    }
}
