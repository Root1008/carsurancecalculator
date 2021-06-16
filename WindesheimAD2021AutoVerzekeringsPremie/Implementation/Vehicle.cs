using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindesheimAD2021AutoVerzekeringsPremie.Implementation
{
    class Vehicle
    {
        // PowerinKW naar double verandert, Basis premie van voertuig moet decimalen achter de komma hebben. Door de int werkt het rekensommetje niet lekker.
        public double PowerInKw { get; private set; }
        public int ValueInEuros { get; private set; }
        public int Age { get; private set; }

        internal Vehicle (int PowerInKw, int ValueInEuros, int constructionYear)
        {
            this.PowerInKw = PowerInKw;
            this.ValueInEuros = ValueInEuros;
            Age = constructionYear > DateTime.Now.Year ? 0 : DateTime.Now.Year - constructionYear;            
        }
    }
}
