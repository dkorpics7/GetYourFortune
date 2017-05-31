using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetYourFortune
{
    class Program
    {
        static void Main(string[] args)
        {

            // This is the Fortune Teller Project

            // It tells a person's fortune based on their age, birthmonth, 
            // favorite color and number of siblings

            // declare and initialize variables
            string input = "";        //string input by user in response to a question
            string fName = "";        // first name as entered by user
            string tempName = "";     // temporary variable for storing name
            string lName = "";        // last name as entered by user
            int age = -3;             // age
            int month = -3;           // birth month
            string color = "";        // color 
            int numSiblings = -3;     // number of siblings

            int retireYears;          // number of years until retirement
            string vacHome;           // location of vacation home
            string transport;         // method of transportation
            int dollars;              // amount of money in the bank

            string goodbye = "have a nice day!";        //personalized goodbye message

            bool isContinue = true;   //initialize isContinue to "true" -- change to "false" if user wants to quit program
            int icount = 0;           //set counter to 0  (so that I know if the user quits the program before completing their fortune)
            bool answer = true;       //assumes user wants another fortune unless this is changed to false

            String[] transportation = new string[2];
            Dictionary<int, string> months = new Dictionary<int, string>() { { 1, "January" }, { 2, "February" }, { 3, "March" }, { 4, "April" }, { 5, "May" }, { 6, "June" }, { 7, "July" }, { 8, "August" }, { 9, "September" }, { 10, "October" }, { 11, "November" }, { 12, "December" } };

            // Introduce the user to the program
            Introduction();

            // Run program again and again until user enters "quit"
            while (isContinue)
            {
                //If user asks for another fortune, remind them how to quit program.
                icount = RepeatFortune(icount);

                // Collect information from the user
                tempName = GetName("\r\n\r\nEnter your first name:                       ");
                if (tempName == "quit")
                {
                    isContinue = false;
                }
                else
                {
                    fName = tempName;
                }

                if (isContinue) lName = GetName("\r\nEnter your last name:                        ");
                if (lName == "quit") isContinue = false;

                if (isContinue) age = GetInteger("\r\nEnter your age(in years):                    ", 1, 120);
                if (age == -3) isContinue = false;

                //I wanted to challenge myself by letting the user enter the birthmonth as an integer or a string
                if (isContinue) month = GetBirthMonth("\r\nIn what month were you born?                 ", months);
                if (month == -3) isContinue = false;

                if (isContinue) color = GetColor("\r\n\r\nEnter your favorite ROYGBIV color \r\n(or type \"Help\" to see your color choices):  ");
                if (color == "quit") isContinue = false;

                if (isContinue) numSiblings = GetInteger("\r\nHow many siblings do you have?:              ", 0, 10000);
                if (numSiblings == -3) isContinue = false;
                if (isContinue && numSiblings >= 20) Console.WriteLine("\r\n\r\n                      WOW!  Your mom was a busy bee!!!\r\n\r\n");

                // assign fortune based on the user input entered above
                if (isContinue)
                {
                    // display user entries
                    DisplayInput(fName, lName, age, month, color, numSiblings, months);

                    retireYears = SetRetirement(age);            //set retirement
                    vacHome = SetHome(numSiblings);              //set vacation home
                    transportation = SetTransport(color);
                    transport = transportation[0];               //set transportation
                    goodbye = transportation[1];                 //set goodbye message
                    dollars = SetMoney(month);                   //set money

                    // Write the fortune to the screen
                    DisplayFortune(fName, lName, retireYears, dollars, vacHome, transport);

                    // See if the user wants to get another fortune
                    answer = WantNewFortune();
                    if (!answer)
                    {
                        icount++;
                        isContinue = false;
                        Console.WriteLine("\r\n\r\nPress any key to continue ...");
                        Console.ReadKey();
                        Console.Clear();
                    }

                }
            }

            //print goodbye screen
            Goodbye(icount, fName, goodbye);
        }

        //This method introduces the user to the program
        static void Introduction()
        {
            Console.WriteLine("\r\n\r\n  *************************************************************");
            Console.WriteLine("  *                                                           *");
            Console.WriteLine("  *        Hi!  I'm Diane, your friendly fortune teller!      *");
            Console.WriteLine("  *                                                           *");
            Console.WriteLine("  *        If you will answer a few simple questions,         *");
            Console.WriteLine("  *              I will tell you your fortune!                *");
            Console.WriteLine("  *                                                           *");
            Console.WriteLine("  * if you want to quit the program, type \"Quit\" at any time  *");
            Console.WriteLine("  *                                                           *");
            Console.WriteLine("  *************************************************************");
        }

        //This method reminds the user how to quit the program if they ask for repeat fortunes
        static int RepeatFortune(int counter)
        {
            counter++;                                                         // increase counter every time the user asks for a new fortune
            if (counter > 1)                                                   // if it is not the first fortune, remind user to enter "quit" to exit
            {
                Console.WriteLine("\r\nPress any key to continue ...");
                Console.ReadKey();
                Console.Clear();                                              // clear screen if user is getting a new fortune
                Console.WriteLine("\r\n*****  Remember to type \"Quit\" if you want to leave the program!");
            }
            return counter;
        }

        //This method parses input and gets first or last name
        static string GetName(string message)
        {
            bool isValid = false;                          // assume input is invalid until checked for validity
            string input;
            string Name = "";
            string tempname;

            while (!isValid)                               //keep prompting for name as long as input is invalid
            {
                Console.Write(message);
                input = Console.ReadLine();
                tempname = input.Trim().ToLower();
                if (tempname.Length == 0)
                {
                    Console.Write("\r\n***** Invalid Entry:   You must enter a name.\r\n");
                }
                else
                {
                    if (tempname == "quit" || tempname == "exit" || tempname == "q" || tempname == "e")
                    {
                        return "quit";
                    }
                    else
                    {
                        Name = input.Trim();
                    }
                    isValid = true;
                }
            }

            return Name;
        }

        static int GetInteger(string message, int min, int max) // parses input string to return an integer
        {
            int integerNumber;
            double decimalNumber;
            string input;
            bool isValid = false;
            bool isValidInt = false;
            bool isValidDouble = false;


            while (!isValid)
            {
                Console.Write(message);
                input = Console.ReadLine().Trim().ToLower();

                isValidInt = int.TryParse(input, out integerNumber);
                isValidDouble = double.TryParse(input, out decimalNumber);

                if (isValidInt && integerNumber >= min && integerNumber <= max)
                {
                    return integerNumber;                         // a valid integer was entered
                }
                else if (isValidDouble && decimalNumber >= min && decimalNumber <= max)                           // a decimal number was entered
                {
                    return integerNumber = Convert.ToInt32(decimalNumber); // convert decimal to an integer
                }
                else if (input == "exit" || input == "quit" || input == "e" || input == "q")
                {
                    return -3;                                   // -3 signals user wants to quit
                }
                else                                             // invalid entry
                {
                    Console.WriteLine("\r\n *****Invalid Entry: Please enter a number between {0} and {1}.\r\n", min, max); // invalid entry
                }
            }
            return -3;
        }

        //This method parses user input to return an integer representing their birth month
        static int GetBirthMonth(string message, Dictionary<int, string> months)
        {
            string input = "";
            int month = -3;
            bool isValid = false;

            while (!isValid)
            {
                Console.Write(message);
                input = Console.ReadLine().Trim().ToLower();
                if (input == "quit" || input == "q" || input == "exit" || input == "e")
                {
                    return -3;                                     //user wants to quit
                }

                isValid = int.TryParse(input, out month);
                if (isValid && month > 0 && month < 13)
                {
                    return month;                                 //User entered month as an integer
                }

                if (!isValid && input.Length>=3)
                {
                    foreach (var pair in months)
                    {
                        if (input.Substring(0, 3) == pair.Value.Substring(0, 3).ToLower())
                        {
                            month = pair.Key;                    //User entered month as a string
                            return month;
                        }
                    }
                }
                isValid = false;
                Console.Write("\r\n\r\n***** Invalid Entry:  Enter month as a digit or text (e.g., \"7\" or \"July\"\r\n");
            }
            return -3;
        }

        //This method parses user input to return their favorite color
        static string GetColor(string message)
        {
            bool isValid = false;
            string input;

            while (!isValid)
            {
                Console.Write(message);
                input = Console.ReadLine().Trim().ToLower();

                if (input == "quit" || input == "q" || input == "exit" || input == "e")
                {
                    return "quit";
                }
                else if (input == "help")
                {
                    Console.WriteLine("\r\n\r\nROYGBIV stands for:\r\n\r\n\tR = red\r\n\tO = orange\r\n\tY = yellow\r\n\tG = green\r\n\tB = blue\r\n\tI = indigo\r\n\tV = violet");
                }
                else if (input.Length == 0)
                {
                    Console.Write("\r\n***** Invalid Entry:  You must enter a color.\r\n");
                }
                else
                {
                    // I decided to allow the user to enter an invalid color
                    return input;
                }
            }
            return "quit";
        }

        //This method displays the user input
        static void DisplayInput(string fName, string lName, int age, int month, string color, int numSiblings, Dictionary<int, string> months)
        {
            Console.WriteLine("\r\nPress any key to continue ...");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\r\n\r\n*****   Thank you for your input!   *****\r\n\r\nHere is what you entered:\r\n");
            Console.WriteLine("\r\n\tName:          {0} {1} \r\n\tAge:           {2}\r\n\tBirth Month:   {3}\r\n\tColor:         {4}\r\n\tSiblings:      {5}\r\n\r\n", fName, lName, age, months[month], color, numSiblings);
        }

        //This method sets the retirement years based on age
        static int SetRetirement(int age)
        {
            if (age % 2 == 0)
            {
                return 5;                             // if age is even, retirement is in 5 years
            }
            else
            {
                return 99;                            // if age is odd, retirement is in 99 years
            }
        }

        //This method sets the vacation home based on number of siblings
        static string SetHome(int numSiblings)
        {
            switch (numSiblings)
            {
                case 0:
                    return "The Virgin Islands";
                case 1:
                    return "Cleveland, Ohio";
                case 2:
                    return "a lovely trailer park";
                case 3:
                    return "the nearest homeless shelter";
                default:
                    return " a cardboard box under a bridge";
            }
        }

        //This method sets transportation based on color (and also prepares a goodbye message for when the user exits the program)
        static string[] SetTransport(string color)
        {
            string[] Strings = new string[2];

            switch (color)
            {
                case "red":
                    Strings[0] = "red, convertible ferrari";
                    Strings[1] = "don't forget to wear your seatbelt!";
                    break;
                case "orange":
                    Strings[0] = "orange Yamaha motorcyle";
                    Strings[1] = "don't forget to wear your helmet!";
                    break;
                case "yellow":
                    Strings[0] = "yellow submarine";
                    Strings[1] = "did you know that we both live in a yellow submarine, \r\n\t a yellow submarine, a yellow submarine?";
                    break;
                case "green":
                    Strings[0] = "private leer jet";
                    Strings[1] = "if you have any extra room in that jet of yours, \r\n\t remember ... I love Paris!";
                    break;
                case "blue":
                    Strings[0] = "1941 orange and yellow bi-plane";
                    Strings[1] = "you may want to invest in a parachute!  Just Saying ...";
                    break;


                case "indigo":
                    Strings[0] = "pair of indigo speed skates";
                    Strings[1] = "don't forget your knee and elbow pads.  Safety First!";
                    break;
                case "violet":
                    Strings[0] = "purple mountain bike";
                    Strings[1] = "have fun on that bike of yours. Don't forget to hydrate!";
                    break;
                default:
                    Console.WriteLine("\r\n***** Warning:  You entered an invalid color.\r\n***** Don't worry! I can still work with it!");
                    Strings[0] = "pair of perfectly good feet for exploring new places";
                    Strings[1] = "you may want to invest in a good pair of hiking boots.";
                    break;
            }
            return Strings;
        }


        //This method sets the amount of money based on birth month
        static int SetMoney(int month)
        {
            if (month >= 1 && month <= 4)
            {
                return 39752;
            }
            else if (month >= 5 && month <= 8)
            {
                return 12874512;
            }
            else if (month >= 9 && month <= 12)
            {
                return 111;
            }
            else
            {
                Console.WriteLine("\r\n***** Warning:  You entered an invalid birth month.\r\n***** Fortunately, I am also telepathic so I already know when you were born!");
                return 1;
            }
        }

        //This method sets the amount of money based on birth month
        static void DisplayFortune(string fName, string lName, int retireYears, int dollars, string vacHome, string transport)
        {
            Console.WriteLine("\r\nPress any key to get your fortune!!!");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\r\n\r\n\a\a\a          !!!!!!!!!! Here is your fortune !!!!!!!!!!\r\n\r\n\r\n\a\a\a");
            Console.WriteLine("\r\n  ******************************************************************\r\n");

            Console.WriteLine("\t{0} {1} will retire in {2} years \r\n\twith {3:C} in the bank, \r\n\ta vacation home in {4}\r\n\tand a {5}.", fName, lName, retireYears, dollars, vacHome, transport);
            Console.WriteLine("\r\n  ******************************************************************\r\n\r\n");
        }

        //This method displays the "goodbye" message
        static void Goodbye(int icount, string fName, string goodbye)
        {
            if (icount == 1)
            {
                //prints only if they quit before getting their fortune
                Console.WriteLine("\r\n\r\n\t\tNobody likes a quitter ...\r\n\a\a\a");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\r\n\r\n                             --");
                Console.WriteLine("                          --    --");
                Console.WriteLine("      Thanks           --          --");
                Console.WriteLine("        for          --              --");
                Console.WriteLine("     visiting       --                --         Come");
                Console.WriteLine("                    --                --         again");
                Console.WriteLine("      Diane's        --              --          soon!");
                Console.WriteLine("      Crystal          --          --");
                Console.WriteLine("       Ball.              --    --");
                Console.WriteLine("                             --\r\n\r\n\r\n\r\n\t {0}, {1}\r\n", fName, goodbye);
            }
            Console.WriteLine("\r\nPress any key to exit...");
            Console.ReadKey();  // keeps screen from disappearing
        }

        static bool WantNewFortune()
        {
            string input;

            Console.Write("\r\n\r\n\r\nIf you are unhappy with your fortune, would you like to try again?  ");
            input = Console.ReadLine().Trim().ToLower();
            if (input == "y" || input == "yes")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }  //end of class
}  //end of namespace
