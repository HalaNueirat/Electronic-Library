using Microsoft.EntityFrameworkCore.Migrations;

namespace Electronic_Library1.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Salary = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    BookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Name", "Password", "Salary" },
                values: new object[] { 1, "Ruba Hardan", "111", 2000 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Name", "Password", "Salary" },
                values: new object[] { 2, "Hajar Draghma", "222", 2000 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Name", "Password", "Salary" },
                values: new object[] { 3, "Sara Salama", "333", 2000 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "EmployeeId", "Price", "Title" },
                values: new object[] { 1, "Ernest Hemingway", 1, 20, "The Old Man And The Sea" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "EmployeeId", "Price", "Title" },
                values: new object[] { 2, "J.K Rowling", 2, 40, "Harry Potter" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "EmployeeId", "Price", "Title" },
                values: new object[] { 3, "Lois Lowry", 3, 30, "The Giver" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "BookId", "Name", "Password" },
                values: new object[] { 1, 1, "Hala Nairat", "123" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "BookId", "Name", "Password" },
                values: new object[] { 2, 2, "Ola Alawna", "234" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "BookId", "Name", "Password" },
                values: new object[] { 3, 3, "Aya Almoghayir", "456" });

            migrationBuilder.CreateIndex(
                name: "IX_Books_EmployeeId",
                table: "Books",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BookId",
                table: "Customers",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
