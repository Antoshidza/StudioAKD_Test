using Source.Items;
using UnityEngine;

// can be optimized further by implementing spatial hashmap to efficiently skip items inaccessible from current chunk
public class InteractionManager : MonoBehaviour
{
    [SerializeField] private float _distanceThreshold = .5f;
    [SerializeField] private float _lookThreshold = .9f;
    [SerializeField] private Item[] _items;
    [SerializeField] private Camera _playerCamera;

    private Item _interactableItemThisFrame;

    private void Update() =>
        _interactableItemThisFrame = default;

    public bool TryGetInteractableItem(out Item interactableItem, in bool allowItemFromCache = true)
    {
        if (_interactableItemThisFrame && allowItemFromCache)
        {
            interactableItem = _interactableItemThisFrame;
            return true;
        }
        
        interactableItem = default;
        var playerTransform = _playerCamera.transform;
        var closestLook = -1f;
        
        foreach (var item in _items)
        {
            if (!(Vector3.Distance(playerTransform.position, item.transform.position) < _distanceThreshold)) continue;
            var look = Vector3.Dot((item.transform.position - playerTransform.position).normalized, playerTransform.forward);
            if (!(look > _lookThreshold) || !(look > closestLook)) continue;
            closestLook = look;
            interactableItem = item;
        }

        return interactableItem;
    }
}
