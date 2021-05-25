using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballmovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    Transform Player;
    
    [SerializeField]
    private float speed = 100;
    [SerializeField]
    private float sensibility = 10;


    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        Debug.Log(-1>80);
    }

    private void FixedUpdate()
    {
        Vector3 rotation = new Vector3(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
        rotation = rotation.normalized;
        rotation = new Vector3(rotation.x * Mathf.Cos( Player.eulerAngles.y * Mathf.Deg2Rad) + rotation.z * Mathf.Cos((Player.eulerAngles.y+90)  * Mathf.Deg2Rad),0, rotation.x * Mathf.Sin(-Player.eulerAngles.y * Mathf.Deg2Rad)+ rotation.z * Mathf.Sin(-(Player.eulerAngles.y + 90) * Mathf.Deg2Rad)); 
        rotation = rotation * speed * Time.fixedDeltaTime;
        rb.AddTorque(rotation);
        Player.position = transform.position;
    }

    private void Update()
    {
        Player.eulerAngles += new Vector3(0, Input.GetAxis("Mouse X") * sensibility, 0);
        
        Vector3 cRotation = Player.GetChild(0).eulerAngles;
        cRotation += new Vector3(-Input.GetAxis("Mouse Y") * sensibility, 0, 0);

        if (cRotation.x > 80 && cRotation.x < 180)
        {
            cRotation = new Vector3 (80, cRotation.y, cRotation.z);
        }
        else if(cRotation.x-360 < -80&&cRotation.x>180)
        {
            cRotation = new Vector3(-80, cRotation.y, cRotation.z);
        }

        Player.GetChild(0).eulerAngles = cRotation;

    }

}
