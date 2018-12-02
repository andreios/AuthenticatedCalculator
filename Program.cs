using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AuthenticatedCalculator
{
    class Program
    {
        //Global variables for the main program
        public static double NumX { get; set; } = 0;
        public static bool XCheck { get; set; } = false;
        public static int MenuChoice { get; set; } = 0;
        public static string AuthLevel { get; set; }

        static void Main(string[] args)
        {
            try {
                //Create authorized user list.
                List<User> AuthUsers = new List<User>{
                    new User("brookhou", "password!%", "prof"),
                    new User("jkirk", "11A", "admiral"),
                    new User("mscott", "11A2B", "prof"),
                    new User("pchekhov", "1B2B3", "default"),
                };

                AuthenticateUser(AuthUsers);    //checks for user authentication before running menu

                bool loop = true;

                do
                {
                    if (MenuChoice == 0)
                    {
                        MenuChoice = MainMenu();
                    }
                    switch (MenuChoice)
                    {
                        case 1:
                            AddNumbers();
                            break;

                        case 2:
                            SubNumbers();
                            break;

                        case 3:
                            MultNumbers();
                            break;

                        case 4:
                            DivNumbers();
                            break;

                        case 5:             //option only available to "prof" access level
                            if (AuthLevel == "prof")
                            {
                                ExpNumbers();
                            }
                            else
                            {
                                Console.WriteLine("Invalid Entry.");
                                System.Threading.Thread.Sleep(1000);
                                MenuChoice = 0;
                            }
                            break;

                        case 9:
                            ClearResult();
                            break;

                        case 00:             //option only available to "admiral" access level
                            if (AuthLevel == "admiral")
                            {
                                SelfDestruct();
                            }
                            else
                            {
                                Console.WriteLine("Invalid Entry.");
                                System.Threading.Thread.Sleep(1000);
                                MenuChoice = 0;
                            }
                            break;
                            
                        case 99:
                            EndProgram();
                            break;

                        default:
                            Console.WriteLine("Invalid Entry.");
                            System.Threading.Thread.Sleep(1000);
                            MenuChoice = 0;
                            break;
                    }
                } while (loop == true);
            }
            catch (Exception ex)
            {
                ErrorTrap(ex);
            }

        }


        private static int MainMenu()
        {
            //Main Menu

            bool loop = true;
            int MenuChoice = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("Calculator Main Menu \n");
                if (XCheck == true)
                {
                    Console.WriteLine("Current result:  " + NumX.ToString("g4") + "\n");
                }
                Console.WriteLine("1.  Addition");
                Console.WriteLine("2.  Subtraction");
                Console.WriteLine("3.  Multiplication");
                Console.WriteLine("4.  Division");
                if (AuthLevel == "prof") { Console.WriteLine("5.  Exponents"); }
                Console.WriteLine("9.  Clear result");
                if (AuthLevel == "admiral") { Console.WriteLine("00. Console Self-destruct"); }
                Console.WriteLine("99. Exit \n");
                Console.WriteLine("Enter selection:  ");

                if (int.TryParse(Console.ReadLine(), out int selection))
                {
                    MenuChoice = selection;
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Invalid selection");
                    System.Threading.Thread.Sleep(1000);
                }
            } while (loop == true);

            return MenuChoice;
        }

        private static void AddNumbers()        //Addition subroutine.
        {
            double numY = 0;            //second value
            double result = 0;          //stores result

            Console.Clear();
            Console.WriteLine("Addition");
            if (XCheck == true)      //check for saved previous result
            {
                Console.WriteLine("\nCurrent result:  " + NumX.ToString("g4") + "\n");
            }
            else                    //get first number if no saved result
            {
                bool isXValid = false;
                do
                {
                    Console.WriteLine("\nEnter first number to be added:  ");
                    if (double.TryParse(Console.ReadLine(), out double input))
                    {
                        NumX = input;
                        isXValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid entry.");
                    }
                } while (isXValid == false);
            }

            //get second number
            bool isYValid = false;
            do
            {
                Console.WriteLine("\nEnter second number to be added:  ");
                if (double.TryParse(Console.ReadLine(), out double input))
                {
                    numY = input;
                    isYValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid entry.");
                }
            } while (isYValid == false);

            //Call function from Arithmetic class.
            result = Arithmetic.Add(NumX, numY);
            Console.WriteLine("\nResult of addition:  " + result.ToString("g4") + "\n\n");

            ResultsMenu(result, "Add");
        }

        private static void SubNumbers()        //subtraction subroutine.
        {
            double numY = 0;            //second value
            double result = 0;          //stores result

            Console.Clear();
            Console.WriteLine("Subtraction");
            if (XCheck == true)      //check for saved previous result
            {
                Console.WriteLine("\nCurrent result:  " + NumX.ToString("g4") + "\n");
            }
            else                    //get first number if no saved result
            {
                bool isXValid = false;
                do
                {
                    Console.WriteLine("\nEnter first number:  ");
                    if (double.TryParse(Console.ReadLine(), out double input))
                    {
                        NumX = input;
                        isXValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid entry.");
                    }
                } while (isXValid == false);
            }

            //get second number
            bool isYValid = false;
            do
            {
                Console.WriteLine("\nEnter number to be subtracted:  ");
                if (double.TryParse(Console.ReadLine(), out double input))
                {
                    numY = input;
                    isYValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid entry.");
                }
            } while (isYValid == false);

            //Call function from Arithmetic class.
            result = Arithmetic.Subtract(NumX, numY);
            Console.WriteLine("\nResult of subtraction:  " + result.ToString("g4") + "\n\n");

            ResultsMenu(result, "Subtract");
        }

        private static void MultNumbers()        //multiplication subroutine.
        {
            double numY = 0;            //second value
            double result = 0;          //stores result

            Console.Clear();
            Console.WriteLine("Multiplication");
            if (XCheck == true)      //check for saved previous result
            {
                Console.WriteLine("\nCurrent result:  " + NumX.ToString("g4") + "\n");
            }
            else                    //get first number if no saved result
            {
                bool isXValid = false;
                do
                {
                    Console.WriteLine("\nEnter first number to be multiplied:  ");
                    if (double.TryParse(Console.ReadLine(), out double input))
                    {
                        NumX = input;
                        isXValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid entry.");
                    }
                } while (isXValid == false);
            }

            //get second number
            bool isYValid = false;
            do
            {
                Console.WriteLine("\nEnter second number to be multiplied:  ");
                if (double.TryParse(Console.ReadLine(), out double input))
                {
                    numY = input;
                    isYValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid entry.");
                }
            } while (isYValid == false);

            //Call function from Arithmetic class.
            result = Arithmetic.Multiply(NumX, numY);
            Console.WriteLine("\nResult of multiplication:  " + result.ToString("g4") + "\n\n");

            ResultsMenu(result, "Multiply by");
        }

        private static void DivNumbers()        //division subroutine.
        {
            double numY = 0;            //second value
            double result = 0;          //stores result

            Console.Clear();
            Console.WriteLine("Division");
            if (XCheck == true)      //check for saved previous result
            {
                Console.WriteLine("\nCurrent result:  " + NumX.ToString("g4") + "\n");
            }
            else                    //get first number if no saved result
            {
                bool isXValid = false;
                do
                {
                    Console.WriteLine("\nEnter number to be divided:  ");
                    if (double.TryParse(Console.ReadLine(), out double input))
                    {
                        NumX = input;
                        isXValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid entry.");
                    }
                } while (isXValid == false);
            }

            //get second number
            bool isYValid = false;
            do
            {
                Console.WriteLine("\nEnter number to divide by:  ");
                if (double.TryParse(Console.ReadLine(), out double input))
                {
                    numY = input;
                    isYValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid entry.");
                }
            } while (isYValid == false);

            //Call function from Arithmetic class.
            result = Arithmetic.Divide(NumX, numY);
            Console.WriteLine("\nResult of division:  " + result.ToString("g4") + "\n\n");

            ResultsMenu(result, "Divide by");
        }

        private static void ExpNumbers()        //Addition subroutine.
        {
            int numY = 0;            //second value
            double result = 0;          //stores result

            Console.Clear();
            Console.WriteLine("Addition");
            if (XCheck == true)      //check for saved previous result
            {
                Console.WriteLine("\nCurrent result:  " + NumX.ToString("g4") + "\n");
            }
            else                    //get first number if no saved result
            {
                bool isXValid = false;
                do
                {
                    Console.WriteLine("\nEnter base number:  ");
                    if (double.TryParse(Console.ReadLine(), out double input))
                    {
                        NumX = input;
                        isXValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid entry.");
                    }
                } while (isXValid == false);
            }

            //get second number
            bool isYValid = false;
            do
            {
                Console.WriteLine("\nEnter exponent value:  ");
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    numY = input;
                    isYValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid entry.");
                }
            } while (isYValid == false);

            //Call function from Arithmetic class.
            result = Arithmetic.Exponent(NumX, numY);
            Console.WriteLine("\nResult of addition:  " + result.ToString("g4") + "\n\n");

            ResultsMenu(result, "Raise result to the power of");
        }


        //End of function submenu to determine what to do with result.
        private static void ResultsMenu(double result, string operation)
        {
            bool loop = true;
            do
            {
                Console.WriteLine("Select next operation: \n");
                Console.WriteLine("1. " + operation + " another number");
                Console.WriteLine("2. Save result and return to main menu");
                Console.WriteLine("3. Clear result and return to main menu");

                if (int.TryParse(Console.ReadLine(), out int selection))
                {
                    switch (selection)
                    {
                        case 1:
                            NumX = result;
                            XCheck = true;
                            loop = false;
                            break;

                        case 2:
                            NumX = result;
                            MenuChoice = 0;
                            XCheck = true;
                            loop = false;
                            break;

                        case 3:
                            NumX = 0;
                            MenuChoice = 0;
                            XCheck = false;
                            loop = false;
                            break;

                        default:
                            Console.WriteLine("Invalid entry.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid entry.");
                }
            } while (loop == true);
        }

        private static void ClearResult()
        {
            Console.WriteLine("\nClearing result...");
            System.Threading.Thread.Sleep(2000);
            NumX = 0;
            XCheck = false;
            MenuChoice = 0;
        }

        private static void SelfDestruct()      //with apologies to Star Trek III
        {
            string confirm = "";
            const string DCODE = "000 DESTRUCT 0";

            Console.Clear();
            Console.WriteLine("CONSOLE SELF-DESTRUCT SEQUENCE\n");
            Console.WriteLine("---Enter final validation code to confirm---");
            confirm = Console.ReadLine();

            if(confirm == DCODE)
            {
                Console.WriteLine("Console self-destruct in:");
                //countdown sequence
                for (int i = 10; i >= 0; i--)
                {
                    Console.WriteLine(i);
                    System.Threading.Thread.Sleep(1000);
                }
                Console.WriteLine("KA-BOOM");
                System.Threading.Thread.Sleep(1000);
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("\nInvalid Entry.  Console self-destruct aborted.");
                Console.WriteLine("Returning to main menu...");
                System.Threading.Thread.Sleep(2000);
            }
        }

        private static void AuthenticateUser(List<User> users)      //User authetication
        {
            string user = "";
            string pass = "";
            bool isAuth = false;

            Console.Clear();

            int count = 0;
            while (count < 4)               //limits login attempts to 4
            {
                //get username and password from user
                Console.WriteLine("Enter username:");
                user = Console.ReadLine();
                Console.WriteLine("\nEnter password:");
                pass = Console.ReadLine();

                //validate against user list
                for(int i = 0; i < users.Count; i++)
                {
                    if(user == users[i].Username)
                    {
                        //if username is valid, check password
                        if(pass == users[i].Password)
                        {
                            Console.WriteLine("\nAccess Granted.  Loading Calculator menu...");
                            isAuth = true;
                            AuthLevel = users[i].AccessLevel;       //gets user access level and sets for rest of program
                            count = 4;
                            i = users.Count;
                            System.Threading.Thread.Sleep(2000);
                        }
                    }
                }

                if(isAuth == false)
                {
                    //NOTE:  for added security, checks both credentials, but does not specify which credential is incorrect.
                    Console.WriteLine("\nInvalid username or password.\n");
                    count++;
                }
                LogAttempt(isAuth);
            }

            if(isAuth == false)
            {
                //end program after four failed attempts
                Console.WriteLine("\nAttempt limit exceeded.");
                EndProgram();
            }

        }

        private static void LogAttempt(bool isAuth)
        {
            DateTime attemptTimeStamp = new DateTime();
            attemptTimeStamp = DateTime.Now;

            string logPath = @"D:\" + "AuthLog.txt";            //NOTE TO INSTRUCTOR:  Please replace "D:\" with a location of your choice.

            StreamWriter authLog = new StreamWriter(logPath, true);

            //creates a log entry and writes it to the log file
            authLog.WriteLine(attemptTimeStamp);
            if (isAuth == true) { authLog.WriteLine("Success" + "\n"); }
            else { authLog.WriteLine("Failed"); }
            authLog.Close();
        }

        private static void ErrorTrap(Exception ex)
        {
            DateTime errorTimeStamp = new DateTime();
            errorTimeStamp = DateTime.Now;

            string logPath = @"D:\" + "ErrorLog.txt";            //NOTE TO INSTRUCTOR:  Please replace "D:\" with a location of your choice.

            StreamWriter errorLog = new StreamWriter(logPath, true);

            //creates a log entry and writes it to the log file
            errorLog.WriteLine(errorTimeStamp);
            errorLog.WriteLine(ex.Message);
            errorLog.WriteLine(ex.StackTrace + "\n");
            errorLog.Close();

            Console.WriteLine("An error occured: " + ex.Message);
            Console.WriteLine("\nPress ENTER to continue.");
            Console.ReadLine();
        }

        private static void EndProgram()
        {
            Console.WriteLine("\nExiting...");
            System.Threading.Thread.Sleep(2000);
            Environment.Exit(0);
        }
    }
}
