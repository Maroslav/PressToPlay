using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code.GameState
{
    ///Represents an attribute of the journalist, newspaper or of the world
    ///named Attrib to avoid system class collision
    public class Attrib
    {
        public Attrib(string description)
        {
            Description = description;
        }

        public string Description { get; private set; }
        public AttribsCategory Category { get; set; }
        public bool IsDisplayed { get; set; }
    }
}
