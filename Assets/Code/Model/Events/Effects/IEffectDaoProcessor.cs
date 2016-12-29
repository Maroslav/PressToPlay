using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code.Model.Events.Effects
{
    public interface IEffectDaoProcessor<T>
    {
        T Process(ModifyEffectDao effect);

        T Process(MoveTowardsEffectDao effect);

        T Process(SetEffectDao effect);
    }
}
