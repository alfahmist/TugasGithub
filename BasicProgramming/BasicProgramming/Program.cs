using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicProgramming
{
    class Program
    {

        static void Main(string[] args)
        {
            String yes;
            void RestartMessage()
            {
                Console.WriteLine();
                Console.WriteLine("type yes to restart program");
            }

            bool RestartValue(String yesAsk)
            {
                bool askRestart = true;
                if (yesAsk.ToLower() != "yes")
                {
                    askRestart = false;
                }
                return askRestart;
            }

            bool ask = true;

            while (ask)
            {

                Console.WriteLine("Input Number from 1-4");
                Console.WriteLine("1. Body Mass Index\n2. Reprint Name\n3. Print Even's Character\n4. Sum the Inputted Array");

                Console.WriteLine();
                Console.WriteLine("Please input a number : ");
                String input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        //BMI
                        double bmi;
                        Console.WriteLine("Input Your Weight (Kg)");
                        double weight = Double.Parse(Console.ReadLine());
                        Console.WriteLine("Input Your Height (Cm)");
                        double height = Double.Parse(Console.ReadLine());
                        Console.WriteLine();

                        bmi = Math.Round(weight / (Math.Pow(height / 100, 2)), 1);

                        //Kurang dari 18.1, maka kamu underweight.
                        //Antara 18.1 – 23.1, maka kamu normal.
                        //Antara 23.1 – 28.1, maka kamu overweight.
                        //Lebih dari 28.1, maka kamu obesitas.

                        if (bmi < 18.1)
                        {
                            Console.WriteLine($"Your BMI's {bmi} You're Underweight");
                        }
                        else if (bmi >= 18.1 && bmi <= 23.1)
                        {
                            Console.WriteLine($"Your BMI's {bmi} You're Normal");
                        }
                        else if (bmi >= 23.1 && bmi <= 28.1)
                        {
                            Console.WriteLine($"Your BMI's {bmi} You're Overweight");
                        }
                        else if (bmi >= 28.1)
                        {
                            Console.WriteLine($"Your BMI's {bmi} You're Obesitas");
                        }

                        //restart

                        RestartMessage();
                        yes = Console.ReadLine();
                        ask = RestartValue(yes);
                        break;

                    case "2":
                        // Print urut nama
                        Console.WriteLine("Please Input Your Name");
                        string name = Console.ReadLine();
                        for (int i = 0; i < name.Length; i++)
                        {
                            Console.WriteLine($"Huruf ke {i + 1} adalah {name[i]}");
                        }

                        //restart
                        RestartMessage();
                        yes = Console.ReadLine();
                        ask = RestartValue(yes);
                        break;
                    case "3":
                        //print karakter urutan genap
                        Console.WriteLine("Please Input Your Name");
                        string nameGenap = Console.ReadLine();

                        // index array mulai dari 0
                        // index genap mulai dari 1
                        for (int i = 1; i < nameGenap.Length; i += 2)
                        {
                            Console.WriteLine($"Karakter Genap : {nameGenap[i]}");
                        }

                        //restart
                        RestartMessage();
                        yes = Console.ReadLine();
                        ask = RestartValue(yes);
                        break;
                    case "4":

                        Console.WriteLine("Please Input the Array Size");
                        // masukkan maximum array
                        int arraySize = Int32.Parse(Console.ReadLine());

                        Console.WriteLine("Please Input the Array Value");

                        // menampung value integer
                        int[] arrValue = new int[arraySize];

                        for (int i = 0; i < arraySize; i++)
                        {
                            Console.Write($"index ke - {i} : ");
                            arrValue[i] = int.Parse(Console.ReadLine());
                        }

                        Console.WriteLine("Result");
                        Console.WriteLine(arrValue.Sum());

                        //restart
                        RestartMessage();
                        yes = Console.ReadLine();
                        ask = RestartValue(yes);
                        break;
                    default:
                        Console.WriteLine("Please Input a number 1 - 4");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
