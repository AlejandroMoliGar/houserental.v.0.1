using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

public class Vendedor 
{
    public decimal Price { get; set; }
    public string Location { get; set; }
    public decimal SquareMeters { get; set; }
    public int NumberOfRooms { get; set; }
    public bool Furnished { get; set; }
    public string TypeProperty { get; set; }
    public string PaymentType { get; set; }
    public string VendorName { get; set; }
    public int PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Description { get; set; }
    public string Photo { get; set; }
    public bool FreeOfLien { get; set; } 
    // Nueva propiedad agregada
    // Resto del código de la clase
    // ...

    public void PublishHouseForVent()
    {
        Console.WriteLine("\nPublicar una Casa para Venta!");
        string filePath = @"C:\Users\aleja\houserentalv.0.1\HouseForSale.json";

        try
        {
            // Leer el archivo JSON
            string jsonData = File.ReadAllText(filePath);

            // Deserializar el JSON en una lista de objetos Vendedor
            var houseforsaleList = JsonConvert.DeserializeObject<List<Vendedor>>(jsonData);

            // Acceder a las propiedades de los objetos
            foreach (var property in houseforsaleList)
            {
                Console.WriteLine("Datos obtenidos del archivo:");
                Console.WriteLine($"Precio: {property.Price}");
                Console.WriteLine($"Ubicación: {property.Location}");
                Console.WriteLine($"Metros cuadrados: {property.SquareMeters}");
                Console.WriteLine($"Número de habitaciones: {property.NumberOfRooms}");
                Console.WriteLine($"Amueblado: {property.Furnished}");
                Console.WriteLine($"Libre de gravamen: {property.FreeOfLien}");
                Console.WriteLine($"Tipo de propiedad: {property.TypeProperty}");
                Console.WriteLine($"Tipo de pago: {property.PaymentType}");
                Console.WriteLine($"Nombre del vendedor: {property.VendorName}");
                Console.WriteLine($"Teléfono: {property.PhoneNumber}");
                Console.WriteLine($"Correo electrónico: {property.Email}");
                Console.WriteLine($"Descripción: {property.Description}");
                Console.WriteLine($"Foto: {property.Photo}");
                Console.WriteLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al leer el archivo JSON: " + ex.Message);
        }
    }
}
