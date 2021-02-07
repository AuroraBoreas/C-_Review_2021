using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExportDataToOfficeApp;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExportDataToOfficeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>
            {
                new Car {Color="Green", Make="VW", PetName="XY"},
                new Car {Color="Red", Make="ZL", PetName="DD"},
                new Car {Color="Black", Make="Ford", PetName="Hank"},
                new Car {Color="Yellow", Make="BMW", PetName="Davie" }
            };

            ExportToExcel(cars);
        }


        private static void ExportToExcel(List<Car> carsInstock)
        {
            Excel.Application excelApp = new Excel.Application();
            excelApp.Workbooks.Add();

            Excel._Worksheet ws = excelApp.ActiveSheet;

            ws.Cells[1, "A"] = "Make";
            ws.Cells[1, "B"] = "Color";
            ws.Cells[1, "C"] = "Pet Name";


            int i = 1;
            foreach(Car c in carsInstock)
            {
                ++i;
                ws.Cells[i, "A"] = c.Make;
                ws.Cells[i, "B"] = c.Color;
                ws.Cells[i, "C"] = c.PetName;

            }

            // format table
            // nope

            ws.SaveAs($@"{Environment.CurrentDirectory}\Inventory.xlsx");
            excelApp.Quit();
            Console.WriteLine("The Inventory.xlsx file has been saved to your app foldr");

        }


    }
}
