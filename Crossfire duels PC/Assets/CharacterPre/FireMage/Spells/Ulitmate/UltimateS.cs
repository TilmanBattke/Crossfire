using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateS : MonoBehaviour
{

    public float dmg;
    public float speed;
    public float maxAdjustementAngle;
    public float burntime;
    Transform target;
    Rigidbody2D rb2D;
    SpriteRenderer sr;

    public Sprite s1;
    public Sprite s2;
    public Sprite s3;
    public Sprite s4;

    private void Awake()
    {
        
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        
    }

    private void Start()
    {
        if (tag.Equals("Player1"))
        {
            target = GameObject.FindObjectOfType<PlayerScript2>().gameObject.transform;//setting target to the transformer of the gameObject the script is attached to
        }
        else
        {
            target = GameObject.FindObjectOfType<PlayerScript1>().gameObject.transform;
        }
        Debug.Log(target.gameObject.tag);
        StartCoroutine(changeThroughSprites());
    }

    private void Update()
    {
        float deltaY = target.position.y - gameObject.transform.position.y;//diference between ther objects on the y axe
        float deltaX = deltaX = target.position.x - gameObject.transform.position.x;//diference between ther objects on the x axe
        
        float deltaAngel = Mathf.Atan2(deltaY, deltaX) * Mathf.Rad2Deg;//the angle of the line that would conect the target with the spell object

        if (deltaAngel < -90)//this is a solution to a bug we had were I couldn't figure out how to do it without hard coding it.The problem was that atan2 returns -170 instead of 190 which is not the input we need so i hard coded it.
        {
            deltaAngel = 360 + deltaAngel;
        }

        float currentAdjustmentAngleNeeded = deltaAngel - rb2D.rotation;//the adjustements needed 
        if (tag.Equals("Player1"))//i had to mirror the logic becuase the object is mirrored
        {
            if (currentAdjustmentAngleNeeded > -maxAdjustementAngle && currentAdjustmentAngleNeeded < maxAdjustementAngle)//when the adjustment angle is smaller the our max angle the programm can adjust acording to that angle
            {
                rb2D.rotation += currentAdjustmentAngleNeeded;
            }
            else if (currentAdjustmentAngleNeeded < -maxAdjustementAngle)//if the adjustement needed is larger then the maxAngle we adjust the angle by maxAngle
            {
                rb2D.rotation += -maxAdjustementAngle;
            }
            else//if its smaller the by -maxAngle
            {
                rb2D.rotation += maxAdjustementAngle;
            }

        }
        else//for a spell casted by Player2 it is oposite.
        {
            if(currentAdjustmentAngleNeeded > -maxAdjustementAngle && currentAdjustmentAngleNeeded < maxAdjustementAngle)
            {
                rb2D.rotation += currentAdjustmentAngleNeeded;
            }
            else if(currentAdjustmentAngleNeeded > maxAdjustementAngle)
            {
                rb2D.rotation += maxAdjustementAngle;
            }
            else
            {
                rb2D.rotation += -maxAdjustementAngle;
            }
        }

        //making the object move acording to its rotation
        Vector2 d = new Vector2(Mathf.Cos(rb2D.rotation * Mathf.Deg2Rad), Mathf.Sin(rb2D.rotation * Mathf.Deg2Rad));
        rb2D.velocity = (d * Time.deltaTime * 100f * speed);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall side"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player2") && tag.Equals("Player1"))
        {
            collision.gameObject.GetComponent<PlayerScript2>().takeDamage(dmg);//dealing damage to Player2(see PlayerScript2 line 61)
            collision.gameObject.GetComponent<PlayerScript2>().BurnFor(burntime);//setting him to burn for burntime sec(see PlayerScript2 line 111)
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player1") && tag.Equals("Player2"))
        {
            collision.gameObject.GetComponent<PlayerScript1>().takeDamage(dmg);//dealing damage to Player2(see PlayerScript1 line 61)
            collision.gameObject.GetComponent<PlayerScript1>().BurnFor(burntime);//setting him to burn for burntime sec(see PlayerScript1 line 111)
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Background"))
        {
            Destroy(gameObject);
        }
    }


    IEnumerator changeThroughSprites()
    {
        while (true)
        {
            sr.sprite = s1;
            yield return new WaitForSeconds(0.1f);
            sr.sprite = s2;
            yield return new WaitForSeconds(0.1f);
            sr.sprite = s3;
            yield return new WaitForSeconds(0.1f);
            sr.sprite = s4;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
