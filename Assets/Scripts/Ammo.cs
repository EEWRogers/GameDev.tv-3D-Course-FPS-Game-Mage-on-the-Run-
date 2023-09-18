using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;
    
    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }
    public int GetAmmoAmount(AmmoType ammoType)
    {
        AmmoSlot ammoSlot = GetAmmoSlot(ammoType);
        return ammoSlot.ammoAmount;
    }

    public void ReduceAmmo(AmmoType ammoType)
    {
        AmmoSlot ammoSlot = GetAmmoSlot(ammoType);
        ammoSlot.ammoAmount--;
    }

    public void IncreaseAmmo(AmmoType ammoType, int ammoIncreaseQuantity)
    {
        AmmoSlot ammoSlot = GetAmmoSlot(ammoType);
        ammoSlot.ammoAmount += ammoIncreaseQuantity;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }

}
