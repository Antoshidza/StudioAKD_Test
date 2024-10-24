using System;
using System.Collections.Generic;
using UnityEngine;

namespace Source.Items
{
    public class ItemContainer : MonoBehaviour
    {
        private readonly HashSet<Item> _containedItems = new();
        private int _itemCount;

        public event Action<int> ItemCountChanged; 

        private void OnTriggerEnter(Collider other)
        {
            if (!other.transform.root.TryGetComponent<Item>(out var item) || !_containedItems.Add(item)) return;
            _itemCount++;
            ItemCountChanged?.Invoke(_itemCount);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.transform.root.TryGetComponent<Item>(out var item)) return;
            _containedItems.Remove(item);
            _itemCount--;
            ItemCountChanged?.Invoke(_itemCount);
        }
    }
}