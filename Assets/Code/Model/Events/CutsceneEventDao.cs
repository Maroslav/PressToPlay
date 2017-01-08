using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Assets.Code.Model
{

    public class CutsceneEventDao:PressEventDao
    {
       
        [XmlElement("ImagePath")]
        public string ImagePath { get; set; }
        [XmlElement("Text")]
        public string Text { get; set; }



        public override T Process<T>(IPressEventDaoProcessor<T> processor)
        {
            return processor.Process(this);
        }
    }
}
