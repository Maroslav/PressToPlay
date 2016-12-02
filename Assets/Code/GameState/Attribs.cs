using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code.GameState
{
    public struct Attribs
    {
        //STATIC CONSTANTS:
        //Values 0 - 1000;
        public static readonly Attrib Credibility = new Attrib("Credibility");

        public const int MinValue = 0;
        public const int MaxValue = 1000;
        public const int MidValue = (MinValue + MaxValue)/2;

        public static List<Attrib> JournalistAttributes =new List<Attrib>() {Credibility};

        //CLASS DECLARATION
        public Attribs(Dictionary<Attrib, int> val )
        {
            _values = val;
        }
        public Dictionary<Attrib, int> Values
        {
            get
            {
                if (_values==null) _values=new Dictionary<Attrib, int>();
                return _values;
            }
        }

        private Dictionary<Attrib, int> _values;

        public void AddAttribute(Attrib attrib, int value)
        {
           Values.Add(attrib,value);
        }
    }
}
