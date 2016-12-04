using System;

namespace Assets.Code.PressEvents
{
    public abstract class PressEvent
    {
        public DateTime Date { get; private set; }
        public bool IsFinished { get;protected set; }

        protected PressEvent(DateTime date)
        {
            Date = date;
            IsFinished = false;
        }

        //Visitor pattern, corresponds to the 'accept' method.
        public abstract void ProcessEvent(IEventProcessor processor);
    }
}
