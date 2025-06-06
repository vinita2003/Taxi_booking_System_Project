using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taxi_Booking_System.Migrations
{
    /// <inheritdoc />
    public partial class updateContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    LocationLatitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LocationLongitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Availabilty = table.Column<int>(type: "int", nullable: true),
                    CarNumber = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    CarType = table.Column<int>(type: "int", nullable: true),
                    EmergencyContactNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
