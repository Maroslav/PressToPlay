using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.GameState;

namespace Assets.Code.Model.Events.Effects
{
    public abstract class Effect
    {
        protected Effect(Attrib affectedAttribute, int value)
        {
            AffectedAttribute = affectedAttribute;
            Value = value;
        }
        public Attrib AffectedAttribute { get; set; }
        public int Value { get; set; }
        public abstract void Apply(WorldState worldState);

        /// <summary>
        /// Calculates how much the effect affects the journalist's
        /// attributes if it is applied.
        /// </summary>
        /// <returns></returns>
        public virtual int GetDistance(WorldState worldState)
        {
            return 0;
        }
    }
}
