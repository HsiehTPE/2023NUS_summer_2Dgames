using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class save2_1 : MonoBehaviour
{
    private bool isTriggered=false;
    private int num=0;

    private AudioSource myAudio;
    
    private float delta=0.5f;
    private float d1;
    public GameObject ice1;
    private Vector3 ice1_pos,ice1_scale;    
    public GameObject ango;
    // Start is called before the first frame update
    public Vector3 pos;

    
    void Start()
    {
        ice1_pos=ice1.transform.position;
        ice1_scale=ice1.transform.localScale;

        d1=ice1.GetComponent<ice>().delta;
        myAudio = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        num++;
        if(num==1&&collision.name=="ango"){
        myAudio.PlayOneShot(myAudio.clip);
        Color c = GetComponent<Renderer>().material.color;
        c.a = c.a * delta;
        GetComponent<Renderer>().material.color = c;
        }
        isTriggered=true;
        pos=ango.transform.position;
    }

    private void OnTriggerExit2D(Collider2D other) {
        num--;
        if(num==0&&other.name=="ango"){
            Color c = GetComponent<Renderer>().material.color;
            c.a = c.a / delta;
            GetComponent<Renderer>().material.color = c;
            isTriggered=false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
            {
                ango.transform.position=pos;
                ice1.transform.position=ice1_pos;
                ice1.transform.localScale=ice1_scale;
                ice1.GetComponent<ice>().delta=d1;

            }   
    }
  
}