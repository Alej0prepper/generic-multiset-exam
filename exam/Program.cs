using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace MatCom.Exam
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(Exam.Nombre);
            Console.WriteLine(Exam.Grupo);

            ExampleCase();
        }

        static void ExampleCase()
        {
            IMultiSet<string> matcom = Exam.CreateMultiSet<string>();

            matcom.Add("Guinovart");
            matcom.Add("Idania");

            Debug.Assert(matcom.Count == 2);

            IMultiSet<string> pro = matcom.CreateSubset();

            pro.Add("Piad");
            pro.Add("Leynier");
            pro.Add("Mauricio");

            Debug.Assert(pro.Count == 3);
            Debug.Assert(matcom.Count == 5);

            Debug.Assert(matcom.Contains("Guinovart"));
            Debug.Assert(matcom.Contains("Leynier"));
            Debug.Assert(!pro.Contains("Idania")); // Este no está en pro

            IMultiSet<string> matematica = matcom.CreateSubset();

            matematica.Add("Yudivian");
            matematica.Add("Celia");
            matematica.Add("Idania");

            string[] shortNames = matcom.Find(s => s.Length <= 5).ToArray();
            Debug.Assert(shortNames.Length == 2);

            foreach (var x in matcom)
            {
                Console.WriteLine(x);
            }

            // Guinovart
            // Idania
            // Piad
            // Leynier
            // Mauricio
            // Yudivian
            // Celia

            foreach (var x in matematica)
            {
                Console.WriteLine(x);
            }

            // Yudivian
            // Celia
            // Idania

            matcom.Remove("Idania", 0);
            // Aunque se eliminó de la raíz, este elemento sigue existiendo
            // en el subconjunto `matematica`
            Debug.Assert(matematica.Contains("Idania"));
            // Y por tanto el `Count` de matcom no cambia
            Debug.Assert(matcom.Count == 7);
        }
    }
}