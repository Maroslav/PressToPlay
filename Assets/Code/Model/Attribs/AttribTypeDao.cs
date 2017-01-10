using System.Xml.Serialization;

namespace Assets.Code.Model.Attribs
{
    public class AttribTypeDao
    {
        public AttribTypeDao()
        {
            InitialValue = GameState.Attribs.MidValue;
        }
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("description")]
        public string Description { get; set; }
        [XmlAttribute("initialValue")]
        public int InitialValue { get; set; }
        [XmlAttribute("isDisplayed")]
        public bool IsDisplayed { get; set; }

        [XmlAttribute("color")]
        public string Color { get; set; }
    }
}
