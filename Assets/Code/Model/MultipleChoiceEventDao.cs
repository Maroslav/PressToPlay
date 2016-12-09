using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Assets.Code.Model
{
    //Data Access Object, stores raw data loaded from the database.
    public class MultipleChoiceEventDao: PressEventDao
    {
        public MultipleChoiceEventDao(string description, List<DecisionChoiceDao> choices, string date=null):base(date) 
        {
            Description = description;
            Choices = choices.ToArray();
        }

        public MultipleChoiceEventDao():base(null)
        {
            
        }
        [XmlElement("Description")]
        public string Description { get; private set; }
        [XmlArray("Choices")]
        [XmlArrayItem("Choice",typeof(DecisionChoiceDao))]
        public DecisionChoiceDao[] Choices { get; private set; }

        public override T Process<T>(IPressEventDaoProcessor<T> processor)
        {
            return processor.Process(this);
        }
    }
}
