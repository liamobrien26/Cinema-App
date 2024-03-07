using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using CinemaBookingApp;
using System.Collections;
using System.Xml.Linq;
using System;

internal class Program
{
    
    static string StartLoginUsername()
    {
        Console.WriteLine("Please enter your username: ");
        string StartUsername = Console.ReadLine();
        return StartUsername;
    }
    //Checks username to ensure the user meets the following criteria when creating a new username
    static bool checkUsername(string StartUsername)
    {
       
        if (StartUsername.Any(char.IsWhiteSpace))
        {
            Console.WriteLine("MUST NOT contain any spaces!");
            return false;
        }
        if (!(StartUsername.Length >= 5))
        {
            Console.WriteLine("MUST contain at least 5 letters!");
            return false;
        }
        if (((StartUsername.Any(char.IsPunctuation) || StartUsername.Any(char.IsSymbol))))
        {
            Console.WriteLine("MUST NOT include special characters!");
            return false;
        }
        return true;
    }
    static string StartLoginPassword()
    {
        Console.WriteLine("Please enter your password:");
        string StartPassword = Console.ReadLine();
        return StartPassword;
    }

    //Checks password to ensure the user meets the following criteria when creating a new password
    static bool checkPassword(string StartPassword)
    {
        if (!(StartPassword.Length >= 6))
        {
            Console.WriteLine("MUST contain at least 6 letters!");
            return false;
        }
        if (!StartPassword.Any(char.IsUpper))
        {
            Console.WriteLine("MUST contain at least one capital letter!");
            return false;
        }
        if (!StartPassword.Any(char.IsLower))
        {
            Console.WriteLine("MUST contain at least one lowercase letter!");
            return false;
        }
        if (!StartPassword.Any(char.IsDigit))
        {
            Console.WriteLine("MUST contain a number!");
            return false;
        }
        if (!(StartPassword.Any(char.IsPunctuation) || StartPassword.Any(char.IsSymbol)))
        {
            Console.WriteLine("MUST contain at least one special character");
            return false;
        }
        return true;
    }

    static int Menu()
    {
        Console.WriteLine("----- WESTON SUPER MARE CINEMA BOOKING SYSTEM -----\n");
        Console.WriteLine("Input 1 to view customer details. "); 
        Console.WriteLine("Input 2 to view all films and times for the week");
        Console.WriteLine("Input 3 to view ticket prices");
        Console.WriteLine("Input 4 to view seating plan");
        Console.WriteLine("Input 5 to buy tickets");
        Console.WriteLine("Input 6 to Exit");
        int ReadingInputFromMenu = Convert.ToInt32(Console.ReadLine());
        return ReadingInputFromMenu;
    }

    //User Input1
    //-------------------------------------------------------------------------------------------------------------------------------------------------
    static string CheckingIfUsernameIsCorrect1()
    {
        Console.WriteLine("Please input your username in order to view customer details: ");
        string checkUser = Console.ReadLine();
        return checkUser;
    }
    static string CheckingIfPasswordIsCorrect1()
    {
        Console.WriteLine("Please input your password in order to view customer details: ");
        string checkPass = Console.ReadLine();
        return checkPass;
    }
    //-------------------------------------------------------------------------------------------------------------------------------------------------
    //BUYING TICKETS

    static int ChoiceOfMovieByCustomer()
    {
        Console.WriteLine("\n\nPlease select a movie the customer wishes to watch:");
        Console.WriteLine("\n\nInput 1 for 'Avatar'\nInput 2 for 'The Matrix'\nInput 3 for 'Home Alone'\nInput 4 for 'The Godfather'\n");
        int ChoiceOfMovie = Convert.ToInt32(Console.ReadLine());
        return ChoiceOfMovie;
    }

