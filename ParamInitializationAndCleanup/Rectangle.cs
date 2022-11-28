using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamInitializationAndCleanup
{
    public class Rectangle
    {
        public double Longueur { get; set; }
        public double Largeur { get; set; }

        public double Surface()
        {
            return Longueur * Largeur;
        }
        public double Perimetre()
        {
            return 2 * (Longueur + Largeur);
        }
    }
}
