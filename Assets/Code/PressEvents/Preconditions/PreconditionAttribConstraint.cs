using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.GameState;

namespace Assets.Code.PressEvents.Preconditions
{
    internal abstract class PreconditionAttribConstraint:Precondition
    {
        public PreconditionAttribConstraint(Attrib attribute)
        {
            Attribute = attribute;

        }
        public Attrib Attribute { get; private set; }
    }
}
