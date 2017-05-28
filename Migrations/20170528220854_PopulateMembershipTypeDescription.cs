using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vidly.Migrations
{
    public partial class PopulateMembershipTypeDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Update MembershipTypes SET Description = 'Pay As You Go' WHERE Id = 1");
            migrationBuilder.Sql("Update MembershipTypes SET Description = 'Quarterly' WHERE Id = 2");
            migrationBuilder.Sql("Update MembershipTypes SET Description = 'Bi-Annual' WHERE Id = 3");
            migrationBuilder.Sql("Update MembershipTypes SET Description = 'Annual' WHERE Id = 4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
