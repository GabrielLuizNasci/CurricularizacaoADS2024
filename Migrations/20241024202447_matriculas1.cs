using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurricularizacaoADS2024.Migrations
{
    /// <inheritdoc />
    public partial class matriculas1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matriculas_Alunos_AlunoId",
                table: "Matriculas");

            migrationBuilder.DropIndex(
                name: "IX_Matriculas_AlunoId",
                table: "Matriculas");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "Matriculas");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_alunoID",
                table: "Matriculas",
                column: "alunoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Matriculas_Alunos_alunoID",
                table: "Matriculas",
                column: "alunoID",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matriculas_Alunos_alunoID",
                table: "Matriculas");

            migrationBuilder.DropIndex(
                name: "IX_Matriculas_alunoID",
                table: "Matriculas");

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "Matriculas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_AlunoId",
                table: "Matriculas",
                column: "AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matriculas_Alunos_AlunoId",
                table: "Matriculas",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
