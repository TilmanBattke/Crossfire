using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpell2 : MonoBehaviour
{
    public float speed;
    public float dmg;
    public float burntime;
    Rigidbody2D rb2D;
    SpriteRenderer sr;

    private void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        StartCoroutine(ChangeThroughSprites());
    }

    private void FixedUpdate()
    {
        Vector2 d = new Vector2(Mathf.Cos(rb2D.rotation * Mathf.Deg2Rad), Mathf.Sin(rb2D.rotation * Mathf.Deg2Rad));
        rb2D.velocity = (d * Time.deltaTime * 100 * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall side"))
        {
            rb2D.SetRotation(rb2D.rotation * -1);
        }
        if (collision.gameObject.CompareTag("Player2") && tag.Equals("Player1"))
        {
            collision.gameObject.GetComponent<PlayerScript2>().takeDamage(dmg);
            collision.gameObject.GetComponent<PlayerScript2>().BurnFor(burntime);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player1") && tag.Equals("Player2"))
        {
            collision.gameObject.GetComponent<PlayerScript1>().takeDamage(dmg);
            collision.gameObject.GetComponent<PlayerScript1>().BurnFor(burntime);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Background"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator ChangeThroughSprites()
    {
        while (true)
        {
            sr.flipY = true;
            yield return new WaitForSeconds(.25f);
            sr.flipY = false;
            yield return new WaitForSeconds(.25f);
        }
    }

}