    //Asks customer to choose ticket category
    static int TicketChoice()
    {
        Console.WriteLine("----- TICKET CATEGORY -----\n");
        Console.WriteLine("Which ticket category does the customer wishes to purchase? ");
        Console.WriteLine("\n-Input 1 for 'Standard'\n-Input 2 for 'Premium'");
        int InputTicketChoice = Convert.ToInt32(Console.ReadLine());
        return InputTicketChoice;
    }
    static int StandardAdultTicket()
    {
        Console.WriteLine("Please input the number of 'Adult' tickets the customer wishes to purchase: ");

        int NumberOfAdults = Convert.ToInt32(Console.ReadLine());
        return NumberOfAdults;
    }
    static int StandardChildTicket()
    {
        Console.WriteLine("\nPlease input the number of 'Child' tickets the customer wishes to purchase:");
        int NumberOfChild = Convert.ToInt32(Console.ReadLine());
        return NumberOfChild;
    }
    static int StandardSeniorTicket()
    {
        Console.WriteLine("\nPlease input the number of 'Senior' tickets the customer wishes to purchase");
        int NumberOfSenior = Convert.ToInt32(Console.ReadLine());
        return NumberOfSenior;
    }
    static int NumberOfCustomers(int NumberOfAdults, int NumberOfChild, int NumberOfSenior)
    {
        int TotalCustomers = (NumberOfAdults + NumberOfChild + NumberOfSenior);
        return TotalCustomers;
    }

    //Total price for tickets
    static void Maths1(int NumberOfAdults, int NumberOfChild,int NumberOfSenior,int InputTicketChoice)
    {
        TicketPricesNew Rates = new TicketPricesNew();
        int TotalPriceForSA = (NumberOfAdults * Rates.PriceNew[0]);
        int TotalPriceForSC = (NumberOfChild  * Rates.PriceNew[1]);
        int TotalPriceForSS = (NumberOfSenior * Rates.PriceNew[2]);

        int TotalPriceForPA = (NumberOfAdults * Rates.PriceNew[3]);
        int TotalPriceForPC = (NumberOfChild * Rates.PriceNew[4]);
        int TotalPriceForPS = (NumberOfSenior * Rates.PriceNew[5]);

        switch (InputTicketChoice)
        {
            case 1:
                Console.WriteLine("-----BASKET-----");
                Console.Write("Number of Standard Adult tickets = " + NumberOfAdults + "\nTotal price: £" + TotalPriceForSA+ "\n");
                Console.Write("\nNumber of Standard Child tickets = " + NumberOfChild + "\nTotal price: £" + TotalPriceForSC + "\n");
                Console.Write("\nNumber of Standard Senior tickets = " + NumberOfSenior + "\nTotal price: £" + TotalPriceForSS + "\n");
                Console.Write("\n\nBASKET TOTAL = £" + (TotalPriceForSA+ TotalPriceForSC + TotalPriceForSS));
                break;

            case 2:
                Console.WriteLine("-----BASKET-----");
                Console.Write("Number of Premium Adult tickets = " + NumberOfAdults + "\nTotal price: £" + TotalPriceForPA + "\n");
                Console.Write("\nNumber of Premium Child tickets = " + NumberOfChild + "\nTotal price: £" + TotalPriceForPC + "\n");
                Console.Write("\nNumber of Premium Senior tickets = " + NumberOfSenior + "\nTotal price: £" + TotalPriceForPS + "\n");
                Console.Write("\n\nBASKET TOTAL = £" + (TotalPriceForPA + TotalPriceForPC + TotalPriceForPS));
                break;
        }
    }

    //Member------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    static string AskCustomerIfMember()
    {
        Console.WriteLine("Is the customer currently a member of Weston-Super-Mare cinmea?");
        Console.WriteLine("\nEnter 'YES' if customer is a member -");
        Console.WriteLine("Enter 'NO' if customer is not a member -");
        string CustomerMembership = Console.ReadLine().ToUpper();
        return CustomerMembership;
    }

    static int Number()//Sets int NumberOfBookings to 0 to allow to add number of bookings to Dictonary 
    {
        int NumberOfBookings = 0;
        return NumberOfBookings;
    }

