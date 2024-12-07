using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokemon.Interfaces;

namespace Pokemon.Services
{
    internal class PokeService : IPokeProvider
    {
        public bool IsShiny()
        {
            int randomNumber = new Random().Next(1, 101);

            return randomNumber <= 5;
        }

        public bool CaptureSuccess(int PokeLifePercentage)
        {
            int randomNumber = new Random().Next(1, 101);

            return randomNumber <= (100- PokeLifePercentage);
        }

        public int NumAtack()
        {
            return new Random().Next(0, 41);
        }
    }
}
