using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Collections;

namespace MatCom.Exam
{

    public class Exam
    {
        public static IMultiSet<T> CreateMultiSet<T>()
        {
            // Borre este código y devuelva una nueva instancia de su clase
            return new MultiSet<T>();
        }

        // Borre esta excepción y ponga su nombre como string, e.j.
        // Nombre => "Fulano Pérez Pérez";
        public static string Nombre => "Alejandro Alvarez";

        // Borre esta excepción y ponga su grupo como string, e.j.
        // Grupo => "C2XX";
        public static string Grupo => "C212";
    }
    public class MultiSet<T> : IMultiSet<T>
    {
        public int Count { get{ return Count2(0, new List<T>());} }

        public MultiSet()
        {
           
        }
        public List<MultiSet<T>> sets = new List<MultiSet<T>>();
        public List<T> elements = new List<T>();

        public int Count2(int cuenta, List<T> counted){
             
            int contado = cuenta;
            
            foreach (var item in elements)
            {
                if(!counted.Contains(item)) 
                             counted.Add(item);
            }
            foreach (var item in sets)
            {
                item.Count2(contado, counted);
            }
            
            return counted.Count();

        }
        public void Add(T element)
        {
            if (elements.Contains(element)) throw new Exception("Elemento ya existe");

            else elements.Add(element);
        }

        public bool Contains(T element)
        {
            foreach (var item in elements)
            {
                if (object.Equals(item, element)) return true;
            }
            foreach (var item in sets)
            {
                return item.Contains(element);
            }
            return false;
        }

        public IMultiSet<T> CreateSubset()
        {
            MultiSet<T> set = new MultiSet<T>();
            sets.Add(set);
            return set;
        }

        public IEnumerable<T> Find(Predicate<T> filter)
        {
            foreach (var item in elements)
            {
                if (filter(item)) yield return item;
            }
            foreach (var item in sets)
            {
                foreach (var ele in item.Find(filter))
                {
                    yield return ele;


                }
            }
        }

            public IEnumerator<T> GetEnumerator()
            {
                return elements.GetEnumerator();
            }

            public void Remove(T item, int depth)
            {
                int count = 0;
                if (depth < double.Epsilon+1) return;

                foreach (var elem in elements)
                {
                    if (object.Equals(elem, item)) elements.Remove(elem);
                }

                foreach (var set in sets)
                {
                    set.Remove(item, depth - 1);
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
        {
               return elements.GetEnumerator();
            }
        }
    }