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
            bool ask = true;

            void BmiOutput(double bmi)
            {
                string message;
                Console.ForegroundColor = ConsoleColor.Green;
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
                Console.ResetColor();
            }

            //Restart method
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
                Console.Clear();
                return askRestart;
            }

            //Enter to continue
            void EndMessage(string message)
            {
                Console.Clear();
                Console.WriteLine(message);
                
            }

            void ErrorMessage(params string[] messages)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR : ");
                foreach(string message in messages)
                {
                    Console.Write($"{message}");
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Press Enter To Continue");
                Console.ReadLine();
                Console.ResetColor();
                Console.Clear();
            }

            

            while (ask)
            {

                Console.WriteLine("Input Number from 1-4");
                Console.WriteLine("1. Body Mass Index\n2. Reprint Name\n3. Print Even's Character\n4. Sum the Inputted Array");

                Console.WriteLine();
                Console.WriteLine("Please input a number : ");
                string inputChoice = Console.ReadLine();
                Console.WriteLine();

                //  
                if (Int32.TryParse(inputChoice, out int input))
                {
                    switch (input)
                    {
                        case 1:
                            //BMI
                            double bmi;
                            double weight;
                            double height;
                            try
                            {
                                
                                Console.WriteLine("Input Your Weight (Kg)");
                                weight = Double.Parse(Console.ReadLine());
                                Console.WriteLine("Input Your Height (Cm)");
                                height = Double.Parse(Console.ReadLine());
                                Console.WriteLine();
                                bmi = Math.Round(weight / (Math.Pow(height / 100, 2)), 1);
                                BmiOutput(bmi);

                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine($"ERROR : {e}");
                            }

                            //finally selalu dijalankan walaupun kode berhasil atau gagal
                            finally
                            {
                                RestartMessage();
                                yes = Console.ReadLine();
                                ask = RestartValue(yes);
                            }
                            break;

                        case 2:
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
                        case 3:
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
                        case 4:

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
                            ErrorMessage("Please Input a number 1 - 4");
                            break;
                    }
                    Console.WriteLine();
                }
                // Jika kosong
                else if (inputChoice == null || inputChoice == "")
                {
                    ErrorMessage("Input Value is : ",inputChoice);
                }
                
                // Jika Selain angka bulat
                else
                {
                    ErrorMessage("Invalid Input : ",inputChoice);

                }
            }
            EndMessage("Exit : Bye Bye ");
        }
    }
}
