using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestingInADO.Migrations
{
    public partial class Setup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MovieId = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Title", "Year" },
                values: new object[,]
                {
                    { 1, "Minions", 2015 },
                    { 24, "Arrietty", 2010 },
                    { 25, "L'era glaciale 3 - L'alba dei dinosauri", 2009 },
                    { 26, "La Principessa e il Ranocchio", 2009 },
                    { 27, "Piovono gnocchi", 2009 },
                    { 28, "Kung Fu Panda", 2008 },
                    { 29, "Madagascar 2", 2008 },
                    { 30, "Ponyo sulla scogliera", 2008 },
                    { 31, "Ratatouille", 2007 },
                    { 23, "Le avventure di Sammy", 2010 },
                    { 32, "Shrek terzo", 2007 },
                    { 34, "Zootropolis", 2016 },
                    { 35, "Oceania", 2016 },
                    { 36, "Your Name", 2016 },
                    { 37, "Ballerina", 2016 },
                    { 38, "Coco", 2017 },
                    { 39, "Cars 3", 2017 },
                    { 40, "Cattivissimo Me 3", 2017 },
                    { 41, "Sherlock Gnomes", 2018 },
                    { 33, "Il viaggio di Arlo", 2015 },
                    { 42, "Il Grinch", 2018 },
                    { 22, "Shrek e vissero felici e contenti", 2010 },
                    { 20, "Toy Story 3 - La grande fuga", 2010 },
                    { 2, "Big Hero 6", 2014 },
                    { 3, "Rio 2 - Missione Amazzonia", 2014 },
                    { 4, "Frozen - Il Regno di Ghiaccio", 2013 },
                    { 5, "Monsters University", 2013 },
                    { 6, "Cattivissimo Me 2", 2013 },
                    { 7, "I Croodz", 2013 },
                    { 8, "Epic - Il mondo segreto", 2013 },
                    { 9, "Planes", 2013 },
                    { 21, "Rapunzel - L'Intreccio della Torre", 2010 },
                    { 10, "Si alza il vento", 2013 },
                    { 12, "Le 5 leggende", 2012 },
                    { 13, "L'era glaciale 4 - Continenti alla deriva", 2012 },
                    { 14, "Madagascar 3: Ricercati in Europa", 2012 },
                    { 15, "Cars 2", 2011 },
                    { 16, "Kung Fu Panda 2", 2011 },
                    { 17, "Il gatto con gli stivali", 2011 },
                    { 18, "Rio", 2011 },
                    { 19, "Cattivissimo Me", 2010 },
                    { 11, "Ribelle - The Brave", 2012 },
                    { 43, "I Primitivi", 2018 }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "MovieId", "Value" },
                values: new object[,]
                {
                    { 1, 1, 5 },
                    { 99, 28, 5 },
                    { 100, 29, 2 },
                    { 101, 29, 3 },
                    { 102, 29, 2 },
                    { 103, 29, 3 },
                    { 104, 30, 1 },
                    { 105, 30, 2 },
                    { 106, 30, 3 },
                    { 107, 30, 5 },
                    { 108, 31, 1 },
                    { 109, 31, 4 },
                    { 110, 31, 3 },
                    { 111, 31, 5 },
                    { 112, 32, 4 },
                    { 113, 32, 4 },
                    { 98, 28, 4 },
                    { 114, 32, 5 },
                    { 97, 28, 2 },
                    { 95, 27, 2 },
                    { 80, 23, 4 },
                    { 81, 23, 5 },
                    { 82, 23, 2 },
                    { 83, 23, 5 },
                    { 84, 24, 5 },
                    { 85, 24, 4 },
                    { 86, 24, 1 },
                    { 87, 25, 1 },
                    { 88, 25, 4 },
                    { 89, 25, 5 },
                    { 90, 26, 1 },
                    { 91, 26, 4 },
                    { 92, 26, 3 },
                    { 93, 27, 4 },
                    { 94, 27, 1 },
                    { 96, 28, 1 },
                    { 115, 33, 3 },
                    { 116, 33, 1 },
                    { 117, 33, 1 },
                    { 138, 39, 2 },
                    { 139, 39, 1 },
                    { 140, 40, 3 },
                    { 141, 40, 1 },
                    { 142, 40, 2 },
                    { 143, 41, 2 },
                    { 144, 41, 5 },
                    { 145, 41, 1 },
                    { 146, 41, 3 },
                    { 147, 42, 5 },
                    { 148, 42, 1 },
                    { 149, 42, 4 },
                    { 150, 42, 2 },
                    { 151, 43, 3 },
                    { 152, 43, 4 },
                    { 137, 39, 1 },
                    { 136, 38, 3 },
                    { 135, 38, 3 },
                    { 134, 38, 1 },
                    { 118, 33, 4 },
                    { 119, 34, 5 },
                    { 120, 34, 3 },
                    { 121, 34, 1 },
                    { 122, 35, 5 },
                    { 123, 35, 3 },
                    { 124, 35, 4 },
                    { 79, 22, 4 },
                    { 125, 36, 5 },
                    { 127, 36, 3 },
                    { 128, 36, 1 },
                    { 129, 37, 4 },
                    { 130, 37, 3 },
                    { 131, 37, 3 },
                    { 132, 37, 4 },
                    { 133, 38, 2 },
                    { 126, 36, 1 },
                    { 78, 22, 1 },
                    { 77, 22, 1 },
                    { 76, 21, 5 },
                    { 22, 7, 3 },
                    { 23, 7, 1 },
                    { 24, 7, 1 },
                    { 25, 7, 3 },
                    { 26, 8, 5 },
                    { 27, 8, 4 },
                    { 28, 8, 4 },
                    { 29, 9, 2 },
                    { 30, 9, 2 },
                    { 31, 9, 5 },
                    { 32, 10, 4 },
                    { 33, 10, 1 },
                    { 34, 10, 2 },
                    { 35, 10, 5 },
                    { 36, 11, 2 },
                    { 21, 6, 5 },
                    { 20, 6, 3 },
                    { 19, 6, 4 },
                    { 18, 5, 5 },
                    { 2, 1, 4 },
                    { 3, 1, 3 },
                    { 4, 1, 2 },
                    { 5, 2, 5 },
                    { 6, 2, 3 },
                    { 7, 2, 5 },
                    { 8, 2, 2 },
                    { 37, 11, 3 },
                    { 9, 3, 3 },
                    { 11, 3, 3 },
                    { 12, 4, 1 },
                    { 13, 4, 5 },
                    { 14, 4, 5 },
                    { 15, 4, 4 },
                    { 16, 5, 5 },
                    { 17, 5, 5 },
                    { 10, 3, 4 },
                    { 153, 43, 2 },
                    { 38, 11, 1 },
                    { 40, 12, 4 },
                    { 61, 17, 4 },
                    { 62, 18, 5 },
                    { 63, 18, 1 },
                    { 64, 18, 3 },
                    { 65, 19, 2 },
                    { 66, 19, 4 },
                    { 67, 19, 3 },
                    { 68, 19, 5 },
                    { 69, 20, 4 },
                    { 70, 20, 4 },
                    { 71, 20, 5 },
                    { 72, 20, 2 },
                    { 73, 21, 4 },
                    { 74, 21, 2 },
                    { 75, 21, 2 },
                    { 60, 17, 4 },
                    { 59, 17, 1 },
                    { 58, 17, 5 },
                    { 57, 16, 4 },
                    { 41, 12, 4 },
                    { 42, 12, 3 },
                    { 43, 13, 5 },
                    { 44, 13, 5 },
                    { 45, 13, 4 },
                    { 46, 14, 4 },
                    { 47, 14, 4 },
                    { 39, 11, 2 },
                    { 48, 14, 2 },
                    { 50, 15, 1 },
                    { 51, 15, 5 },
                    { 52, 15, 1 },
                    { 53, 15, 4 },
                    { 54, 16, 2 },
                    { 55, 16, 5 },
                    { 56, 16, 3 },
                    { 49, 14, 5 },
                    { 154, 43, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_Title",
                table: "Movies",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_Year",
                table: "Movies",
                column: "Year");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_MovieId",
                table: "Ratings",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
