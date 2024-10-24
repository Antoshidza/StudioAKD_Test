using TMPro;
using UnityEngine;

namespace Source.Items
{
    public class InteractionMarkerView : MonoBehaviour
    {
        [SerializeField] private Transform _markerRoot;
        [SerializeField] private TMP_Text _markerLabel;
        [SerializeField] private float _yOffset = .5f;
        [SerializeField] private InteractionManager _interactionManager;
        [SerializeField] private Transform _playerTransform;

        private void Start() => 
            _markerRoot.gameObject.SetActive(false);

        private void Update()
        {
            if (!_interactionManager.TryGetInteractableItem(out var item))
            {
                _markerRoot.gameObject.SetActive(false);
                return;
            }

            _markerRoot.gameObject.SetActive(true);
            _markerLabel.text = item.Name;
            _markerRoot.position = item.transform.position + new Vector3(0f, _yOffset, 0f);
            _markerRoot.LookAt(_playerTransform);
        }
    }
}