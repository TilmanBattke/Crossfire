using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zipzapAnimation : MonoBehaviour
{

    public SpriteRenderer sr;
    public Sprite s1;
    public Sprite s2;
    public Sprite s3;

    void Start()
    {
        StartCoroutine("SwitchThroughSprites");
    }
    //switches through the sprites in 0.1 sec intervals
    IEnumerator SwitchThroughSprites()
    {
        while (true)
        {
            sr.sprite = s1;
            yield return new WaitForSeconds(0.1f);
            sr.sprite = s2;
            yield return new WaitForSeconds(0.1f);
            sr.sprite = s3;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
