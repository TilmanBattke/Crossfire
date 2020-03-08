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
        if (collision.gameObject.CompareTag("Player2")&&tag.Equals("Player1"))
        {
            collision.GetComponent<PlayerScript2>().stunedFor(stunTime);
            GameObject.FindObjectOfType<PlayerScript1>().castingSpell(duration);
            collision.GetComponent<PlayerScript2>().takeDamage(dmg);
        }
        if (collision.gameObject.CompareTag("Player1")&&tag.Equals("Player2"))
        {
            collision.GetComponent<PlayerScript1>().stunedFor(stunTime);
            GameObject.FindObjectOfType<PlayerScript2>().castingSpell(duration);
            collision.GetComponent<PlayerScript1>().takeDamage(dmg);
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
