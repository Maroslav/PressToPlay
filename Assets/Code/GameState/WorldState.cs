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
    }
}

