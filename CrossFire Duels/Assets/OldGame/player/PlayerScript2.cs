using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript2 : MonoBehaviour
{
    float currentMoveSpeed;
    public float moveSpeedNormal = 10f;
    Rigidbody2D rb2D;
    Transform tf;
    public float startHealth = 100f;
    public float currentHealth;
    GSM gameSM;
    CoolDownsSpellManager2 cDM;//the UI element that comunicates the state of the spell Icons
    SpriteRenderer sr;
    Color normal = new Color(1, 1, 1, 1);
    Color onFire = new Color(1, 0.2f, 0.2f, 1);
    Color stuned = new Color(0.2f, 0.2f, 1, 1);

    public bool burning = false;
    Slider HealthS2;

    public bool canMove;


    private void Awake()
    {
        cDM = GameObject.FindObjectOfType<CoolDownsSpellManager2>();//reference to the Icon Manager
        sr = gameObject.GetComponent<SpriteRenderer>();
        gameSM = GameObject.Find("GameStateManager").GetComponent<GSM>();//reference to the Game State Manager
        HealthS2 = GameObject.Find("HealthSlider2").GetComponent<Slider>();//referene to the UI health slider
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        tf = gameObject.GetComponent<Transform>();
        currentHealth = startHealth;
        currentMoveSpeed = moveSpeedNormal;
        canMove = true;
    }

    void FixedUpdate()
    {//waiting for keysstrokes and adding force according to the keys pressed
        if (Input.GetKey(KeyCode.UpArrow) && canMove)
        {
            rb2D.AddForce(Vector2.up * currentMoveSpeed * Time.deltaTime * 100f);
        }
        if (Input.GetKey(KeyCode.DownArrow) && canMove)
        {
            rb2D.AddForce(Vector2.down * currentMoveSpeed * Time.deltaTime * 100f);
        }
        if (Input.GetKey(KeyCode.RightArrow) && canMove)
        {
            rb2D.AddForce(Vector2.right * currentMoveSpeed * Time.deltaTime * 100f);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && canMove)
        {
            rb2D.AddForce(Vector2.left * currentMoveSpeed * Time.deltaTime * 100f);
        }
    }


    public void takeDamage(float amount)
    {
        currentHealth -= amount;//changing the current Health according to the imput value
        HealthS2.value = currentHealth;//comunicating the number of hp to the health Bar
        if (currentHealth <= 0)
        {
            gameSM.GameEnd("Player1");//see GSM line 84
        }
        if (currentHealth >= 100)
        {
            currentHealth = 100;
        }
    }

    private IEnumerator stunP(float time)
    {
        if(currentMoveSpeed == 0)//if the player is already stuned we need to stop the old coroutines or he will be stuned for a to short time and the color will disapear to fast
        {
            StopCoroutine("castS");
            StopCoroutine("stunP");
        }
        sr.color = stuned;//loading the stuned color
        StartCoroutine(castS(time));//see line 97
        yield return new WaitForSeconds(time);
        sr.color = normal;//setting the color back to normal
    }

    public void castingSpell(float time)
    {
        if (currentMoveSpeed == 0)//if the player is already stuned we need to stop the old coroutine or he will be stuned for a to short time 
        {
            StopCoroutine("castS");
        }
        StartCoroutine(castS(time));//see line 97
    }

    private IEnumerator castS(float time)
    {
        canMove = false;
        rb2D.velocity = Vector2.zero;
        cDM.setAllIconsOnCD(true);//see coolDownsSpellManager line 128
        yield return new WaitForSeconds(time);
        canMove = true;
        cDM.setAllIconsOnCD(false);
    }

    public void stunedFor(float time)
    {
        if(currentMoveSpeed == 0)//same resone as above
        {
            StopCoroutine("stunP");
        }
        StartCoroutine(stunP(time));//see line 75
    }

    public void BurnFor(float a)
    {
        if (burning)
        {
            StopCoroutine("BurnFor");//same resone as above
        }
        StartCoroutine(burnf(a));//see line 125
    }

    IEnumerator burnf(float a)
    {
        burning = true;
        sr.color = onFire;
        for (int i = (int)a; i > 0; i--)//taking 2 time 0.5 damage per sec for input sec
        {
            takeDamage(0.5f);
            yield return new WaitForSeconds(0.5f);
            takeDamage(0.5f);
            yield return new WaitForSeconds(0.5f);
        }
        burning = false;
        sr.color = normal;
    }

}
