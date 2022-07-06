using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace InventorySystem.Item
{
    public class TwoHandedSword : ItemBase
    {
        protected override void DealDamage()
        {
            Debug.Log("Pow! Pow!");
        }
    }
}
