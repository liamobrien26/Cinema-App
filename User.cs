using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

namespace CinemaBookingApp
{
    public class User
    {
        //SAVES USERNAME WHEN LOG INTO PROGRAM
        public string User1U;
        private string User1u  // property
        {
            get { return User1U; }   // get method
            set { User1U = value; }  // set method
        }

        //SAVES PASSWORD WHEN LOG INTO PROGRAM
        public string User1P;
        private string User1p  // property
        {
            get { return User1P; }   // get method
            set { User1P = value; }  // set method
        }


        //GETS CUSTOMERSNAME AND Number of bookings made
        static Dictionary<string, int> _Names = new Dictionary<string, int>
        {
             {"LIAM O'BRIEN", 25},
             {"ANDREA GRADECAK", 30},
             {"CIARAN O'BRIEN", 3},
        };

        // Method to get the dictionary of customer names and their bookings
        public static Dictionary<string, int> GetNames()
        {
            return _Names;
        }

        // Method to update the number of bookings for a customer
        public static void UpdateBooking(string customerName)
        {
            if (_Names.ContainsKey(customerName))
            {
                _Names[customerName] += 1;
            }
        }



        public static int RecordData(string CustomerName, int NumberOfBookings, string CustomerMembership)
        {
            int valuefornumberofbookings = 0;

            try
            {
                if (_Names.ContainsKey(CustomerName)) // finds if name is found in System
                {
                    valuefornumberofbookings = _Names[CustomerName]; // Saves value that was found in the system by returning it into 'valuefornumberofbookings'

                    if (CustomerMembership == "NO")
                    {
                        Console.WriteLine("ERROR! Customer is already a member!");
                        Console.WriteLine("\n\n\n-----[Press Enter]-----");
                        Console.ReadKey();
                    }
                    else //if (CustomerMembership == "YES")
                    {
                        Console.WriteLine("Member Found!");
                        Console.WriteLine("\nNumber of bookings made: " + valuefornumberofbookings);

                        if (valuefornumberofbookings > 10) // Checks if the customer is eligible for a discount
                        {
                            Console.WriteLine("\n(Customer is eligible for 15% discount through our loyalty program)");
                        }

                        Console.ReadKey();
                    }
                    
                }
                else // Name is not found in the system
                {
                    if (CustomerMembership == "NO")
                    {
                        Console.WriteLine("New Member has been added to the system");
                        Console.WriteLine("\n\n\n-----[Press Enter]-----");
                        Console.ReadKey();
                    }
                    else // if (CustomerMembership == "YES")
                    {
                        Console.WriteLine("ERROR!\n\nCustomer is not a member!!");
                        Console.WriteLine("\n\nCustomer details will be added to the system!");
                        Console.WriteLine("\n\n\n-----[Press Enter]-----");
                        Console.ReadKey();
                    }
                    _Names.Add(CustomerName, NumberOfBookings); // Adds name
                    _Names[CustomerName] += 1; // Adds 1 new booking for the customer
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("\n\n\n-----[Press Enter]-----");
                Console.ReadKey();
            }

            // Return the correct value at the end of the method
            return valuefornumberofbookings;
        }



        //Method to print Seats
        public static void DisplayAllFullNames()
        {
            Console.WriteLine("----- CUSTOMER DETAILS -----\n\n");
            foreach (KeyValuePair<string, Int32> value in _Names)
            {
                Console.WriteLine("Customer Full Name: {0}\nNumber of bookings: {1}\n\n", value.Key, value.Value);
            }
        }
    }

    //Film Information
    public class Film_Information
    {
        public List<string> FilmDate { get; set; }
        public List<string> FilmName { get; set; }
        public List<string> FilmTime { get; set; }

        public Film_Information()
        {
            FilmDate = new List<string>() { "01/01/2023", "03/01/2023", "05/01/2023", "07/01/2023" };
            FilmName = new List<string>() { "Avatar", "The Matrix", "Home Alone", "The Godfather" };
            FilmTime = new List<string>() { "20:00", "17:30", "10:00", "21:00" };
        }


    }
    //Tickets cataorgaory
    public class TicketPricesNew
    {
        public List<string> TicketNew { get; set; }
        public List<int> PriceNew { get; set; }

