using UnityEngine;
using System.Collections;

public abstract class ConditionalBehavior : DecoratorBehavior {
    // ===== Constructor ===== //
    public ConditionalBehavior(string _name = "Conditional Behavior", BaseBehavior _child = null) : base(_name, _child)
    {

    }
    // ======================= //

    // ===== Properties ===== //
    public override BehaviorTypes Type {
        get { return BehaviorTypes.BT_Conditional; }
    }
    // ====================== //
}
