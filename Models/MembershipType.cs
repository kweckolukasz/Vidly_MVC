using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonth { get; set; }
        public byte DiscountRate { get; set; }
        public string Name { get; set; }

        public static readonly byte UnAssigned = 0;
        public static readonly byte PayAsYouGo = 1;
        public static readonly byte Monthly = 1;
        public static readonly byte Quarterly = 1;
        public static readonly byte Annual = 1;
    }
}