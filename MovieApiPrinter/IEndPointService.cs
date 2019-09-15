using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApiPrinter
{
    public interface IEndPointService
    {
        void GetMoviesAndPrint();

        void AddMovie();

        void UpdateMovie();

        void DeleteMovie();
    }
}
