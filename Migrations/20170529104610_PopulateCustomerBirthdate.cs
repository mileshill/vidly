using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vidly.Migrations
{
    public partial class PopulateCustomerBirthdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Customers SET Birthdate = CAST('1983-05-24' as DATETIME) WHERE Name LIKE '%Miles%';");
            migrationBuilder.Sql("UPDATE Customers SET Birthdate = CAST('2015-06-03' as DATETIME) WHERE Name LIKE '%Emilia%';");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
