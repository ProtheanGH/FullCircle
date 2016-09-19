using UnityEngine;
using System.Collections;

// === Enumerations
public enum ComparisionTypes { LessThan, LessThanEqual, Equal, NotEqual, GreatThan, GreaterThanEqual };

public abstract class ComparisionBehavior : ConditionalBehavior {
    // === Variables
    ComparisionTypes m_eComparisionType;

    // ===== Constructor ===== //
    public ComparisionBehavior(ComparisionTypes _compareType = ComparisionTypes.Equal, string _name = "Comparision Behavior", BaseBehavior _child = null) : base(_name, _child)
    {
        m_eComparisionType = _compareType;
    }
    // ======================= //

    // ===== Protected Interface ===== //
    protected abstract bool CompareValueFromBlackBoard(BlackBoard _blackBoard);

    protected bool CompareInts(int _varValue, int _constVal)
    {
        switch (m_eComparisionType) {
            case ComparisionTypes.LessThanEqual:
                return (_varValue <= _constVal);
            case ComparisionTypes.LessThan:
                return (_varValue < _constVal);
            case ComparisionTypes.Equal:
                return (_varValue == _constVal);
            case ComparisionTypes.NotEqual:
                return (_varValue != _constVal);
            case ComparisionTypes.GreaterThanEqual:
                return (_varValue >= _constVal);
            case ComparisionTypes.GreatThan:
                return (_varValue > _constVal);
            default:
                return false;
        }
    }

    protected bool CompareLongs(long _varValue, long _constVal)
    {
        switch (m_eComparisionType) {
            case ComparisionTypes.LessThanEqual:
                return (_varValue <= _constVal);
            case ComparisionTypes.LessThan:
                return (_varValue < _constVal);
            case ComparisionTypes.Equal:
                return (_varValue == _constVal);
            case ComparisionTypes.NotEqual:
                return (_varValue != _constVal);
            case ComparisionTypes.GreaterThanEqual:
                return (_varValue >= _constVal);
            case ComparisionTypes.GreatThan:
                return (_varValue > _constVal);
            default:
                return false;
        }
    }

    protected bool CompareFloats(float _varValue, float _constVal)
    {
        switch (m_eComparisionType) {
            case ComparisionTypes.LessThanEqual:
                return (_varValue <= _constVal);
            case ComparisionTypes.LessThan:
                return (_varValue < _constVal);
            case ComparisionTypes.Equal:
                return (_varValue == _constVal);
            case ComparisionTypes.NotEqual:
                return (_varValue != _constVal);
            case ComparisionTypes.GreaterThanEqual:
                return (_varValue >= _constVal);
            case ComparisionTypes.GreatThan:
                return (_varValue > _constVal);
            default:
                return false;
        }
    }

    protected bool CompareStrings(string _varValue, string _constVal)
    {
        switch (m_eComparisionType) {
            case ComparisionTypes.Equal:
                return (_varValue == _constVal);
            case ComparisionTypes.NotEqual:
                return (_varValue != _constVal);
            default:
                return false;
        }
    }

    protected bool CompareBools(bool _varValue, bool _constVal)
    {
        switch (m_eComparisionType) {
            case ComparisionTypes.Equal:
                return (_varValue == _constVal);
            case ComparisionTypes.NotEqual:
                return (_varValue != _constVal);
            default:
                return false;
        }
    }

    protected bool CompareVector2s(Vector2 _varValue, Vector2 _constVal)
    {
        switch (m_eComparisionType) {
            case ComparisionTypes.Equal:
                return (_varValue == _constVal);
            case ComparisionTypes.NotEqual:
                return (_varValue != _constVal);
            default:
                return false;
        }
    }

    protected bool CompareVector3s(Vector3 _varValue, Vector3 _constVal)
    {
        switch (m_eComparisionType) {
            case ComparisionTypes.Equal:
                return (_varValue == _constVal);
            case ComparisionTypes.NotEqual:
                return (_varValue != _constVal);
            default:
                return false;
        }
    }

    protected bool CompareVector4s(Vector4 _varValue, Vector4 _constVal)
    {
        switch (m_eComparisionType) {
            case ComparisionTypes.Equal:
                return (_varValue == _constVal);
            case ComparisionTypes.NotEqual:
                return (_varValue != _constVal);
            default:
                return false;
        }
    }
    // =============================== //

    // ===== Mutators ===== //
    public void SetComparisionType(ComparisionTypes _type)
    {
        m_eComparisionType = _type;
    }
    // ==================== //
}