    static string AskForCustomerFullName()
    {
        Console.WriteLine("Please enter customer's full name");
        string CustomerName = Console.ReadLine().ToUpper();
        return CustomerName;
    }

    //Member------------------------------------------------------------------------------------------------------------------------------------------------------------------------



    //Seating plan

    static void PrintOutSeatsPlan() //NEW SEATING PLAN VIA MATRIX
    {
        NewSeating DisplaySeats = new NewSeating();
        //Prints all seats
        Console.WriteLine("-------------------------------");
        Console.WriteLine("           SCREEN\n");
        for (int i = 0; i < DisplaySeats.DisplaySeatingPlan.GetLength(0); i++)
        {
            Console.WriteLine();

            for (int j = 0; j < DisplaySeats.DisplaySeatingPlan.GetLength(1); j++)
            {
                Console.Write(DisplaySeats.DisplaySeatingPlan[i, j]);
                Console.Write(" ");
            }
        }
    }

    static string CustomerChooseSeats(int TotalCustomers)
    {
        Console.WriteLine("Number of seats to book: " + TotalCustomers+"\n\n");
        Console.WriteLine("\n\nWhich seats would the customer like to seat?: ");
        string SeatsInput = Console.ReadLine();
        ListTest.Record(SeatsInput);
        return SeatsInput;
    }

    //old method
    static void SeatsTaken(NewSeating checkseat,string SeatsInput)
    {
        //NewSeating checkseat = new NewSeating();
        int Row1 = checkseat.SeatsNewRow1.IndexOf(SeatsInput);
        int idx2 = checkseat.SeatsNewRow2.IndexOf(SeatsInput);
        int idx3 = checkseat.SeatsNewRow3.IndexOf(SeatsInput);
        int idx4 = checkseat.SeatsNewRow4.IndexOf(SeatsInput);
        int idx5 = checkseat.SeatsNewRow5.IndexOf(SeatsInput);

            if (Row1 >= 0)
            { checkseat.SeatsNewRow1[Row1] = "X "; }
            else if (idx2 >= 0)
            { checkseat.SeatsNewRow2[idx2] = "X "; }
            else if (idx3 >= 0)
            { checkseat.SeatsNewRow3[idx3] = "X "; }
            else if (idx4 >= 0)
            { checkseat.SeatsNewRow4[idx4] = "X "; }
            else if (idx5 >= 0)
            { checkseat.SeatsNewRow5[idx5] = "X"; }
            else { Console.WriteLine("Error! Seat not found"); }


            Console.WriteLine("-------------------------------");
            Console.WriteLine("           SCREEN\n");
            foreach (var i in checkseat.SeatsNewRow1)
            { Console.Write(i); }
            Console.WriteLine();
            foreach (var i in checkseat.SeatsNewRow2)
            { Console.Write(i); }
            Console.WriteLine();
            foreach (var i in checkseat.SeatsNewRow3)
            { Console.Write(i); }
            Console.WriteLine();
            foreach (var i in checkseat.SeatsNewRow4)
            { Console.Write(i); }
            Console.WriteLine();
            foreach (var i in checkseat.SeatsNewRow5)
            { Console.Write(i); }
            Console.WriteLine();
    }

        //-------------------------------------------------------------------------------------
        //OOP

        //Film listing
        static void Films()
    {
        //Print Film listing
        Console.WriteLine("----- SHOWTIMES AT WESTON CINEMA -----\n");

        Film_Information films = new Film_Information();
        for (int i = 0; i < films.FilmDate.Count(); i++)
        {
            Console.WriteLine("Date: {0}\nFilm: {1}\nTime: {2}\n\n", films.FilmDate[i], films.FilmName[i], films.FilmTime[i]);
        }
    }

    //TicketRates
    static void PrintOutTicketRates()
    {
        TicketPricesNew Rates = new TicketPricesNew();

        for (int i = 0; i < Rates.TicketNew.Count(); i++)
        {
            Console.WriteLine("Ticket Type: " + Rates.TicketNew[i] + "\nTicket Price: £" + Rates.PriceNew[i] + "\n\n");
        }
    }

   

