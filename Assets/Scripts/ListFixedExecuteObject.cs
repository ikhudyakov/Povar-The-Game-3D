﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace povar3d {
    public sealed class ListFixedExecuteObject : IEnumerator, IEnumerable
    {
        private List<IFixedExecute> _interactiveObjects;
        private int _index = -1;

        public void AddExecuteObject(IFixedExecute execute)
        {
            if (_interactiveObjects == null)
            {
                _interactiveObjects = new List<IFixedExecute> { execute };
                return;
            }
            _interactiveObjects.Add(execute);
        }

        public void AddExecuteObjects(IFixedExecute[] execute)
        {
            foreach (var item in execute)
            {
                AddExecuteObject(item);
            }
        }

        public void DeleteExecuteObject(IFixedExecute execute)
        {
            _interactiveObjects.Remove(execute);
        }

        public IFixedExecute this[int index]
        {
            get => _interactiveObjects[index];
            private set => _interactiveObjects[index] = value;
        }

        public int Length => _interactiveObjects.Count;

        public bool MoveNext()
        {
            if (_index == _interactiveObjects.Count - 1)
            {
                Reset();
                return false;
            }

            _index++;
            return true;
        }

        public void Reset() => _index = -1;

        public object Current => _interactiveObjects[_index];

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
