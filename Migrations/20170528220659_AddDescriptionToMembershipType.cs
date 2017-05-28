using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vidly.Migrations
{
    public partial class AddDescriptionToMembershipType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MembershipTypes",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "MembershipTypes");
        }
    }
}