    //Invoice
    static void Invoice(User edit ,TicketPricesNew Rates, Film_Information films, int NumberOfAdults, int NumberOfChild, int NumberOfSenior, int InputTicketChoice, int ChoiceOfMovie,string CustomerName, int valuefornumberofbookings)
    {
        int TotalPriceForSA = (NumberOfAdults * Rates.PriceNew[0]);
        int TotalPriceForSC = (NumberOfChild * Rates.PriceNew[1]);
        int TotalPriceForSS = (NumberOfSenior * Rates.PriceNew[2]);

        int TotalPriceForPA = (NumberOfAdults * Rates.PriceNew[3]);
        int TotalPriceForPC = (NumberOfAdults * Rates.PriceNew[4]);
        int TotalPriceForPS = (NumberOfAdults * Rates.PriceNew[5]);

    

        Console.Clear();
        //PRINTS TICKETS
        if (InputTicketChoice == 1)
        {
            Console.WriteLine("----- INVOICE -----\n\n");
            if (TotalPriceForSA > 0)
            { Console.WriteLine(NumberOfAdults + "x Standard Adult ticket = £" + TotalPriceForSA); }
            if (TotalPriceForSC > 0)
            { Console.WriteLine(NumberOfChild + "x Standard Child ticket = £" + TotalPriceForSC); }
            if (TotalPriceForSS > 0)
            { Console.WriteLine(NumberOfSenior + "x Standard Senior ticket = £" + TotalPriceForSS); }
        }
        else if (InputTicketChoice == 2)
        {
            if (TotalPriceForPA > 0)
            { Console.WriteLine(NumberOfAdults + "x Premium Adult ticket = £" + TotalPriceForPA); }
            if (TotalPriceForPC > 0)
            { Console.WriteLine(NumberOfSenior + "x Premium Child ticket = £" + TotalPriceForPC); }
            if (TotalPriceForPS > 0)
            { Console.WriteLine(NumberOfSenior + "x Premium Senior ticket = £" + TotalPriceForPS); }
        }

        int TS = (TotalPriceForSA + TotalPriceForSC + TotalPriceForSS);//Adds up total cost for Standard tickets
        int TP = (TotalPriceForPA + TotalPriceForPC + TotalPriceForPS);//Adds up total cost for Premium

        //Prints Film/Date/Time
        if (ChoiceOfMovie == 1)
        { 
           Console.WriteLine("\n\nDate: {0}\nFilm: {1}\nTime: {2}\n\n", films.FilmDate[0], films.FilmName[0], films.FilmTime[0]);
        }
        if (ChoiceOfMovie == 2)
        {
            Console.WriteLine("\n\nDate: {0}\nFilm: {1}\nTime: {2}\n\n", films.FilmDate[1], films.FilmName[1], films.FilmTime[1]);
        }
        if (ChoiceOfMovie == 3)
        {
            Console.WriteLine("\n\nDate: {0}\nFilm: {1}\nTime: {2}\n\n", films.FilmDate[2], films.FilmName[2], films.FilmTime[2]);
        }
        if (ChoiceOfMovie == 4)
        {
            Console.WriteLine("\n\nDate: {0}\nFilm: {1}\nTime: {2}\n\n", films.FilmDate[3], films.FilmName[3], films.FilmTime[3]);
        }
        //Displays Seat numbers
        ListTest.DisplayTest();

        //Displays Customer name:
        Console.WriteLine("\n\nCUSTOMER NAME: " + CustomerName);

        double VATforS = TS - (TS * 0.2); //Works out the Subtotal for Standard tickets
        double VATforP = TP - (TP * 0.2); //Works out the Subtotal for Premium tickets
        double VATofS = TS * 0.2; //Works out the VAT of Standard tickets
        double VATofP = TP * 0.2; //Works out the VAT of Premium tickets

        if (InputTicketChoice == 1) //Displays total ticket price
        {
            Console.WriteLine("\n\nSubtotal: £" + VATforS); //Displays subtotal
            Console.WriteLine("VAT 20% : £"+VATofS); //Displays the VAT
            Console.Write("\n\nTOTAL: £" + (TS));

            //Check if discount applies through loyaltly program
            if (valuefornumberofbookings > 10)
            {
                double DiscountTS = TS * 0.85;//applies discount to total 
                Console.WriteLine("\n\nTOTAL after 15% discount applied: £" + (DiscountTS));
                User.UpdateBooking(CustomerName); // Increase number of bookings
            }
            

        }
        else if (InputTicketChoice == 2) //Displays total tickt price
        {
            Console.WriteLine("\n\nSubtotal: £" + VATforP); //Displays subtotal
            Console.WriteLine("VAT 20% : £"+VATofP); //Displays the VAT
            Console.Write("\n\nTOTAL: £" + (TP));

            // Check if discount applies through loyaltly program
            if (valuefornumberofbookings > 10)
            {
                double DiscountTS = TP * 0.85;//applies discount to total 
                Console.WriteLine("\n\nTOTAL after 15% discount applied: £" + (DiscountTS));
                User.UpdateBooking(CustomerName); // Increase number of bookings
            }

        }

       
        

        Console.WriteLine("\n\n\nPress enter to proceed....");
        Console.ReadKey();
        Console.Clear();
    }

