using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSpellTest : MonoBehaviour
{
    public float castTime;
    public float heal;

    public SpriteRenderer sR;
    public Sprite s1;
    public Sprite s2;
    public Sprite s3;
    public Sprite s4;

    void Start()
    {
        StartCoroutine(changeThroughSprites());
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

    //Todo fix this pls cant get refrence to colliding object

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
