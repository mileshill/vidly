using System.ComponentModel.DataAnnotations;
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
        
        [StringLength(255)]
        public string Description {get; set;}

        
        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;

    }
}