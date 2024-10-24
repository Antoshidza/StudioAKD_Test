using UnityEngine;

namespace Source.Items
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        
        public string Name => name;
        public Rigidbody Rigidbody => _rigidbody;
    }
}