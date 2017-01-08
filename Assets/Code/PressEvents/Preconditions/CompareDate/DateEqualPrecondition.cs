using System;
using Assets.Code.GameState;

namespace Assets.Code.PressEvents.Preconditions
{
    class DateEqualPrecondition : PreconditionDateConstraint
    {
        public DateEqualPrecondition(DateTime date) : base(date)
        {
        }

        public override bool Check(WorldState state)
        {
            return Date == state.Date;
        }
    }
}