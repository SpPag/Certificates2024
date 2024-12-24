using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Certificates2024.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhotoIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CertificateTopics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificateTopics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CandidateCertificates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    CertificateTopicId = table.Column<int>(type: "int", nullable: false),
                    ExaminationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CandidateScore = table.Column<int>(type: "int", nullable: true),
                    MaximumScore = table.Column<int>(type: "int", nullable: true),
                    ResultLabel = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateCertificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateCertificates_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateCertificates_CertificateTopics_CertificateTopicId",
                        column: x => x.CertificateTopicId,
                        principalTable: "CertificateTopics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertificateTopicId = table.Column<int>(type: "int", nullable: false),
                    ImageSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BooleanA = table.Column<bool>(type: "bit", nullable: false),
                    AnswerA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BooleanB = table.Column<bool>(type: "bit", nullable: false),
                    AnswerB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BooleanC = table.Column<bool>(type: "bit", nullable: false),
                    AnswerC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BooleanD = table.Column<bool>(type: "bit", nullable: false),
                    AnswerD = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_CertificateTopics_CertificateTopicId",
                        column: x => x.CertificateTopicId,
                        principalTable: "CertificateTopics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateCertificates_CandidateId",
                table: "CandidateCertificates",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateCertificates_CertificateTopicId",
                table: "CandidateCertificates",
                column: "CertificateTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CertificateTopicId",
                table: "Questions",
                column: "CertificateTopicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateCertificates");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "CertificateTopics");
        }
    }
}
