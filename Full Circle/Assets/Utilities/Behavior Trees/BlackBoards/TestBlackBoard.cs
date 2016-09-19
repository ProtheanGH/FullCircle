using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestBlackBoard : MonoBehaviour {
    // === Variables
    BlackBoard m_BlackBoard;

	// Use this for initialization
	void Start () {
        m_BlackBoard = new BlackBoard();

        // === Local Vars
        List<int> intList = new List<int>();
        intList.Add(15); intList.Add(20);

        // === Store some objects
        m_BlackBoard.SetBool("Bool", true);
        m_BlackBoard.SetInt("Int", 15);
        m_BlackBoard.SetLong("Long", 100);
        m_BlackBoard.SetFloat("Float", 12.35f);
        m_BlackBoard.SetString("String", "Hello World");
        m_BlackBoard.SetVector2("Vec2", new Vector2(2, 2));
        m_BlackBoard.SetVector3("Vec3", new Vector3(3, 3, 3));
        m_BlackBoard.SetVector4("Vec4", new Vector4(4, 4, 4, 4));
        m_BlackBoard.SetObject<TestBlackBoard>("TestScript", this);
        m_BlackBoard.SetSystemObject("List", intList);
    }
	
	// Update is called once per frame
	void Update () {
        bool testResult;

        // === Has Key Check (Should all be true)
        testResult = m_BlackBoard.HasBool("Bool");
        testResult = m_BlackBoard.HasInt("Int");
        testResult = m_BlackBoard.HasLong("Long");
        testResult = m_BlackBoard.HasFloat("Float");
        testResult = m_BlackBoard.HasString("String");
        testResult = m_BlackBoard.HasVector2("Vec2");
        testResult = m_BlackBoard.HasVector3("Vec3");
        testResult = m_BlackBoard.HasVector4("Vec4");
        testResult = m_BlackBoard.HasObject("TestScript");
        testResult = m_BlackBoard.HasSystemObject("List");

        // === Has Key Check (Should all be false)
        testResult = m_BlackBoard.HasBool("Bool_Fake");
        testResult = m_BlackBoard.HasInt("Int_Fake");
        testResult = m_BlackBoard.HasLong("Long_Fake");
        testResult = m_BlackBoard.HasFloat("Float_Fake");
        testResult = m_BlackBoard.HasString("String_Fake");
        testResult = m_BlackBoard.HasVector2("Vec2_Fake");
        testResult = m_BlackBoard.HasVector3("Vec3_Fake");
        testResult = m_BlackBoard.HasVector4("Vec4_Fake");
        testResult = m_BlackBoard.HasObject("TestScript_Fake");
        testResult = m_BlackBoard.HasSystemObject("List_Fake");

        // === Value Check
        bool boolVal = m_BlackBoard.GetBool("Bool");
        int intVal = m_BlackBoard.GetInt("Int");
        long longVal = m_BlackBoard.GetLong("Long");
        float floatVal = m_BlackBoard.GetFloat("Float");
        string stringVal = m_BlackBoard.GetString("String");
        Vector2 v2Val = m_BlackBoard.GetVector2("Vec2");
        Vector3 v3Val = m_BlackBoard.GetVector3("Vec3");
        Vector4 v4Val = m_BlackBoard.GetVector3("Vec4");
        TestBlackBoard scriptVal = m_BlackBoard.GetObject<TestBlackBoard>("TestScript");
        List<int> listVal = (List<int>)m_BlackBoard.GetSystemObject("List");

        // === Clear Values;
        boolVal = false;
        intVal = 0;
        longVal = 0;
        floatVal = 0.0f;
        stringVal = "";
        v2Val = new Vector2();
        v3Val = new Vector3();
        v4Val = new Vector4();
        scriptVal = null;
        listVal = new List<int>();

        // === TryGet Check
        object tryGetObject = null;
        testResult = m_BlackBoard.TryGetBool("Bool", out boolVal);
        testResult = m_BlackBoard.TryGetInt("Int", out intVal);
        testResult = m_BlackBoard.TryGetLong("Long", out longVal);
        testResult = m_BlackBoard.TryGetFloat("Float", out floatVal);
        testResult = m_BlackBoard.TryGetString("String", out stringVal);
        testResult = m_BlackBoard.TryGetVector2("Vec2", out v2Val);
        testResult = m_BlackBoard.TryGetVector3("Vec3", out v3Val);
        testResult = m_BlackBoard.TryGetVector4("Vec4", out v4Val);
        testResult = m_BlackBoard.TryGetObject<TestBlackBoard>("TestScript", out scriptVal);
        testResult = m_BlackBoard.TryGetSystemObject("List", out tryGetObject);
        listVal = (List<int>)tryGetObject;
    }
}
