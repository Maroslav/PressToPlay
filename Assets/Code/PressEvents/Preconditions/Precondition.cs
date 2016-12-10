using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.GameState;
using Assets.Code.Model;

namespace Assets.Code.PressEvents.Preconditions
{
    public abstract class Precondition
    {
        public Precondition(Attrib attribute, int value)
        {
            Attribute = attribute;
            Value = value;
        }

        public Attrib Attribute { get; private set; }
        public int Value { get; set; }
        public abstract bool Check(WorldState state);

        public static Precondition FromDao(PreconditionDao dao)
        {

            var attribute = Attribs.GetAttribByName(dao.AttributeName);
            var val = dao.Value;
            switch (dao.Operation)
            {
                case PreconditionOp.LessThan:
                    return new LessThanPrecondition(attribute, val);
                case PreconditionOp.GreaterThan:
                    return new GreaterThanPrecondition(attribute, val);
                case PreconditionOp.Equal:
                    return new EqualPrecondition(attribute, val);
                case PreconditionOp.LessOrEqual:
                    return new LessOrEqualPrecondition(attribute,val);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
