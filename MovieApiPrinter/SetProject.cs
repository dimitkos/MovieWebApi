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

                //var input = UserInput();

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
                //Console.WriteLine("Please Enter the Title");
                //string title = Console.ReadLine();
                //Console.WriteLine("Please Enter the Name");
                //string name = Console.ReadLine();
                //Console.WriteLine("Please Enter the Description");
                //string description = Console.ReadLine();

                //AddMovieRequest request = new AddMovieRequest()
                //{
                //    Title = title,
                //    Name = name,
                //    Description = description
                //};

                //var client = new RestClient("http://localhost:59881");
                //var postRequest = new RestRequest("api/movie/getMovies", Method.POST);
                //postRequest.AddParameter("application/json; charset=utf-8", ParameterType.RequestBody);
                //postRequest.RequestFormat = DataFormat.Json;
            }
            else if (input == "3")
            {
                //update
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
