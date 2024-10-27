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
    public class ListElement<T> where T : class
    {
        //TODO might not need an index and just dynamic indexing
        /// <summary>
        /// An Id of an element
        /// </summary>
        public int Id { get; set; }

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
