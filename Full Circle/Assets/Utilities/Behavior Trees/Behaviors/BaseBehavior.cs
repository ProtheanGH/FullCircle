using UnityEngine;
using System.Collections;

public abstract class BaseBehavior {
    // === Enumerations
    public enum BehaviorStatus { BS_Success, BS_Failure, BS_Running, BS_Error, BS_MAX };
    public enum BehaviorTypes { BT_Action, BT_Composite, BT_Sequence, BT_Selecter, BT_Decorator, BT_Conditional, BT_Rerouter, BT_MAX };

    // === Variables
    string m_sName;
    protected ushort m_usBehaviorUID;
    protected BehaviorStatus m_eStatus;

    // ===== Constructor ===== //
    public BaseBehavior(string _name)
    {
        m_sName = _name;
        m_usBehaviorUID = 0;
    }
    // ======================= //

    // ===== Interface ===== //
    /// <summary>
    /// Finializes the behaviors UID as well as initializing any of it's chilren to set their UIDs. Returns the last 
    /// used UID.
    /// ** Note, this function should only be called once by it's owning behavior tree, once the tree is fully built.
    /// </summary>
    /// <param name="_UID"></param>
    /// <returns></returns>
    abstract public ushort Finialize(ushort _UID);

    /// <summary>
    /// Runs the specific code related to this behavior, returning 'Success' if it completed it's task, 'Failure' if it could not complete it,
    /// 'Running' if it's still working on it, or 'Error' if something logically went wrong.
    /// </summary>
    /// <param name="_tick"></param>
    /// <returns></returns>
    abstract public BehaviorStatus Execute(Tick _tick);
    // ===================== //

    // ===== Properties ===== //
    public string Name {
        get { return m_sName; }
    }

    abstract public BehaviorTypes Type {
        get;
    }
    // ====================== //
}
