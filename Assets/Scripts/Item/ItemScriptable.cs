using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem.Item
{
    [CreateAssetMenu(fileName = "Item", menuName = "Item/ItemBase", order = 1)]
    ///TODO: Incase of we'll going to add poiton or any another item types we can take heritage and use these fields and variables on that heritage.
    public class ItemScriptable : ScriptableObject 
    {
        public string ItemName;
        public int SlotCoverage;

        public ItemType[] CompetibleItemTypes;
        public SlotPriority[] SlotPriority;
    }
}
