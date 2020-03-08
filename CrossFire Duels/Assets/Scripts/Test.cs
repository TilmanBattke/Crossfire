using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour
{
    Transform tr;

    PlayerScript p1s;
    PlayerScript p2s;
    // Start is called before the first frame update
    void Start()
    { 

        PlayerScript[] a = GameObject.FindObjectsOfType<PlayerScript>();

        foreach (PlayerScript ps in a)
        {
            if (ps.tag.Equals("Player1"))
            {
                p1s = ps;
            }
            else if (ps.tag.Equals("Player2"))
            {
                p2s = ps;
            }
        }

        tr = gameObject.transform;
        p1s.setTarget(new Vector3(0f, -3.5f, 0f));
        p2s.setTarget(new Vector3(0f, 3.5f, 0f));

    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                int id = touch.fingerId;
                if (!EventSystem.current.IsPointerOverGameObject(id))
                {

                    Vector2 wPos = (Vector2)Camera.main.ScreenToWorldPoint(touch.position);
                    Vector3 position = new Vector3(wPos.x, wPos.y, 0f);
                    if (position.y > 0)
                    {
                        p2s.setTarget(position);
                    }
                    else
                    {
                        p1s.setTarget(position);
                    }
                }
            }
        }
    }
}
