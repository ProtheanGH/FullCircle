using UnityEngine;
using System.Collections;


public class Movement : MonoBehaviour {

    new Rigidbody rigidbody = null;
    public float speed = 10.0f;
    Vector3 currentVelocity = Vector3.zero;
    public Vector3 groundCheckOffset = Vector3.zero;
    public float checkRadius = 0.0f;

	// Use this for initialization
	protected virtual void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}

    protected virtual void Update()
    {
        
    }

    protected void Jump(float velocity)
    {
        if (Physics.OverlapSphere(transform.position + groundCheckOffset, checkRadius).Length > 1)
        {
            rigidbody.AddForce(new Vector3(0.0f, velocity, 0.0f), ForceMode.Impulse);
        }
    }

    protected virtual void VerticalMovement(float velocity)
    {
        rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, velocity);
    }

    protected virtual void HorizontalMovement(float velocity)
    {
        rigidbody.velocity = new Vector3(velocity, rigidbody.velocity.y, rigidbody.velocity.z);
    }

    protected virtual void Rotate(float degrees)
    {
        gameObject.transform.Rotate(new Vector3(0.0f, degrees, 0.0f));
    }

    protected virtual void RotateTowards(Vector3 target)
    {
        gameObject.transform.rotation = Quaternion.LookRotation(target - transform.position);
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0.0f, gameObject.transform.rotation.eulerAngles.y, 0.0f));
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(transform.position + groundCheckOffset, checkRadius);
    }
}
