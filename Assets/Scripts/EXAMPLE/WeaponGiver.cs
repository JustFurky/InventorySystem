using InventorySystem;
using InventorySystem.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGiver : MonoBehaviour
{
    //TODO: Could give items when Inventory instantiated.
    //This is just for availability of dynamic inventory system.
    private const float WeaponGiveTimer = 1.2f;
    private const int RandomItemCount = 3;



    private float _weaponGiverRemainingTime;
    private int _randomItemsCapacity; //To not calculate length of array every time.

    [SerializeField]
    private ItemBase[] _randomItemsToGive;

    [SerializeField]
    private Inventory _inventory;

    private void Start()
    {
        _weaponGiverRemainingTime = WeaponGiveTimer;

        _randomItemsCapacity = _randomItemsToGive.Length;
    }

    private void Update()
    {
        _weaponGiverRemainingTime -= Time.deltaTime;

        if(_weaponGiverRemainingTime < 0)
        {
            int selectedIndex = Random.Range(0, _randomItemsCapacity);
            GiveWeapon(_randomItemsToGive[selectedIndex]);

            _weaponGiverRemainingTime = WeaponGiveTimer;
        }
    }

    private void GiveWeapon(ItemBase itemBase)
    {
        _inventory.AddItem(itemBase);

        Debug.Log(itemBase.ItemScriptable.ItemName + " added.");
    }
}
