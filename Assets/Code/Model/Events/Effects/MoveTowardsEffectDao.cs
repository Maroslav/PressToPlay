using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Assets.Code.GameState;

namespace Assets.Code.Model.Events.Effects
{
    public class MoveTowardsEffectDao:EffectDao
    {
        [XmlAttribute("amount")]
        public int Amount { get; set; }
        public override T Process<T>(IEffectDaoProcessor<T> processor)
        {
            return processor.Process(this);
        }

        public MoveTowardsEffectDao()
        {
            Amount = Algorithms.AttribMoveStep;
        }
    }
}
