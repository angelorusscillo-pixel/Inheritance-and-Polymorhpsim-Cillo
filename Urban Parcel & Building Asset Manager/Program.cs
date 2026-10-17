using System;
using System.Collections.Generic;
using static Urban_Parcel___Building_Asset_Manager.Residential;
using static Urban_Parcel___Building_Asset_Manager.TriangulaPark;

namespace Urban_Parcel___Building_Asset_Manager
{
    class Program
    {
        static List<PropertyAsset> assets = new List<PropertyAsset>();

        static void Main()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("╔══════════════════════════════════════════════════╗");
                Console.WriteLine("║     Urban Parcel & Building Asset Manager        ║");
                Console.WriteLine("╠══════════════════════════════════════════════════╣");
                Console.WriteLine("║  1. Add Residential Lot                          ║");
                Console.WriteLine("║  2. Add Circular Storage Depot                   ║");
                Console.WriteLine("║  3. Add Triangular Park                          ║");
                Console.WriteLine("║  4. View All Assets                              ║");
                Console.WriteLine("║  5. Show Total Combined Tax                      ║");
                Console.WriteLine("║  6. Exit                                         ║");
                Console.WriteLine("╚══════════════════════════════════════════════════╝");
                Console.Write("\nEnter your choice (1-6): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddResidentialLot();
                        break;
                    case "2":
                        AddCircularStorageDepot();
                        break;
                    case "3":
                        AddTriangularPark();
                        break;
                    case "4":
                        ViewAllAssets();
                        break;
                    case "5":
                        ShowTotalTax();
                        break;
                    case "6":
                        running = false;
                        Console.WriteLine("\nThank you for using the Asset Manager. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice. Press any key to try again...");
                        Console.ReadKey();
                        break;
                }
            }
        }


        static void AddResidentialLot()
        {
            Console.Clear();
            Console.WriteLine("=== Add Residential Lot ===\n");

            Console.Write("Property Code: ");
            string code = Console.ReadLine();

            Console.Write("Tax Rate per Unit Area: ");
            double taxRate = ReadDouble();

            Console.Write("Frontage (m): ");
            double frontage = ReadDouble();

            Console.Write("Depth (m): ");
            double depth = ReadDouble();

            assets.Add(new ResidentialLot(code, taxRate, frontage, depth));
            Console.WriteLine("\nResidential Lot added successfully!");
            Pause();
        }

        static void AddCircularStorageDepot()
        {
            Console.Clear();
            Console.WriteLine("=== Add Circular Storage Depot ===\n");

            Console.Write("Property Code: ");
            string code = Console.ReadLine();

            Console.Write("Tax Rate per Unit Area: ");
            double taxRate = ReadDouble();

            Console.Write("Radius (m): ");
            double radius = ReadDouble();

            assets.Add(new CircularStorageDepot(code, taxRate, radius));
            Console.WriteLine("\nCircular Storage Depot added successfully!");
            Pause();
        }

        static void AddTriangularPark()
        {
            Console.Clear();
            Console.WriteLine("=== Add Triangular Park ===\n");

            Console.Write("Property Code: ");
            string code = Console.ReadLine();

            Console.Write("Tax Rate per Unit Area: ");
            double taxRate = ReadDouble();

            Console.Write("Base Span (m): ");
            double baseSpan = ReadDouble();

            Console.Write("Height (m): ");
            double height = ReadDouble();

            Console.Write("Side 1 (m): ");
            double side1 = ReadDouble();

            Console.Write("Side 2 (m): ");
            double side2 = ReadDouble();

            Console.Write("Side 3 (m): ");
            double side3 = ReadDouble();

            assets.Add(new TriangularPark(code, taxRate, baseSpan, height, side1, side2, side3));
            Console.WriteLine("\nTriangular Park added successfully!");
            Pause();
        }

       

        static void ViewAllAssets()
        {
            Console.Clear();
            Console.WriteLine("=== All Stored Assets ===\n");

            if (assets.Count == 0)
            {
                Console.WriteLine("No assets have been added yet.");
            }
            else
            {
                int i = 1;
                foreach (PropertyAsset asset in assets)
                {
                    double area = asset.ComputeFootprintArea();
                    double perimeter = asset.ComputeEnclosurePerimeter();
                    double tax = asset.ComputeEstimatedTax();

                    Console.WriteLine($"[{i}] Property Code : {asset.PropertyCode}");
                    Console.WriteLine($"    Type          : {asset.GetType().Name}");
                    Console.WriteLine($"    Area          : {area:F2}");
                    Console.WriteLine($"    Perimeter     : {perimeter:F2}");
                    Console.WriteLine($"    Estimated Tax : {tax:F2}");
                    Console.WriteLine(new string('-', 45));
                    i++;
                }
            }

            Pause();
        }

        static void ShowTotalTax()
        {
            Console.Clear();
            Console.WriteLine("=== Total Combined Tax ===\n");

            if (assets.Count == 0)
            {
                Console.WriteLine("No assets have been added yet.");
            }
            else
            {
                double totalTax = 0;
                foreach (PropertyAsset asset in assets)
                {
                    totalTax += asset.ComputeEstimatedTax();
                }

                Console.WriteLine($"Number of assets : {assets.Count}");
                Console.WriteLine($"Total Combined Tax: {totalTax:F2}");
            }

            Pause();
        }


        static double ReadDouble()
        {
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double value) && value >= 0)
                    return value;

                Console.Write("Invalid input. Please enter a non-negative number: ");
            }
        }

        static void Pause()
        {
            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
        }
    }
}