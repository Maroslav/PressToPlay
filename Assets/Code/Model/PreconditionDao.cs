using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Assets.Code.Model
{
    public class PreconditionDao
    {
        [XmlAttribute("attribute")]
        public string AttributeName { get; set; }
        [XmlAttribute("operation")]
        public PreconditionOp Operation { get; set; }
        [XmlAttribute("value")]
        public string Value { get; set; }
    }
}
