using System.Collections;

namespace GenericListProject
{
    /// <summary>
    /// Generic list to work with collections
    /// </summary>
    public class GenericList<T> : IEnumerable<T> where T : class
    {
        /// <summary>
        /// An element of the collection
        /// </summary>
        private ListElement<T> element;

        /// <summary>
        /// Constractor for <see cref="GenericList"/>
        /// </summary>
        public GenericList()
        {
            // Nothing here so far
        }

        /// <summary>
        /// Add element to collection in order that first added element is first in the list
        /// </summary>
        /// <param name="item"></param>
        public void AddBefore(T item)
        {
            var elementToAdd = new ListElement<T>();
            elementToAdd.Value = item;
            elementToAdd.Element = element;
            element = elementToAdd;
        }

        /// <summary>
        /// Add element to collection
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            if (element == null)
            {
                element = new ListElement<T>();
                element.Value = item;
            }
            else
            {
                var elementToAdd = new ListElement<T>();
                elementToAdd.Value = item;
                var current = element;
                while (current.Element != null)
                {
                    current = current.Element;
                }
                current.Element = elementToAdd;
            }
        }

        /// <summary>
        /// Get all elements from the list
        /// </summary>
        /// <returns>A collection of all elements from the list</returns>
        public IEnumerable<T> GetAllElements()
        {
            var currentElement = element;
            while (currentElement != null)
            {
                var valueToReturn = currentElement.Value;
                currentElement = currentElement.Element;
                yield return valueToReturn;
            }
        }

        /// <summary>
        /// Returns an generic enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the collection.
        /// </returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            foreach (var element in GetAllElements())
            {
                yield return element;
            }
        }

        /// <summary>
        /// Returns an generic enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var element in GetAllElements())
            {
                yield return element;
            }
        }
    }
}
