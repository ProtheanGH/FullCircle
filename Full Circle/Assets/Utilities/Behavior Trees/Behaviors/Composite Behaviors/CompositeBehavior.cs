using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class CompositeBehavior : BaseBehavior {
    // === Variables
    protected List<BaseBehavior> m_vChildren = new List<BaseBehavior>();

    // ===== Constructor ===== //
    public CompositeBehavior(string _name = "Composite Behavior") : base(_name)
    {

    }
    // ======================= //

    // ===== Interface ===== //
    public override ushort Finialize(ushort _UID)
    {
        // === Set the UID
        m_usBehaviorUID = _UID;

        // === Finialize all the Children
        int count = m_vChildren.Count;
        for (int i = 0; i < count; ++i) {
            _UID = m_vChildren[i].Finialize(++_UID);
        }

        return _UID;
    }
    // ===================== //

    // ===== Mutators ===== //
    public void AddChild(BaseBehavior _child)
    {
        m_vChildren.Add(_child);
    }

    public void RemoveChild(BaseBehavior _child)
    {
        m_vChildren.Remove(_child);
    }
    // ==================== //

    // ===== Properties ===== //
    public override BehaviorTypes Type {
        get { return BehaviorTypes.BT_Composite; }
    }
    // ====================== //
}
