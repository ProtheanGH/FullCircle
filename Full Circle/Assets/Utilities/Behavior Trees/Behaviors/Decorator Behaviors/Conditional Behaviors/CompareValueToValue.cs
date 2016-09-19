using UnityEngine;
using System.Collections;
using System;

public class CompareValueToValue<type> : ComparisionBehavior {
    // === Variables
    string m_sLeftVariableID;
    string m_sRightVariableID;

    // ===== Constructor ===== //
    public CompareValueToValue(string _leftVarID = "", string _rightVarID = "", ComparisionTypes _compareType = ComparisionTypes.Equal, string _name = "Value - Value Comparision", BaseBehavior _child = null) : base(_compareType, _name, _child)
    {
        m_sLeftVariableID = _leftVarID;
        m_sRightVariableID = _rightVarID;
    }
    // ======================= //

    // ===== Interface ===== //
    public override BehaviorStatus Execute(Tick _tick)
    {
        // === Error checking
        if (m_sLeftVariableID == "" || m_sRightVariableID == "") {
            return (m_eStatus = BehaviorStatus.BS_Error);
        }

        // === Run the Comparision
        bool result = CompareValueFromBlackBoard(_tick.BlackBoard);

        if (m_ChildNode != null && result) {
            // == Execute the ChildNode
            return (m_eStatus = m_ChildNode.Execute(_tick));
        }

        // === Comparision returned as false, or there's no ChildNode, return the converted result
        return (m_eStatus = (result == true ? BehaviorStatus.BS_Success : BehaviorStatus.BS_Failure));
    }
    // ===================== //

    // ===== Protected Interface ===== //
    protected override bool CompareValueFromBlackBoard(BlackBoard _blackBoard)
    {
        if (typeof(type) == typeof(int) || typeof(type) == typeof(uint)) {
            // === Int 
            int leftValue = 0, rightValue = 0;
            if (_blackBoard.TryGetInt(m_sLeftVariableID, out leftValue) && _blackBoard.TryGetInt(m_sRightVariableID, out rightValue)) {
                return CompareInts(leftValue, rightValue);
            }
        }
        else if (typeof(type) == typeof(long) || typeof(type) == typeof(ulong)) {
            // === Long
            long leftValue = 0L, rightValue = 0L;
            if (_blackBoard.TryGetLong(m_sLeftVariableID, out leftValue) && _blackBoard.TryGetLong(m_sRightVariableID, out rightValue)) {
                return CompareLongs(leftValue, rightValue);
            }
        }
        else if (typeof(type) == typeof(float) || typeof(type) == typeof(double)) {
            // === Float
            float leftValue = 0.0f, rightValue = 0.0f;
            if (_blackBoard.TryGetFloat(m_sLeftVariableID, out leftValue) && _blackBoard.TryGetFloat(m_sRightVariableID, out rightValue)) {
                return CompareFloats(leftValue, rightValue);
            }
        }
        else if (typeof(type) == typeof(string)) {
            // === String
            string leftValue = "", rightValue = "";
            if (_blackBoard.TryGetString(m_sLeftVariableID, out leftValue) && _blackBoard.TryGetString(m_sRightVariableID, out rightValue)) {
                return CompareStrings(leftValue, rightValue);
            }
        }
        else if (typeof(type) == typeof(bool)) {
            // === Bool
            bool leftValue = false, rightValue = false;
            if (_blackBoard.TryGetBool(m_sLeftVariableID, out leftValue) && _blackBoard.TryGetBool(m_sRightVariableID, out rightValue)) {
                return CompareBools(leftValue, rightValue);
            }
        }
        else if (typeof(type) == typeof(Vector2)) {
            // === Vector2
            Vector2 leftValue, rightValue;
            if (_blackBoard.TryGetVector2(m_sLeftVariableID, out leftValue) && _blackBoard.TryGetVector2(m_sRightVariableID, out rightValue)) {
                return CompareVector2s(leftValue, rightValue);
            }
        }
        else if (typeof(type) == typeof(Vector3)) {
            // === Vector3
            Vector3 leftValue, rightValue;
            if (_blackBoard.TryGetVector3(m_sLeftVariableID, out leftValue) && _blackBoard.TryGetVector3(m_sRightVariableID, out rightValue)) {
                return CompareVector3s(leftValue, rightValue);
            }
        }
        else if (typeof(type) == typeof(Vector4)) {
            // === Vector4
            Vector4 leftValue, rightValue;
            if (_blackBoard.TryGetVector4(m_sLeftVariableID, out leftValue) && _blackBoard.TryGetVector4(m_sRightVariableID, out rightValue)) {
                return CompareVector4s(leftValue, rightValue);
            }
        }

        // === Either wrong type, or the Variable wasn't found
        return false;
    }
    // =============================== //

    // ===== Mutators ===== //
    public void SetLeftVariableID(string _varID)
    {
        m_sLeftVariableID = _varID;
    }

    public void SetRightVariableID(string _varID)
    {
        m_sRightVariableID = _varID;
    }
    // ==================== //
}
