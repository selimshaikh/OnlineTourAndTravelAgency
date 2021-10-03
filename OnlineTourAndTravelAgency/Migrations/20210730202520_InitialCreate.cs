using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineTourAndTravelAgency.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Complementaries",
                columns: table => new
                {
                    ComplementaryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocalTransportForsightseeing = table.Column<int>(nullable: false),
                    MealDetails = table.Column<string>(nullable: false),
                    OtherFacility = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complementaries", x => x.ComplementaryId);
                });

            migrationBuilder.CreateTable(
                name: "ContractUs",
                columns: table => new
                {
                    ContractId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractUs", x => x.ContractId);
                });

            migrationBuilder.CreateTable(
                name: "CorporateTourPackages",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmailAddress = table.Column<string>(nullable: false),
                    NameOfOrganization = table.Column<string>(nullable: false),
                    TypeOfBusiness = table.Column<string>(nullable: false),
                    DestinationName = table.Column<string>(nullable: false),
                    NumberOfGuests = table.Column<string>(nullable: false),
                    Durationoftrip = table.Column<string>(nullable: false),
                    DateOfYourJourney = table.Column<DateTime>(nullable: false),
                    EstimatedBudget = table.Column<decimal>(type: "money", nullable: false),
                    ContractPersonName = table.Column<string>(nullable: false),
                    ContactPersonMobile = table.Column<string>(nullable: false),
                    OfficeAddress = table.Column<string>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateTourPackages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 80, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Phone = table.Column<string>(maxLength: 20, nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: false),
                    NID = table.Column<string>(maxLength: 50, nullable: false),
                    Passport = table.Column<string>(maxLength: 50, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    PhotoPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Guides",
                columns: table => new
                {
                    GuideId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GuideName = table.Column<string>(nullable: false),
                    Skill = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guides", x => x.GuideId);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    HotelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    HotelDetails = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.HotelId);
                });

            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    TourId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TourTitle = table.Column<string>(maxLength: 50, nullable: false),
                    NumberOfPackage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.TourId);
                });

            migrationBuilder.CreateTable(
                name: "Transports",
                columns: table => new
                {
                    TransportId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TransportType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transports", x => x.TransportId);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    VenueId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    VenueDetails = table.Column<string>(nullable: true),
                    SpotImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.VenueId);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    PackageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PackageName = table.Column<string>(maxLength: 80, nullable: false),
                    TourId = table.Column<int>(nullable: false),
                    GuideId = table.Column<int>(nullable: false),
                    VenueId = table.Column<int>(nullable: false),
                    HotelId = table.Column<int>(nullable: false),
                    TransportId = table.Column<int>(nullable: false),
                    ComplementaryId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    PricePerAdult = table.Column<decimal>(nullable: false),
                    PricePerChild = table.Column<decimal>(nullable: false),
                    Capacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.PackageId);
                    table.ForeignKey(
                        name: "FK_Packages_Complementaries_ComplementaryId",
                        column: x => x.ComplementaryId,
                        principalTable: "Complementaries",
                        principalColumn: "ComplementaryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Packages_Guides_GuideId",
                        column: x => x.GuideId,
                        principalTable: "Guides",
                        principalColumn: "GuideId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Packages_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "HotelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Packages_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "TourId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Packages_Transports_TransportId",
                        column: x => x.TransportId,
                        principalTable: "Transports",
                        principalColumn: "TransportId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Packages_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "VenueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookingDate = table.Column<DateTime>(nullable: false),
                    PackageId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    NumberOfAdult = table.Column<int>(nullable: false),
                    NumberOfChild = table.Column<int>(nullable: false),
                    TotalPackagePrice = table.Column<decimal>(type: "money", nullable: false),
                    IsCancellation = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "PackageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notess",
                columns: table => new
                {
                    Noteid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PackagesId = table.Column<int>(nullable: false),
                    NoteDetails = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notess", x => x.Noteid);
                    table.ForeignKey(
                        name: "FK_Notess_Packages_PackagesId",
                        column: x => x.PackagesId,
                        principalTable: "Packages",
                        principalColumn: "PackageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentDetails",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookingId = table.Column<int>(nullable: false),
                    paymentSystem = table.Column<int>(nullable: false),
                    BKashNumber = table.Column<string>(maxLength: 11, nullable: false),
                    BankDetails = table.Column<string>(maxLength: 200, nullable: true),
                    OtherDetails = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PaymentDetails_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CustomerId",
                table: "Bookings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PackageId",
                table: "Bookings",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Notess_PackagesId",
                table: "Notess",
                column: "PackagesId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_ComplementaryId",
                table: "Packages",
                column: "ComplementaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_GuideId",
                table: "Packages",
                column: "GuideId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_HotelId",
                table: "Packages",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_TourId",
                table: "Packages",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_TransportId",
                table: "Packages",
                column: "TransportId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_VenueId",
                table: "Packages",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDetails_BookingId",
                table: "PaymentDetails",
                column: "BookingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractUs");

            migrationBuilder.DropTable(
                name: "CorporateTourPackages");

            migrationBuilder.DropTable(
                name: "Notess");

            migrationBuilder.DropTable(
                name: "PaymentDetails");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Complementaries");

            migrationBuilder.DropTable(
                name: "Guides");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Tours");

            migrationBuilder.DropTable(
                name: "Transports");

            migrationBuilder.DropTable(
                name: "Venues");
        }
    }
}
