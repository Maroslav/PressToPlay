using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Assets.Code.Model
{
    public class AttributeDao
    {
        public AttributeDao(string attributeName, int value)
        {
            AttributeName = attributeName;
            Value = value;
        }

        public AttributeDao()
        {
                
        }
        [XmlAttribute("attribute")]
        public string AttributeName { get; set; }
        [XmlAttribute("value")]
        public int Value { get; set; }
    }
}
