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
            JournalistState=new Attribs();
            JournalistState.AddAttribute(Attribs.Credibility,Attribs.MidValue);
        }
        public Attribs JournalistState { get; private set; }
    }
}

