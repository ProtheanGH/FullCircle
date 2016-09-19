using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class RerouteBehavior : DecoratorBehavior {
    // === Structures
    struct KeyTypePair {
        public string VariableID;
        public BlackBoard.DataTypes DataType;

        public KeyTypePair(string _varID, BlackBoard.DataTypes _type)
        {
            VariableID = _varID;
            DataType = _type;
        }
    }

    // === Variables
    List<KeyTypePair> m_vVariablesToWatchFor;
    BlackBoard.ValueWatchMode m_eWatchMode;

    // ===== Constructor ===== //
    public RerouteBehavior(BlackBoard.ValueWatchMode _watchType = BlackBoard.ValueWatchMode.VWM_Full_Watch, string _name = "Reroute Behavior", BaseBehavior _child = null) : base(_name, _child)
    {
        m_vVariablesToWatchFor = new List<KeyTypePair>();
        m_eWatchMode = _watchType;
    }
    // ======================= //

    // ===== Interface ===== //
    public override BehaviorStatus Execute(Tick _tick)
    {
        // === Set up the BlackBoard to reroute to this node
        _tick.BlackBoard.RemoveAllWatchedKeys();
        _tick.BlackBoard.SetRerouteNode(this);
        _tick.BlackBoard.SetWatchMode(m_eWatchMode);
        
        // === Set the Variable IDs, if we need to
        if (m_eWatchMode == BlackBoard.ValueWatchMode.VWM_Specified_Watch) {
            // === Error Check
            if (m_vVariablesToWatchFor.Count == 0) {
                return (m_eStatus = BehaviorStatus.BS_Error);
            }

            SetVariablesToWatchFor(_tick.BlackBoard);
        }

        // === Execute the Child Node
        return (m_eStatus = m_ChildNode.Execute(_tick));
    }

    public BehaviorStatus ReroutedExecute(Tick _tick)
    {
        // === Check if the BlackBoard has been alerted yet
        if (_tick.BlackBoard.ValuesUpdated()) {
            _tick.BlackBoard.RemoveAllWatchedKeys();
            return (m_eStatus = BehaviorStatus.BS_Failure);
        }

        // === Execute the Child Node
        return (m_eStatus = m_ChildNode.Execute(_tick));
    }
    // ===================== //

    // ===== Private Interface ===== //
    void SetVariablesToWatchFor(BlackBoard _blackBoard)
    {
        int count = m_vVariablesToWatchFor.Count;
        for (int i = 0; i < count; ++i) {
            switch (m_vVariablesToWatchFor[i].DataType) {
                case BlackBoard.DataTypes.Bool:
                    _blackBoard.AddBoolKeyForWatch(m_vVariablesToWatchFor[i].VariableID);
                    break;
                case BlackBoard.DataTypes.Float:
                    _blackBoard.AddFloatKeyForWatch(m_vVariablesToWatchFor[i].VariableID);
                    break;
                case BlackBoard.DataTypes.Int:
                    _blackBoard.AddIntKeyForWatch(m_vVariablesToWatchFor[i].VariableID);
                    break;
                case BlackBoard.DataTypes.Long:
                    _blackBoard.AddLongKeyForWatch(m_vVariablesToWatchFor[i].VariableID);
                    break;
                case BlackBoard.DataTypes.String:
                    _blackBoard.AddStringKeyForWatch(m_vVariablesToWatchFor[i].VariableID);
                    break;
                case BlackBoard.DataTypes.SystemObject:
                    _blackBoard.AddSystemObjectKeyForWatch(m_vVariablesToWatchFor[i].VariableID);
                    break;
                case BlackBoard.DataTypes.UnityObject:
                    _blackBoard.AddObjectKeyForWatch(m_vVariablesToWatchFor[i].VariableID);
                    break;
                case BlackBoard.DataTypes.Vector2:
                    _blackBoard.AddVector2KeyForWatch(m_vVariablesToWatchFor[i].VariableID);
                    break;
                case BlackBoard.DataTypes.Vector3:
                    _blackBoard.AddVector3KeyForWatch(m_vVariablesToWatchFor[i].VariableID);
                    break;
                case BlackBoard.DataTypes.Vector4:
                    _blackBoard.AddVector4KeyForWatch(m_vVariablesToWatchFor[i].VariableID);
                    break;
            }
        }
    }
    // ============================= //

    // ===== Mutators ===== //
    public void AddVariableForWatch(string _varID, BlackBoard.DataTypes _dataType)
    {
        KeyTypePair newKTPair = new KeyTypePair(_varID, _dataType);
        m_vVariablesToWatchFor.Add(newKTPair);
    }
    // ==================== //
}
