using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculateur.DLL
{
    public class Calculator
    {
        public static int Division(int numerateur, int denominateur)
        {
            return numerateur / denominateur;
        }

        //Exos:
        //méthode qui renvoie le nombre de char qui composent une chaine

        public static int NbChar(string chaine)
        {
            if (string.IsNullOrEmpty(chaine))
            {
                //Soit renvoyer une Exception, soit renvoyer une valeur par defaut = 0
                return 0;
            }
            return chaine.Length;
        }

        //méthode qui renvoie le nombre de mots qui composent une chaine

        public static int NbMots(string chaine)
        {
            if (string.IsNullOrEmpty(chaine))
            {
                throw new ArgumentException("Paramètre not null and not empty");
            }
            return chaine.Trim().Replace("  ", " ").Split(' ').Length;
        }

        //méthode qui renvoie la somme des éléments d'un tableau d'entiers

        public static int SommeTab(int[] tab)
        {
            if (tab == null)
            {
                throw new ArgumentException("Tab ne peut pas être null....");
            }
            int somme = 0;
            foreach (var item in tab)
            {
                somme += item;
            }
            return somme;
        }

        //Méthode static private
        /*
         * 2 options possibles pour tester une méthode privée et static
         * 1- Utiliser la méthode privée dans une méthode publique, ensuite tester la méthode publique
         * 2- Tester directement la méthode privée
         */

        private static bool IsPositif(int x)
        {
            return x > 0;
        }

        public static int Add(int x, int y)
        {
            if (IsPositif(x) && IsPositif(y))
            {
                return x + y;
            }
            else
            {
                throw new ArgumentException("Les 2 params doivent être positifs");
            }
        }

        //Méthode privée non static

        private bool IsNegatif(int x)
        {
            return x < 0;
        }

        //Pour exclure cette méthode du calcul du taux de code coverage:
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static void Test()
        {
            Console.WriteLine("Autre méthode");
        }

    }
}
