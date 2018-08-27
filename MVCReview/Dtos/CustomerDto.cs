using MVCReview.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCReview.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        // Going to remove MembershipType becuase
        // this will cause a dependency to our Domain
        // Model - if you cahnge membership type
        // use primative types like int, bool, string
        // or custom Dtos
        // want hierarchialy data then need
        // MembershipTypeDto
        //public MembershipType MembershipType { get; set; }

        // Foreign key
        // this is implicitly required because type is byte
        // optional is byte?
        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        //[Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}