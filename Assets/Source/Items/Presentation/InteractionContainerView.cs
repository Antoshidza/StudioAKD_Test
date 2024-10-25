using TMPro;
using UnityEngine;

namespace Source.Items
{
    public class InteractionContainerView : MonoBehaviour
    {
        [SerializeField] private int _neededWeaponCount;
        [SerializeField] private Transform _labelRoot;
        [SerializeField] private Transform _playerCamera;
        [SerializeField] private TMP_Text _label;
        [SerializeField] private ItemContainer _itemContainer;

        private void Start()
        {
            SetLabel(0);
            _itemContainer.ItemCountChanged += SetLabel;
        }

        private void Update() =>
            _labelRoot.LookAt(_playerCamera);

        private void SetLabel(int itemCount) =>
            _label.text = itemCount >= _neededWeaponCount
                ? "Well done!"
                : $"John Riccitiello is about to make some shit again.\nStop him. Pick weapon!\n{itemCount} / {_neededWeaponCount}";
    }
}