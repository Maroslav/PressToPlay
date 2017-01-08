using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.GameState;

namespace Assets.Code.PressEvents.Preconditions
{
    internal abstract class PreconditionCompareAttrib: PreconditionAttribConstraint
    {
        public Attrib ComparedAttribute { get; private set; }   

        public PreconditionCompareAttrib(Attrib attribute, Attrib comparedAttribute) : base(attribute)
        {
            ComparedAttribute = comparedAttribute;
        }
    }
}
