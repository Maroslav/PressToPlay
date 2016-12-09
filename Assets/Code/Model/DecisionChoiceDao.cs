using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Assets.Code.GameState;

namespace Assets.Code.Model
{
    //Data Access Object, stores raw data loaded from the database.
    public struct DecisionChoiceDao
    {
        public DecisionChoiceDao(string description) : this()
        {
            Description = description;
        }

        [XmlElement("Description")]
        public string Description { get; private set; }
        [XmlElement("Title")]
        public string Title { get; private set; }
        [XmlArray("Effects")]
        [XmlArrayItem("Effect", typeof(AttributeDao))]
        public AttributeDao[] Attribs { get; set; }
    }
}
