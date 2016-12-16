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
    }
}

