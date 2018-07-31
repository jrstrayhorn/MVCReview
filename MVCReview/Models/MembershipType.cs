using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCReview.Models
{
    public class MembershipType
    {
        // using a byte because we only have a few membership types
        public byte Id { get; set; }

        // short because value wont get higher than 32,000
        public short SignUpFee { get; set; }

        // byte because largest value only going up to 12
        public byte DurationInMonths { get; set; }

        // byte percentage between 0 and 100
        public byte DiscountRate { get; set; }

        [Required]
        public string Name { get; set; }
    }
}