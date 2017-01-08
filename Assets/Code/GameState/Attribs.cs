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

        public static readonly string StringCredibility = "Credibility";
        public static readonly Attrib Credibility = new Attrib(StringCredibility);

        public static int MinValue = 0;
        public static int MaxValue = 16;
        public static int MidValue = (MinValue + MaxValue)/2;

        private static Dictionary<string, Attrib> _attribsByName;
        public static Attrib GetAttribByName(string name)
        {
            if (!_attribsByName.ContainsKey(name))
            {
                throw new ArgumentException("Requiring non-existing attribute: "+name);
            }      
            return _attribsByName[name];      
        }

        public static void SetAttribsCollection(Dictionary<string, Attrib> col)
        {
            _attribsByName = col;
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
