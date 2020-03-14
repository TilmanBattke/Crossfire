using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour
{

    public int dmg = 10;
    public float speed = 12f;
    public Rigidbody2D rb2D;
    public SpriteRenderer sR;
    public Sprite s1;
    public Sprite s2;
    public Sprite s3;
    public Sprite SpellIcon;


    private void Start()
    {
        StartCoroutine("changeThroughSprites");
    }

    void FixedUpdate()
    {
        Vector2 d = new Vector2(Mathf.Cos(rb2D.rotation * Mathf.Deg2Rad), Mathf.Sin(rb2D.rotation * Mathf.Deg2Rad));
        rb2D.velocity = (d * Time.deltaTime * 100 * speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall side"))
        {
            rb2D.SetRotation(rb2D.rotation * -1);
        }else if (collision.gameObject.CompareTag("Background"))
        {
            Destroy(gameObject);
        }else if (!collision.gameObject.CompareTag(gameObject.tag))
        {
            collision.gameObject.GetComponent<PlayerScript1>().takeDamage(dmg);
            Destroy(gameObject);

        }
        
    }

    IEnumerator changeThroughSprites()
    {
        while (true)
        {
            sR.sprite = s1;
            yield return new WaitForSeconds(0.1f);
            sR.sprite = s2;
            yield return new WaitForSeconds(0.1f);
            sR.sprite = s3;
            yield return new WaitForSeconds(0.1f);
        }
    }

}
