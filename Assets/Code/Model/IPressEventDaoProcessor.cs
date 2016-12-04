using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code.Model
{
    interface IPressEventDaoProcessor<T>
    {
        T process(MultipleChoiceEventDao evt);
        T process(CutsceneEventDao evt);

    }
}
