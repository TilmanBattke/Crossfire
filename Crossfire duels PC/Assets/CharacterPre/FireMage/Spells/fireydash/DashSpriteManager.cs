using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSpriteManager : MonoBehaviour
{
    public float dashTime;
    public float dashspeed;

    private void Start()
    {
        Invoke("DestroyObject", dashTime);
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
