using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.GameState;

namespace Assets.Code.Model.Events.Effects
{
    //adds or subtracts the given value from the given attribute.
    public class ModifyEffect:Effect
    {
        public ModifyEffect(Attrib affectedAttribute, int value) : base(affectedAttribute, value)
        {
        }

        public override void Apply(WorldState worldState)
        {
            var oldValue = worldState.GetValue(AffectedAttribute);
            worldState.SetValue(AffectedAttribute,oldValue+Value);
        }
    }
}
