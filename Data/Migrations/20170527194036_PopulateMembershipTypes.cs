using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vidly.Data.Migrations
{
    public partial class PopulateMembershipTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Pay as you go
            migrationBuilder.Sql("INSERT INTO MembershipType (SignUpFee, DurationInMonths, DiscountRate) VALUES (0, 0, 0)");
            
            // Monthly
            migrationBuilder.Sql("INSERT INTO MembershipType (SignUpFee, DurationInMonths, DiscountRate) VALUES (30, 1, 10)");
            
            // Quartly
            migrationBuilder.Sql("INSERT INTO MembershipType (SignUpFee, DurationInMonths, DiscountRate) VALUES (90, 3, 15)");
            
            // Annual
            migrationBuilder.Sql("INSERT INTO MembershipType (SignUpFee, DurationInMonths, DiscountRate) VALUES (300, 12, 20)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("DELETE FROM MembershipType");
        }
    }
}
