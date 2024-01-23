using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace asp_net_core_web_app_authentication_authorisation.Migrations
{
    /// <inheritdoc />
    public partial class gettingtheremigrtion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelDiscounts");

            migrationBuilder.DeleteData(
                table: "HotelAvailabilities",
                keyColumn: "HotelAvailabilityId",
                keyValue: new Guid("8ef56834-9376-460a-8869-bec55817cc53"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("207f790c-2ff5-4624-b39c-735584a35269"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("99b4fff7-ef38-4ce8-9aad-65393d5c9f18"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("bf8a64d5-8281-48fa-885f-a461e46af6fd"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("c2d2af4e-27ef-48fd-b425-e51fb1e0a7c8"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("df332196-0602-4b42-b3d5-62d4f099416c"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("e02bf361-74fd-49d1-8546-fba73629fcc1"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("e22b9fd9-bfe9-4925-be41-e880b3ad1d7b"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("eec71ffb-7b0c-402d-a0a7-7ed8f9d61228"));

            migrationBuilder.DeleteData(
                table: "TourAvailabilities",
                keyColumn: "TourAvailabilityId",
                keyValue: new Guid("03881b87-89e3-49e3-ba2d-6c6015967330"));

            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "TourId",
                keyValue: new Guid("8bc8d1ba-4388-4591-a2bb-621ed5720a51"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("c09fc506-a50c-45c1-871f-3e7fc9b74892"));

            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "TourId",
                keyValue: new Guid("8c114f4c-dfdc-4050-818b-e245f7e9a825"));

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "AvailableSpaces", "Cost", "Name", "RoomType" },
                values: new object[,]
                {
                    { new Guid("00d9a7c5-0bef-4a11-99f2-d035a17875ea"), 20, 375m, "HiltonLondonHotel", "single" },
                    { new Guid("0ccfbd3f-62ef-492e-94f6-af9d6369f114"), 20, 300m, "LondonMarriotHotel", "family suite" },
                    { new Guid("232deb8b-7105-45f0-873d-321a8d9e063d"), 20, 950m, "HiltonLondonHotel", "family suite" },
                    { new Guid("49101899-236e-494a-8d34-d5fd69611f6a"), 20, 300m, "LondonMarriotHotel", "single" },
                    { new Guid("87fc9b97-e622-405a-9549-c4cd30899fd6"), 20, 300m, "LondonMarriotHotel", "Double" },
                    { new Guid("8af858a5-0a76-4f04-bb87-baba38293d68"), 20, 300m, "LondonMarriotHotel", "family suite" },
                    { new Guid("b333930e-6fcc-4273-a2bf-9f5c6b026872"), 20, 775m, "HiltonLondonHotel", "double" },
                    { new Guid("dae80db6-641b-477c-a65b-e9fc7a070796"), 20, 300m, "LondonMarriotHotel", "single" },
                    { new Guid("f29a33df-deab-418d-ad96-228fe77b5742"), 20, 300m, "LondonMarriotHotel", "double" }
                });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "TourId", "AvailableSpaces", "Cost", "DurationInDays", "Name" },
                values: new object[,]
                {
                    { new Guid("24011b1c-6e84-428e-95f4-0ab4fb1bc85f"), 20, 600m, 5, "Britain and Ireland Explorer" },
                    { new Guid("b80bd332-2779-49a3-8d79-4f931836dc46"), 20, 600m, 5, "Real Britain" }
                });

            migrationBuilder.InsertData(
                table: "HotelAvailabilities",
                columns: new[] { "HotelAvailabilityId", "AvailableFrom", "AvailableTo", "HotelId" },
                values: new object[] { new Guid("c1d4aea9-197f-41b4-bfeb-9c94fdbbea36"), new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00d9a7c5-0bef-4a11-99f2-d035a17875ea") });

            migrationBuilder.InsertData(
                table: "TourAvailabilities",
                columns: new[] { "TourAvailabilityId", "AvailableFrom", "AvailableTo", "TourId" },
                values: new object[] { new Guid("9bb45630-1e85-44ec-828a-297f10fb8980"), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b80bd332-2779-49a3-8d79-4f931836dc46") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HotelAvailabilities",
                keyColumn: "HotelAvailabilityId",
                keyValue: new Guid("c1d4aea9-197f-41b4-bfeb-9c94fdbbea36"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("0ccfbd3f-62ef-492e-94f6-af9d6369f114"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("232deb8b-7105-45f0-873d-321a8d9e063d"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("49101899-236e-494a-8d34-d5fd69611f6a"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("87fc9b97-e622-405a-9549-c4cd30899fd6"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("8af858a5-0a76-4f04-bb87-baba38293d68"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("b333930e-6fcc-4273-a2bf-9f5c6b026872"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("dae80db6-641b-477c-a65b-e9fc7a070796"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("f29a33df-deab-418d-ad96-228fe77b5742"));

            migrationBuilder.DeleteData(
                table: "TourAvailabilities",
                keyColumn: "TourAvailabilityId",
                keyValue: new Guid("9bb45630-1e85-44ec-828a-297f10fb8980"));

            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "TourId",
                keyValue: new Guid("24011b1c-6e84-428e-95f4-0ab4fb1bc85f"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("00d9a7c5-0bef-4a11-99f2-d035a17875ea"));

            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "TourId",
                keyValue: new Guid("b80bd332-2779-49a3-8d79-4f931836dc46"));

            migrationBuilder.CreateTable(
                name: "HotelDiscounts",
                columns: table => new
                {
                    HotelDiscountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelDiscountPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelDiscounts", x => x.HotelDiscountId);
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "AvailableSpaces", "Cost", "Name", "RoomType" },
                values: new object[,]
                {
                    { new Guid("207f790c-2ff5-4624-b39c-735584a35269"), 20, 300m, "LondonMarriotHotel", "double" },
                    { new Guid("99b4fff7-ef38-4ce8-9aad-65393d5c9f18"), 20, 300m, "LondonMarriotHotel", "Double" },
                    { new Guid("bf8a64d5-8281-48fa-885f-a461e46af6fd"), 20, 300m, "LondonMarriotHotel", "family suite" },
                    { new Guid("c09fc506-a50c-45c1-871f-3e7fc9b74892"), 20, 375m, "HiltonLondonHotel", "single" },
                    { new Guid("c2d2af4e-27ef-48fd-b425-e51fb1e0a7c8"), 20, 775m, "HiltonLondonHotel", "double" },
                    { new Guid("df332196-0602-4b42-b3d5-62d4f099416c"), 20, 300m, "LondonMarriotHotel", "family suite" },
                    { new Guid("e02bf361-74fd-49d1-8546-fba73629fcc1"), 20, 300m, "LondonMarriotHotel", "single" },
                    { new Guid("e22b9fd9-bfe9-4925-be41-e880b3ad1d7b"), 20, 300m, "LondonMarriotHotel", "single" },
                    { new Guid("eec71ffb-7b0c-402d-a0a7-7ed8f9d61228"), 20, 950m, "HiltonLondonHotel", "family suite" }
                });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "TourId", "AvailableSpaces", "Cost", "DurationInDays", "Name" },
                values: new object[,]
                {
                    { new Guid("8bc8d1ba-4388-4591-a2bb-621ed5720a51"), 20, 600m, 5, "Britain and Ireland Explorer" },
                    { new Guid("8c114f4c-dfdc-4050-818b-e245f7e9a825"), 20, 600m, 5, "Real Britain" }
                });

            migrationBuilder.InsertData(
                table: "HotelAvailabilities",
                columns: new[] { "HotelAvailabilityId", "AvailableFrom", "AvailableTo", "HotelId" },
                values: new object[] { new Guid("8ef56834-9376-460a-8869-bec55817cc53"), new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c09fc506-a50c-45c1-871f-3e7fc9b74892") });

            migrationBuilder.InsertData(
                table: "TourAvailabilities",
                columns: new[] { "TourAvailabilityId", "AvailableFrom", "AvailableTo", "TourId" },
                values: new object[] { new Guid("03881b87-89e3-49e3-ba2d-6c6015967330"), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8c114f4c-dfdc-4050-818b-e245f7e9a825") });
        }
    }
}
