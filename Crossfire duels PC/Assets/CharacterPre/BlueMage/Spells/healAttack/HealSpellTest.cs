using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSpellTest : MonoBehaviour
{
    public float castTime;
    public float heal;
    PlayerScript1 ps1;
    PlayerScript2 ps2;

    public SpriteRenderer sR;
    public Sprite s1;
    public Sprite s2;
    public Sprite s3;
    public Sprite s4;

    private void Awake()
    {
        ps1 = GameObject.FindObjectOfType<PlayerScript1>();
        ps2 = GameObject.FindObjectOfType<PlayerScript2>();
    }
    void Start()
    {
        Debug.Log(heal);
        StartCoroutine("healScript");
        StartCoroutine(changeThroughSprites());
    }

    IEnumerator healScript()
    {
        float c = heal / 50f / castTime;
        if (gameObject.tag.Equals("Player1"))
        {

            ps1.castingSpell(castTime);
            for (int i = (int)(50f * castTime); i > 0; i--)
            {
                ps1.takeDamage(-1*c);
                yield return new WaitForSeconds(0.02f);
            }
            Destroy(gameObject);
        }
        else if (gameObject.tag.Equals("Player2"))
        {

            ps2.castingSpell(castTime);  
            for (int i = (int)(50f * castTime); i > 0; i--)
            {
                ps2.takeDamage(-1*c);
                yield return new WaitForSeconds(0.02f);
            }
            Destroy(gameObject);
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
