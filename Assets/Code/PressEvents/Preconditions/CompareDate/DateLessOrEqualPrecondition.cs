using System;
using Assets.Code.GameState;

namespace Assets.Code.PressEvents.Preconditions
{
    class DateLessOrEqualPrecondition : PreconditionDateConstraint
    {
        public DateLessOrEqualPrecondition(DateTime date) : base(date)
        {
        }

        public override bool Check(WorldState state)
        {
            return state.Date <= Date;
        }
    }
}