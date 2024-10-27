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
        /// Add element to collection in order that first added element is first in the list
        /// </summary>
        /// <param name="item"></param>
        public void AddBefore(T item)
        {
            var elementToAdd = new ListElement<T>();
            elementToAdd.Value = item;
            elementToAdd.Id = element == null ? elementToAdd.Id = 0 : elementToAdd.Id = element.Id - 1;
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
                element.Id = 0;
            }
            else
            {
                var elementToAdd = new ListElement<T>();
                var current = element;
                while (current.Element != null)
                {
                    current = current.Element;
                }
                elementToAdd.Value = item;
                elementToAdd.Id = current.Id + 1;
                current.Element = elementToAdd;
            }
        }

        /// <summary>
        /// Gets element at given id
        /// </summary>
        /// <param name="id">Id of searched element</param>
        /// <returns>Returns an element at given id</returns>
        public ListElement<T> GetElementOfId(int id)
        {
            var currentElement = element;
            while (currentElement != null)
            {
                if (currentElement.Id == id)
                {
                    return currentElement;
                }
                currentElement = currentElement.Element;
            }
            throw new IndexOutOfRangeException($"Index: {id} is out of range.");
        }

        /// <summary>
        /// Gets element at given index
        /// </summary>
        /// <param name="index">Index of searched element</param>
        /// <returns>Returns an element at given index</returns>
        public ListElement<T> GetElementAt(int index)
        {
            var currentElement = element;
            for (var i = 0; i < index; i++)
            {
                if (currentElement.Element == null)
                {
                    break;
                }
                currentElement = currentElement.Element;
            }

            if (currentElement != null)
            {
                return currentElement;
            }
            throw new IndexOutOfRangeException($"Index: {index} is out of range.");
        }

        /// <summary>
        /// Delete element at given index
        /// </summary>
        /// <param name="index">Index of searched element</param>
        public void DeleteElementAt(int index)
        {
            var indexer = 0;

            ListElement<T> current;
            if (index == 0)
            {
                current = element.Element;
                element = current;
                return;
            }
            
            current = element;
            while (current.Element != null)
            {
                if (indexer == (index - 1))
                {
                    current.Element = current.Element.Element;
                    indexer++;
                    return;
                }               
                current = current.Element;
                indexer++;
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
