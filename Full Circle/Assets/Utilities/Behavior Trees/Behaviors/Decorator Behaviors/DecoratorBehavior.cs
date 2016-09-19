using UnityEngine;
using System.Collections;
using System;

public abstract class DecoratorBehavior : BaseBehavior {
    // === Variables
    protected BaseBehavior m_ChildNode;

    // ===== Constructor ===== //
    public DecoratorBehavior(string _name = "Decorator Behavior", BaseBehavior _child = null) : base(_name)
    {
        m_ChildNode = _child;
    }
    // ======================= //

    // ===== Interface ===== //
    public override ushort Finialize(ushort _UID)
    {
        // === Set the UID
        m_usBehaviorUID = _UID;

        // === Finialize the ChildNode
        if (m_ChildNode != null) {
            _UID = m_ChildNode.Finialize(++_UID);
        }

        return _UID;
    }
    // ===================== //

    // ===== Properties ===== //
    public override BehaviorTypes Type {
        get { return BehaviorTypes.BT_Decorator; }
    }

    public BaseBehavior Child {
        set { m_ChildNode = value; }
    }
    // ====================== //
}
