using System.ComponentModel.DataAnnotations.Schema;

namespace vidly.Models
{
    [Table("MembershipTypes")]
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

    }
}