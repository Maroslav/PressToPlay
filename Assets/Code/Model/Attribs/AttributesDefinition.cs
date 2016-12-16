using System.Xml.Serialization;

namespace Assets.Code.Model.Attribs
{
    [XmlRoot(elementName:"Attributes")]
    public class AttributesDefinition
    {
        [XmlElement("Category")]
        public AttribCategoryDao[] Categories { get; set; }
    }
}
