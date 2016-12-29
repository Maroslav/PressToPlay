using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code.GameState
{
    public class WorldState
    {
        public WorldState()
        {
        }
        public Attribs JournalistState { get; set; }

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

