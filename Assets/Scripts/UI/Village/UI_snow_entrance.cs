using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_snow_entrance : MonoBehaviour
{
    // public GameObject trigger_object;
    public GameObject trigger_hint;
    // public switch_scene a;
    // public GameObject dialog;
    private bool hint = false; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hint)
        {
            trigger_hint.SetActive(true);
            // if(Input.GetKeyDown(KeyCode.E))
            // {
            //     // dialog.SetActive(true);
            //     // a.change_to_levelone();
            // }
        }
        else
        {
            trigger_hint.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "ango")
        {
            hint = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name == "ango")
        {
            hint = false;
        }
    }
}
