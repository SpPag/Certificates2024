using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Certificates2024.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    CandidateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhotoIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.CandidateId);
                });

            migrationBuilder.CreateTable(
                name: "CertificateTopics",
                columns: table => new
                {
                    CertificateTopicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificateTopics", x => x.CertificateTopicId);
                });

            migrationBuilder.CreateTable(
                name: "CandidateCertificates",
                columns: table => new
                {
                    CandidateCertificateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    CertificateTopicId = table.Column<int>(type: "int", nullable: false),
                    ExaminationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CandidateScore = table.Column<int>(type: "int", nullable: false),
                    MaximumScore = table.Column<int>(type: "int", nullable: false),
                    ResultLabel = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateCertificates", x => x.CandidateCertificateId);
                    table.ForeignKey(
                        name: "FK_CandidateCertificates_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "CandidateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateCertificates_CertificateTopics_CertificateTopicId",
                        column: x => x.CertificateTopicId,
                        principalTable: "CertificateTopics",
                        principalColumn: "CertificateTopicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_Questions_CertificateTopics_CertificateTopicId",
                        column: x => x.CertificateTopicId,
                        principalTable: "CertificateTopics",
                        principalColumn: "CertificateTopicId",
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
