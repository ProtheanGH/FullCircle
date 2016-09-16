using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

    public GameObject target;
    public Vector3 offset;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = target.transform.position + offset;
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(90.0f, 0.0f, 0.0f));
	}
}
