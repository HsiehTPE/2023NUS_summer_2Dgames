using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class UI_eastnpc : MonoBehaviour
{
    // public GameObject trigger_object;
    public GameObject trigger_hint;
    public GameObject dialog;
    private bool hint = false; 
    AudioSource myAudio;
    private bool first = false;
    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hint)
        {
            trigger_hint.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(!first)
                {
                    myAudio.PlayOneShot(myAudio.clip);
                    first = true;
                }
                dialog.SetActive(true);
            }
        }
        else
        {
            trigger_hint.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ango")
        {
            hint = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Ango")
        {
            hint = false;
        }
    }
}
