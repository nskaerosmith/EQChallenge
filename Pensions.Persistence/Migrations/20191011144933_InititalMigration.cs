using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pensions.Persistence.Migrations
{
    public partial class InititalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accrual",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EffectiveDate = table.Column<DateTime>(nullable: false),
                    Rate = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accrual", x => x.Id);
                    table.UniqueConstraint("AK_Accrual_EffectiveDate", x => x.EffectiveDate);
                });

            migrationBuilder.CreateTable(
                name: "Basic",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    Forename = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scheme",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scheme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    BasicId = table.Column<int>(nullable: false),
                    HouseName = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Town = table.Column<string>(nullable: true),
                    County = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.BasicId);
                    table.ForeignKey(
                        name: "FK_Address_Basic_BasicId",
                        column: x => x.BasicId,
                        principalTable: "Basic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalaryHistory",
                columns: table => new
                {
                    EffectiveDate = table.Column<DateTime>(nullable: false),
                    BasicId = table.Column<int>(nullable: false),
                    Value = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryHistory", x => new { x.BasicId, x.EffectiveDate });
                    table.ForeignKey(
                        name: "FK_SalaryHistory_Basic_BasicId",
                        column: x => x.BasicId,
                        principalTable: "Basic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceHistory",
                columns: table => new
                {
                    StartDate = table.Column<DateTime>(nullable: false),
                    BasicId = table.Column<int>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    SchemeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceHistory", x => new { x.BasicId, x.StartDate });
                    table.ForeignKey(
                        name: "FK_ServiceHistory_Basic_BasicId",
                        column: x => x.BasicId,
                        principalTable: "Basic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceHistory_Scheme_SchemeId",
                        column: x => x.SchemeId,
                        principalTable: "Scheme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accrual",
                columns: new[] { "Id", "EffectiveDate", "Rate" },
                values: new object[,]
                {
                    { 1, new DateTime(1950, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 50f },
                    { 2, new DateTime(2000, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 80f },
                    { 3, new DateTime(2015, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 125f }
                });

            migrationBuilder.InsertData(
                table: "Basic",
                columns: new[] { "Id", "DateOfBirth", "Forename", "Surname", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(1969, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael", "Cole", "Mr" },
                    { 2, new DateTime(1981, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elizabeth", "Wright", "Mrs" },
                    { 3, new DateTime(1993, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel", "Rose", "Mr" },
                    { 4, new DateTime(1956, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pauline", "Roberts", "Mrs" }
                });

            migrationBuilder.InsertData(
                table: "Scheme",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Equiniti Scheme 1" });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "BasicId", "Country", "County", "HouseName", "PostCode", "Street", "Town" },
                values: new object[,]
                {
                    { 1, "United Kingdom", "West Sussex", "Sutherland House", "RH10 1UH", "Russell Way", "Crawley" },
                    { 3, "United Kingdom", "West Sussex", "Sutherland House", "RH10 1UH", "Russell Way", "Crawley" },
                    { 4, "United Kingdom", "West Sussex", "Sutherland House", "RH10 1UH", "Russell Way", "Crawley" },
                    { 2, "United Kingdom", "West Sussex", "Sutherland House", "RH10 1UH", "Russell Way", "Crawley" }
                });

            migrationBuilder.InsertData(
                table: "SalaryHistory",
                columns: new[] { "BasicId", "EffectiveDate", "Value" },
                values: new object[,]
                {
                    { 3, new DateTime(2013, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 90000.270000000004 },
                    { 3, new DateTime(2012, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 100762.11 },
                    { 4, new DateTime(2007, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 33012.199999999997 },
                    { 2, new DateTime(2014, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 26540.0 },
                    { 2, new DateTime(2004, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 23000.0 },
                    { 1, new DateTime(2010, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 23334.450000000001 },
                    { 1, new DateTime(2019, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 29594.98 },
                    { 1, new DateTime(2018, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 28823.66 },
                    { 1, new DateTime(2017, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 28072.439999999999 },
                    { 1, new DateTime(2016, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 27340.799999999999 },
                    { 1, new DateTime(2015, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 26628.23 },
                    { 1, new DateTime(2014, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 25934.23 },
                    { 1, new DateTime(2013, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 25258.32 },
                    { 1, new DateTime(2012, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 24600.02 },
                    { 4, new DateTime(1977, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 15032.99 },
                    { 1, new DateTime(2009, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 22726.290000000001 },
                    { 1, new DateTime(2011, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 23958.880000000001 },
                    { 1, new DateTime(2007, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 21557.110000000001 },
                    { 1, new DateTime(1990, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13760.0 },
                    { 1, new DateTime(1991, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 14128.219999999999 },
                    { 1, new DateTime(1992, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 14506.290000000001 },
                    { 1, new DateTime(1993, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 14894.48 },
                    { 1, new DateTime(1994, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 15293.059999999999 },
                    { 1, new DateTime(1995, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 15702.299999999999 },
                    { 1, new DateTime(2008, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 22133.98 },
                    { 1, new DateTime(1997, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 16553.93 },
                    { 1, new DateTime(1998, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 16996.91 },
                    { 1, new DateTime(1996, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 16122.49 },
                    { 1, new DateTime(2000, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 17918.759999999998 },
                    { 1, new DateTime(2001, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 18398.27 },
                    { 1, new DateTime(2002, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 18890.610000000001 },
                    { 1, new DateTime(2003, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 19396.119999999999 },
                    { 1, new DateTime(2004, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 19915.16 },
                    { 1, new DateTime(2005, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 20448.09 },
                    { 1, new DateTime(2006, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 20995.279999999999 },
                    { 1, new DateTime(1999, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 17451.75 }
                });

            migrationBuilder.InsertData(
                table: "ServiceHistory",
                columns: new[] { "BasicId", "StartDate", "EndDate", "SchemeId" },
                values: new object[,]
                {
                    { 4, new DateTime(1977, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1985, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 1, new DateTime(1990, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 2, new DateTime(2004, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2009, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2014, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 3, new DateTime(2012, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, new DateTime(1996, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2008, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHistory_SchemeId",
                table: "ServiceHistory",
                column: "SchemeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accrual");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "SalaryHistory");

            migrationBuilder.DropTable(
                name: "ServiceHistory");

            migrationBuilder.DropTable(
                name: "Basic");

            migrationBuilder.DropTable(
                name: "Scheme");
        }
    }
}
