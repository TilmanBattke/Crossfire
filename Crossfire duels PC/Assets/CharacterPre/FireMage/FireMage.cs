using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMage : MonoBehaviour
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
    public CoolDownsSpellManager1 SCSM1;//reference to the ui
    public CoolDownsSpellManager2 SCSM2;
    bool Player1;


    bool onCdS1 = false;
    bool onCdS2 = false;
    bool onCdS3 = false;
    bool onCdS4 = false;

    


    private void Start()
    {

        //setting up all the references which are not done in the inspectore
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
        SetUpSpellIcons();//see line 234
    }


    void FixedUpdate()
    {

        //action listener for abilities
        if (Player1)
        {

            if (Input.GetKey(KeyCode.F) && !onCdS1 && ps1.canMove)
            {
                StartCoroutine("Spell1");//see line 170
            }

            if (Input.GetKey(KeyCode.G) && !onCdS2 && ps1.canMove)
            {
                StartCoroutine("Spell2");//see line 181
            }

            if (Input.GetKey(KeyCode.H) && !onCdS3 && ps1.canMove)
            {
                StartCoroutine("Spell3");//see line 191
            }

            if (Input.GetKey(KeyCode.J) && !onCdS4 && ps1.canMove)
            {
                StartCoroutine("Spell4");//see line 221
            }

        }
        else if (!Player1)
        {
            
            if (Input.GetKey(KeyCode.Keypad4) && !onCdS1 && ps2.canMove)
            {
                StartCoroutine("Spell1");//see line 170
            }
            if (Input.GetKey(KeyCode.Keypad5) && !onCdS2 && ps2.canMove)
            {
                StartCoroutine("Spell2");//see line 181
            }
            if (Input.GetKey(KeyCode.Keypad6) && !onCdS3 && ps2.canMove)
            {
                StartCoroutine("Spell3");//see line 191
            }
            if (Input.GetKey(KeyCode.KeypadPlus) && !onCdS4 && ps2.canMove)
            {
                StartCoroutine("Spell4");//see line 221
            }
        }

        //Setting the isWalking parameter of the animator for the character, with a tolerance of 0.5 velocity(i'm not sure about the unit but i think its unity-unit/sec)
        if ((rb2D.velocity.x > -0.5 && rb2D.velocity.x < 0.5) && (rb2D.velocity.y > -0.5 && rb2D.velocity.y < 0.5))
        {
            anim.SetBool("isWalking", false);
        }
        else
        {
            anim.SetBool("isWalking", true);
        }
    }


    /*this function instantiates an gameObject infornt of the gameObject it was called from, and it sets the rotation of the instantiated gameObject
     * to the direction of the velocity of the gameObject its called from.
     * parameter: GameObject PreS: the gameObject that is to be spawned. 
     */
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
        else if (x == 0 && y == 0)
        {
            rbS.rotation = 0;
        }
        if (!Player1)
        {
            rbS.rotation = 180 - rbS.rotation;
        }
    }

    //Instantiates Spell 1 infront of the player facing in the walking direction. Setting the fitting icon1 (according to the PlayerTag) for the time of spell1CD to greyed out. 
    IEnumerator Spell1()
    {
        castSpell(spell1);//see line 133
        onCdS1 = true;
        if (Player1) { SCSM1.setIcon1OnCD(true); } else { SCSM2.setIcon1OnCD(true); }//setting the UI icon to greyed out.(see CoolDownsSpellManager1 line 50)
        yield return new WaitForSeconds(spell1CD);
        onCdS1 = false;
        if (Player1) { SCSM1.setIcon1OnCD(false); } else { SCSM2.setIcon1OnCD(false); }

    }

    //Instantiates Spell 2 infront of the player facing in the walking direction. Setting the fitting icon2 (according to the PlayerTag) for the time of spell2CD to greyed out.
    IEnumerator Spell2()
    {
        castSpell(spell2);//see line 133
        onCdS2 = true;
        if (Player1) { SCSM1.setIcon2OnCD(true); } else { SCSM2.setIcon2OnCD(true); }//setting the UI icon to greyed out.(see CoolDownsSpellManager1 line 72)
        yield return new WaitForSeconds(spell2CD);
        onCdS2 = false;
        if (Player1) { SCSM1.setIcon2OnCD(false); } else { SCSM2.setIcon2OnCD(false); }
    }

    //
    IEnumerator Spell3()
    {
        onCdS3 = true;
        GameObject spell = Instantiate(spell3, tf.position, tf.rotation);
        DashSpriteManager dSM = spell.GetComponent<DashSpriteManager>();
        float rotationAngle = Mathf.Atan2(rb2D.velocity.y, rb2D.velocity.x) * Mathf.Rad2Deg;
        Vector2 MoDirection = rb2D.velocity;
        
        spell.transform.eulerAngles = new Vector3 (0, 0, rotationAngle + rb2D.rotation);
        spell.transform.parent = tf;

        if (Player1) { ps1.castingSpell(dSM.dashTime); } else { ps2.castingSpell(dSM.dashTime); }
        StartCoroutine(dash(dSM.dashspeed, dSM.dashTime, MoDirection));
        
        if (Player1) { SCSM1.setIcon3OnCD(true); } else { SCSM2.setIcon3OnCD(true); }
        yield return new WaitForSeconds(spell3CD);
        onCdS3 = false;
        if (Player1) { SCSM1.setIcon3OnCD(false); } else { SCSM2.setIcon3OnCD(false); }
    }

    IEnumerator dash(float dashSpeed,float dashTime, Vector2 moDi)
    {
        float TimeBegin = Time.time;
        while(TimeBegin + dashTime > Time.time)
        {
            rb2D.velocity = moDi * Time.deltaTime * 100f * dashSpeed;
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator Spell4()
    {
        onCdS4 = true;
        for (int i = 3; i > 0; i--)
        {
            castSpell(spell4);
            yield return new WaitForSeconds(0.5f);
        }
        onCdS4 = true;
        if (Player1) { SCSM1.setIcon4OnCD(true); } else { SCSM2.setIcon4OnCD(true); }
        yield return new WaitForSeconds(spell4CD - 1.5f);
        onCdS4 = false;
        if (Player1) { SCSM1.setIcon4OnCD(false); } else { SCSM2.setIcon4OnCD(false); }
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
