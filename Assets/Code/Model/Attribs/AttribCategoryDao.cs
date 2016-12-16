using System.Xml.Serialization;

namespace Assets.Code.Model.Attribs
{
    public class AttribCategoryDao
    {
        
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("description")]
        public string Description { get; set; }

        [XmlElement("Attribute")]
        public AttribTypeDao[] Attributes { get; set; }
    }
}
