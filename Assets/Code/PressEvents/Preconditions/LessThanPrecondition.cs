using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.GameState;

namespace Assets.Code.PressEvents.Preconditions
{
    class LessThanPrecondition:Precondition
    {
        public override bool Check(WorldState state)
        {
            return  state.JournalistState[Attribute]<Value;
        }

        public LessThanPrecondition(Attrib attribute, int value) : base(attribute, value)
        {
        }
    }
}
