using System;

namespace Task4
{
    public class Menu
    {
        #region Variables
        private bool exists = false;

        private int b1, b2, n;
        private string input;

        Matrice m;
        #endregion

        #region Run
        public void Run()
        {
            Console.WriteLine("Choose an option based on the corresponding number:\n1. Create A Matrice\n2. Print current matrice\n3. Get entry\n4. Addition\n5. Multiplication\n0. Exit\n");
            input = Console.ReadLine();

            try
            {
                if (MenuInputCheck(input, out int menuInput))
                {
                    switch (menuInput)
                    {
                        case 1:
                            Console.WriteLine("Enter 3 numbers separated by space.\n" + "First one is the number of rows/columns of the matrice.\n" + "The second one is less than the third number, and they represent the smaller squares inside the matrice.\n" + "Also, the sum of the second and third numbers should equal the first number:\n");

                            Create();

                            Run();
                            break;

                        case 2:
                            if (exists) Print();

                            else Console.WriteLine("\nOoooops! No matrice found :(");

                            Run();
                            break;

                        case 3:
                            if (exists) GetEntry();

                            else Console.WriteLine("\nOoooops! No matrice found :(");

                            Run();
                            break;

                        case 4:
                            if (exists)
                            {
                                Addition();
                                Console.WriteLine("New matrice created and added to the original. Ready for print!");
                            }

                            else Console.WriteLine("\nOoooops! No matrice found :(");

                            Run();
                            break;

                        case 5:
                            if (exists)
                            {
                                Multiplication();
                                Console.WriteLine("New matrice created and multiplied by the original. Ready for print!");
                            }

                            else Console.WriteLine("\nOoooops! No matrice found :(");

                            Run();
                            break;

                        case 0:
                            Exit();
                            break;

                        default:
                            Console.WriteLine("\nERROR: Invalid input!");
                            Run();
                            break;
                    }
                }

                else throw new Exception("\nERROR: Invalid input!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Run();
            }
        }
        #endregion

        #region Menu Functions
        private void Create()
        {
            bool correctInput = false;

            while (!correctInput)
            {
                try
                {
                    input = Console.ReadLine();

                    if (MatriceInputCheck(input)) correctInput = true;

                    else throw new Exception("Input Error! Try again:");
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            try
            {
                m = new Matrice(n, b1, b2);
                exists = true;
            }
            catch (Matrice.OutOfOrderException)
            {
                Console.WriteLine("ERROR: The second number must be smaller than the third number!");
            }
            catch (Matrice.OutOfBoundException)
            {
                Console.WriteLine($"ERROR: {b1} and/or {b2} are/is out of bound!");
            }
            catch (Matrice.UnmatchingAdditionException)
            {
                Console.WriteLine($"ERROR: The sum of {b1} and {b2} doesn't equal to {n}");
            }
        }

        private void Print()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i < b1 && j < b1) Console.Write($"{m.PrintCurrentMatrice(i, j)} ");

                    if (i >= b1 && j >= b1) Console.Write($" {m.PrintCurrentMatrice(i, j)}");

                    if ((i < b1 && j >= b1) || (i >= b1 && j < b1)) Console.Write("  ");
                }

                Console.WriteLine("");
            }
        }

        private void GetEntry()
        {
            Console.WriteLine("Enter two indexes of the matrice separated by a space:\n");

            bool correctInput = false;

            while (!correctInput)
            {
                input = Console.ReadLine();

                try
                {
                    if (int.TryParse(input.Split(" ")[0], out int i) && int.TryParse(input.Split(" ")[1], out int j))
                    {
                        Console.WriteLine(m.GetEntry(i, j));

                        correctInput = true;
                    }

                    else throw new Exception("Oooooops! Incorrect input format. Input must be two separate integers.\nTry again:");
                }

                catch (Matrice.FalseEntryException)
                {
                    Console.WriteLine("ERROR: Inputs are out of range! Try again:");
                }
            }
        }

        private void Addition()
        {
            Matrice newM = new Matrice(n, b1, b2);

            m.Addition(newM);
        }

        private void Multiplication()
        {
            Matrice newM = new Matrice(n, b1, b2);

            m.Multiplication(newM);
        }

        private void Exit() => Environment.Exit(0);
        #endregion

        #region Input Pre-Conditions
        public bool MenuInputCheck(string input, out int menuInput)
        {
            return int.TryParse(input, out menuInput);
        }

        public bool MatriceInputCheck(string input)
        {
            return (int.TryParse(input.Split(" ")[0], out n) && int.TryParse(input.Split(" ")[1], out b1) && int.TryParse(input.Split(" ")[2], out b2));
        }
        #endregion
    }
}
