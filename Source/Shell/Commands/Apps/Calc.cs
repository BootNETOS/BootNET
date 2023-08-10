using System;
using Console = BootNET.Core.Console;

namespace BootNET.Shell.Commands.Apps;

public class Calc : Command
{
    public Calc(string name) : base(name)
    {
    }

    public override string Invoke(string[] args)
    {
        string response;
        try
        {
            if ((args[0] != "") & (args[1] != "") & (args[2] != ""))
            {
                int num1 = Convert.ToInt16(args[0]);
                int num2 = Convert.ToInt16(args[2]);
                switch (args[1])
                {
                    default:
                        Console.SetForegroundColor(ConsoleColor.Red);
                        response = "Error: Invalid operator!";
                        break;
                    case "+":
                        response = Convert.ToString(num1 + num2);
                        break;
                    case "-":
                        response = Convert.ToString(num1 - num2);
                        break;
                    case "*":
                        response = Convert.ToString(num1 * num2);
                        break;
                    case "/":
                        response = Convert.ToString(num1 / num2);
                        break;
                    case "=":
                        if (num1 == num2)
                            response = "true";
                        else
                            response = "false";

                        break;
                    case "!=":
                        if (num1 != num2)
                            response = "true";
                        else
                            response = "false";

                        break;
                }
            }
            else
            {
                Console.SetForegroundColor(ConsoleColor.Red);
                response = "Error: No numbers!";
            }
        }
        catch (Exception ex)
        {
            Console.SetForegroundColor(ConsoleColor.Red);
            response = "Error: " + ex.Message;
        }

        return response;
    }
}