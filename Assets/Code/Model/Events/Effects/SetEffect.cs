using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.GameState;

namespace Assets.Code.Model.Events.Effects
{
    //Sets the value of the given attribute to the given value.
    class SetEffect:Effect
    {
        public SetEffect(Attrib affectedAttribute, int value) : base(affectedAttribute, value)
        {
        }

        public override void Apply(WorldState worldState)
        {
            worldState.SetValue(AffectedAttribute, Value);
        }
    }
}
