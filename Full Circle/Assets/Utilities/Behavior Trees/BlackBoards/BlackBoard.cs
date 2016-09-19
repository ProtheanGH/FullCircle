using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlackBoard {
    // === Enumerations 
    public enum DataTypes { Bool, Int, Long, Float, String, Vector2, Vector3, Vector4, UnityObject, SystemObject };
    public enum ValueWatchMode { VWM_No_Watch, VWM_Specified_Watch, VWM_Full_Watch };

    // === Variables
    Dictionary<string, bool> m_dBoolValues;
    Dictionary<string, int> m_dIntValues;
    Dictionary<string, long> m_dLongValues;
    Dictionary<string, float> m_dFloatValues;
    Dictionary<string, string> m_dStringValues;
    Dictionary<string, Vector2> m_dVector2Values;
    Dictionary<string, Vector3> m_dVector3Values;
    Dictionary<string, Vector4> m_dVector4Values;
    Dictionary<string, UnityEngine.Object> m_dUnityObjectValues;
    Dictionary<string, object> m_dSystemObjectValues;
    List<string> m_vWatchedBoolKeys;
    List<string> m_vWatchedIntKeys;
    List<string> m_vWatchedLongKeys;
    List<string> m_vWatchedFloatKeys;
    List<string> m_vWatchedStringKeys;
    List<string> m_vWatchedVector2Keys;
    List<string> m_vWatchedVector3Keys;
    List<string> m_vWatchedVector4Keys;
    List<string> m_vWatchedUnityObjectKeys;
    List<string> m_vWatchedSystemObjectKeys;
    RerouteBehavior m_RerouteNode;
    ValueWatchMode m_eWatchMode;
    bool m_bValueUpdated;

    // ===== Constructor ===== //
    public BlackBoard()
    {
        // === Variable Storage
        m_dIntValues = new Dictionary<string, int>();
        m_dLongValues = new Dictionary<string, long>();
        m_dFloatValues = new Dictionary<string, float>();
        m_dBoolValues = new Dictionary<string, bool>();
        m_dStringValues = new Dictionary<string, string>();
        m_dVector2Values = new Dictionary<string, Vector2>();
        m_dVector3Values = new Dictionary<string, Vector3>();
        m_dVector4Values = new Dictionary<string, Vector4>();
        m_dUnityObjectValues = new Dictionary<string, UnityEngine.Object>();
        m_dSystemObjectValues = new Dictionary<string, object>();
        
        // === Watched Variable Keys
        m_vWatchedBoolKeys = new List<string>();
        m_vWatchedIntKeys = new List<string>();
        m_vWatchedLongKeys = new List<string>();
        m_vWatchedFloatKeys = new List<string>();
        m_vWatchedStringKeys = new List<string>();
        m_vWatchedVector2Keys = new List<string>();
        m_vWatchedVector3Keys = new List<string>();
        m_vWatchedVector4Keys = new List<string>();
        m_vWatchedUnityObjectKeys = new List<string>();
        m_vWatchedSystemObjectKeys = new List<string>();

        // === Watch Mode
        m_RerouteNode = null;
        m_eWatchMode = ValueWatchMode.VWM_No_Watch;
        m_bValueUpdated = false;
    }
    // ======================= //

    // ===== Private Interface ===== //
    bool CheckIfWatched(DataTypes _type, ref string _varID)
    {
        switch (m_eWatchMode) {
            case ValueWatchMode.VWM_Full_Watch:
                return true;
            case ValueWatchMode.VWM_No_Watch:
                return false;
            case ValueWatchMode.VWM_Specified_Watch:
                switch (_type) {
                    case DataTypes.Bool:
                        if (m_vWatchedBoolKeys.Contains(_varID)) {
                            return true;
                        }
                        return false;
                    case DataTypes.Float:
                        if (m_vWatchedFloatKeys.Contains(_varID)) {
                            return true;
                        }
                        return false;
                    case DataTypes.Int:
                        if (m_vWatchedIntKeys.Contains(_varID)) {
                            return true;
                        }
                        return false;
                    case DataTypes.Long:
                        if (m_vWatchedLongKeys.Contains(_varID)) {
                            return true;
                        }
                        return false;
                    case DataTypes.String:
                        if (m_vWatchedStringKeys.Contains(_varID)) {
                            return true;
                        }
                        return false;
                    case DataTypes.SystemObject:
                        if (m_vWatchedSystemObjectKeys.Contains(_varID)) {
                            return true;
                        }
                        return false;
                    case DataTypes.UnityObject:
                        if (m_vWatchedUnityObjectKeys.Contains(_varID)) {
                            return true;
                        }
                        return false;
                    case DataTypes.Vector2:
                        if (m_vWatchedVector2Keys.Contains(_varID)) {
                            return true;
                        }
                        return false;
                    case DataTypes.Vector3:
                        if (m_vWatchedVector3Keys.Contains(_varID)) {
                            return true;
                        }
                        return false;
                    case DataTypes.Vector4:
                        if (m_vWatchedVector4Keys.Contains(_varID)) {
                            return true;
                        }
                        return false;
                    default:
                        return false;
                }
            default:
                return false;
        }
    }
    // ============================= //

    // ===== Mutators ===== //
    /// <summary>
    /// Removes bool Key-Value pair from the BlackBoard.
    /// </summary>
    /// <param name="_valueID"></param>
    public void ClearBool(string _valueID)
    {
        m_dBoolValues.Remove(_valueID);
    }

    /// <summary>
    /// Removes int Key-Value pair from the BlackBoard.
    /// </summary>
    /// <param name="_valueID"></param>
    public void ClearInt(string _valueID)
    {
        m_dIntValues.Remove(_valueID);
    }

    /// <summary>
    /// Removes long Key-Value pair from the BlackBoard.
    /// </summary>
    /// <param name="_valueID"></param>
    public void ClearLong(string _valueID)
    {
        m_dLongValues.Remove(_valueID);
    }

    /// <summary>
    /// Removes float Key-Value pair from the BlackBoard.
    /// </summary>
    /// <param name="_valueID"></param>
    public void ClearFloat(string _valueID)
    {
        m_dFloatValues.Remove(_valueID);
    }

    /// <summary>
    /// Removes string Key-Value pair from the BlackBoard.
    /// </summary>
    /// <param name="_valueID"></param>
    public void ClearString(string _valueID)
    {
        m_dStringValues.Remove(_valueID);
    }

    /// <summary>
    /// Removes Vector2 Key-Value pair from the BlackBoard.
    /// </summary>
    /// <param name="_valueID"></param>
    public void ClearVector2(string _valueID)
    {
        m_dVector2Values.Remove(_valueID);
    }

    /// <summary>
    /// Removes Vector3 Key-Value pair from the BlackBoard.
    /// </summary>
    /// <param name="_valueID"></param>
    public void ClearVector3(string _valueID)
    {
        m_dVector3Values.Remove(_valueID);
    }

    /// <summary>
    /// Removes Vector4 Key-Value pair from the BlackBoard.
    /// </summary>
    /// <param name="_valueID"></param>
    public void ClearVector4(string _valueID)
    {
        m_dVector4Values.Remove(_valueID);
    }

    /// <summary>
    /// Removes Object Key-Value pair from the BlackBoard.
    /// </summary>
    /// <param name="_valueID"></param>
    public void ClearObject(string _valueID)
    {
        m_dUnityObjectValues.Remove(_valueID);
    }

    /// <summary>
    /// Removes System Object Key-Value pair from the BlackBoard.
    /// </summary>
    /// <param name="_valueID"></param>
    public void ClearSystemObject(string _valueID)
    {
        m_dSystemObjectValues.Remove(_valueID);
    }

    /// <summary>
    /// Sets the given bool with the given ID. If the key doesn't exist, it will add it to the BlackBoard,
    /// else it will just update the the value of the key.
    /// </summary>
    /// <param name="_valueID"></param>
    /// <param name="_value"></param>
    public void SetBool(string _valueID, bool _value)
    {
        // === Does this value need to alert that it's been updated?
        bool watched = CheckIfWatched(DataTypes.Bool, ref _valueID);

        if (m_dBoolValues.ContainsKey(_valueID)) {
            if (watched && m_dBoolValues[_valueID] != _value) {
                // === Only Alert that it's been updated if the values are different
                m_bValueUpdated = true;
            }

            m_dBoolValues[_valueID] = _value;
        }
        else {
            m_dBoolValues.Add(_valueID, _value);

            if (watched) {
                // === Alert, since it's a new value.
                m_bValueUpdated = true;
            }
        }
    }

    /// <summary>
    /// Sets the given int with the given ID. If the key doesn't exist, it will add it to the BlackBoard,
    /// else it will just update the the value of the key.
    /// </summary>
    /// <param name="_valueID"></param>
    /// <param name="_value"></param>
    public void SetInt(string _valueID, int _value)
    {
        // === Does this value need to alert that it's been updated?
        bool watched = CheckIfWatched(DataTypes.Int, ref _valueID);

        if (m_dIntValues.ContainsKey(_valueID)) {
            if (watched && m_dIntValues[_valueID] != _value) {
                // === Only Alert that it's been updated if the values are different
                m_bValueUpdated = true;
            }

            m_dIntValues[_valueID] = _value;
        }
        else {
            m_dIntValues.Add(_valueID, _value);

            if (watched) {
                // === Alert, since it's a new value.
                m_bValueUpdated = true;
            }
        }
    }

    /// <summary>
    /// Sets the given long with the given ID. If the key doesn't exist, it will add it to the BlackBoard,
    /// else it will just update the the value of the key.
    /// </summary>
    /// <param name="_valueID"></param>
    /// <param name="_value"></param>
    public void SetLong(string _valueID, long _value)
    {
        // === Does this value need to alert that it's been updated?
        bool watched = CheckIfWatched(DataTypes.Long, ref _valueID);

        if (m_dLongValues.ContainsKey(_valueID)) {
            if (watched && m_dLongValues[_valueID] != _value) {
                // === Only Alert that it's been updated if the values are different
                m_bValueUpdated = true;
            }

            m_dLongValues[_valueID] = _value;
        }
        else {
            m_dLongValues.Add(_valueID, _value);

            if (watched) {
                // === Alert, since it's a new value.
                m_bValueUpdated = true;
            }
        }
    }

    /// <summary>
    /// Sets the given float with the given ID. If the key doesn't exist, it will add it to the BlackBoard,
    /// else it will just update the the value of the key.
    /// </summary>
    /// <param name="_valueID"></param>
    /// <param name="_value"></param>
    public void SetFloat(string _valueID, float _value)
    {
        // === Does this value need to alert that it's been updated?
        bool watched = CheckIfWatched(DataTypes.Float, ref _valueID);

        if (m_dFloatValues.ContainsKey(_valueID)) {
            if (watched && m_dFloatValues[_valueID] != _value) {
                // === Only Alert that it's been updated if the values are different
                m_bValueUpdated = true;
            }

            m_dFloatValues[_valueID] = _value;
        }
        else {
            m_dFloatValues.Add(_valueID, _value);

            if (watched) {
                // === Alert, since it's a new value.
                m_bValueUpdated = true;
            }
        }
    }

    /// <summary>
    /// Sets the given string with the given ID. If the key doesn't exist, it will add it to the BlackBoard,
    /// else it will just update the the value of the key.
    /// </summary>
    /// <param name="_valueID"></param>
    /// <param name="_value"></param>
    public void SetString(string _valueID, string _value)
    {
        // === Does this value need to alert that it's been updated?
        bool watched = CheckIfWatched(DataTypes.String, ref _valueID);

        if (m_dStringValues.ContainsKey(_valueID)) {
            if (watched && m_dStringValues[_valueID] != _value) {
                // === Only Alert that it's been updated if the values are different
                m_bValueUpdated = true;
            }

            m_dStringValues[_valueID] = _value;
        }
        else {
            m_dStringValues.Add(_valueID, _value);

            if (watched) {
                // === Alert, since it's a new value.
                m_bValueUpdated = true;
            }
        }
    }

    /// <summary>
    /// Sets the given Vector2 with the given ID. If the key doesn't exist, it will add it to the BlackBoard,
    /// else it will just update the the value of the key.
    /// </summary>
    /// <param name="_valueID"></param>
    /// <param name="_value"></param>
    public void SetVector2(string _valueID, Vector2 _value)
    {
        // === Does this value need to alert that it's been updated?
        bool watched = CheckIfWatched(DataTypes.Vector2, ref _valueID);

        if (m_dVector2Values.ContainsKey(_valueID)) {
            if (watched && m_dVector2Values[_valueID] != _value) {
                // === Only Alert that it's been updated if the values are different
                m_bValueUpdated = true;
            }

            m_dVector2Values[_valueID] = _value;
        }
        else {
            m_dVector2Values.Add(_valueID, _value);

            if (watched) {
                // === Alert, since it's a new value.
                m_bValueUpdated = true;
            }
        }
    }

    /// <summary>
    /// Sets the given Vector3 with the given ID. If the key doesn't exist, it will add it to the BlackBoard,
    /// else it will just update the the value of the key.
    /// </summary>
    /// <param name="_valueID"></param>
    /// <param name="_value"></param>
    public void SetVector3(string _valueID, Vector3 _value)
    {
        // === Does this value need to alert that it's been updated?
        bool watched = CheckIfWatched(DataTypes.Vector3, ref _valueID);

        if (m_dVector3Values.ContainsKey(_valueID)) {
            if (watched && m_dVector3Values[_valueID] != _value) {
                // === Only Alert that it's been updated if the values are different
                m_bValueUpdated = true;
            }

            m_dVector3Values[_valueID] = _value;
        }
        else {
            m_dVector3Values.Add(_valueID, _value);

            if (watched) {
                // === Alert, since it's a new value.
                m_bValueUpdated = true;
            }
        }
    }

    /// <summary>
    /// Sets the given Vector4 with the given ID. If the key doesn't exist, it will add it to the BlackBoard,
    /// else it will just update the the value of the key.
    /// </summary>
    /// <param name="_valueID"></param>
    /// <param name="_value"></param>
    public void SetVector4(string _valueID, Vector4 _value)
    {
        // === Does this value need to alert that it's been updated?
        bool watched = CheckIfWatched(DataTypes.Vector4, ref _valueID);

        if (m_dVector4Values.ContainsKey(_valueID)) {
            if (watched && m_dVector4Values[_valueID] != _value) {
                // === Only Alert that it's been updated if the values are different
                m_bValueUpdated = true;
            }

            m_dVector4Values[_valueID] = _value;
        }
        else {
            m_dVector4Values.Add(_valueID, _value);

            if (watched) {
                // === Alert, since it's a new value.
                m_bValueUpdated = true;
            }
        }
    }

    /// <summary>
    /// Sets the given Object with the given ID. If the key doesn't exist, it will add it to the BlackBoard,
    /// else it will just update the the value of the key.
    /// ** Note, the Object must implement the MonoBehavior class
    /// </summary>
    /// <typeparam name="type"></typeparam>
    /// <param name="_valueID"></param>
    /// <param name="_value"></param>
    public void SetObject<type>(string _valueID, type _value) where type : UnityEngine.Object
    {
        // === Does this value need to alert that it's been updated?
        bool watched = CheckIfWatched(DataTypes.UnityObject, ref _valueID);

        if (m_dUnityObjectValues.ContainsKey(_valueID)) {
            if (watched && m_dUnityObjectValues[_valueID] != _value) {
                // === Only Alert that it's been updated if the values are different
                m_bValueUpdated = true;
            }

            m_dUnityObjectValues[_valueID] = _value;
        }
        else {
            m_dUnityObjectValues.Add(_valueID, _value);

            if (watched) {
                // === Alert, since it's a new value.
                m_bValueUpdated = true;
            }
        }
    }

    /// <summary>
    /// Sets the given System Object with the given ID. If the key doesn't exist, it will add it to the BlackBoard,
    /// else it will just update the the value of the key.
    /// </summary>
    /// <param name="_valueID"></param>
    /// <param name="_value"></param>
    public void SetSystemObject(string _valueID, object _value)
    {
        // === Does this value need to alert that it's been updated?
        bool watched = CheckIfWatched(DataTypes.SystemObject, ref _valueID);

        if (m_dSystemObjectValues.ContainsKey(_valueID)) {
            if (watched && m_dSystemObjectValues[_valueID] != _value) {
                // === Only Alert that it's been updated if the values are different
                m_bValueUpdated = true;
            }

            m_dSystemObjectValues[_valueID] = _value;
        }
        else {
            m_dSystemObjectValues.Add(_valueID, _value);

            if (watched) {
                // === Alert, since it's a new value.
                m_bValueUpdated = true;
            }
        }
    }

    /// <summary>
    /// Sets the watch mode of the BlackBoard. Modes are the following:
    /// <para>No_Watch - BlackBoard doesn't watch for any variables, giving no alerts.</para>
    /// <para>Specified_Watch - BlackBoard watches for only the key/type pair that was specified.</para>
    /// <para>Full_Watch - BlackBoard watches all variables, giving an alert when anything changes.</para>
    /// </summary>
    /// <param name="_mode"></param>
    public void SetWatchMode(ValueWatchMode _mode)
    {
        m_eWatchMode = _mode;
    }

    /// <summary>
    /// Sets the Reroute Node for a Behavior Tree to use instead of it's Root Node.
    /// ** Note, this function should only be used in the RerouteBehavior class itself to ensure proper function of a Behavior Tree
    /// </summary>
    /// <param name="_rerouteNode"></param>
    public void SetRerouteNode(RerouteBehavior _rerouteNode)
    {
        m_RerouteNode = _rerouteNode;
    }

    /// <summary>
    /// Adds a bool type variable key to watch for.
    /// </summary>
    /// <param name="_variableID"></param>
    public void AddBoolKeyForWatch(string _variableID)
    {
        m_vWatchedBoolKeys.Add(_variableID);
    }

    /// <summary>
    /// Adds an int type variable key to watch for.
    /// </summary>
    /// <param name="_variableID"></param>
    public void AddIntKeyForWatch(string _variableID)
    {
        m_vWatchedIntKeys.Add(_variableID);
    }

    /// <summary>
    /// Adds a long type variable key to watch for.
    /// </summary>
    /// <param name="_variableID"></param>
    public void AddLongKeyForWatch(string _variableID)
    {
        m_vWatchedLongKeys.Add(_variableID);
    }

    /// <summary>
    /// Adds a float type variable key to watch for.
    /// </summary>
    /// <param name="_variableID"></param>
    public void AddFloatKeyForWatch(string _variableID)
    {
        m_vWatchedFloatKeys.Add(_variableID);
    }

    /// <summary>
    /// Adds a string type variable key to watch for.
    /// </summary>
    /// <param name="_variableID"></param>
    public void AddStringKeyForWatch(string _variableID)
    {
        m_vWatchedStringKeys.Add(_variableID);
    }

    /// <summary>
    /// Adds a Vector2 type variable key to watch for.
    /// </summary>
    /// <param name="_variableID"></param>
    public void AddVector2KeyForWatch(string _variableID)
    {
        m_vWatchedVector2Keys.Add(_variableID);
    }

    /// <summary>
    /// Adds a Vector3 type variable key to watch for.
    /// </summary>
    /// <param name="_variableID"></param>
    public void AddVector3KeyForWatch(string _variableID)
    {
        m_vWatchedVector3Keys.Add(_variableID);
    }

    /// <summary>
    /// Adds a Vector4 type variable key to watch for.
    /// </summary>
    /// <param name="_variableID"></param>
    public void AddVector4KeyForWatch(string _variableID)
    {
        m_vWatchedVector4Keys.Add(_variableID);
    }

    /// <summary>
    /// Adds an Unity Object type variable key to watch for.
    /// </summary>
    /// <param name="_variableID"></param>
    public void AddObjectKeyForWatch(string _variableID)
    {
        m_vWatchedUnityObjectKeys.Add(_variableID);
    }

    /// <summary>
    /// Adds a System Object type variable key to watch for.
    /// </summary>
    /// <param name="_variableID"></param>
    public void AddSystemObjectKeyForWatch(string _variableID)
    {
        m_vWatchedSystemObjectKeys.Add(_variableID);
    }

    /// <summary>
    /// Removes all keys that the BlackBoard is currently watching for AND sets the watch mode to No_Watch AND sets the Reroute Node to null.
    /// </summary>
    public void RemoveAllWatchedKeys()
    {
        // === Clear all the Keys
        m_vWatchedBoolKeys.Clear();
        m_vWatchedFloatKeys.Clear();
        m_vWatchedIntKeys.Clear();
        m_vWatchedLongKeys.Clear();
        m_vWatchedStringKeys.Clear();
        m_vWatchedSystemObjectKeys.Clear();
        m_vWatchedUnityObjectKeys.Clear();
        m_vWatchedVector2Keys.Clear();
        m_vWatchedVector3Keys.Clear();
        m_vWatchedVector4Keys.Clear();

        // === Since there's nothing to watch for, set the mode to No_Watch and remove the Reroute Node
        m_eWatchMode = ValueWatchMode.VWM_No_Watch;
        m_bValueUpdated = false;
        m_RerouteNode = null;
    }

    /// <summary>
    /// Removes a specific bool type key from the watch list.
    /// </summary>
    /// <param name="_variableID"></param>
    public void RemoveBoolKeyFromWatch(string _variableID)
    {
        m_vWatchedBoolKeys.Remove(_variableID);
    }

    /// <summary>
    /// Removes a specific int type key from the watch list.
    /// </summary>
    /// <param name="_variableID"></param>
    public void RemoveIntKeyFromWatch(string _variableID)
    {
        m_vWatchedIntKeys.Remove(_variableID);
    }

    /// <summary>
    /// Removes a specific long type key from the watch list.
    /// </summary>
    /// <param name="_variableID"></param>
    public void RemoveLongKeyFromWatch(string _variableID)
    {
        m_vWatchedLongKeys.Remove(_variableID);
    }

    /// <summary>
    /// Removes a specific float type key from the watch list.
    /// </summary>
    /// <param name="_variableID"></param>
    public void RemoveFloatKeyFromWatch(string _variableID)
    {
        m_vWatchedFloatKeys.Remove(_variableID);
    }

    /// <summary>
    /// Removes a specific string type key from the watch list.
    /// </summary>
    /// <param name="_variableID"></param>
    public void RemoveStringKeyFromWatch(string _variableID)
    {
        m_vWatchedStringKeys.Remove(_variableID);
    }

    /// <summary>
    /// Removes a specific Vector2 type key from the watch list.
    /// </summary>
    /// <param name="_variableID"></param>
    public void RemoveVector2KeyFromWatch(string _variableID)
    {
        m_vWatchedVector2Keys.Remove(_variableID);
    }

    /// <summary>
    /// Removes a specific Vector3 type key from the watch list.
    /// </summary>
    /// <param name="_variableID"></param>
    public void RemoveVector3KeyFromWatch(string _variableID)
    {
        m_vWatchedVector3Keys.Remove(_variableID);
    }

    /// <summary>
    /// Removes a specific Vector4 type key from the watch list.
    /// </summary>
    /// <param name="_variableID"></param>
    public void RemoveVector4KeyFromWatch(string _variableID)
    {
        m_vWatchedVector4Keys.Remove(_variableID);
    }

    /// <summary>
    /// Removes a specific Unity Object type key from the watch list.
    /// </summary>
    /// <param name="_variableID"></param>
    public void RemoveObjectKeyFromWatch(string _variableID)
    {
        m_vWatchedUnityObjectKeys.Remove(_variableID);
    }

    /// <summary>
    /// Removes a specific System Object type key from the watch list.
    /// </summary>
    /// <param name="_variableID"></param>
    public void RemoveSystemObjectKeyFromWatch(string _variableID)
    {
        m_vWatchedSystemObjectKeys.Remove(_variableID);
    }
    // ==================== //

    // ===== Accessors ===== //
    /// <summary>
    /// Retrieves the bool value at the given key.
    /// ** Note, if there is no key with the given value, it will return the default value.
    /// </summary>
    /// <param name="_valueID"></param>
    /// <returns></returns>
    public bool GetBool(string _valueID)
    {
        bool foundValue = false;
        m_dBoolValues.TryGetValue(_valueID, out foundValue);
        return foundValue;
    }

    /// <summary>
    /// Retrieves the int value at the given key.
    /// ** Note, if there is no key with the given value, it will return the default value.
    /// </summary>
    /// <param name="_valueID"></param>
    /// <returns></returns>
    public int GetInt(string _valueID)
    {
        int foundValue = 0;
        m_dIntValues.TryGetValue(_valueID, out foundValue);
        return foundValue;
    }

    /// <summary>
    /// Retrieves the long value at the given key.
    /// ** Note, if there is no key with the given value, it will return the default value.
    /// </summary>
    /// <param name="_valueID"></param>
    /// <returns></returns>
    public long GetLong(string _valueID)
    {
        long foundValue = 0;
        m_dLongValues.TryGetValue(_valueID, out foundValue);
        return foundValue;
    }

    /// <summary>
    /// Retrieves the float value at the given key.
    /// ** Note, if there is no key with the given value, it will return the default value.
    /// </summary>
    /// <param name="_valueID"></param>
    /// <returns></returns>
    public float GetFloat(string _valueID)
    {
        float foundValue = 0.0f;
        m_dFloatValues.TryGetValue(_valueID, out foundValue);
        return foundValue;
    }

    /// <summary>
    /// Retrieves the string value at the given key.
    /// ** Note, if there is no key with the given value, it will return the default value.
    /// </summary>
    /// <param name="_valueID"></param>
    /// <returns></returns>
    public string GetString(string _valueID)
    {
        string foundValue = "";
        m_dStringValues.TryGetValue(_valueID, out foundValue);
        return foundValue;
    }

    /// <summary>
    /// Retrieves the Vector2 value at the given key.
    /// ** Note, if there is no key with the given value, it will return the default value.
    /// </summary>
    /// <param name="_valueID"></param>
    /// <returns></returns>
    public Vector2 GetVector2(string _valueID)
    {
        Vector2 foundValue = new Vector2();
        m_dVector2Values.TryGetValue(_valueID, out foundValue);
        return foundValue;
    }

    /// <summary>
    /// Retrieves the Vector3 value at the given key.
    /// ** Note, if there is no key with the given value, it will return the default value.
    /// </summary>
    /// <param name="_valueID"></param>
    /// <returns></returns>
    public Vector3 GetVector3(string _valueID)
    {
        Vector3 foundValue = new Vector3();
        m_dVector3Values.TryGetValue(_valueID, out foundValue);
        return foundValue;
    }

    /// <summary>
    /// Retrieves the Vector4 value at the given key.
    /// ** Note, if there is no key with the given value, it will return the default value.
    /// </summary>
    /// <param name="_valueID"></param>
    /// <returns></returns>
    public Vector4 GetVector4(string _valueID)
    {
        Vector4 foundValue = new Vector4();
        m_dVector4Values.TryGetValue(_valueID, out foundValue);
        return foundValue;
    }

    /// <summary>
    /// Retrieves the Object value at the given key.
    /// ** Note, if there is no key with the given value, it will return the null.
    /// ** Note, the specified type must implement MonoBehavior.
    /// </summary>
    /// <typeparam name="type"></typeparam>
    /// <param name="_valueID"></param>
    /// <returns></returns>
    public type GetObject<type>(string _valueID) where type : UnityEngine.Object
    {
        UnityEngine.Object foundValue = null;
        m_dUnityObjectValues.TryGetValue(_valueID, out foundValue);
        return (type)System.Convert.ChangeType(foundValue, typeof(type));
    }

    /// <summary>
    /// Checks to see if the BlackBoard contains the desired bool key-value, returning true if it does, false otherwise.
    /// The found value will be stored in the given out parameter.
    /// </summary>
    /// <param name="_valueID"></param>
    /// <param name="_outValue"></param>
    /// <returns></returns>
    public bool TryGetBool(string _valueID, out bool _outValue)
    {
        return m_dBoolValues.TryGetValue(_valueID, out _outValue);
    }

    /// <summary>
    /// Checks to see if the BlackBoard contains the desired int key-value, returning true if it does, false otherwise.
    /// The found value will be stored in the given out parameter.
    /// </summary>
    /// <param name="_valueID"></param>
    /// <param name="_outValue"></param>
    /// <returns></returns>
    public bool TryGetInt(string _valueID, out int _outValue)
    {
        return m_dIntValues.TryGetValue(_valueID, out _outValue);
    }

    /// <summary>
    /// Checks to see if the BlackBoard contains the desired long key-value, returning true if it does, false otherwise.
    /// The found value will be stored in the given out parameter.
    /// </summary>
    /// <param name="_valueID"></param>
    /// <param name="_outValue"></param>
    /// <returns></returns>
    public bool TryGetLong(string _valueID, out long _outValue)
    {
        return m_dLongValues.TryGetValue(_valueID, out _outValue);
    }

    /// <summary>
    /// Checks to see if the BlackBoard contains the desired float key-value, returning true if it does, false otherwise.
    /// The found value will be stored in the given out parameter.
    /// </summary>
    /// <param name="_valueID"></param>
    /// <param name="_outValue"></param>
    /// <returns></returns>
    public bool TryGetFloat(string _valueID, out float _outValue)
    {
        return m_dFloatValues.TryGetValue(_valueID, out _outValue);
    }

    /// <summary>
    /// Checks to see if the BlackBoard contains the desired string key-value, returning true if it does, false otherwise.
    /// The found value will be stored in the given out parameter.
    /// </summary>
    /// <param name="_valueID"></param>
    /// <param name="_outValue"></param>
    /// <returns></returns>
    public bool TryGetString(string _valueID, out string _outValue)
    {
        return m_dStringValues.TryGetValue(_valueID, out _outValue);
    }

    /// <summary>
    /// Checks to see if the BlackBoard contains the desired Vector2 key-value, returning true if it does, false otherwise.
    /// The found value will be stored in the given out parameter.
    /// </summary>
    /// <param name="_valueID"></param>
    /// <param name="_outValue"></param>
    /// <returns></returns>
    public bool TryGetVector2(string _valueID, out Vector2 _outValue)
    {
        return m_dVector2Values.TryGetValue(_valueID, out _outValue);
    }

    /// <summary>
    /// Checks to see if the BlackBoard contains the desired Vector3 key-value, returning true if it does, false otherwise.
    /// The found value will be stored in the given out parameter.
    /// </summary>
    /// <param name="_valueID"></param>
    /// <param name="_outValue"></param>
    /// <returns></returns>
    public bool TryGetVector3(string _valueID, out Vector3 _outValue)
    {
        return m_dVector3Values.TryGetValue(_valueID, out _outValue);
    }

    /// <summary>
    /// Checks to see if the BlackBoard contains the desired Vector4 key-value, returning true if it does, false otherwise.
    /// The found value will be stored in the given out parameter.
    /// </summary>
    /// <param name="_valueID"></param>
    /// <param name="_outValue"></param>
    /// <returns></returns>
    public bool TryGetVector4(string _valueID, out Vector4 _outValue)
    {
        return m_dVector4Values.TryGetValue(_valueID, out _outValue);
    }

    /// <summary>
    /// Checks to see if the BlackBoard contains the desired Object key-value, returning true if it does, false otherwise.
    /// The found value will be stored in the given out parameter.
    /// ** Note, the specified type must implement MonoBehavior.
    /// </summary>
    /// <typeparam name="type"></typeparam>
    /// <param name="_valueID"></param>
    /// <param name="_outValue"></param>
    /// <returns></returns>
    public bool TryGetObject<type>(string _valueID, out type _outValue) where type : UnityEngine.Object
    {
        UnityEngine.Object foundValue = null;
        if (m_dUnityObjectValues.TryGetValue(_valueID, out foundValue)) {
            _outValue = (type)System.Convert.ChangeType(foundValue, typeof(type));
            return true;
        }

        _outValue = null;
        return false;
    }

    /// <summary>
    /// Checks to see if the BlackBoard contains the desired System Object key-value, returning true if it does, false otherwise.
    /// The found value will be stored in the given out parameter.
    /// </summary>
    /// <param name="_valueID"></param>
    /// <param name="_outValue"></param>
    /// <returns></returns>
    public bool TryGetSystemObject(string _valueID, out object _outValue)
    {
        return m_dSystemObjectValues.TryGetValue(_valueID, out _outValue);
    }

    /// <summary>
    /// Retrieves the System Object value at the given key.
    /// ** Note, if there is no key with the given value, it will return the default value.
    /// </summary>
    /// <param name="_valueID"></param>
    /// <returns></returns>
    public object GetSystemObject(string _valueID)
    {
        object foundValue = null;
        m_dSystemObjectValues.TryGetValue(_valueID, out foundValue);
        return foundValue;
    }

    /// <summary>
    /// Checks for whether or not this BlackBoard currently has a bool with the given key value.
    /// </summary>
    /// <param name="_valueID"></param>
    /// <returns></returns>
    public bool HasBool(string _valueID)
    {
        return m_dBoolValues.ContainsKey(_valueID);
    }

    /// <summary>
    /// Checks for whether or not this BlackBoard currently has an int with the given key value.
    /// </summary>
    /// <param name="_valueID"></param>
    /// <returns></returns>
    public bool HasInt(string _valueID)
    {
        return m_dIntValues.ContainsKey(_valueID);
    }

    /// <summary>
    /// Checks for whether or not this BlackBoard currently has a long with the given key value.
    /// </summary>
    /// <param name="_valueID"></param>
    /// <returns></returns>
    public bool HasLong(string _valueID)
    {
        return m_dLongValues.ContainsKey(_valueID);
    }

    /// <summary>
    /// Checks for whether or not this BlackBoard currently has a float with the given key value.
    /// </summary>
    /// <param name="_valueID"></param>
    /// <returns></returns>
    public bool HasFloat(string _valueID)
    {
        return m_dFloatValues.ContainsKey(_valueID);
    }

    /// <summary>
    /// Checks for whether or not this BlackBoard currently has a string with the given key value.
    /// </summary>
    /// <param name="_valueID"></param>
    /// <returns></returns>
    public bool HasString(string _valueID)
    {
        return m_dStringValues.ContainsKey(_valueID);
    }

    /// <summary>
    /// Checks for whether or not this BlackBoard currently has a Vector2 with the given key value.
    /// </summary>
    /// <param name="_valueID"></param>
    /// <returns></returns>
    public bool HasVector2(string _valueID)
    {
        return m_dVector2Values.ContainsKey(_valueID);
    }

    /// <summary>
    /// Checks for whether or not this BlackBoard currently has a Vector3 with the given key value.
    /// </summary>
    /// <param name="_valueID"></param>
    /// <returns></returns>
    public bool HasVector3(string _valueID)
    {
        return m_dVector3Values.ContainsKey(_valueID);
    }

    /// <summary>
    /// Checks for whether or not this BlackBoard currently has a Vector4 with the given key value.
    /// </summary>
    /// <param name="_valueID"></param>
    /// <returns></returns>
    public bool HasVector4(string _valueID)
    {
        return m_dVector4Values.ContainsKey(_valueID);
    }

    /// <summary>
    /// Checks for whether or not this BlackBoard currently has an Object with the given key value.
    /// </summary>
    /// <param name="_valueID"></param>
    /// <returns></returns>
    public bool HasObject(string _valueID)
    {
        return m_dUnityObjectValues.ContainsKey(_valueID);
    }

    /// <summary>
    /// Checks for whether or not this BlackBoard currently has a System Object with the given key value.
    /// </summary>
    /// <param name="_valueID"></param>
    /// <returns></returns>
    public bool HasSystemObject(string _valueID)
    {
        return m_dSystemObjectValues.ContainsKey(_valueID);
    }

    /// <summary>
    /// Gets the BlackBoard's current watch mode for wariables.
    /// </summary>
    /// <returns></returns>
    public ValueWatchMode GetWatchMode()
    {
        return m_eWatchMode;
    }

    /// <summary>
    /// Returns the Reroute Node of this BlackBoard for a Behavior Tree to use instead of it's Root Node.
    /// ** Note, this function is only for the use by Behavior Tree
    /// </summary>
    /// <returns></returns>
    public RerouteBehavior GetRerouteNode()
    {
        return m_RerouteNode;
    }

    /// <summary>
    /// Returns whether or not the values that we being watched have changed at all. If the values were updated, it returns
    /// true, then resets the alert so that it won't alert again until the values change once more.
    /// </summary>
    /// <returns></returns>
    public bool ValuesUpdated()
    {
        if (m_bValueUpdated) {
            // === A watched value has been updated, reset the alert and return true
            m_bValueUpdated = false;
            return true;
        }

        return false;
    }
    // ===================== //
}
