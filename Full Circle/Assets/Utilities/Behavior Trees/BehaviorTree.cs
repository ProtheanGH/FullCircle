using UnityEngine;
using System.Collections;

public struct Tick {
    public GameObject Owner;
    public BehaviorTree BehaviorTree;
    public BlackBoard BlackBoard;

    public Tick(GameObject _owner, BehaviorTree _tree, BlackBoard _blackBoard)
    {
        Owner = _owner;
        BehaviorTree = _tree;
        BlackBoard = _blackBoard;
    }
}

public class BehaviorTree {
    // === Variables
    BaseBehavior m_RootNode;

	// ===== Constructor ===== //
    public BehaviorTree()
    {

    }
    // ======================= //

    // ===== Interface ===== //
    public void Finialize()
    {
        m_RootNode.Finialize(0);
    }

    public void Tick(GameObject _owner, BlackBoard _blackBoard)
    {
        Tick tick = new Tick(_owner, this, _blackBoard);

        // === Is there a Reroute Node set?
        RerouteBehavior reroute = _blackBoard.GetRerouteNode();
        if (reroute != null) {
            reroute.ReroutedExecute(tick);
        }
        else {
            m_RootNode.Execute(tick);
        }
    }
    // ===================== //

    // ===== Properties ===== //
    public BaseBehavior Root {
        set { m_RootNode = value; }
    }
    // ====================== //
}
