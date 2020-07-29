using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSpellTest : MonoBehaviour
{
    public float castTime;
    public float heal;
    PlayerScript1 casterPS;

    public SpriteRenderer sR;
    public Sprite s1;
    public Sprite s2;
    public Sprite s3;
    public Sprite s4;

    private void Awake()
    {
        PlayerScript1[] pss = GameObject.FindObjectsOfType<PlayerScript1>();
        foreach(PlayerScript1 ps in pss)
        {
            if (gameObject.GetComponent<CircleCollider2D>().bounds.Contains(ps.gameObject.transform.position)){
                casterPS = ps;
                Debug.Log(casterPS);
            }
        }
    }
    void Start()
    {
        StartCoroutine(changeThroughSprites());
        StartCoroutine(healScript(casterPS));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    IEnumerator healScript(PlayerScript1 ps)
    {
        float c = heal / 50f / castTime;


        ps.castingSpell(castTime);
        for (int i = (int)(50f * castTime); i > 0; i--)
        {
            ps.takeDamage(-1*c);
            yield return new WaitForSeconds(0.02f);
        }
        Destroy(gameObject);
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
            sR.sprite = s4;
            yield return new WaitForSeconds(0.1f);
        }
    }


}
