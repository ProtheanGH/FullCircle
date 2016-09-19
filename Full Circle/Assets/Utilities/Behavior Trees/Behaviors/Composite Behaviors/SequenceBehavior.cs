using UnityEngine;
using System.Collections;
using System;

public class SequenceBehavior : CompositeBehavior {
    // ===== Constructor ===== //
    public SequenceBehavior(string _name = "Sequence Behavior") : base(_name)
    {

    }
    // ======================= //

    // ===== Interface ===== //
    public override BehaviorStatus Execute(Tick _tick)
    {
        int count = m_vChildren.Count;

        // === Error checking
        if (count == 0) {
            return (m_eStatus = BehaviorStatus.BS_Error);
        }

        for (int i = 0; i < count; ++i) {
            m_eStatus = m_vChildren[i].Execute(_tick);

            // === If the current child behavior wasn't a success, return
            if (m_eStatus != BehaviorStatus.BS_Success) {
                return m_eStatus;
            }
        }

        return m_eStatus;
    }
    // ===================== //
}