    //METHOD for Buying Tickets
    static void BuyTicket()
    {
        int ChoiceOfMovie = ChoiceOfMovieByCustomer();//Asks Customer to display movie choice 
        Console.Clear();
        int InputTicketChoice = TicketChoice();//Asks Customer which ticket category would they like
        Console.Clear();
        int NumberOfAdults = StandardAdultTicket(); //Asks customer number of Adults 
        int NumberOfChild = StandardChildTicket(); //Asks customer number of Children
        int NumberOfSenior = StandardSeniorTicket(); //Asks customer number of Senior 
        Console.Clear();
        Maths1(NumberOfAdults, NumberOfChild, NumberOfSenior, InputTicketChoice); //Basket
        Console.WriteLine("\n\n\nPress enter to proceed....");
        Console.ReadKey();
        Console.Clear();
        int count = 1;
        int TotalCustomers = NumberOfCustomers(NumberOfAdults, NumberOfChild, NumberOfSenior); //Adds up total number of customers
        PrintOutSeatsPlan();
        NewSeating seating = new NewSeating();
        
        do //Set loop
        {
            string SeatsInput = CustomerChooseSeats(TotalCustomers); //Asks customer to choose seat
            Console.Clear();
            seating.ReplaceValue(ChoiceOfMovie, SeatsInput);//Finds out if seat is taken
            Console.WriteLine("\n\nNumber of seats booked: " + count);
            count++;
        } while (count <= TotalCustomers);
        Console.Clear();
        string CustomerMembership = AskCustomerIfMember(); //Displays asking if customer is a member
        Console.Clear();
        int NumberOfBookings = Number();//Auto sets the number of bookings for customers
        string customerName = AskForCustomerFullName();
        Console.Clear();
        List<string> find = new List<string>();
        TicketPricesNew Rates = new TicketPricesNew();
        Film_Information films = new Film_Information();
        User edit = new User();
        int valuefornumberofbookings = User.RecordData(customerName, NumberOfBookings, CustomerMembership); // Call RecordData to get valuefornumberofbookings
        Invoice(edit, Rates, films, NumberOfAdults, NumberOfChild, NumberOfSenior, InputTicketChoice, ChoiceOfMovie, customerName, valuefornumberofbookings); //Prints invoice
    }

    //Create new method
//UpdateSeatingPlan(SeatingPlan, seating)

    //-------------------------------------------------------------------------------------