        public TicketPricesNew()
        {
            TicketNew = new List<string>() {"Standard Adult", "Standard Child", "Standard Senior",
                "Premium Adult", "Premium Child", "Premium Senior",
                "Loyalty Discount Adult", "Loyalty Discount Child"};
            PriceNew = new List<int>() { 12, 8, 10, 18, 12, 14, 8, 4 };

        }
    }
    //Seating plan
    public class NewSeating
    {
        //Old Example
        public List<string> SeatsNewRow1 { get; set; }
        public List<string> SeatsNewRow2 { get; set; }
        public List<string> SeatsNewRow3 { get; set; }
        public List<string> SeatsNewRow4 { get; set; }
        public List<string> SeatsNewRow5 { get; set; }

        //Trying out new matrix array
        public string[,] DisplaySeatingPlan { get; set; }
        public string[,] Avatar { get; set; }
        public string[,] The_Matrix { get; set; }
        public string[,] Home_Alone { get; set; }
        public string[,] The_Godfather { get; set; }

        public NewSeating()
         {
            //Old Example
             SeatsNewRow1 = new List<string>() { "A1", " ", "A2", " ", "A3", " ", "A4", " ", "A5", " ", "A6", " ", "A7", " ", "A8", " ", "A9", " ", "A10" };
             SeatsNewRow2 = new List<string>() { "B1", " ", "B2", " ", "B3", " ", "B4", " ", "B5", " ", "B6", " ", "B7", " ", "B8", " ", "B9", " ", "B10" };
             SeatsNewRow3 = new List<string>() { "C1", " ", "C2", " ", "C3", " ", "C4", " ", "C5", " ", "C6", " ", "C7", " ", "C8", " ", "C9", " ", "C10" };
             SeatsNewRow4 = new List<string>() { "D1", " ", "D2", " ", "D3", " ", "D4", " ", "D5", " ", "D6", " ", "D7", " ", "D8", " ", "D9", " ", "D10" };
             SeatsNewRow5 = new List<string>() { "E1", " ", "E2", " ", "E3", " ", "E4", " ", "E5", " ", "E6", " ", "E7", " ", "E8", " ", "E9", " ", "E10" };



            //MATXRIXS
            DisplaySeatingPlan = new string[5, 10] {
                { "A1","A2","A3","A4","A5","A6","A7","A8","A9","A10" },
                { "B1","B2","B3","B4","B5","B6","B7","B8","B9","B10"},
                { "C1","C2","C3","C4","C5","C6","C7","C8","C9","C10"},
                { "D1","D2","D3","D4","D5","D6","D7","D8","D9","D10"},
                { "E1","E2","E3","E4","E5","E6","E7","E8","E9","E10"}};

            Avatar = new string[5,10] {
                {"A1","A2","A3","A4","A5","A6","A7","A8","A9","A10" },
                {"B1","B2","B3","B4","B5","B6","B7","B8","B9","B10"},
                {"C1","C2","C3","C4","C5","C6","C7","C8","C9","C10"},
                {"D1","D2","D3","D4","D5","D6","D7","D8","D9","D10"},
                {"E1","E2","E3","E4","E5","E6","E7","E8","E9","E10"}};

            The_Matrix = new string[5, 10] {
                {"A1","A2","A3","A4","A5","A6","A7","A8","A9","A10" },
                {"B1","B2","B3","B4","B5","B6","B7","B8","B9","B10"},
                {"C1","C2","C3","C4","C5","C6","C7","C8","C9","C10"},
                {"D1","D2","D3","D4","D5","D6","D7","D8","D9","D10"},
                {"E1","E2","E3","E4","E5","E6","E7","E8","E9","E10"}};

            Home_Alone = new string[5, 10] {
                {"A1","A2","A3","A4","A5","A6","A7","A8","A9","A10" },
                {"B1","B2","B3","B4","B5","B6","B7","B8","B9","B10"},
                {"C1","C2","C3","C4","C5","C6","C7","C8","C9","C10"},
                {"D1","D2","D3","D4","D5","D6","D7","D8","D9","D10"},
                {"E1","E2","E3","E4","E5","E6","E7","E8","E9","E10"}};

            The_Godfather = new string[5, 10] {
                {"A1","A2","A3","A4","A5","A6","A7","A8","A9","A10" },
                {"B1","B2","B3","B4","B5","B6","B7","B8","B9","B10"},
                {"C1","C2","C3","C4","C5","C6","C7","C8","C9","C10"},
                {"D1","D2","D3","D4","D5","D6","D7","D8","D9","D10"},
                {"E1","E2","E3","E4","E5","E6","E7","E8","E9","E10"}};
        }

