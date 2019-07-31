using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart_ConsoleApp
{
    public class ShoppingCart
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\t\t\t\t Welcome to Shopping Cart !!");
            Console.WriteLine("\t\t\t\t ****************************\n\n");

            /*This itemsList can be extended in future or 
           * we can get itemList from database.
           * As of now i am hard coding list.
           */
            var items = new List<Item>
            {
                new Item { Id =1,  Name = "Apple" , Price = 0.60M },
                new Item { Id = 2, Name = "Orange" , Price = 0.25M }
            };

            try
            {
                DisplayAvailableItemList(items);

            ContinueStepLoop: GetInputValuesFromUser(items);

                DisplayFinalItemsList(items,"Shopping Item List");

                Console.WriteLine("Press 1 for Continue Shopping (OR) \nPress 2 for CheckOut");
                var toProcess = Console.ReadLine();

                if (toProcess == "1")
                {
                    goto ContinueStepLoop;
                }
                else if (toProcess == "2")
                {
                    CheckOutProcessItems(items);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid Entry.");
            }

            Console.WriteLine("\n Thank you for shopping with us !!! ");

            Console.WriteLine("\n Press Enter button to exit.");

            Console.ReadLine();

            return;
        }

        private static void DisplayAvailableItemList(List<Item> items)
        {
            Console.WriteLine("\t Available Items");
            Console.WriteLine("\t-------------------------------------");

            var dataTable = new DataTable("Items");
            dataTable.Columns.Add("ItemNo", typeof(int));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Price", typeof(string));

            foreach (var item in items)
            {
                dataTable.Rows.Add(item.Id, item.Name, "£" + item.Price);
            }

            Console.WriteLine("\t {0}\t\t{1}\t\t{2}", dataTable.Columns[0], dataTable.Columns[1], dataTable.Columns[2]);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Console.WriteLine("\t {0}\t\t {1}\t\t {2}", dataRow[0], dataRow[1], dataRow[2]);
            }
            Console.WriteLine("\n");
        }

        /*
         * if the input value is not integer then raised an error 
         * and repeate continueStep.
         */
        private static void GetInputValuesFromUser(List<Item> items)
        {
            foreach (var item in items)
            {
            ContinueStep:
                Console.WriteLine("\nPlease enter number of " + item.Name + "s you want:");
                var inputValue = Console.ReadLine();
                var output = GetValues(inputValue);
                if (!Int32.TryParse(output, out int result))
                {
                    Console.WriteLine(output);
                    goto ContinueStep;
                }
                else
                {
                    item.Quantity = Convert.ToInt16(output);
                }
            }
        }

        /*
         * This method is used to display the list of checkout items.
         * Calculate the total bill amount.
         */

        private static void CheckOutProcessItems(List<Item> items)
        {
            DisplayFinalItemsList(items, "Checkout Items List");

            CalculateTotalAmount(items);
        }

        private static void CalculateTotalAmount(List<Item> items)
        {
            decimal totalAmount = 0;

            foreach (var item in items)
            {
                totalAmount += (item.Quantity * item.Price);
            }

            Console.WriteLine("\t\t TotalAmount: £" + totalAmount);

        }

        private static void DisplayFinalItemsList(List<Item> items, string titleList)
        {
            Console.WriteLine("\t"+ titleList);
            Console.WriteLine("\t--------------------------------------------------------");

            var dataTable = new DataTable("Items");
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("QTY", typeof(int));
            dataTable.Columns.Add("Price", typeof(string));
            dataTable.Columns.Add("Amount", typeof(string));

            foreach (var item in items)
            {
                dataTable.Rows.Add(item.Name, item.Quantity, "£" + item.Price, "£" + (item.Quantity * item.Price));
            }

            Console.WriteLine("\t {0}\t\t{1}\t\t{2}\t\t{3}", dataTable.Columns[0], dataTable.Columns[1], dataTable.Columns[2], dataTable.Columns[3]);

            foreach (DataRow dr in dataTable.Rows)
            {
                Console.WriteLine("\t {0}\t\t {1}\t\t {2}\t\t{3}", dr[0], dr[1], dr[2], dr[3]);
            }
            Console.WriteLine("\n");
        }

        public static string GetValues(string input)
        {
            try
            {
                string ouput = string.Empty;

                if (!Int32.TryParse(input, out int result))
                {
                    ouput = "Invalid input entry. Please enter only integers";//calls int overload
                }
                else
                {
                    ouput = input;
                }

                return ouput;
            }
            catch (Exception e)
            {
                Console.WriteLine("" + e.InnerException);
            }
            return "";
        }
    }
}
