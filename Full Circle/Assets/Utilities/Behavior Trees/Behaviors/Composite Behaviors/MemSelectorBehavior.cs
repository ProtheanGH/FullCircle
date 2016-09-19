using UnityEngine;
using System.Collections;

public class MemSelectorBehavior : CompositeBehavior {
    // ===== Constructor ===== //
    public MemSelectorBehavior(string _name = "Selector Behavior") : base(_name)
    {

    }
    // ======================= //

    // ===== Interface ===== //
    public override BehaviorStatus Execute(Tick _tick)
    {
        int count = m_vChildren.Count;

        // === Get the starting index
        int i = _tick.BlackBoard.GetInt(m_usBehaviorUID.ToString() + "_CurrentIndex");

        // === Error checking
        if (count == 0 || i >= count) {
            return (m_eStatus = BehaviorStatus.BS_Error);
        }

        for (; i < count; ++i) {
            m_eStatus = m_vChildren[i].Execute(_tick);

            // === If the current child behavior wasn't a success, return
            if (m_eStatus != BehaviorStatus.BS_Failure) {
                if (m_eStatus == BehaviorStatus.BS_Running) {
                    // == Current Child is still running, save out it's index
                    _tick.BlackBoard.SetInt(m_usBehaviorUID.ToString() + "_CurrentIndex", i);
                }
                else {
                    // == Current Child finished (Success), reset the index
                    _tick.BlackBoard.SetInt(m_usBehaviorUID.ToString() + "_CurrentIndex", 0);
                }

                return m_eStatus;
            }
        }

        // === Current Child finished (Failure or Error), reset the index
        _tick.BlackBoard.SetInt(m_usBehaviorUID.ToString() + "_CurrentIndex", 0);
        return m_eStatus;
    }
    // ===================== //
}
