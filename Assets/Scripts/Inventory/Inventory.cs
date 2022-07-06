using InventorySystem.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        /// <summary>
        /// Inventory slots capacity.
        /// <br/><br/>
        /// Additional: Could be converted to the non-const variable.
        /// </summary>
        private const byte InventorySlots = 20;

        [SerializeField]
        private GameObject _itemSlot;

        [SerializeField]
        private Transform _inventoryPanel;

        [SerializeField]
        private CharacterPanel _characterPanel;

        private ItemBase[] _containedItems = new ItemBase[InventorySlots];
        private Transform[] _itemSlots = new Transform[InventorySlots]; //To avoid from find childs.


        private GameObject _lastSelectedEquipButton;
        private void Start()
        {
            UpdateSlots();
        }

        public void AddItem(ItemBase itemBase)
        {
            int emptySlotIndex = GetEmptySlotIndex();

            if (emptySlotIndex == -1) return;

            _containedItems[emptySlotIndex] = itemBase;

            Transform selectedItemSlot = _itemSlots[emptySlotIndex];

            //For optimization could be done from adding script to the ItemSlot and controling datas in that way.
            selectedItemSlot.GetComponentInChildren<Text>().text = itemBase.ItemScriptable.ItemName;
            selectedItemSlot.GetComponent<Button>().onClick.AddListener(() => EnableEquipButtonOnSlot(selectedItemSlot));
            selectedItemSlot.GetChild(1).GetComponent<Button>().onClick.AddListener(() => EquipItem(itemBase)); ;
        }

        private void UpdateSlots()
        {
            if (_inventoryPanel.childCount == InventorySlots) return;


            for(int i = 0; i < InventorySlots; i++)
            {
                _itemSlots[i] = Instantiate(_itemSlot, _inventoryPanel).transform;
            }
        }

        private void EnableEquipButtonOnSlot(Transform equipButtonTransform)
        {
            Debug.Log(equipButtonTransform.GetChild(1));
            GameObject selectedButtonChild = equipButtonTransform.GetChild(1).gameObject;

            selectedButtonChild.SetActive(true);

            if (_lastSelectedEquipButton != null)
                _lastSelectedEquipButton.SetActive(false);

            _lastSelectedEquipButton = selectedButtonChild;
        }

        private void EquipItem(ItemBase itemBase)
        {
            Debug.Log(itemBase.ItemScriptable.ItemName + " equipped.");
            _characterPanel.EquipItem(itemBase);
        }

        private int GetEmptySlotIndex()
        {
            for(int i = 0; i < InventorySlots; i++)
            {
                ItemBase selectedSlot = _containedItems[i];

                if (selectedSlot == null)
                    return i;
            }

            return -1;
        }

        private void RemoveItem()
        {
            //Incase of adding remove item.
        }

        private void DropItem()
        {

        }
    }
}
