using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Code.Model;
using Assets.Code.PressEvents.Preconditions;

namespace Assets.Code.PressEvents
{
    /// <summary>
    /// Converts data access objects loaded from database to events.
    /// </summary>
    class DaoToEventsConverter : IPressEventDaoProcessor<PressEvent>
    {
        /// <summary>
        /// The date that is assigned to events if the event has no date itself.
        /// </summary>
        public DateTime AssignedDate { get; set; }
        public PressEvent Process(MultipleChoiceEventDao evt)
        {
            var d = GetDate(evt);
            var choices = (from x in evt.Choices select new DecisionChoice(x)).ToList();
            var descr = evt.Description;
            var precond = GetPreconditions(evt);
            return new MultipleChoiceEvent(descr,d,choices,precond);
        }

        

        public PressEvent Process(CutsceneEventDao evt)
        {
            var d = GetDate(evt);
            return new CutsceneEvent(evt.ImagePath, evt.Text,d,GetPreconditions(evt));
        }
        private DateTime GetDate(PressEventDao evt)
        {
            DateTime d;
            if (!string.IsNullOrEmpty(evt.Date))
            {
                if (DateTime.TryParse(evt.Date, out d))
                {
                    return d;
                }
            }
            d = AssignedDate;
            return d;
        }

        private List<Precondition> GetPreconditions(PressEventDao dao)
        {
            if (dao.Preconditions==null) return new List<Precondition>();
            return (from x in dao.Preconditions select Precondition.FromDao(x)).ToList();

        }
    }
}
