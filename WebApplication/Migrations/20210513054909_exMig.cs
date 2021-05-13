using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class exMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassInputModeles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CH4 = table.Column<double>(nullable: false),
                    C2H6 = table.Column<double>(nullable: false),
                    C3H8 = table.Column<double>(nullable: false),
                    C4H10 = table.Column<double>(nullable: false),
                    C5H12 = table.Column<double>(nullable: false),
                    N2 = table.Column<double>(nullable: false),
                    CO2 = table.Column<double>(nullable: false),
                    KPD = table.Column<double>(nullable: false),
                    ParPr = table.Column<double>(nullable: false),
                    WorkPressureOnDrum = table.Column<double>(nullable: false),
                    WorkPressureOnExit = table.Column<double>(nullable: false),
                    Tpp = table.Column<double>(nullable: false),
                    Tpv = table.Column<double>(nullable: false),
                    Tug = table.Column<double>(nullable: false),
                    Tgv = table.Column<double>(nullable: false),
                    Thv = table.Column<double>(nullable: false),
                    Tpodgas = table.Column<double>(nullable: false),
                    Tpodvosd = table.Column<double>(nullable: false),
                    alfa = table.Column<double>(nullable: false),
                    himnedog = table.Column<double>(nullable: false),
                    Vlagosod = table.Column<double>(nullable: false),
                    D = table.Column<double>(nullable: false),
                    L = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassInputModeles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassInputModeles");
        }
    }
}
