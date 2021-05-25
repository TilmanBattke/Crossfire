using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HudM : MonoBehaviour
{
    Slider s1;
    Slider s2;
    Button[] SpellButtons;

    int[] SpellOnCD = { 0, 0, 0, 0, 0, 0, 0, 0};

    private void Awake()
    {

        SpellButtons = gameObject.GetComponentsInChildren<Button>();
        Debug.Log(SpellButtons.Length);

        Slider[] a = gameObject.GetComponentsInChildren<Slider>();
        foreach(Slider s in a)
        {
            if (s.tag.Equals("Player1"))
                s1 = s;
            else if(s.tag.Equals("Player2"))
                s2 = s;
        }

    }

    public void setOnCd(string c, int a, bool b)
    {
        a -= 1;
        if (c.Equals("Player2"))
            a += 4;
        if (b)
            SpellOnCD[a]++;
        else
            SpellOnCD[a]--;

        if (SpellOnCD[a] == 0)
            SpellButtons[a].interactable = true;
        else
            SpellButtons[a].interactable = false;
    }

    public void setSlider(string b, float a)
    {
        if (b.Equals("Player1"))
            s1.value = a;
        else
            s2.value = a;

    }

    public void setSpellIcon(string c, int a,Sprite b)
    {
        a -= 1;
        if (c.Equals("Player1"))
            SpellButtons[a].GetComponent<Image>().sprite = b;
        else
            SpellButtons[a + 4].GetComponent<Image>().sprite = b;
    }

    public void setAllOnCd(string a, bool b)
    {
        if (a.Equals("Player1"))
        {
            setOnCd("Player1", 1, b);
            setOnCd("Player1", 2, b);
            setOnCd("Player1", 3, b);
            setOnCd("Player1", 4, b);
        }
        else
        {
            setOnCd("Player2", 1, b);
            setOnCd("Player2", 2, b);
            setOnCd("Player2", 3, b);
            setOnCd("Player2", 4, b);
        }
    }

    public void setOnclickEvent(string c,int a, UnityAction b)
    {
        a -= 1;
        if (c.Equals("Player2"))
            a += 4;

        SpellButtons[a].onClick.AddListener(b);


    }

}
