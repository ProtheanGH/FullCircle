using UnityEngine;
using System.Collections;
using System;

public abstract class ActionBehavior : BaseBehavior {
    // ===== Constructor ===== //
    public ActionBehavior(string _name) : base(_name)
    {

    }
    // ======================= //

    // ===== Interface ===== //
    public override ushort Finialize(ushort _UID)
    {
        return (m_usBehaviorUID = _UID);
    }
    // ===================== //

    // ===== Properties ===== //
    public override BehaviorTypes Type {
        get { return BehaviorTypes.BT_Action; }
    }
    // ====================== //
}
