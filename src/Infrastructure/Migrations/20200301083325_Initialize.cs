using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransportationInfos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyName = table.Column<string>(maxLength: 40, nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportationInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotelInfos",
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
                    table.PrimaryKey("PK_HotelInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelInfos_Cities_cityId",
                        column: x => x.cityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
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
                    table.PrimaryKey("PK_Packages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Package_DestinationCityId",
                        column: x => x.DestinationCityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Package_OriginCityId",
                        column: x => x.OriginCityId,
                        principalTable: "Cities",
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
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotel_HotelInfoId",
                        column: x => x.HotelInfoId,
                        principalTable: "HotelInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hotel_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
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
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transportation_TransportationInfoId",
                        column: x => x.TransportationInfoId,
                        principalTable: "TransportationInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UX_City_Title",
                table: "Cities",
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
                table: "HotelInfos",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelInfos_cityId",
                table: "HotelInfos",
                column: "cityId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_DestinationCityId",
                table: "Packages",
                column: "DestinationCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_OriginCityId",
                table: "Packages",
                column: "OriginCityId");

            migrationBuilder.CreateIndex(
                name: "UX_Package_Title",
                table: "Packages",
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
                table: "TransportationInfos",
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
                name: "HotelInfos");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "TransportationInfos");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
