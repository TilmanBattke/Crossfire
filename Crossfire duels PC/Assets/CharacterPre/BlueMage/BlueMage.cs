using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueMage : MonoBehaviour
{
    Rigidbody2D rb2D;
    Transform tf;
    SpriteRenderer sr;
    Animator anim;
    UIM uIM;

    public GameObject spell1;
    public Sprite Icon1;
    public float spell1CD;

    public GameObject spell2;
    public Sprite Icon2;
    public float spell2CD;

    public GameObject spell3;
    public Sprite Icon3;
    public float spell3CD;

    public GameObject spell4;
    public Sprite Icon4;
    public float spell4CD;

    PlayerScript1 ps;
    
    
    bool onCdS1 = false;
    bool onCdS2 = false;
    bool onCdS3 = false;
    bool onCdS4 = false;


    
    private void Start()
    {
        uIM = GameObject.FindObjectOfType<UIM>();
        anim = gameObject.GetComponent<Animator>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        tf = gameObject.GetComponent<Transform>();
        ps = gameObject.AddComponent<PlayerScript1>() as PlayerScript1;
        sr.sortingLayerName = "forground";
        Sprite[] sprites = { Icon1, Icon2, Icon3, Icon4 };
        ps.cDM.setSpellIcons(sprites);
    }

    void FixedUpdate()
    {
        
        
            if (Input.GetKey(ps.InputS[0]) && !onCdS1 && ps.canMove)
            {
                StartCoroutine("Spell1");
            }

            if (Input.GetKey(ps.InputS[1]) && !onCdS2 && ps.canMove)
            {
                StartCoroutine("Spell2");
            }

            if (Input.GetKey(ps.InputS[2]) && !onCdS3 && ps.canMove)
            {
                StartCoroutine("Spell3");
            }

            if (Input.GetKey(ps.InputS[3]) && !onCdS4 && ps.canMove)
            {
                StartCoroutine("Spell4");
            }

        
        

        if((rb2D.velocity.x > -0.5 && rb2D.velocity.x < 0.5)&&(rb2D.velocity.y > -0.5 && rb2D.velocity.y < 0.5))
        {
            anim.SetBool("isWalking",false);
        }
        else
        {
            anim.SetBool("isWalking", true);
        }
    }

    

    void castSpell(GameObject PreS)
    {
        GameObject spell = Instantiate(PreS, tf.position, tf.rotation);
        spell.tag = tag;
        if (ps.PlayerIndex.Equals("1"))
        {
            spell.layer = 9;
        }
        else
        {
            spell.layer = 13;
        }
        Rigidbody2D rbS = spell.GetComponent<Rigidbody2D>();
        Transform tfS = spell.GetComponent<Transform>();
        tfS.Translate(Vector2.right);
        float y = rb2D.velocity.y;
        float x = rb2D.velocity.x;
        
        if (x < 0)
        {
            x *= -1;
            rbS.rotation = Mathf.Asin(y / (Mathf.Sqrt(y * y + x * x))) / 2f * Mathf.Rad2Deg;
        }
        else if (x > 0 || y != 0)
        {
            rbS.rotation = Mathf.Asin(y / (Mathf.Sqrt(y * y + x * x))) / 2f * Mathf.Rad2Deg;
        }
        else if(x==0&&y==0)
        {
            rbS.rotation = 0;
        }
        if (!ps.PlayerIndex.Equals("1")){
            rbS.rotation = 180 - rbS.rotation;
        }
    }



    //Specific spells
    IEnumerator Spell1()
    {
        castSpell(spell1);
        onCdS1 = true;
        ps.cDM.setIcon1OnCD(true);
        yield return new WaitForSeconds(spell1CD);
        onCdS1 = false;
        ps.cDM.setIcon1OnCD(false);
    }

    IEnumerator Spell2()
    {
        GameObject spell = Instantiate(spell2, tf.position, tf.rotation);
        Vector3 a = new Vector3(0, 0, 90);
        spell.GetComponent<Transform>().eulerAngles += a;
        spell.GetComponent<Transform>().Translate(0, -10, 0);
        spell.tag = tag;
        if (ps.PlayerIndex.Equals("1"))
        {
            spell.layer = 9;
        }
        else
        {
            spell.layer = 13;
        }
        onCdS2 = true;
        ps.cDM.setIcon2OnCD(true);
        yield return new WaitForSeconds(spell2CD);
        onCdS2 = false;
        ps.cDM.setIcon2OnCD(false);
    }

    IEnumerator Spell3()
    {
        GameObject spell = Instantiate(spell3, tf.position, tf.rotation);
        spell.SetActive(true);
        spell.tag = tag;

        onCdS3 = true;
        ps.cDM.setIcon3OnCD(true);
        yield return new WaitForSeconds(spell3CD);
        onCdS3 = false;
        ps.cDM.setIcon3OnCD(false);
    }

    IEnumerator Spell4()
    {
        StartCoroutine(Ultimate());
        onCdS4 = true;
        ps.cDM.setIcon4OnCD(true);
        yield return new WaitForSeconds(spell4CD);
        onCdS4 = false;
        ps.cDM.setIcon4OnCD(false);
    }

    IEnumerator Ultimate()
    {
        GameObject spell = Instantiate(spell4, tf.position, tf.rotation);
        spell.transform.parent = tf;
        spell1CD /= 2;
        spell2CD /= 2;
        spell3CD /= 2;
        yield return new WaitForSeconds(spell.GetComponent<Ultimatescript>().ultimateDuration);
        spell1CD *= 2;
        spell2CD *= 2;
        spell3CD *= 2;
    }

}
