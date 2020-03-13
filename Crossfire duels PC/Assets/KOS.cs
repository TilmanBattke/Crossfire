using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KOS : MonoBehaviour
{
    public Image kO;
    public GameObject gOM;
    RectTransform rt;
    float max = 600;

    private void Awake()
    {
        rt = kO.gameObject.GetComponent<RectTransform>();
        this.enabled = false;
    }
    // Start is called before the first frame update
   

    void OnEnable() 

    {
        gOM.SetActive(false);
        rt.sizeDelta = Vector2.zero;
        StartCoroutine(getBigger());
    }

    IEnumerator getBigger()
    {
        for (int i = 10; i < 50;i++)
        {
            rt.sizeDelta = Vector2.one * (600f - 600f / ((float)i/10f));//TODO figure out whats this
            yield return new WaitForSecondsRealtime(0.01f);
        }
        kO.enabled = false;
        gOM.SetActive(true);
    }

}
