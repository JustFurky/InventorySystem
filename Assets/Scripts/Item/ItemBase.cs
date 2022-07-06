using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace InventorySystem.Item
{
    public class ItemBase : MonoBehaviour
    {
        [SerializeField]
        protected ItemScriptable _itemScriptable;

        public ItemScriptable ItemScriptable { get { return _itemScriptable; }}

        protected virtual void DealDamage()
        {
            Debug.Log($"{_itemScriptable.ItemName} executed.");
        }
    }
}
