using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueMageMobile : MonoBehaviour
{

    HudM HUD;

    public GameObject Spell1;
    GameObject Spell2;
    GameObject Spell3;
    GameObject Spell4;

    PlayerScript ps;

    bool[] OnCD = { false, false, false, false };


    private void Start()
    {

        HUD = GameObject.FindObjectOfType<HudM>();
        ps = gameObject.GetComponent<PlayerScript>();
        HUD.setOnclickEvent(gameObject.tag, 1, CSpell1);
        HUD.setSpellIcon(tag, 1, Spell1.GetComponent<SpellInfo>().Icon);

    }


    public void CSpell1()
    {
        if(!OnCD[0])
            StartCoroutine("CastSpell1");
    }

    public IEnumerator CastSpell1()
    {

        GameObject spell = Instantiate(Spell1, gameObject.transform.position, gameObject.transform.rotation);
        spell.tag = tag;
        if (tag.Equals("Player1"))
        {
            spell.layer = 10;
        }
        else
        {
            spell.layer = 11;
        }
        Transform tf = spell.transform;
        float rotation = Mathf.Atan2(ps.getTarget().y, ps.getTarget().x);
        if (tag.Equals("Player1"))
        {
            rotation = Mathf.Abs(rotation * Mathf.Rad2Deg);
        }
        else
        {
            rotation = -1 * Mathf.Abs(rotation * Mathf.Rad2Deg);
        }
        tf.rotation = Quaternion.Euler(new Vector3(0, 0, rotation));
        OnCD[0] = true;
        HUD.setOnCd(tag, 1, true);
        yield return new WaitForSeconds(Spell1.GetComponent<SpellInfo>().Cooldown);
        OnCD[0] = false;
        HUD.setOnCd(tag, 1, false);
    }
}
