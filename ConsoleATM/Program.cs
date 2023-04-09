using System;
using System.Collections.Generic;

public class userDB
{
    public string name;
    public int pin;
    public double balance;

    public userDB(string name, int pin, double balance)
    {
        this.name = name;
        this.pin = pin;
        this.balance = balance;
    }
    public string Name { get { return name; } set { name = value; } }
    public int Pin { get { return pin; } set { pin = value; } }
    public double Balance { get { return balance; } set { balance = value; } }
}

namespace ConsoleATM
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<userDB> userList = new List<userDB>();
            userList.Add(new userDB("Ali", 1453, 550.50));

            Console.WriteLine("Welcome to ConsoleATM System\n");
            foreach (var userDB in userList)
            {
            Name:
                Console.WriteLine("Your name:");
                string userName = Console.ReadLine().ToLower();
                if (userName == userDB.name.ToLower())
                {
                Pin:
                    Console.WriteLine("Your pin:");

                    int p = 0;
                    string k = Console.ReadLine();
                    if (int.TryParse(k, out p) && p == userDB.pin)
                    {
                    Greeting:
                        Console.Clear();
                    dORw:
                        Console.WriteLine($"Greetings {userDB.name}. Your balance is {userDB.balance}$\n");
                        Console.WriteLine("Press 1 to Deposit, Press 2 to Withdraw, 0 to Exit");

                        int i = 0;
                        string l = Console.ReadLine();
                        if (int.TryParse(l, out i))
                        {
                            switch (i)
                            {
                                case 1: // deposit
                                    Console.WriteLine("Enter the amount you'd like to deposit:");
                                    int depositAmount = 0;
                                    string depositString = Console.ReadLine();
                                    Console.Clear();
                                    if (int.TryParse(depositString, out depositAmount) && depositAmount > 0)
                                    {
                                        userDB.balance += depositAmount;
                                        Console.WriteLine($"You successfully deposited {depositAmount}$\nYour new balance is: {userDB.balance}$\nPress any key to go back...");
                                        Console.ReadKey();
                                        goto Greeting;
                                    }
                                    else { goto dORw; }
                                case 2: // withdraw
                                    Console.WriteLine("Enter the amount you'd like to withdraw:");
                                    int withdrawAmount = 0;
                                    string withdrawString = Console.ReadLine();
                                    Console.Clear();
                                    if (int.TryParse(withdrawString, out withdrawAmount) && withdrawAmount <= userDB.balance)
                                    {
                                        userDB.balance -= withdrawAmount;
                                        Console.WriteLine($"You succesfully withdrawn {withdrawAmount}$.\nYour new balance is: {userDB.balance}$\nPress any key to go back...");
                                        Console.ReadKey();
                                        goto Greeting;
                                    }
                                    else { goto dORw; }
                                case 0:
                                    break;
                                default:
                                    Console.WriteLine("Bad input, please try again");
                                    goto dORw;
                            }
                        }
                        else { goto dORw; }
                    }
                    else { goto Pin; }
                }
                else { goto Name; }
            }
        }
    }
}