        public void ReplaceValue(int ChoiceOfMovie, string SeatsInput)
        {
            switch (ChoiceOfMovie)
            {
                case 1://Avatar
                    //Displays seats
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("           SCREEN\n");
                    for (int i = 0; i < Avatar.GetLength(0); i++)
                    {
                        Console.WriteLine();

                        for (int j = 0; j < Avatar.GetLength(1); j++)
                        {
                            Console.Write(Avatar[i, j]);
                            Console.Write(" ");
                        }
                    }

                    for (int i = 0; i < Avatar.GetLength(0); i++)
                    {
                        for (int j = 0; j < Avatar.GetLength(1); j++)
                        {
                            if (Avatar[i, j] == SeatsInput)
                            {
                                Avatar[i, j] = "X";
                                return;
                            }
                            else
                            {
                                Console.WriteLine("\n\nERROR! Seats not found! Please try again!");
                            }

                        }
                    }
                   
                    break;
                case 2: //The Matrix

                    //Displays seats
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("           SCREEN\n");
                    for (int i = 0; i < The_Matrix.GetLength(0); i++)
                    {
                        Console.WriteLine();

                        for (int j = 0; j < The_Matrix.GetLength(1); j++)
                        {
                            Console.Write(The_Matrix[i, j]);
                            Console.Write(" ");
                        }
                    }
                    for (int i = 0; i < The_Matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < The_Matrix.GetLength(1); j++)
                        {
                            if (The_Matrix[i, j] == SeatsInput)
                            {
                                The_Matrix[i, j] = "X";
                                return;
                            }
                            else
                            {
                                Console.WriteLine("\n\nERROR! Seats not found! Please try again!");
                            }
                        }
                    }
                    
                    break;
                case 3: //Home Alone

                    //Displays seats
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("           SCREEN\n");
                    for (int i = 0; i < Home_Alone.GetLength(0); i++)
                    {
                        Console.WriteLine();

                        for (int j = 0; j < Home_Alone.GetLength(1); j++)
                        {
                            Console.Write(Home_Alone[i, j]);
                            Console.Write(" ");
                        }
                    }

                    for (int i = 0; i < Home_Alone.GetLength(0); i++)
                    {
                        for (int j = 0; j < Home_Alone.GetLength(1); j++)
                        {
                            if (Home_Alone[i, j] == SeatsInput)
                            {
                                Home_Alone[i, j] = "X";
                                return;
                            }
                            else
                            {
                                Console.WriteLine("\n\nERROR! Seats not found! Please try again!");
                            }
                        }
                    }
                    
                    break;
                case 4: //The Godfather

                    //Displays seats
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("           SCREEN\n");
                    for (int i = 0; i < The_Godfather.GetLength(0); i++)
                    {
                        Console.WriteLine();

                        for (int j = 0; j < The_Godfather.GetLength(1); j++)
                        {
                            Console.Write(The_Godfather[i, j]);
                            Console.Write(" ");
                        }
                    }
                    for (int i = 0; i < The_Godfather.GetLength(0); i++)
                    {
                        for (int j = 0; j < The_Godfather.GetLength(1); j++)
                        {
                            if (The_Godfather[i, j] == SeatsInput)
                            {
                                The_Godfather[i, j] = "X";
                                return;
                            }
                            else
                            {
                                Console.WriteLine("\n\nERROR! Seats not found! Please try again!");
                            }
                        }
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid input");
            }
        }
    }

    //Gets data for Seat choice by Customer
    static class ListTest
    {
        static List<string> _list; // Static List instance

        static ListTest()
        {
            // Allocate the list.

            _list = new List<string>();
        }
        public static void Record(string SeatsInput)
        {
            _list.Add(SeatsInput);
        }
        //Method to print Seats
        public static void DisplayTest()
        {
            //
            // Write out the results.
            //
            foreach (var value in _list)
            {
                Console.WriteLine("Your seats are: " + value);
            }
        }

    }
}
