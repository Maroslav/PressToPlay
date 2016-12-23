using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Assets.Code.Model.Events.Effects
{
    public abstract class EffectDao
    {
        [XmlAttribute("attribute")]
        public string Attribute { get; set; }

        [XmlAttribute("value")]
        public int Value { get; set; }

        public abstract T Process<T>(IEffectDaoProcessor<T> processor);

    }
}
