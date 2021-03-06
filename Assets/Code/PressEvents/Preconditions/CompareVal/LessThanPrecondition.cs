﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.GameState;

namespace Assets.Code.PressEvents.Preconditions
{
    class LessThanPrecondition:PreconditionCompareValue
    {
        public override bool Check(WorldState state)
        {
            return  state.GetValue(Attribute) <Value;
        }

        public LessThanPrecondition(Attrib attribute, int value) : base(attribute, value)
        {
        }
    }
}
