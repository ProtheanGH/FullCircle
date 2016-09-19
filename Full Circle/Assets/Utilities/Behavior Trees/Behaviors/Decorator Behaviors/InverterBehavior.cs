using UnityEngine;
using System.Collections;
using System;

public class InverterBehavior : DecoratorBehavior {
    // ===== Constructor ===== //
    public InverterBehavior(string _name = "Inverter Behavior", BaseBehavior _child = null) : base(_name, _child)
    {

    }
    // ======================= //

    // ===== Interface ===== //
    public override BehaviorStatus Execute(Tick _tick)
    {
        // === Error Checking
        if (m_ChildNode == null) {
            return (m_eStatus = BehaviorStatus.BS_Error);
        }

        // === Execute the ChildNode
        m_eStatus = m_ChildNode.Execute(_tick);

        // === Invert the resulting status
        if (m_eStatus == BehaviorStatus.BS_Failure) {
            return (m_eStatus = BehaviorStatus.BS_Success);
        }
        else if (m_eStatus == BehaviorStatus.BS_Success) {
            return (m_eStatus = BehaviorStatus.BS_Failure);
        }

        // === Result must either be 'Running' or 'Error', leave it as it is
        return m_eStatus;
    }
    // ===================== //
}
