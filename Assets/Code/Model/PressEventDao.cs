using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Assets.Code.Model
{

    public abstract class PressEventDao
    {
        public PressEventDao(string date)
        {
            Date = date;
        }

        public PressEventDao()
        {
            
        }
        [XmlAttribute("date")]
        public string Date { get; private set; }

        [XmlArray("Preconditions")]
        [XmlArrayItem("Precondition",typeof(PreconditionDao))]
        public PreconditionDao[] Preconditions { get; set; }
    }
}
