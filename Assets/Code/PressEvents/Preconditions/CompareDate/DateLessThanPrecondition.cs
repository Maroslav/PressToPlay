using System;
using Assets.Code.GameState;

namespace Assets.Code.PressEvents.Preconditions
{
    class DateLessThanPrecondition : PreconditionDateConstraint
    {
        public DateLessThanPrecondition(DateTime date) : base(date)
        {
        }

        public override bool Check(WorldState state)
        {
            return state.Date < Date;
        }
    }
}