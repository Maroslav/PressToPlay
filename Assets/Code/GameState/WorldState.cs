using System;
using System.Collections.Generic;

namespace Assets.Code.GameState
{
    public class WorldState
    {
        // A shorthand to the AllStates category
        public Attribs JournalistState { get; set; }
        public DateTime Date { get; set; }

        public Dictionary<AttribsCategory, Attribs> AllStates;

        public int GetValue(Attrib attrib)
        {
            Attribs states = AllStates[attrib.Category];
            return states[attrib];
        }

       public void SetValue(Attrib attrib, int value)
        {
            Attribs states = AllStates[attrib.Category];
            states[attrib] = value;
        }

        public void AddToValue(Attrib attrib, int value)
        {
            var oldValue = GetValue(attrib);
            var newValue = oldValue + value;
            if (newValue < Attribs.MinValue) newValue = Attribs.MinValue;
            else if (newValue > Attribs.MaxValue) newValue = Attribs.MaxValue;
            SetValue(attrib, newValue);
        }
    }
}

