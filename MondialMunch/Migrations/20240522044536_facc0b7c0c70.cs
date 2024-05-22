using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MondialMunch.Migrations
{
    /// <inheritdoc />
    public partial class facc0b7c0c70 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_MondialMunchEvents_EventId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_EventId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Countries");

            migrationBuilder.CreateTable(
                name: "CountryMondialMunchEvent",
                columns: table => new
                {
                    EventCountriesId = table.Column<int>(type: "INTEGER", nullable: false),
                    EventsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryMondialMunchEvent", x => new { x.EventCountriesId, x.EventsId });
                    table.ForeignKey(
                        name: "FK_CountryMondialMunchEvent_Countries_EventCountriesId",
                        column: x => x.EventCountriesId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryMondialMunchEvent_MondialMunchEvents_EventsId",
                        column: x => x.EventsId,
                        principalTable: "MondialMunchEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountryMondialMunchEvent_EventsId",
                table: "CountryMondialMunchEvent",
                column: "EventsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryMondialMunchEvent");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Countries",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_EventId",
                table: "Countries",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_MondialMunchEvents_EventId",
                table: "Countries",
                column: "EventId",
                principalTable: "MondialMunchEvents",
                principalColumn: "Id");
        }
    }
}
