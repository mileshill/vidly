using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vidly.Migrations
{
    public partial class PopulateMovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Movies (Genre, Name, NumberInStock, Added, ReleaseDate) VALUES ('Comedy', 'The Wolf of Wall Street', 5, CURRENT_TIMESTAMP, CAST('2013-01-01' AS DateTime));");
            migrationBuilder.Sql("INSERT INTO Movies (Genre, Name, NumberInStock, Added, ReleaseDate) VALUES ('Sci-Fi', 'Gravity', 5, CURRENT_TIMESTAMP, CAST('2013-02-01' AS DateTime));");
            migrationBuilder.Sql("INSERT INTO Movies (Genre, Name, NumberInStock, Added, ReleaseDate) VALUES ('Action', 'Iron Man 3', 5, CURRENT_TIMESTAMP, CAST('2013-03-01' AS DateTime));");
            migrationBuilder.Sql("INSERT INTO Movies (Genre, Name, NumberInStock, Added, ReleaseDate) VALUES ('Action', 'Man of Steel', 5, CURRENT_TIMESTAMP, CAST('2013-04-01' AS DateTime));");
            migrationBuilder.Sql("INSERT INTO Movies (Genre, Name, NumberInStock, Added, ReleaseDate) VALUES ('Crime', 'Now You See Me', 5, CURRENT_TIMESTAMP, CAST('2013-05-01' AS DateTime));");
            migrationBuilder.Sql("INSERT INTO Movies (Genre, Name, NumberInStock, Added, ReleaseDate) VALUES ('History', '12 Years a Slave', 5, CURRENT_TIMESTAMP, CAST('2013-06-01' AS DateTime));");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
