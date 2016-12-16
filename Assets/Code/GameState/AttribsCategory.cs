using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code.GameState
{
    public class AttribsCategory
    {
        public AttribsCategory(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public List<Attrib> Attribs { get; private set; }
    }
}
