using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hair.Migrations
{
    /// <inheritdoc />
    public partial class DENE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Geçici sütun ekle
            migrationBuilder.AddColumn<int>(
                name: "TempTime",
                table: "Islems",
                type: "int",
                nullable: true);

            // Mevcut datetime2 verilerini taşımak için SQL sorgusu
            migrationBuilder.Sql("UPDATE Islems SET TempTime = DATEDIFF(SECOND, '1970-01-01', Time)");

            // Eski Time sütununu kaldır
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Islems");

            // Yeni Time sütununu ekle
            migrationBuilder.AddColumn<int>(
                name: "Time",
                table: "Islems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            // Geçici sütundaki verileri yeni Time sütununa taşı
            migrationBuilder.Sql("UPDATE Islems SET Time = TempTime");

            // Geçici sütunu sil
            migrationBuilder.DropColumn(
                name: "TempTime",
                table: "Islems");
        }



        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Geçici sütun ekle
            migrationBuilder.AddColumn<DateTime>(
                name: "TempTime",
                table: "Islems",
                type: "datetime2",
                nullable: true);

            // Mevcut int verilerini datetime2 olarak taşımak için SQL sorgusu
            migrationBuilder.Sql("UPDATE Islems SET TempTime = DATEADD(SECOND, Time, '1970-01-01')");

            // Eski Time sütununu kaldır
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Islems");

            // Yeni Time sütununu ekle
            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "Islems",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            // Geçici sütundaki verileri yeni Time sütununa taşı
            migrationBuilder.Sql("UPDATE Islems SET Time = TempTime");

            // Geçici sütunu sil
            migrationBuilder.DropColumn(
                name: "TempTime",
                table: "Islems");
        }



    }
}

