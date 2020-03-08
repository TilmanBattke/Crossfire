using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Script : MonoBehaviour
{


    public Vector3 target;
    public float speed;
    public float spielraum;


    Rigidbody2D rb2d;
    Transform tf;



    void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        tf = gameObject.transform;
        target = new Vector3(0, 3.5f, 0);
    }

    void Update()
    {
        Vector2 deltaA = new Vector2(target.x - tf.position.x, target.y - tf.position.y);
        if(Mathf.Abs(deltaA.x) > spielraum || Mathf.Abs(deltaA.y) > spielraum)
        {
            rb2d.AddForce(deltaA.normalized * speed * Time.deltaTime * 100f);
        }
    }

    public void setTarget(Vector3 a)
    {
        target = a;
    }
}
