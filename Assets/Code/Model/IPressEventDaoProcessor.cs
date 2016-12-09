using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code.Model
{
    /// <summary>
    /// Event data access object visitor interface
    /// </summary>
    /// <typeparam name="T">return type</typeparam>
    public interface IPressEventDaoProcessor<T>
    {
        T Process(MultipleChoiceEventDao evt);
        T Process(CutsceneEventDao evt);

    }
}
