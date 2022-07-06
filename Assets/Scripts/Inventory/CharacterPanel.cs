using InventorySystem.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    public class CharacterPanel : MonoBehaviour
    {
        private const int EquipableItemCount = 2;

        [SerializeField]
        private Transform _leftHandSlot;

        [SerializeField]
        private Transform _rightHandSlot;

        [SerializeField]
        private ItemBase[] _equippedItems = new ItemBase[EquipableItemCount];

        private void Start()
        {
            _equippedItems = new ItemBase[EquipableItemCount];
        }

        public void EquipItem(ItemBase itemBase)
        {
            FillAvailableSlotWithItemBase(itemBase);
        }

        private void FillAvailableSlotWithItemBase(ItemBase itemBase)
        {
            if (GetEquippedItemsCoverageSlotCount() > 1) ClearEquippedHandItems(); //Incase of we fully equipped.

            SlotPriority[] itemSlotPriority = itemBase.ItemScriptable.SlotPriority;

            for(int i = 0; i < itemSlotPriority.Length;i++)
            {
                SlotPriority selectedSlotPriority = itemSlotPriority[i];

                int slotPriorityEquipIndex = GetEquipIndexofSlotPriority(selectedSlotPriority);

                if (_equippedItems[slotPriorityEquipIndex] == null)
                {
                    FillEquippedItemSlot(itemBase, i);

                    Transform targetSlotTransform = GetPrioritySlotTransform(selectedSlotPriority);
                    targetSlotTransform.GetComponentInChildren<Text>().text = itemBase.ItemScriptable.ItemName;
                    return;
                }
            }
        }

        private int GetEquippedItemsCoverageSlotCount()
        {
            int equippedItemsSlotCoverageSlotCount = 0;
            for (int i = 0; i < _equippedItems.Length; i++)
            {
                if (_equippedItems[i] == null) continue;
                var itemScriptable = _equippedItems[i].ItemScriptable;
                equippedItemsSlotCoverageSlotCount += itemScriptable.SlotCoverage;
            }

            return equippedItemsSlotCoverageSlotCount;
        }

        private void ClearEquippedHandItems()
        {
            int equippedItemsCount = _equippedItems.Length;

            for (int i = 0; i < equippedItemsCount; i++)
                _equippedItems[i] = null;

            _leftHandSlot.GetComponentInChildren<Text>().text = "Empty";
            _rightHandSlot.GetComponentInChildren<Text>().text = "Empty";
        }

        private Transform GetPrioritySlotTransform(SlotPriority slotPriority)
        {
            switch (slotPriority)
            {
                case SlotPriority.RightHand: return _rightHandSlot;
                case SlotPriority.LeftHand: return _leftHandSlot;
            }
            return null;
        }

        private void FillEquippedItemSlot(ItemBase itemBase, int index)
        {
            _equippedItems[index] = itemBase;
        }

        private int GetEquipIndexofSlotPriority(SlotPriority slotPriority)
        {
            return (int)slotPriority;
        }
    }
}
