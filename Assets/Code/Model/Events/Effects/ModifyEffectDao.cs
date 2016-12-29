using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code.Model.Events.Effects
{
    public class ModifyEffectDao:EffectDao
    {
        public override T Process<T>(IEffectDaoProcessor<T> processor)
        {
            return processor.Process(this);
        }
    }
}
