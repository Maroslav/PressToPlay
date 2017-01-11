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
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("date")]
        public string Date { get; private set; }

        [XmlAttribute("isTerminating")]
        public bool IsTerminating { get; private set; }

        [XmlAttribute("soundPath")]
        public string SoundPath { get; set; }


        [XmlArray("Preconditions")]
        [XmlArrayItem("Precondition",typeof(PreconditionDao))]
        public PreconditionDao[] Preconditions { get; set; }

        public abstract T Process<T>(IPressEventDaoProcessor<T> processor);

    }
}
