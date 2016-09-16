using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttachmentSlots : MonoBehaviour
{
    public Dictionary<string, Transform> AttachSlots;

    void FindAllSlots()
    {
        AttachSlots = new Dictionary<string, Transform>();

        Slot[] slots = GetComponentsInChildren<Slot>();
        for (int slot = 0; slot < slots.Length; slot++)
        {
            AttachSlots.Add(slots[slot].SlotName, slots[slot].transform);
        }
    }

    public Transform GetSlot(string slotName)
    {
        return AttachSlots[slotName];
    }

    void Start()
    {
        FindAllSlots();
    }
}
