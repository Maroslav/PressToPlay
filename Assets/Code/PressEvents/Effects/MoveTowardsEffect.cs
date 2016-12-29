using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.GameState;

namespace Assets.Code.Model.Events.Effects
{
    //Moves the value of an attribute towards the given value by the given delta.
    public class MoveTowardsEffect : Effect
    {
        public int Amount { get; set; }
        public MoveTowardsEffect(Attrib affectedAttribute, int value, int amount) : base(affectedAttribute, value)
        {
            Amount = amount;
        }

        public override void Apply(WorldState worldState)
        {
            var oldValue = worldState.GetValue(AffectedAttribute);
            var newValue = Algorithms.MoveTowardsPosition(oldValue, Value, Amount);
            worldState.SetValue(AffectedAttribute, newValue);
        }

        public override int GetDistance(WorldState worldState)
        {
            var journalistState = worldState.JournalistState;
            if (!journalistState.Values.ContainsKey(AffectedAttribute)) return 0;
            var current = journalistState[AffectedAttribute];
            return Math.Abs(current - Value);
        }
    }
}
