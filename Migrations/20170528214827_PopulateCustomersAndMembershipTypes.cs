using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vidly.Migrations
{
    public partial class PopulateCustomersAndMembershipTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("INSERT INTO MembershipTypes (DiscountRate, DurationInMonths, SignUpFee) Values (0, 0, 90);");
            migrationBuilder.Sql("INSERT INTO MembershipTypes (DiscountRate, DurationInMonths, SignUpFee) Values (10, 3, 60);");
            migrationBuilder.Sql("INSERT INTO MembershipTypes (DiscountRate, DurationInMonths, SignUpFee) Values (20, 6, 30);");
            migrationBuilder.Sql("INSERT INTO MembershipTypes (DiscountRate, DurationInMonths, SignUpFee) Values (30, 12, 0);");

            migrationBuilder.Sql("INSERT INTO Customers (IsSubscribedToNewsletter, MembershipTypeId, Name) Values (0, 1, 'Miles Hill');");
            migrationBuilder.Sql("INSERT INTO Customers (IsSubscribedToNewsletter, MembershipTypeId, Name) Values (0, 2, 'Shana Hill');");
            migrationBuilder.Sql("INSERT INTO Customers (IsSubscribedToNewsletter, MembershipTypeId, Name) Values (1, 3, 'Emilia Taylor');");
            migrationBuilder.Sql("INSERT INTO Customers (IsSubscribedToNewsletter, MembershipTypeId, Name) Values (1, 4, 'Chunk Norris');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
