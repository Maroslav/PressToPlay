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

        [XmlElement("ChoiceText")]
        public string ChoiceText { get; set; }
       
    }
}