    private static void Main(string[] args)
    {
        //Vailiding input
        User user = new User();

        //set up list
        //SeatingPlans List = [seatingplan1, seatinplan2, NewSeatingPlan()]

        //outputs entering new username while loops username checker
        while (true)
        {
         string StartUsername = StartLoginUsername();
         Console.Clear();
         user.User1U = StartUsername;
           if (checkUsername(StartUsername))
           {
            Console.Clear();
            break;
           }
        }

                //outputs entering new password while loops password checker
                while (true)
                {
                    string StartPassword = StartLoginPassword();
                    Console.Clear();
                    user.User1P = StartPassword;
                    Console.Clear();
                    if (checkPassword(StartPassword))
                    {
                        Console.Clear();
                        Console.WriteLine("LOGIN GRANTED!");
                        Console.WriteLine("\n");
                        Console.WriteLine("Press enter to acknowledge....");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                }
        //Checks if input is correct!
        /*Console.WriteLine("Your username is: " + user.user1U + "\nYour password is: " + user.user1P);
        Console.ReadKey();*/

        //list for adding new users 
        List<User> Customers = new List<User>();

        //Setting loop for the Switch case for menu
        while (true)
        {
            //Outputs Menu
            int ReadingInputFromMenu = Menu();
            Console.Clear();

            switch (ReadingInputFromMenu)
            {
                //ADD NEW CUSTOMER DETAILS
                case 1:
                    //Setting Max Password attempts and asking user to enter their details in order to add new logins
                    int tries = 4;
                    while (true)
                    {
                        string checkUser = CheckingIfUsernameIsCorrect1();
                        if (checkUser == user.User1U)
                        {
                            Console.Clear();
                            string checkPass = CheckingIfPasswordIsCorrect1();
                            if (checkPass == user.User1P)
                            {
                                Console.Clear();
                                Console.WriteLine("ACCESS GRANTED!\n");
                                Console.WriteLine("Press enter to begin....");
                                Console.ReadKey();
                                break;
                            }
                            else if (--tries > 0)
                            {
                                Console.Clear();
                                Console.WriteLine("ERROR! PASSWORD INCORRECT! PLEASE TRY AGAIN!");
                                Console.WriteLine("Remaining attempts: " + tries);
                            }
                            else                   // too many tries
                            {
                                Console.Clear();
                                Console.WriteLine("ACCESS DENIED!");
                                Console.WriteLine("You have used up all of your attempts!");
                                Environment.Exit(0);
                                break;             // end the loop
                            }
                        }
                        else if (--tries > 0)
                        {
                            Console.Clear();
                            Console.WriteLine("ERROR! YOUR USERNAME NOT FOUND! PLEASE TRY AGAIN!");
                            Console.WriteLine("Remaining attempts: " + tries);
                        }
                        else                   // too many tries
                        {
                            Console.Clear();
                            Console.WriteLine("ACCESS DENIED!");
                            Console.WriteLine("You have used up all of your attempts!");
                            Environment.Exit(0);
                            break;             // end the loop
                        }
                    }

                    Console.Clear();
                    User.DisplayAllFullNames(); //Displays all users
                    Console.WriteLine("\nPress enter to acknowledge....");
                    Console.ReadKey();
                    Console.Clear();


                    //Break for case 1
                    break;

                //VIEW ALL FILMS AND TIMES FOR THE WEEK
                case 2:
                    Films();
                    Console.WriteLine("Press enter to acknowledge....");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                //VIEW TICKET PRICES
                case 3:
                    PrintOutTicketRates();
                    Console.WriteLine("Press enter to acknowledge....");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                //VIEW SEATING PLAN
                case 4:
                    PrintOutSeatsPlan();
                    Console.WriteLine("\n\n\nPress enter to acknowledge....");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                //BUY TICKETS
                case 5:
                    Console.Clear();
                    Films();//Displays listing
                    BuyTicket();
                    

                    // EXAMPLE BuyTicket(ChoiceOfMovie, SeatingPlans[ChoiceOfMovie-1]); BY ANDREA
                    break;
                    
                // EXIT       
                case 6:
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
