using UnityEngine;
using System.Collections;
using System;

public class BlackBoardHasKey<type> : ConditionalBehavior {
    // === Variables
    string m_sVariableID;

    // ===== Constructor ===== //
    public BlackBoardHasKey(string _varID = "", string _name = "Has Key Conditional", BaseBehavior _child = null) : base (_name, _child)
    {
        m_sVariableID = _varID;
    }
    // ======================= //

    // ===== Interface ===== //
    public override BehaviorStatus Execute(Tick _tick)
    {
        // === Error Checking
        if (m_sVariableID == "") {
            return (m_eStatus = BehaviorStatus.BS_Error);
        }

        // === Check for the key
        bool result = HasKey(_tick.BlackBoard);
        if (m_ChildNode != null && result) {
            // === Execute the ChildNode
            return (m_eStatus = m_ChildNode.Execute(_tick));
        }

        // === No key of the desired ID was found, or there's no child, return the converted result
        return (result == true ? BehaviorStatus.BS_Success : BehaviorStatus.BS_Failure);
    }
    // ===================== //

    // ===== Private Interface ===== //
    bool HasKey(BlackBoard _blackBoard)
    {
        if (typeof(type) == typeof(int) || typeof(type) == typeof(uint)) {
            // === Int
            return _blackBoard.HasInt(m_sVariableID);
        }
        else if (typeof(type) == typeof(long) || typeof(type) == typeof(ulong)) {
            // === Long
            return _blackBoard.HasLong(m_sVariableID);
        }
        else if (typeof(type) == typeof(float) || typeof(type) == typeof(double)) {
            // === Float
            return _blackBoard.HasFloat(m_sVariableID);
        }
        else if (typeof(type) == typeof(string)) {
            // === String
            return _blackBoard.HasString(m_sVariableID);
        }
        else if (typeof(type) == typeof(bool)) {
            // === Bool
            return _blackBoard.HasBool(m_sVariableID);
        }
        else if (typeof(type) == typeof(Vector2)) {
            // === Vector2
            return _blackBoard.HasVector2(m_sVariableID);
        }
        else if (typeof(type) == typeof(Vector3)) {
            // === Vector3
            return _blackBoard.HasVector3(m_sVariableID);
        }
        else if (typeof(type) == typeof(Vector4)) {
            // === Vector4
            return _blackBoard.HasVector4(m_sVariableID);
        }
        else if (IsSubClassOfUnityObject()) {
            // === Unity Object
            return _blackBoard.HasObject(m_sVariableID);
        }
        else {
            // === Either Object type or other type, look for the key in the Object Section
            return _blackBoard.HasSystemObject(m_sVariableID);
        }
    }
    // ============================= //

    // ===== Private Interface ===== //
    bool IsSubClassOfUnityObject()
    {
        Type toCheck = typeof(type);

        while (toCheck != null && toCheck != typeof(object)) {
            Type currType = (toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck);
            if (currType == typeof(UnityEngine.Object)) {
                return true;
            }

            toCheck = toCheck.BaseType;
        }

        return false;
    }
    // ============================= //

    // ===== Mutators ===== //
    public void SetVariableID(string _varID)
    {
        m_sVariableID = _varID;
    }
    // ==================== //
}
