using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code.PressEvents.Preconditions
{
    internal abstract class PreconditionDateConstraint:Precondition
    {
        public DateTime Date { get; set; }

        public PreconditionDateConstraint(DateTime date)
        {
            Date = date;
        }
    }
}
