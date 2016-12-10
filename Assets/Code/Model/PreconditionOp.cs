using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Assets.Code.Model
{
    public enum PreconditionOp
    {
        [XmlEnum(Name = "less")]
        LessThan,
        [XmlEnum(Name = "greater")]
        GreaterThan,
        [XmlEnum(Name = "equal")]
        Equal,
        [XmlEnum(Name = "lessOrEqual")]
        LessOrEqual
    }
}
