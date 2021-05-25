using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{


    public Vector3 target;
    float speed;
    float spielraum = 0.1f;
    float startingHealth = 100f;
    float currentHealth;
    bool burning;
    HudM hM;

    public float NormalSpeed;

    Rigidbody2D rb2d;
    Transform tf;
    SpriteRenderer sr;



    void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        tf = gameObject.transform;
        hM = GameObject.FindObjectOfType<HudM>();

        speed = NormalSpeed;
        burning = false;
        currentHealth = startingHealth;
        target = new Vector3(0, -3.5f, 0);

    }

    void FixedUpdate()
    {
        Vector2 deltaA = new Vector2(target.x - tf.position.x, target.y - tf.position.y);
        if (Mathf.Abs(deltaA.x) > spielraum || Mathf.Abs(deltaA.y) > spielraum)
        {
            rb2d.AddForce(deltaA.normalized * speed * Time.deltaTime * 100f);
        }
    }

    private IEnumerator stunn(float time)
    {
        sr.color = Color.blue;
        speed = 0;
        yield return new WaitForSeconds(time);
        speed = NormalSpeed;
        sr.color = Color.white;
        //TODO CoolDownManager
    }

    public void stunnfor(float time)
    {
        if (speed==0)
        {
            StopCoroutine("stunn");
        }
        StartCoroutine(stunn(time));
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;
        hM.setSlider(gameObject.tag, currentHealth);
    }

    public void burnfor(float time)
    {
        if (burning)
        {
            StopCoroutine("burn");
        }
        StartCoroutine(burn(time));
    }

    private IEnumerator burn(float time)
    {
        sr.color = Color.red;
        burning = true;
        for(float i = 2 * time ; i > 0; i--)
        {
            takeDamage(0.5f);
            yield return new WaitForSeconds(time);
        }
        sr.color = Color.white;
        burning = false;
    }

    public void setTarget(Vector3 a)
    {
        target = a;
    }

    public Vector3 getTarget()
    {
        return target;
    }

}
