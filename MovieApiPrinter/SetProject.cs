using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApiPrinter
{
    public class SetProject
    {
        public void StartUpProject()
        {
            while (true)
            {
                DisplayInfo();

                CheckInput(UserInput());

                if (ContinueOrNot())
                {
                    Console.Clear();
                    continue;
                }
                break;
            }
        }

        #region private methods

        private void DisplayInfo()
        {
            Console.WriteLine("Please Choose Action");
            Console.WriteLine("[1] Get Movies");
            Console.WriteLine("[2] Add Movie");
            Console.WriteLine("[3] Update Movie");
            Console.WriteLine("[4] Delete Movie");
        }

        private string UserInput()
        {
            string input = Console.ReadLine();
            return input.Trim();
        }

        private void CheckInput(string input)
        {
            if (input == "1")
            {
                MovieEndPoints mv = new MovieEndPoints();
                mv.GetMoviesAndPrint();
            }
            else if (input == "2")
            {
                MovieEndPoints mv = new MovieEndPoints();
                mv.AddMovie();
            }
            else if (input == "3")
            {
                MovieEndPoints mv = new MovieEndPoints();
                mv.UpdateMovie();
            }
            else if (input == "4")
            {
                //delete
            }
            else
            {
                Console.WriteLine("Wrong Input");
            }
        }

        private bool ContinueOrNot()
        {
            Console.WriteLine("Would you like more actions?? [Y] or [N]");

            if (UserInput().ToLower() == "y")
            {
                return true;
            }
            else
            {
                return false; 
            }
        }

        #endregion
    }
}
