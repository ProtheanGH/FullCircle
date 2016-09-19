using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// === Behavior Tree Types
public enum BehaviorTreeTypes { BTT_MAX };

public class BehaviorTreeManager {
    // === Variables
    Dictionary<BehaviorTreeTypes, BehaviorTree> m_dBehaviorTrees;

	// ===== Constructor ===== //
    public BehaviorTreeManager()
    {
        m_dBehaviorTrees = new Dictionary<BehaviorTreeTypes, BehaviorTree>();
    }
    // ======================= //

    // ===== Interface ===== //
    public void TickTree(BehaviorTreeTypes _tree, GameObject _owner, BlackBoard _blackBoard)
    {
        // === Find and Tick the desired Behavior Tree
        BehaviorTree bTree;
        if (m_dBehaviorTrees.TryGetValue(_tree, out bTree)) {
            bTree.Tick(_owner, _blackBoard);
        }
        else {
            // === Tree wasn't found, load it now
            LoadBehaviorTree(_tree);
        }
    }

    public void LoadBehaviorTree(BehaviorTreeTypes _treeType)
    {
        // === Has the Tree already been loaded? 
        if (m_dBehaviorTrees.ContainsKey(_treeType)) {
            return;
        }

        // === Create the desired tree
        switch (_treeType) {
            default:
                return;
        }
    }
    // ===================== //

    // ===== Tree Creation Functions ===== //

    // =================================== //
}
