using System;
using System.ComponentModel.DataAnnotations;

namespace vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        public DateTime? Birthdate { get; set; }
        
        public byte MembershipTypeId { get; set; }
    }
}