using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    internal class HangTonAmException : Exception
    {
        public string Mahh_loi;

        public HangTonAmException(string mahh_loi)
        {
            Mahh_loi = mahh_loi;
        }
    }
}