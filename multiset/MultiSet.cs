using System.Collections.Generic;


namespace MatCom.Exam
{
    public interface IMultiSet<T> : IEnumerable<T>
    {
        /// <summary>
        /// Cantidad de elementos total en el multi-conjunto, incluye elementos de subconjuntos
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Añade un elemento al multi-conjunto
        /// </summary>
        /// <param name="element">Elemento a añadir</param>
        void Add(T element);

        /// <summary>
        /// Determina si un elemento está en el multi-conjunto
        /// </summary>
        /// <param name="element">Elemento a Buscar</param>
        /// <returns>True si existe y False si no</returns>
        bool Contains(T element);

        /// <summary>
        /// Crea un nuevo multi-conjunto anidado
        /// </summary>
        /// <returns>El Subset creado</returns>
        IMultiSet<T> CreateSubset();

        /// <summary>
        /// Encuentra todos los elementos que cumplen con el filtro
        /// </summary>
        /// <param name="filter">Condicion que deben cumplir los elementos</param>
        /// <returns>Un IEnumerable de elementos segun filter</returns>
        IEnumerable<T> Find(Predicate<T> filter);

        /// <summary>
        /// Elimina una o más referencias de un elemento
        /// </summary>
        /// <param name="item">Elemento a eliminar</param>
        /// <param name="depth">Profundidad maxima valida para eliminar, en caso de ser negativa se considera infinita</param>
        void Remove(T item, int depth);
    }
}