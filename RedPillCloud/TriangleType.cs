using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RedPillCloud
{
    [DataContract(Name = "TriangleType")]
    public enum TriangleType : int
    {
        [EnumMember]
        Error = 0,
        [EnumMember]
        Equilateral = 1,
        [EnumMember]
        Isosceles = 2,
        [EnumMember]
        Scalene = 3,
    }
}