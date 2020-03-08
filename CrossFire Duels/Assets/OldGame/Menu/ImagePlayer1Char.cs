using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImagePlayer1Char : MonoBehaviour
{
    Image image;

    public Sprite char1;
    public Sprite char2;
    public Sprite char3;


    private void Awake()
    {
        image = gameObject.GetComponent<Image>();
    }

    private void Start()
    {
        image.sprite = char1;
    }
    // Update is called once per frame
    void Update()
    {
        if (GameInfo.Player1char.Equals("Mage3"))
        {
            image.sprite = char3;
        }else if (GameInfo.Player1char.Equals("FireMage"))
        {
            image.sprite = char2;
        }
        else
        {
            image.sprite = char1;
        }
    }
}
