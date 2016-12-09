using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.PressEvents;

namespace Assets.Code.Model
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
            return new MultipleChoiceEvent(evt, d);
        }

        

        public PressEvent Process(CutsceneEventDao evt)
        {
            var d = GetDate(evt);
            return new CutsceneEvent(evt.ImagePath, evt.Text,d);
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
    }
}
