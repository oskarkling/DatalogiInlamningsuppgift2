using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatalogiInlamningsuppgift2.Utility
{
    internal static class Input
    {
        internal static bool IsMenuInputValid(string input, out int menuChoice, out string errormsg, int nrOfMenuChoices)
        {
            errormsg = "";
            menuChoice = 0;
            if(IsIntInputValid(input, out menuChoice, out errormsg, true))
            {
                if(menuChoice < nrOfMenuChoices)
                {
                    return true;
                }
                else
                {
                    errormsg = $"Menu choice is out for range for menu choices. Use 0 - {nrOfMenuChoices - 1}\n";
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        internal static bool IsIntInputValid(string input, out int validNumber, out string errormsg, bool canBeZero)
        {
            errormsg = "no error";
            validNumber = 0;

            if (IsInputEmpty(input))
            {
                errormsg = "Input was empty\n";
                return false;
            }
            else
            {
                if (IsInputANumber(input, out validNumber))
                {
                    if (!IsNumberNegative(validNumber))
                    {
                        if (canBeZero)
                        {
                            return true;
                        }
                        else
                        {
                            if (validNumber != 0)
                            {
                                return true;
                            }
                            else
                            {
                                errormsg = "You can not input 0.\nIs 0 a Natural Number? No, 0 is NOT a natural number because natural numbers are counting numbers. For counting any number of objects, we start counting from 1 and not from 0.\n";
                                return false;
                            }
                        }
                    }
                    else
                    {
                        errormsg = "No negative numbers here!\n";
                        return false;
                    }
                }
                else
                {
                    errormsg = "Input was not a valid number\n";
                    return false;
                }
            }
        }

        // Checks if string input is a number
        // Then sends an int with that number
        private static bool IsInputANumber(string input, out int number)
        {
            return int.TryParse(input, out number);
        }

        // Checks if string is empty
        private static bool IsInputEmpty(string input)
        {
            return input == string.Empty;
        }

        // Checks if the number is negative
        private static bool IsNumberNegative(long number)
        {
            return number < 0;
        }
    }
}
