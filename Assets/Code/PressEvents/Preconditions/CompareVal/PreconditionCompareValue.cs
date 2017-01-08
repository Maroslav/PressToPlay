using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.GameState;

namespace Assets.Code.PressEvents.Preconditions
{
    internal abstract class PreconditionCompareValue:PreconditionAttribConstraint
    {
        public PreconditionCompareValue(Attrib attribute, int value) : base(attribute)
        {
            Value = value;
        }

        public int Value { get; set; }
    }
}
