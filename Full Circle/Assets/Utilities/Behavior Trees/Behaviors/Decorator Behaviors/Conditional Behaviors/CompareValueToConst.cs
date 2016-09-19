using UnityEngine;
using System.Collections;

public class CompareValueToConst<type> : ComparisionBehavior {
    // === Variables
    string m_sVariableID;
    type m_tConstValue;

    // ===== Constructor ===== //
    public CompareValueToConst(string _varID = "", type _constVal = default(type), ComparisionTypes _compareType = ComparisionTypes.Equal, string _name = "Value - Const Comparision", BaseBehavior _child = null) : base(_compareType, _name, _child)
    {
        m_sVariableID = _varID;
        m_tConstValue = _constVal;
    }
    // ======================= //

    // ===== Interface ===== //
    public override BehaviorStatus Execute(Tick _tick)
    {
        // === Error checking
        if (m_sVariableID == "") {
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
            int foundValue = 0;
            if (_blackBoard.TryGetInt(m_sVariableID, out foundValue)) {
                return CompareInts(foundValue, System.Convert.ToInt32(m_tConstValue));
            }
        }
        else if (typeof(type) == typeof(long) || typeof(type) == typeof(ulong)) {
            // === Long
            long foundValue = 0L;
            if (_blackBoard.TryGetLong(m_sVariableID, out foundValue)) {
                return CompareLongs(foundValue, System.Convert.ToInt64(m_tConstValue));
            }
        }
        else if (typeof(type) == typeof(float) || typeof(type) == typeof(double)) {
            // === Float
            float foundValue = 0.0f;
            if (_blackBoard.TryGetFloat(m_sVariableID, out foundValue)) {
                return CompareFloats(foundValue, (float)System.Convert.ToDouble(m_tConstValue));
            }
        }
        else if (typeof(type) == typeof(string)) {
            // === String
            string foundValue = "";
            if (_blackBoard.TryGetString(m_sVariableID, out foundValue)) {
                return CompareStrings(foundValue, System.Convert.ToString(m_tConstValue));
            }
        }
        else if (typeof(type) == typeof(bool)) {
            // === Bool
            bool foundValue = false;
            if (_blackBoard.TryGetBool(m_sVariableID, out foundValue)) {
                return CompareBools(foundValue, System.Convert.ToBoolean(m_tConstValue));
            }
        }
        else if (typeof(type) == typeof(Vector2)) {
            // === Vector2
            Vector2 foundValue;
            if (_blackBoard.TryGetVector2(m_sVariableID, out foundValue)) {
                return CompareVector2s(foundValue, (Vector2)System.Convert.ChangeType(m_tConstValue, typeof(Vector2)));
            }
        }
        else if (typeof(type) == typeof(Vector3)) {
            // === Vector3
            Vector3 foundValue;
            if (_blackBoard.TryGetVector3(m_sVariableID, out foundValue)) {
                return CompareVector3s(foundValue, (Vector3)System.Convert.ChangeType(m_tConstValue, typeof(Vector3)));
            }
        }
        else if (typeof(type) == typeof(Vector4)) {
            // === Vector4
            Vector4 foundValue;
            if (_blackBoard.TryGetVector4(m_sVariableID, out foundValue)) {
                return CompareVector4s(foundValue, (Vector4)System.Convert.ChangeType(m_tConstValue, typeof(Vector4)));
            }
        }

        // === Either wrong type, or the Variable wasn't found
        return false;
    }
    // =============================== //

    // ===== Mutators ===== //
    public void SetVariableID(string _varID)
    {
        m_sVariableID = _varID;
    }

    public void SetConstValue(type _constVal)
    {
        m_tConstValue = _constVal;
    }
    // ==================== //
}