using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTestScript : MonoBehaviour
{

    public float dmg = 20f;
    public float stunTime = 2f;
    public float duration = 0.25f;
    public SpriteRenderer sr;
    public Sprite s1;
    public Sprite s2;

    private void Start()
    {
        Invoke("DestroyGameObject", duration);
        changeThroughSprites();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerScript1>()!= null)
        {
            collision.gameObject.GetComponent<PlayerScript1>().stunedFor(stunTime);
            collision.gameObject.GetComponent<PlayerScript1>().takeDamage(dmg);
        }
    }

    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    private void changeThroughSprites()
    {
        sr.sprite = s1;
        Invoke("loadSprite2", duration / 2f);
    }

    public void loadSprite2()
    {
        sr.sprite = s2;
    }

}
