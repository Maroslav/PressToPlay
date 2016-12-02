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
            JournalistState=new Dictionary<string, int>();
            JournalistState.Add(Attributes.Credibility,Attributes.MidValue);
        }
        public Dictionary<string, int> JournalistState { get; private set; }
    }
}

