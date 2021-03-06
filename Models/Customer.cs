using System;
using System.ComponentModel.DataAnnotations;

namespace vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name")]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Date of Birth")]
        public DateTime? Birthdate { get; set; }
        
        
        [Min18YearsIfAMember]
        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        
    }
}