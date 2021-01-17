using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class ClassKoeffModels
    {
        public double AGasCOCKS(double SV)
        {
            if (SV == 20)
            {
                return 1.706;
            }
            if (SV < 20)
            {
                return 1.747;
            }
            else
            {
                return 1.666;
            }
        }
        public double BGasCOCKS(double SV)
        {
            if (SV == 20)
            {
                return -144.4;
            }
            if (SV < 20)
            {
                return -153.66;
            }
            else
            {
                return -131.72;
            }
        }
        public double ACoal(double SV)
        {
            if (SV == 20)
            {
                return 1.714;
            }
            if (SV < 20)
            {
                return 1.752;
            }
            else
            {
                return 1.677;
            }
        }
        public double BCoal(double SV)
        {
            if (SV == 20)
            {
                return -132.8;
            }
            if (SV < 20)
            {
                return -140.8;
            }
            else
            {
                return -129.21;
            }
        }
        public double ADomGas(double SV)
        {
            if (SV == 20)
            {
                return 1.765;
            }
            if (SV < 20)
            {
                return 1.811;
            }
            else
            {
                return 1.716;
            }
        }
        public double BDomGas(double SV)
        {
            if (SV == 20)
            {
                return -161.65;
            }
            if (SV < 20)
            {
                return -163.65;
            }
            else
            {
                return -148.63;
            }
        }
    }
}
