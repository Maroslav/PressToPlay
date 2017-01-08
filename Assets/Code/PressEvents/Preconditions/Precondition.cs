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
        public abstract bool Check(WorldState state);

        public static Precondition FromDao(PreconditionDao dao)
        {

            if (dao.AttributeName == "date")
            {
                return CreateDatePrecond(dao.Operation, dao.Value);
            }
            var attribute = Attribs.GetAttribByName(dao.AttributeName);
            var valStr = dao.Value;
            int val;
            bool isNum=Int32.TryParse(valStr,out val);
            Attrib comparedAttrib = null;
            if (!isNum)
            {
                comparedAttrib = Attribs.GetAttribByName(valStr);
            }
            switch (dao.Operation)
            {
                case PreconditionOp.LessThan:
                    if (isNum) return new LessThanPrecondition(attribute, val);
                    return new LessThanAttribPrecondition(attribute, comparedAttrib);
                case PreconditionOp.GreaterThan:
                    if (isNum) return new GreaterThanPrecondition(attribute, val);
                    return new GreaterThanAttribPrecondition(attribute, comparedAttrib);
                case PreconditionOp.Equal:
                    if (isNum) return new EqualPrecondition(attribute, val);
                    return new EqualAttribPrecondition(attribute, comparedAttrib);
                case PreconditionOp.LessOrEqual:
                    if (isNum) return new LessOrEqualPrecondition(attribute,val);
                    return new LessOrEqualAttribPrecondition(attribute, comparedAttrib);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static Precondition CreateDatePrecond(PreconditionOp operation, string dateStr)
        {
            var date = DateTime.Parse(dateStr);
            switch (operation)
            {
                case PreconditionOp.LessThan:
                    return new DateLessThanPrecondition(date);
                case PreconditionOp.GreaterThan:
                    return new DateGreaterThanPrecondition(date);
                case PreconditionOp.Equal:
                    return new DateEqualPrecondition(date);
                case PreconditionOp.LessOrEqual:
                    return new DateLessOrEqualPrecondition(date);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
