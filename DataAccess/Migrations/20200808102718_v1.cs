using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IhbarDurumu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<string>(nullable: true),
                    Adi = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IhbarDurumu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IslemDurumu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<string>(nullable: true),
                    Adi = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IslemDurumu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Olay",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<string>(nullable: true),
                    IlkNeden = table.Column<string>(nullable: true),
                    OlusSekli = table.Column<string>(nullable: false),
                    Yer = table.Column<string>(nullable: false),
                    Tarih = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Olay", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<string>(nullable: true),
                    Isim = table.Column<string>(maxLength: 50, nullable: false),
                    Soyisim = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<string>(nullable: true),
                    Adi = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ihbar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<string>(nullable: true),
                    IhbarDurumuId = table.Column<int>(nullable: false),
                    Ozet = table.Column<string>(nullable: false),
                    Yer = table.Column<string>(nullable: false),
                    Tarih = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ihbar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ihbar_IhbarDurumu_IhbarDurumuId",
                        column: x => x.IhbarDurumuId,
                        principalTable: "IhbarDurumu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Kullanici",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<string>(nullable: true),
                    KullaniciAdi = table.Column<string>(maxLength: 50, nullable: false),
                    Sifre = table.Column<string>(maxLength: 50, nullable: false),
                    Aktif = table.Column<bool>(nullable: false),
                    PersonelId = table.Column<int>(nullable: true),
                    RolId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kullanici_Personel_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kullanici_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Faaliyet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<string>(nullable: true),
                    IhbarId = table.Column<int>(nullable: false),
                    IslemDurumuId = table.Column<int>(nullable: false),
                    PersonelId = table.Column<int>(nullable: false),
                    Aciklama = table.Column<string>(nullable: false),
                    Tarih = table.Column<DateTime>(nullable: false),
                    Yer = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faaliyet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faaliyet_Ihbar_IhbarId",
                        column: x => x.IhbarId,
                        principalTable: "Ihbar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Faaliyet_IslemDurumu_IslemDurumuId",
                        column: x => x.IslemDurumuId,
                        principalTable: "IslemDurumu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Faaliyet_Personel_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OlayIhbar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<string>(nullable: true),
                    OlayId = table.Column<int>(nullable: false),
                    IhbarId = table.Column<int>(nullable: false),
                    OlaySira = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OlayIhbar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OlayIhbar_Ihbar_IhbarId",
                        column: x => x.IhbarId,
                        principalTable: "Ihbar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OlayIhbar_Olay_OlayId",
                        column: x => x.OlayId,
                        principalTable: "Olay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PersonelIhbar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<string>(nullable: true),
                    PersonelId = table.Column<int>(nullable: false),
                    IhbarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelIhbar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonelIhbar_Ihbar_IhbarId",
                        column: x => x.IhbarId,
                        principalTable: "Ihbar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PersonelIhbar_Personel_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Faaliyet_IhbarId",
                table: "Faaliyet",
                column: "IhbarId");

            migrationBuilder.CreateIndex(
                name: "IX_Faaliyet_IslemDurumuId",
                table: "Faaliyet",
                column: "IslemDurumuId");

            migrationBuilder.CreateIndex(
                name: "IX_Faaliyet_PersonelId",
                table: "Faaliyet",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_Ihbar_IhbarDurumuId",
                table: "Ihbar",
                column: "IhbarDurumuId");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanici_PersonelId",
                table: "Kullanici",
                column: "PersonelId",
                unique: true,
                filter: "[PersonelId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanici_RolId",
                table: "Kullanici",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_OlayIhbar_IhbarId",
                table: "OlayIhbar",
                column: "IhbarId");

            migrationBuilder.CreateIndex(
                name: "IX_OlayIhbar_OlayId",
                table: "OlayIhbar",
                column: "OlayId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelIhbar_IhbarId",
                table: "PersonelIhbar",
                column: "IhbarId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelIhbar_PersonelId",
                table: "PersonelIhbar",
                column: "PersonelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faaliyet");

            migrationBuilder.DropTable(
                name: "Kullanici");

            migrationBuilder.DropTable(
                name: "OlayIhbar");

            migrationBuilder.DropTable(
                name: "PersonelIhbar");

            migrationBuilder.DropTable(
                name: "IslemDurumu");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Olay");

            migrationBuilder.DropTable(
                name: "Ihbar");

            migrationBuilder.DropTable(
                name: "Personel");

            migrationBuilder.DropTable(
                name: "IhbarDurumu");
        }
    }
}
