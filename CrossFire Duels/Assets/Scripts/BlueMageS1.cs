using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMageS1 : MonoBehaviour
{

    public Rigidbody2D rb2D;
    public SpriteRenderer sR;
    public Sprite s1;
    public Sprite s2;
    public Sprite s3;






    private void Start()
    {
        StartCoroutine("changeThroughSprites");
    }

    void FixedUpdate()
    {
        Vector2 d = new Vector2(Mathf.Cos(rb2D.rotation * Mathf.Deg2Rad), Mathf.Sin(rb2D.rotation * Mathf.Deg2Rad));
        rb2D.velocity = (d.normalized * Time.fixedDeltaTime * 100 * gameObject.GetComponent<SpellInfo>().speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("SeitenWand"))
        {
            rb2D.SetRotation((rb2D.rotation-90) * -1 + 90);
        }
        else if (collision.gameObject.name.Equals("EndWand"))
        {
            Destroy(gameObject);
        }
        else if (!collision.gameObject.tag.Equals(tag))
        {
            collision.gameObject.GetComponent<PlayerScript>().takeDamage(gameObject.GetComponent<SpellInfo>().damage);
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
