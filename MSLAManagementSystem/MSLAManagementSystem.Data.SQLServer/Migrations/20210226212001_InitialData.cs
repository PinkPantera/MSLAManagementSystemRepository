using Microsoft.EntityFrameworkCore.Migrations;

namespace MSLAManagementSystem.Data.SQLServer.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Adresses (Street, HouseNumber, ApartmentNumber, Town, Region, Country, СityСode) VALUES ('Boulevard de la Madeleine', '23', '3', 'Paris', NULL, 'France', '75001')");
            migrationBuilder.Sql("INSERT INTO Adresses (Street, HouseNumber, ApartmentNumber, Town, Region, Country, СityСode) VALUES ('Rue Cambon', '2', NULL, 'Paris', NULL, 'France', '75001')");
            migrationBuilder.Sql("INSERT INTO Adresses (Street, HouseNumber, ApartmentNumber, Town, Region, Country, СityСode) VALUES ('Rue Cambon', '2', '14', 'Paris', NULL, 'France', '75001')");
            migrationBuilder.Sql("INSERT INTO Adresses (Street, HouseNumber, ApartmentNumber, Town, Region, Country, СityСode) VALUES ('Boulevard de la Madeleine', '22', '1', 'Paris', NULL, 'France', '75001')");
            
            
            migrationBuilder
                .Sql("INSERT INTO Persons (FirstName, SecondName, Age, IdentityCard, AdressId, Phone, Email) VALUES ('Michèle', 'Grandmangin', 45, 'HJGD45DSQ12', (SELECT id FROM Adresses WHERE Street='Boulevard de la Madeleine' AND HouseNumber=23 AND ApartmentNumber=3 ), '+33668783383', 'michel.grand@gmail.com')");
            migrationBuilder
                .Sql("INSERT INTO Persons (FirstName, SecondName, Age, IdentityCard, AdressId, Phone, Email) VALUES ('Dominique', 'Colombani', 56, 'LKHJ78FS4DF5', (SELECT id FROM Adresses WHERE Street='Boulevard de la Madeleine' AND HouseNumber=22 AND ApartmentNumber=1 ), '+33608783542', 'dominique.colombani@gmail.com')");

            migrationBuilder.Sql("INSERT INTO ControlPosts (AdressId, Phone) VALUES ((SELECT id FROM Adresses WHERE Street='Rue Cambon' AND HouseNumber=2 AND ApartmentNumber=14 ), '+33998783786')");


            migrationBuilder.Sql("INSERT INTO Buildings (Name, AdressId, ControlPostId) VALUES ('Cicina', (SELECT id FROM Adresses WHERE Street='Rue Cambon' AND HouseNumber=2 AND ApartmentNumber is NULL ),  (SELECT id FROM ControlPosts WHERE Phone='+33998783786') )");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM AttendanceLogs");
            migrationBuilder.Sql("DELETE FROM ControlPosts");
            migrationBuilder.Sql("DELETE FROM Buildings");
            migrationBuilder.Sql("DELETE FROM Persons");
            migrationBuilder.Sql("DELETE FROM Adresses");
        }
    }
}
