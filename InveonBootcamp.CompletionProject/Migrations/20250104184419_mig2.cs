using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InveonBootcamp.CompletionProject.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    Instructor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderCourses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderCourses", x => new { x.OrderId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_OrderCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderCourses_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Category", "Description", "Instructor", "Name", "Price", "Rating" },
                values: new object[,]
                {
                    { 1, "Category 1", "Description 1", "Instructor 1", "Course 1", 110m, 4.0999999999999996 },
                    { 2, "Category 2", "Description 2", "Instructor 2", "Course 2", 120m, 4.2000000000000002 },
                    { 3, "Category 3", "Description 3", "Instructor 3", "Course 3", 130m, 4.2999999999999998 },
                    { 4, "Category 4", "Description 4", "Instructor 4", "Course 4", 140m, 4.4000000000000004 },
                    { 5, "Category 0", "Description 5", "Instructor 5", "Course 5", 150m, 4.0 },
                    { 6, "Category 1", "Description 6", "Instructor 6", "Course 6", 160m, 4.0999999999999996 },
                    { 7, "Category 2", "Description 7", "Instructor 7", "Course 7", 170m, 4.2000000000000002 },
                    { 8, "Category 3", "Description 8", "Instructor 8", "Course 8", 180m, 4.2999999999999998 },
                    { 9, "Category 4", "Description 9", "Instructor 9", "Course 9", 190m, 4.4000000000000004 },
                    { 10, "Category 0", "Description 10", "Instructor 10", "Course 10", 200m, 4.0 },
                    { 11, "Category 1", "Description 11", "Instructor 11", "Course 11", 210m, 4.0999999999999996 },
                    { 12, "Category 2", "Description 12", "Instructor 12", "Course 12", 220m, 4.2000000000000002 },
                    { 13, "Category 3", "Description 13", "Instructor 13", "Course 13", 230m, 4.2999999999999998 },
                    { 14, "Category 4", "Description 14", "Instructor 14", "Course 14", 240m, 4.4000000000000004 },
                    { 15, "Category 0", "Description 15", "Instructor 15", "Course 15", 250m, 4.0 },
                    { 16, "Category 1", "Description 16", "Instructor 16", "Course 16", 260m, 4.0999999999999996 },
                    { 17, "Category 2", "Description 17", "Instructor 17", "Course 17", 270m, 4.2000000000000002 },
                    { 18, "Category 3", "Description 18", "Instructor 18", "Course 18", 280m, 4.2999999999999998 },
                    { 19, "Category 4", "Description 19", "Instructor 19", "Course 19", 290m, 4.4000000000000004 },
                    { 20, "Category 0", "Description 20", "Instructor 20", "Course 20", 300m, 4.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "PhoneNumber", "Username" },
                values: new object[,]
                {
                    { new Guid("1085409f-952a-4013-948b-d0f1a2dd56ea"), "test9@example.com", "password9", "1234567899", "testuser9" },
                    { new Guid("159d43ba-d5ed-4b4e-a00d-d1f074b981c8"), "test13@example.com", "password13", "12345678913", "testuser13" },
                    { new Guid("1f8cc70c-763e-48ec-8343-75db0ce64115"), "test3@example.com", "password3", "1234567893", "testuser3" },
                    { new Guid("1f911c79-9e8d-42c7-9cd3-ae48d2f7ee29"), "test14@example.com", "password14", "12345678914", "testuser14" },
                    { new Guid("2475eb2c-6809-4625-a1e4-b95e0c615ced"), "test2@example.com", "password2", "1234567892", "testuser2" },
                    { new Guid("2e6f547a-a6f6-4c81-9a50-f07d61dda94b"), "test4@example.com", "password4", "1234567894", "testuser4" },
                    { new Guid("30469696-8b9d-4da2-bdb6-294c4f9a15cf"), "test7@example.com", "password7", "1234567897", "testuser7" },
                    { new Guid("309c62fe-7205-459d-a00b-5cd05710d09a"), "test17@example.com", "password17", "12345678917", "testuser17" },
                    { new Guid("496f5bf6-96f3-4e95-8832-8bbcd8ff6e93"), "test10@example.com", "password10", "12345678910", "testuser10" },
                    { new Guid("4a931f2b-8fe4-4311-8aff-bdd3c26663df"), "test12@example.com", "password12", "12345678912", "testuser12" },
                    { new Guid("565a67f7-6142-428f-83c6-8d7228cf3af7"), "test20@example.com", "password20", "12345678920", "testuser20" },
                    { new Guid("61b6fe51-8241-4bc5-bf7d-cd7e0ddc1395"), "test19@example.com", "password19", "12345678919", "testuser19" },
                    { new Guid("6734178d-6e4d-4a1e-84ef-5026622210ca"), "test8@example.com", "password8", "1234567898", "testuser8" },
                    { new Guid("864cedd7-e8fb-493b-a4fe-db4918f2aeab"), "test11@example.com", "password11", "12345678911", "testuser11" },
                    { new Guid("97989c12-d29d-4609-ab8b-b8461edf3e4e"), "test18@example.com", "password18", "12345678918", "testuser18" },
                    { new Guid("9faf99e8-9d71-46e7-8729-a4192f5272f2"), "test6@example.com", "password6", "1234567896", "testuser6" },
                    { new Guid("baaf44d7-acbd-4b70-af3c-b054d150ab2d"), "test16@example.com", "password16", "12345678916", "testuser16" },
                    { new Guid("bf22affc-9fbd-46df-aede-25de58799f57"), "test15@example.com", "password15", "12345678915", "testuser15" },
                    { new Guid("ca4f7195-789c-4aad-b4e6-7f378634920a"), "test1@example.com", "password1", "1234567891", "testuser1" },
                    { new Guid("cd3bf022-dca1-4a48-8243-3720afa2af4c"), "test5@example.com", "password5", "1234567895", "testuser5" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "OrderDate", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 3, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6258), new Guid("2475eb2c-6809-4625-a1e4-b95e0c615ced") },
                    { 2, new DateTime(2025, 1, 2, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6274), new Guid("1f8cc70c-763e-48ec-8343-75db0ce64115") },
                    { 3, new DateTime(2025, 1, 1, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6275), new Guid("2e6f547a-a6f6-4c81-9a50-f07d61dda94b") },
                    { 4, new DateTime(2024, 12, 31, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6276), new Guid("cd3bf022-dca1-4a48-8243-3720afa2af4c") },
                    { 5, new DateTime(2024, 12, 30, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6277), new Guid("9faf99e8-9d71-46e7-8729-a4192f5272f2") },
                    { 6, new DateTime(2024, 12, 29, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6279), new Guid("30469696-8b9d-4da2-bdb6-294c4f9a15cf") },
                    { 7, new DateTime(2024, 12, 28, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6280), new Guid("6734178d-6e4d-4a1e-84ef-5026622210ca") },
                    { 8, new DateTime(2024, 12, 27, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6280), new Guid("1085409f-952a-4013-948b-d0f1a2dd56ea") },
                    { 9, new DateTime(2024, 12, 26, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6281), new Guid("496f5bf6-96f3-4e95-8832-8bbcd8ff6e93") },
                    { 10, new DateTime(2024, 12, 25, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6283), new Guid("864cedd7-e8fb-493b-a4fe-db4918f2aeab") },
                    { 11, new DateTime(2024, 12, 24, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6283), new Guid("4a931f2b-8fe4-4311-8aff-bdd3c26663df") },
                    { 12, new DateTime(2024, 12, 23, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6284), new Guid("159d43ba-d5ed-4b4e-a00d-d1f074b981c8") },
                    { 13, new DateTime(2024, 12, 22, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6285), new Guid("1f911c79-9e8d-42c7-9cd3-ae48d2f7ee29") },
                    { 14, new DateTime(2024, 12, 21, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6286), new Guid("bf22affc-9fbd-46df-aede-25de58799f57") },
                    { 15, new DateTime(2024, 12, 20, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6286), new Guid("baaf44d7-acbd-4b70-af3c-b054d150ab2d") },
                    { 16, new DateTime(2024, 12, 19, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6287), new Guid("309c62fe-7205-459d-a00b-5cd05710d09a") },
                    { 17, new DateTime(2024, 12, 18, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6288), new Guid("97989c12-d29d-4609-ab8b-b8461edf3e4e") },
                    { 18, new DateTime(2024, 12, 17, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6289), new Guid("61b6fe51-8241-4bc5-bf7d-cd7e0ddc1395") },
                    { 19, new DateTime(2024, 12, 16, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6290), new Guid("565a67f7-6142-428f-83c6-8d7228cf3af7") },
                    { 20, new DateTime(2024, 12, 15, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6291), new Guid("ca4f7195-789c-4aad-b4e6-7f378634920a") }
                });

            migrationBuilder.InsertData(
                table: "OrderCourses",
                columns: new[] { "CourseId", "OrderId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 2 },
                    { 5, 2 },
                    { 6, 3 },
                    { 7, 3 },
                    { 8, 4 },
                    { 9, 4 },
                    { 10, 5 },
                    { 11, 5 },
                    { 12, 6 },
                    { 13, 6 },
                    { 14, 7 },
                    { 15, 7 },
                    { 16, 8 },
                    { 17, 8 },
                    { 18, 9 },
                    { 19, 9 },
                    { 1, 10 },
                    { 20, 10 },
                    { 2, 11 },
                    { 3, 11 },
                    { 4, 12 },
                    { 5, 12 },
                    { 6, 13 },
                    { 7, 13 },
                    { 8, 14 },
                    { 9, 14 },
                    { 10, 15 },
                    { 11, 15 },
                    { 12, 16 },
                    { 13, 16 },
                    { 14, 17 },
                    { 15, 17 },
                    { 16, 18 },
                    { 17, 18 },
                    { 18, 19 },
                    { 19, 19 },
                    { 1, 20 },
                    { 20, 20 }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "OrderId", "PaymentDate", "PaymentStatus" },
                values: new object[,]
                {
                    { 1, 110m, 1, new DateTime(2025, 1, 3, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6325), "Completed" },
                    { 2, 120m, 2, new DateTime(2025, 1, 2, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6362), "Completed" },
                    { 3, 130m, 3, new DateTime(2025, 1, 1, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6363), "Completed" },
                    { 4, 140m, 4, new DateTime(2024, 12, 31, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6364), "Completed" },
                    { 5, 150m, 5, new DateTime(2024, 12, 30, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6365), "Completed" },
                    { 6, 160m, 6, new DateTime(2024, 12, 29, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6366), "Completed" },
                    { 7, 170m, 7, new DateTime(2024, 12, 28, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6367), "Completed" },
                    { 8, 180m, 8, new DateTime(2024, 12, 27, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6368), "Completed" },
                    { 9, 190m, 9, new DateTime(2024, 12, 26, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6368), "Completed" },
                    { 10, 200m, 10, new DateTime(2024, 12, 25, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6370), "Completed" },
                    { 11, 210m, 11, new DateTime(2024, 12, 24, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6370), "Completed" },
                    { 12, 220m, 12, new DateTime(2024, 12, 23, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6371), "Completed" },
                    { 13, 230m, 13, new DateTime(2024, 12, 22, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6372), "Completed" },
                    { 14, 240m, 14, new DateTime(2024, 12, 21, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6372), "Completed" },
                    { 15, 250m, 15, new DateTime(2024, 12, 20, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6373), "Completed" },
                    { 16, 260m, 16, new DateTime(2024, 12, 19, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6374), "Completed" },
                    { 17, 270m, 17, new DateTime(2024, 12, 18, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6374), "Completed" },
                    { 18, 280m, 18, new DateTime(2024, 12, 17, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6376), "Completed" },
                    { 19, 290m, 19, new DateTime(2024, 12, 16, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6377), "Completed" },
                    { 20, 300m, 20, new DateTime(2024, 12, 15, 21, 44, 19, 86, DateTimeKind.Local).AddTicks(6377), "Completed" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderCourses_CourseId",
                table: "OrderCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderCourses");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
