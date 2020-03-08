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

    PlayerScript1 ps1;
    PlayerScript2 ps2;
    public CoolDownsSpellManager1 SCSM1;
    public CoolDownsSpellManager2 SCSM2;
    bool Player1;
    
    
    bool onCdS1 = false;
    bool onCdS2 = false;
    bool onCdS3 = false;
    bool onCdS4 = false;


    
    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        tf = gameObject.GetComponent<Transform>();
        if (gameObject.tag.Equals("Player1"))
        {
            ps1 = gameObject.AddComponent<PlayerScript1>() as PlayerScript1;
            Player1 = true;
        }
        else if (gameObject.tag.Equals("Player2"))
        {
            ps2 = gameObject.AddComponent<PlayerScript2>() as PlayerScript2;
            Player1 = false;
        }
        sr.sortingLayerName = "forground";
        SetUpSpellIcons();
    }

    void FixedUpdate()
    {
        if (Player1)
        {
            if (Input.GetKey(KeyCode.F) && !onCdS1 && ps1.canMove)
            {
                StartCoroutine("Spell1");
            }

            if (Input.GetKey(KeyCode.G) && !onCdS2 && ps1.canMove)
            {
                StartCoroutine("Spell2");
            }

            if (Input.GetKey(KeyCode.H) && !onCdS3 && ps1.canMove)
            {
                StartCoroutine("Spell3");
            }

            if (Input.GetKey(KeyCode.J) && !onCdS4 && ps1.canMove)
            {
                StartCoroutine("Spell4");
            }

        }
        else
        {
            if (Input.GetKey(KeyCode.Keypad4) && !onCdS1 && ps2.canMove)
            {
                StartCoroutine("Spell1");
            }
            if (Input.GetKey(KeyCode.Keypad5) && !onCdS2 && ps2.canMove)
            {
                StartCoroutine("Spell2");
            }
            if (Input.GetKey(KeyCode.Keypad6) && !onCdS3 && ps2.canMove)
            {
                StartCoroutine("Spell3");
            }
            if (Input.GetKey(KeyCode.KeypadPlus) && !onCdS4 && ps2.canMove)
            {
                StartCoroutine("Spell4");
            }
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
        if (Player1)
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
        if (!Player1){
            rbS.rotation = 180 - rbS.rotation;
        }
    }



    //Specific spells
    IEnumerator Spell1()
    {
        castSpell(spell1);
        onCdS1 = true;
        if (Player1) { SCSM1.setIcon1OnCD(true); } else { SCSM2.setIcon1OnCD(true); }
        yield return new WaitForSeconds(spell1CD);
        onCdS1 = false;
        if (Player1) { SCSM1.setIcon1OnCD(false); } else { SCSM2.setIcon1OnCD(false); }
    }

    IEnumerator Spell2()
    {
        GameObject spell = Instantiate(spell2, tf.position, tf.rotation);
        Vector3 a = new Vector3(0, 0, 90);
        spell.GetComponent<Transform>().eulerAngles += a;
        spell.GetComponent<Transform>().Translate(0, -10, 0);
        spell.tag = tag;
        if (Player1)
        {
            spell.layer = 9;
        }
        else
        {
            spell.layer = 13;
        }
        onCdS2 = true;
        if (Player1) { SCSM1.setIcon2OnCD(true); } else { SCSM2.setIcon2OnCD(true); }
        yield return new WaitForSeconds(spell2CD);
        onCdS2 = false;
        if (Player1) { SCSM1.setIcon2OnCD(false); } else { SCSM2.setIcon2OnCD(false); }
    }

    IEnumerator Spell3()
    {
        GameObject spell = Instantiate(spell3, tf.position, tf.rotation);
        spell.SetActive(true);
        spell.tag = tag;

        onCdS3 = true;
        if (Player1) { SCSM1.setIcon3OnCD(true); } else { SCSM2.setIcon3OnCD(true); }
        yield return new WaitForSeconds(spell3CD);
        onCdS3 = false;
        if (Player1) { SCSM1.setIcon3OnCD(false); } else { SCSM2.setIcon3OnCD(false); }
    }

    IEnumerator Spell4()
    {
        StartCoroutine(Ultimate());
        onCdS4 = true;
        if (Player1) { SCSM1.setIcon4OnCD(true); } else { SCSM2.setIcon4OnCD(true); }
        yield return new WaitForSeconds(spell4CD);
        onCdS4 = false;
        if (Player1) { SCSM1.setIcon4OnCD(false); } else { SCSM2.setIcon4OnCD(false); }
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

    private void SetUpSpellIcons()
    {
        if (Player1)
        {
            SCSM1.setspell1(Icon1);
            SCSM1.setspell2(Icon2);
            SCSM1.setspell3(Icon3);
            SCSM1.setspell4(Icon4);
        }
        else
        {
            SCSM2.setspell1(Icon1);
            SCSM2.setspell2(Icon2);
            SCSM2.setspell3(Icon3);
            SCSM2.setspell4(Icon4);
        }
    }
}
