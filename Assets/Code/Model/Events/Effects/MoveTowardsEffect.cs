using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.GameState;

namespace Assets.Code.Model.Events.Effects
{
    //Moves the value of an attribute towards the given value by the given delta.
    class MoveTowardsEffect:Effect
    {
        public MoveTowardsEffect(Attrib affectedAttribute, int value, int amount) : base(affectedAttribute, value)
        {
            Amount = amount;
        }

        public override void Apply(WorldState worldState)
        {
            var oldValue = worldState.GetValue(AffectedAttribute);
            var newValue = Algorithms.MoveTowardsPosition(oldValue,Value,Amount);
            worldState.SetValue(AffectedAttribute, newValue);
        }

        public int Amount { get; set; }
    }
}
