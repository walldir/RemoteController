using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RemoteController.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    MacAddress = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    IpAddress = table.Column<string>(type: "varchar(39)", maxLength: 39, nullable: true),
                    Antivirus = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    IsFirewallActive = table.Column<bool>(nullable: false, defaultValue: false),
                    IsAvailable = table.Column<bool>(nullable: false, defaultValue: false),
                    WindowsVersion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    DotNetFrameworkVersion = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    SpaceHdUsed = table.Column<double>(nullable: false),
                    HdSize = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    CommandExeccuted = table.Column<string>(nullable: true),
                    Result = table.Column<string>(nullable: true),
                    MachineId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Machines",
                columns: new[] { "Id", "Antivirus", "DotNetFrameworkVersion", "HdSize", "IpAddress", "IsAvailable", "IsFirewallActive", "MacAddress", "Name", "SpaceHdUsed", "WindowsVersion" },
                values: new object[] { new Guid("356b872e-37fd-49fb-a1bf-9dc1353d869f"), "Norton", "net461", 2000000.0, "10.0.0.1", true, true, "8A-71-9B-CA-BB-D7", "Waldir 01", 100000.0, null });

            migrationBuilder.InsertData(
                table: "Machines",
                columns: new[] { "Id", "Antivirus", "DotNetFrameworkVersion", "HdSize", "IpAddress", "IsAvailable", "IsFirewallActive", "MacAddress", "Name", "SpaceHdUsed", "WindowsVersion" },
                values: new object[] { new Guid("4210d3ba-f838-442e-a71b-e6349a9c480e"), "Avast", "net461", 2000000.0, "10.0.0.2", true, true, "8A-71-9B-CA-BB-D4", "Waldir 02", 100000.0, null });

            migrationBuilder.InsertData(
                table: "Machines",
                columns: new[] { "Id", "Antivirus", "DotNetFrameworkVersion", "HdSize", "IpAddress", "IsAvailable", "IsFirewallActive", "MacAddress", "Name", "SpaceHdUsed", "WindowsVersion" },
                values: new object[] { new Guid("e5295786-b721-49c8-9197-6f0871a9ceaf"), "Avg", "net461", 2000000.0, "10.0.0.3", false, true, "8A-71-9B-CA-BB-D5", "Waldir 03", 100000.0, null });

            migrationBuilder.CreateIndex(
                name: "IX_Logs_MachineId",
                table: "Logs",
                column: "MachineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Machines");
        }
    }
}
