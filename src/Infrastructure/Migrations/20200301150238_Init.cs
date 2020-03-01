using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransportationInfo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyName = table.Column<string>(maxLength: 40, nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportationInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotelInfo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 40, nullable: false),
                    Stars = table.Column<int>(nullable: false, defaultValue: 0),
                    Rate = table.Column<decimal>(type: "decimal(4, 2)", nullable: false, defaultValue: 0m),
                    cityId = table.Column<long>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelInfo_City_cityId",
                        column: x => x.cityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 40, nullable: false),
                    OriginCityId = table.Column<long>(nullable: false),
                    DestinationCityId = table.Column<long>(nullable: false),
                    SupportPhone = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Package_DestinationCityId",
                        column: x => x.DestinationCityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Package_OriginCityId",
                        column: x => x.OriginCityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HotelInfoId = table.Column<long>(nullable: false),
                    PackageId = table.Column<long>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(6,1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotel_HotelInfoId",
                        column: x => x.HotelInfoId,
                        principalTable: "HotelInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hotel_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transportation",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TransportationInfoId = table.Column<long>(nullable: false),
                    PackageId = table.Column<long>(nullable: false),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transportation_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transportation_TransportationInfoId",
                        column: x => x.TransportationInfoId,
                        principalTable: "TransportationInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UX_City_Title",
                table: "City",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_HotelInfoId",
                table: "Hotel",
                column: "HotelInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_PackageId",
                table: "Hotel",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "UX_HotelInfo_Title",
                table: "HotelInfo",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelInfo_cityId",
                table: "HotelInfo",
                column: "cityId");

            migrationBuilder.CreateIndex(
                name: "IX_Package_DestinationCityId",
                table: "Package",
                column: "DestinationCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Package_OriginCityId",
                table: "Package",
                column: "OriginCityId");

            migrationBuilder.CreateIndex(
                name: "UX_Package_Title",
                table: "Package",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transportation_PackageId",
                table: "Transportation",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Transportation_TransportationInfoId",
                table: "Transportation",
                column: "TransportationInfoId");

            migrationBuilder.CreateIndex(
                name: "UX_TransportationInfo_CompanyName",
                table: "TransportationInfo",
                column: "CompanyName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "Transportation");

            migrationBuilder.DropTable(
                name: "HotelInfo");

            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "TransportationInfo");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
