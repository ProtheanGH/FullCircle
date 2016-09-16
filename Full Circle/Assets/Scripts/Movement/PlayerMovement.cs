using UnityEngine;
using System.Collections;

public class PlayerMovement : Movement
{

    // Use this for initialization
    override protected void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    override protected void Update()
    {
        VerticalMovement(Input.GetAxis("Vertical") * speed);
        HorizontalMovement(Input.GetAxis("Horizontal") * speed);
        if (Input.GetButtonDown("Jump"))
            Jump(5.0f);

        base.Update();

        LookAtMouse();
    }

    protected void LookAtMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit))
        {
            RotateTowards(hit.point);
        }
        else
        {
            RotateTowards(Camera.main.transform.position + ray.direction * 15.0f);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit))
        {
            Gizmos.DrawLine(Camera.main.transform.position, hit.point);
        }

        Gizmos.DrawLine(transform.position, transform.position + (transform.forward * 1.0f));
    }
}
