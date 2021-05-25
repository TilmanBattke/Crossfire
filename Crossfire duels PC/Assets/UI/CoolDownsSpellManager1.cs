using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownsSpellManager1 : MonoBehaviour
{
    Image s1;
    Image s2;
    Image s3;
    Image s4;

    private int onCD1 = 0;
    private int onCD2 = 0;
    private int onCD3 = 0;
    private int onCD4 = 0;

    Color grey = Color.grey;
    Color normal = Color.white;

    private void Awake()
    {
        Image[] a = gameObject.GetComponentsInChildren<Image>(true);
        s1 = a[0];
        s2 = a[1];
        s3 = a[2];
        s4 = a[3];
    }


    public void setSpellIcons(Sprite[] s)
    {
        setspell1(s[0]);
        setspell2(s[1]);
        setspell3(s[2]);
        setspell4(s[3]); 
    }

    private void setspell1(Sprite s)
    {
        s1.sprite = s;
    }
    private void setspell2(Sprite s)
    {
        s2.sprite = s;
    }
    private void setspell3(Sprite s)
    {
        s3.sprite = s;
    }
    private void setspell4(Sprite s)
    {
        s4.sprite = s;
    }



    public void setIcon1OnCD(bool a)
    {
        if (a)
        {
            onCD1++;
        }
        else
        {
            onCD1--;
        }

        if (onCD1 > 0)
        {
            s1.color = grey;
        }
        else
        {
            s1.color = normal;
        }
    }


    public void setIcon2OnCD(bool a)
    {
        if (a)
        {
            onCD2++;
        }
        else
        {
            onCD2--;
        }

        if (onCD2 > 0)
        {
            s2.color = grey;
        }
        else
        {
            s2.color = normal;
        }
    }


    public void setIcon3OnCD(bool a)
    {
        if (a)
        {
            onCD3++;
        }
        else
        {
            onCD3--;
        }

        if (onCD3 > 0)
        {
            s3.color = grey;
        }
        else
        {
            s3.color = normal;
        }
    }


    public void setIcon4OnCD(bool a)
    {
        if (a)
        {
            onCD4++;
        }
        else
        {
            onCD4--;
        }

        if (onCD4 > 0)
        {
            s4.color = grey;
        }
        else
        {
            s4.color = normal;
        }
    }


    public void setAllIconsOnCD(bool a)
    {
        setIcon1OnCD(a);
        setIcon2OnCD(a);
        setIcon3OnCD(a);
        setIcon4OnCD(a);
    }

}
