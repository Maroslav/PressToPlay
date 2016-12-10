using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code.GameState
{
    public class Attribs : IEnumerable<KeyValuePair<Attrib,int>>
    {
        //STATIC CONSTANTS:
        //Values 0 - 1000;
        public static readonly string StringCredibility = "Credibility";
        public static readonly Attrib Credibility = new Attrib(StringCredibility);

        public const int MinValue = 0;
        public const int MaxValue = 1000;
        public const int MidValue = (MinValue + MaxValue)/2;

        public static List<Attrib> JournalistAttributes = new List<Attrib>() {Credibility};

        private static Dictionary<string, Attrib> attribsByName=
            new Dictionary<string, Attrib>()
            {
                {StringCredibility,Credibility}
            };
        public static Attrib GetAttribByName(string name)
        {
            if (!attribsByName.ContainsKey(name))
            {
                throw new ArgumentException("Requiring non-existing attribute: "+name);
            }      
            return attribsByName[name];      
        }

    //CLASS DECLARATION
        public Attribs(Dictionary<Attrib, int> val )
        {
            _values = val;
        }

        public Attribs()
        {
            
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

        //Creates a collection of attributes that contain only Credibility
        public static Attribs AttributesWithCredibility(int credibilityValue)
        {
            Attribs  at = new Attribs();
            at[Attribs.Credibility] = credibilityValue;
            return at;
        }

        public int this[Attrib attrib]
        {
            get { return Values[attrib]; }
            set { Values[attrib] = value; }
        }

        public IEnumerator<KeyValuePair<Attrib, int>> GetEnumerator()
        {
            return Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
