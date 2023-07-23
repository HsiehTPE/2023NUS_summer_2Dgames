using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class save1 : MonoBehaviour
{
    private bool isTriggered=false;
    private int num=0;

    private AudioSource myAudio;
    
    private float delta=0.5f;
    private float d1,d2;
    public GameObject ice1,ice2,box;
    private Vector3 ice1_pos,ice2_pos,box_pos,ice1_scale,ice2_scale;    
    public GameObject ango;
    // Start is called before the first frame update
    public Vector3 pos;

    
    void Start()
    {
        ice1_pos=ice1.transform.position;
        ice2_pos=ice2.transform.position;
        box_pos=box.transform.position;
        ice1_scale=ice1.transform.localScale;
        ice2_scale=ice2.transform.localScale;

        d1=ice1.GetComponent<ice>().delta;
        d2=ice2.GetComponent<ice_up>().delta;
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
                ice2.transform.position=ice2_pos;
                ice1.transform.localScale=ice1_scale;
                ice2.transform.localScale=ice2_scale;
                box.transform.position=box_pos+new Vector3(0f,3f,0f);
                ice1.GetComponent<ice>().delta=d1;
                ice2.GetComponent<ice_up>().delta=d2;

            }   
    }
  
}