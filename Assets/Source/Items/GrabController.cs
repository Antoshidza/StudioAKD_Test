using UnityEngine;

namespace Source.Items
{
    public class GrabController : MonoBehaviour
    {
        [SerializeField] private InteractionManager _interactionManager;
        [SerializeField] private Transform _playerCamera;
        [SerializeField] private float _holdDistance = .5f;
        [SerializeField] private float _holdStrength = 1f;

        private Item _grabbingItem;
        private bool _sourceUseGravity;
        private float _sourceDrag;

        private void Update()
        {
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                if (!_interactionManager.TryGetInteractableItem(out _grabbingItem)) return;
                _sourceUseGravity = _grabbingItem.Rigidbody.useGravity;
                _sourceDrag = _grabbingItem.Rigidbody.drag;
                _grabbingItem.Rigidbody.useGravity = false;
                _grabbingItem.Rigidbody.drag = 10;
            }
            else if (UnityEngine.Input.GetMouseButtonUp(0) && _grabbingItem)
            {
                _grabbingItem.Rigidbody.useGravity = _sourceUseGravity;
                _grabbingItem.Rigidbody.drag = _sourceDrag;
                _grabbingItem = default;
            }

        }

        private void FixedUpdate()
        {
            if(!_grabbingItem) return;
            
            var holdPoint = _playerCamera.position + _playerCamera.forward * _holdDistance;
            var direction = (holdPoint - _grabbingItem.transform.position).normalized;
            _grabbingItem.Rigidbody.AddForce(direction * (_holdStrength * Vector3.Distance(holdPoint, _grabbingItem.transform.position) * 2f));
        }
    }
}