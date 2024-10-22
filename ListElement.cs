using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericListProject
{
    /// <summary>
    /// Element of the generic list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class ListElement<T> where T : class
    {
        /// <summary>
        /// An element of the collection
        /// </summary>
        public ListElement<T> Element { get; set; }

        /// <summary>
        /// A value of en element
        /// </summary>
        public T Value { get; set; }
    }
}
