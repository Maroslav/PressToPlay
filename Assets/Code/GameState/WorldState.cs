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
        }
        public Attribs JournalistState { get; private set; }
    }
}

