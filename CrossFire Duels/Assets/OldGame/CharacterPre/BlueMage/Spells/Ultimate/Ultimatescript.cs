using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ultimatescript : MonoBehaviour
{
    SpriteRenderer sr;
    public Sprite s1;
    public Sprite s2;
    public Sprite s3;
    public float ultimateDuration;

    
    private void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine(changeThroughSprites());
        StartCoroutine(waitTillDestroy());
    }

    private IEnumerator changeThroughSprites()
    {
        while (true)
        {
            sr.sprite = s1;
            yield return new WaitForSeconds(0.20f);
            sr.sprite = s2;
            yield return new WaitForSeconds(0.20f);
            sr.sprite = s3;
            yield return new WaitForSeconds(0.20f);
        }
    }

    private IEnumerator waitTillDestroy()
    {
        yield return new WaitForSeconds(ultimateDuration);
        Destroy(gameObject);
    }
}
