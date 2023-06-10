using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

public class Seller
{
    public decimal Price { get; set; }
    public string Location { get; set; }
    public decimal SquareMeters { get; set; }
    public int NumberOfRooms { get; set; }
    public bool Furnished { get; set; }
    public string PropertyType { get; set; }
    public string PaymentType { get; set; }
    public string SellerName { get; set; }
    public int PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Description { get; set; }
    public string Photo { get; set; }
    public bool FreeOfLiens { get; set; }

    public void PublishHouseForSale()
    {
        Console.WriteLine("\nPublish a House for Sale!");

        string filePath = @"C:\Users\aleja\houserentalv.0.1\HouseForSale.json";

        try
        {
            List<Seller> houseForSaleList;

            // Read the JSON file if it exists
            if (File.Exists(filePath))
            {
                // Read the file content
                string jsonData = File.ReadAllText(filePath);

                // Deserialize the JSON into a list of Seller objects
                houseForSaleList = JsonConvert.DeserializeObject<List<Seller>>(jsonData);
            }
            else
            {
                // If the file doesn't exist, create a new empty list
                houseForSaleList = new List<Seller>();
            }

            // Create a new Seller object with user-provided data
            Seller newHouseForSale = new Seller();

            Console.Write("Price: ");
            decimal Price = Convert.ToDecimal(Console.ReadLine());
            if (Price < 0)
            {
                Console.WriteLine("El precio ingresado no es válido. Debe ser un valor positivo.");
            }


            Console.Write("Location: ");
            string Location = string.Empty;
            while (string.IsNullOrEmpty(Location))
            {
                Console.Write("Ubicacion: ");
                Location = Console.ReadLine();
            }

            
            Console.Write("Square Meters: ");
            decimal squareMeters;

            while (!decimal.TryParse(Console.ReadLine(), out squareMeters) || squareMeters <= 0)
            {
                Console.WriteLine("Cantidad inválida de metros cuadrados. Por favor, ingrese un valor numérico válido y mayor que cero.");
                Console.Write("Square Meters: ");
            }
            newHouseForSale.SquareMeters = squareMeters;


            Console.Write("Number of Rooms: ");
            int numberOfRooms;

            while (!int.TryParse(Console.ReadLine(), out numberOfRooms) || numberOfRooms <= 0)
            {
                Console.WriteLine("Cantidad inválida de habitaciones. Por favor, ingrese un valor numérico válido y mayor que cero.");
                Console.Write("Number of Rooms: ");
            }

            newHouseForSale.NumberOfRooms = numberOfRooms;

  

            Console.Write("Furnished (true/false): ");
            bool furnished;

            while (!bool.TryParse(Console.ReadLine(), out furnished))
            {
                Console.WriteLine("Valor inválido. Por favor, ingrese 'true' para sí o 'false' para no.");
                Console.Write("Furnished (true/false): ");
            }

            newHouseForSale.Furnished = furnished;


            Console.Write("Free of Liens (true/false): ");
            bool freeOfLiens;

            while (!bool.TryParse(Console.ReadLine(), out freeOfLiens))
            {
                Console.WriteLine("Valor inválido. Por favor, ingrese 'true' para sí o 'false' para no.");
                Console.Write("Free of Liens (true/false): ");
            }

            newHouseForSale.FreeOfLiens = freeOfLiens;


            Console.Write("Property Type: ");
            string propertyType = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(propertyType))
            {
                Console.WriteLine("Tipo de propiedad inválido. Por favor, ingrese un tipo de propiedad válido.");
                Console.Write("Property Type: ");
                propertyType = Console.ReadLine();
            }

            newHouseForSale.PropertyType = propertyType;


            Console.Write("Payment Type: ");
            string paymentType = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(paymentType))
            {
                Console.WriteLine("Tipo de pago inválido. Por favor, ingrese un tipo de pago válido.");
                Console.Write("Payment Type: ");
                paymentType = Console.ReadLine();
            }

            newHouseForSale.PaymentType = paymentType;



            Console.Write("Seller Name: ");
            string sellerName = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(sellerName))
            {
                Console.WriteLine("Nombre de vendedor inválido. Por favor, ingrese un nombre de vendedor válido.");
                Console.Write("Seller Name: ");
            sellerName = Console.ReadLine();
            }

            newHouseForSale.SellerName = sellerName;
            
            
            Console.Write("Phone Number: ");
            int phoneNumber;

            while (!int.TryParse(Console.ReadLine(), out phoneNumber) || phoneNumber <= 0)
            {
                Console.WriteLine("Número de teléfono inválido. Por favor, ingrese un número de teléfono válido.");
                Console.Write("Phone Number: ");
            }

            newHouseForSale.PhoneNumber = phoneNumber;


            Console.Write("Email: ");
            string email = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
            {
                Console.WriteLine("Dirección de correo electrónico inválida. Por favor, ingrese una dirección de correo electrónico válida.");
                Console.Write("Email: ");
                email = Console.ReadLine();
            }

            
            static bool IsValidEmail(string email)
            {
            try
                {
                var address = new System.Net.Mail.MailAddress(email);
                return address.Address == email;
                }
                catch
                {
                return false;
                }
            }
            newHouseForSale.Email = email;



            Console.Write("Description: ");
            string description = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(description))
            {
                Console.WriteLine("Descripción inválida. Por favor, ingrese una descripción válida.");
                Console.Write("Description: ");
                description = Console.ReadLine();
            }

            newHouseForSale.Description = description;


            Console.Write("Photo: ");
            string photo = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(photo))
            {
                Console.WriteLine("Foto inválida. Por favor, ingrese una foto válida.");
                Console.Write("Photo: ");
                photo = Console.ReadLine();
            }

            newHouseForSale.Photo = photo;

            // Add the new object to the list
            houseForSaleList.Add(newHouseForSale);

            // Serialize the list of objects to JSON format
            string json = JsonConvert.SerializeObject(houseForSaleList, Formatting.Indented);

            // Save the JSON to the file
            File.WriteAllText(filePath, json);

            Console.WriteLine("The house for sale has been successfully published.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error publishing the house for sale: " + ex.Message);
        }
    }
}

