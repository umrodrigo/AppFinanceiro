using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financ.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "category",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "origin",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_origin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "typePay",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "varchar(255)", nullable: false),
                    flag = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_typePay", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false),
                    Password = table.Column<string>(type: "varchar(255)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(25)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Region = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "income",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdOrigin = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cust = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Recurrent = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_income", x => x.Id);
                    table.ForeignKey(
                        name: "FK_income_origin_IdOrigin",
                        column: x => x.IdOrigin,
                        principalSchema: "dbo",
                        principalTable: "origin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "profilePay",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdExpanse = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTypePay = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Parcel = table.Column<int>(type: "int", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profilePay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_profilePay_typePay_IdTypePay",
                        column: x => x.IdTypePay,
                        principalSchema: "dbo",
                        principalTable: "typePay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "profileIncome",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdIncome = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profileIncome", x => x.Id);
                    table.ForeignKey(
                        name: "FK_profileIncome_income_IdIncome",
                        column: x => x.IdIncome,
                        principalSchema: "dbo",
                        principalTable: "income",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_profileIncome_user_IdUser",
                        column: x => x.IdUser,
                        principalSchema: "dbo",
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "expense",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCategory = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdOrigin = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProfilePay = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cust = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Recurrent = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_expense_category_IdCategory",
                        column: x => x.IdCategory,
                        principalSchema: "dbo",
                        principalTable: "category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_expense_origin_IdOrigin",
                        column: x => x.IdOrigin,
                        principalSchema: "dbo",
                        principalTable: "origin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_expense_profilePay_IdProfilePay",
                        column: x => x.IdProfilePay,
                        principalSchema: "dbo",
                        principalTable: "profilePay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "profileExpense",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdExpense = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profileExpense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_profileExpense_expense_IdExpense",
                        column: x => x.IdExpense,
                        principalSchema: "dbo",
                        principalTable: "expense",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_profileExpense_user_IdUser",
                        column: x => x.IdUser,
                        principalSchema: "dbo",
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_expense_IdCategory",
                schema: "dbo",
                table: "expense",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_expense_IdOrigin",
                schema: "dbo",
                table: "expense",
                column: "IdOrigin");

            migrationBuilder.CreateIndex(
                name: "IX_expense_IdProfilePay",
                schema: "dbo",
                table: "expense",
                column: "IdProfilePay");

            migrationBuilder.CreateIndex(
                name: "IX_income_IdOrigin",
                schema: "dbo",
                table: "income",
                column: "IdOrigin");

            migrationBuilder.CreateIndex(
                name: "IX_profileExpense_IdExpense",
                schema: "dbo",
                table: "profileExpense",
                column: "IdExpense",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_profileExpense_IdUser",
                schema: "dbo",
                table: "profileExpense",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_profileIncome_IdIncome",
                schema: "dbo",
                table: "profileIncome",
                column: "IdIncome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_profileIncome_IdUser",
                schema: "dbo",
                table: "profileIncome",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_profilePay_IdTypePay",
                schema: "dbo",
                table: "profilePay",
                column: "IdTypePay");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "profileExpense",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "profileIncome",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "expense",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "income",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "user",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "category",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "profilePay",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "origin",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "typePay",
                schema: "dbo");
        }
    }
}
