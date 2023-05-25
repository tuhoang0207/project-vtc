using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Version_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountAdmin",
                columns: table => new
                {
                    Admin_no = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    PassWord = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountAdmin", x => x.Admin_no);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AccountEmployee",
                columns: table => new
                {
                    Emp_no = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    PassWord = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Emp_st = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountEmployee", x => x.Emp_no);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Cate_no = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Cate_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Cate_Description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Cate_no);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Cus_no = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Last_name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    First_name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    Cus_st = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Cus_no);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Order_no = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CheckIn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Emp_no = table.Column<int>(type: "int", nullable: false),
                    Table_no = table.Column<int>(type: "int", nullable: false),
                    Cus_no = table.Column<int>(type: "int", nullable: true),
                    Payment = table.Column<int>(type: "int", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Discount = table.Column<int>(type: "int", nullable: true),
                    Order_st = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Order_no);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TableSeat",
                columns: table => new
                {
                    Table_no = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Table_name = table.Column<string>(type: "longtext", nullable: false),
                    Table_st = table.Column<int>(type: "int", nullable: false),
                    Table_Description = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableSeat", x => x.Table_no);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Emp_no = table.Column<int>(type: "int", nullable: false),
                    Last_name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    First_name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Emp_no);
                    table.ForeignKey(
                        name: "FK_Employee_AccountEmployee_Emp_no",
                        column: x => x.Emp_no,
                        principalTable: "AccountEmployee",
                        principalColumn: "Emp_no",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Prod_no = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Prod_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Prod_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Prod_st = table.Column<int>(type: "int", nullable: false),
                    Cate_no = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Prod_no);
                    table.ForeignKey(
                        name: "FK_Product_Category_Cate_no",
                        column: x => x.Cate_no,
                        principalTable: "Category",
                        principalColumn: "Cate_no",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Salary",
                columns: table => new
                {
                    Emp_no = table.Column<int>(type: "int", nullable: false),
                    Coefficients_salary = table.Column<float>(type: "float", nullable: false),
                    WorkDay = table.Column<float>(type: "float", nullable: false),
                    TotalSalary = table.Column<float>(type: "float", nullable: false),
                    EmployeeEmp_no = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salary", x => x.Emp_no);
                    table.ForeignKey(
                        name: "FK_Salary_AccountEmployee_Emp_no",
                        column: x => x.Emp_no,
                        principalTable: "AccountEmployee",
                        principalColumn: "Emp_no",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Salary_Employee_EmployeeEmp_no",
                        column: x => x.EmployeeEmp_no,
                        principalTable: "Employee",
                        principalColumn: "Emp_no");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Prod_no = table.Column<int>(type: "int", nullable: false),
                    Order_no = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => new { x.Order_no, x.Prod_no });
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_Order_no",
                        column: x => x.Order_no,
                        principalTable: "Order",
                        principalColumn: "Order_no",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Product_Prod_no",
                        column: x => x.Prod_no,
                        principalTable: "Product",
                        principalColumn: "Prod_no",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_Prod_no",
                table: "OrderDetail",
                column: "Prod_no");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Cate_no",
                table: "Product",
                column: "Cate_no");

            migrationBuilder.CreateIndex(
                name: "IX_Salary_EmployeeEmp_no",
                table: "Salary",
                column: "EmployeeEmp_no");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountAdmin");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Salary");

            migrationBuilder.DropTable(
                name: "TableSeat");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "AccountEmployee");
        }
    }
}
