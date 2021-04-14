using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicProgramming
{
    class Program
    {
        static void RestartProgram(ref bool ask)
        {
            Console.WriteLine();
            Console.WriteLine("type yes to restart program");
            string yesAsk = Console.ReadLine();
            if (yesAsk.ToLower() != "yes")
            {
                ask = false;
            }
            Console.Clear();
        }

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
                
            }

            

            while (ask)
            {

                Console.WriteLine("Input Number from 1-4");
                Console.WriteLine("1. Body Mass Index\n2. Reprint Name\n3. Print Even's Character\n4. Sum the Inputted Array");

                Console.WriteLine();
                Console.WriteLine("Please input a number : ");
                string inputChoice = Console.ReadLine();
                Console.WriteLine();

                //  Try Parse
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
                                ErrorMessage($"{e}");
                            }

                            //finally selalu dijalankan walaupun kode berhasil atau gagal
                            finally
                            {
                                RestartProgram(ref ask);
                            }
                            break;

                        case 2:
                            // Print urut nama
                            Console.WriteLine("Please Input Your Name");
                            string name = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Green;
                            for (int i = 0; i < name.Length; i++)
                            {
                                Console.WriteLine($"Huruf ke {i + 1} adalah {name[i]}");
                            }
                            Console.ResetColor();
                            
                            RestartProgram(ref ask);
                            break;
                        case 3:
                            //print karakter urutan genap
                            Console.WriteLine("Please Input Your Name");
                            string nameGenap = Console.ReadLine();

                            // index array mulai dari 0
                            // index genap mulai dari 1
                            Console.ForegroundColor = ConsoleColor.Green;
                            for (int i = 1; i < nameGenap.Length; i += 2)
                            {
                                Console.WriteLine($"Karakter Genap : {nameGenap[i]}");
                            }
                            Console.ResetColor();
                            RestartProgram(ref ask);
                            break;
                        case 4:
                            
                            try
                            {
                                // masukkan maximum array
                                Console.WriteLine("Please Input the Array Size");
                                int arraySize = Int32.Parse(Console.ReadLine());

                                // menampung value integer
                                Console.WriteLine("Please Input the Array Value");
                                int[] arrValue = new int[arraySize];
                                Console.ForegroundColor = ConsoleColor.Green;
                                for (int i = 0; i < arraySize; i++)
                                {
                                    Console.Write($"index ke - {i} : ");
                                    arrValue[i] = int.Parse(Console.ReadLine());
                                }
                                Console.WriteLine("Result");
                                Console.WriteLine(arrValue.Sum());
                                Console.ResetColor();
                            }
                            catch (FormatException e)
                            {
                                
                                ErrorMessage($"{e}");
                            }

                            RestartProgram(ref ask);
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
                    ErrorMessage("Input Value is : Null");
                    Console.Clear();
                }
                
                // Jika Selain angka bulat
                else
                {
                    ErrorMessage("Invalid Input : ",inputChoice);
                    Console.Clear();
                }
            }
            EndMessage("Exit : Bye Bye ");
        }
    }
}
