using UnityEngine;
using System.Collections;

public class ParallelBehavior : CompositeBehavior {
    // === Enumerations
    public enum Policy { Policy_Require_One, Policy_Require_All, Policy_MAX };

    // === Variables
    Policy m_eSuccessPolicy;
    Policy m_eFailurePolicy;

    // ===== Constructor ===== //
    public ParallelBehavior(Policy _successPolicy = Policy.Policy_Require_All, Policy _failurePolicy = Policy.Policy_Require_All, string _name = "Parallel Behavior") : base(_name)
    {
        m_eSuccessPolicy = _successPolicy;
        m_eFailurePolicy = _failurePolicy;
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

        uint successCount = 0, failureCount = 0;

        for (int i = 0; i < count; ++i) {
            m_eStatus = m_vChildren[i].Execute(_tick);

            // === Check the result against the Policy
            if (m_eStatus == BehaviorStatus.BS_Success && (m_eSuccessPolicy == Policy.Policy_Require_One || successCount == count)) {
                // === Success
                return m_eStatus;
            }
            else if (m_eStatus == BehaviorStatus.BS_Failure && (m_eFailurePolicy == Policy.Policy_Require_One || failureCount == count)) {
                // === Failure
                return m_eStatus;
            }
        }

        // === Must still be running
        return (m_eStatus = BehaviorStatus.BS_Running);
    }
    // ===================== //

    // ===== Properties ===== //
    public Policy SuccessPolicy {
        get { return m_eSuccessPolicy; }
        set { m_eSuccessPolicy = value; }
    }

    public Policy FailurePolicy {
        get { return m_eFailurePolicy; }
        set { m_eFailurePolicy = value; }
    }
    // ====================== //
}
