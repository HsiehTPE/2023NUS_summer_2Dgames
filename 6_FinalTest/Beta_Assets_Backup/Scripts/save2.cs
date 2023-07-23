using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class save2 : MonoBehaviour
{
    public GameObject save1;
    private bool isTriggered=false;
    private int num=0;

    private AudioSource myAudio;
    
    private float delta=0.5f;
    private float d1;
    public GameObject ice1,box1,box2;
    private Vector3 ice1_pos,box1_pos,box2_pos,ice1_scale;    
    public GameObject ango;
    // Start is called before the first frame update
    public Vector3 pos;

    
    void Start()
    {
        ice1_pos=ice1.transform.position;
        box1_pos=box1.transform.position;
        box2_pos=box2.transform.position;
        ice1_scale=ice1.transform.localScale;

        d1=ice1.GetComponent<ice_up>().delta;
        myAudio = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name=="ango"){
            save1.SetActive(false);
            num++;
            if(num==1){
            myAudio.PlayOneShot(myAudio.clip);
            Color c = GetComponent<Renderer>().material.color;
            c.a = c.a * delta;
            GetComponent<Renderer>().material.color = c;
            }
            isTriggered=true;
            pos=ango.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.name=="ango"){
            num--;
            if(num==0){
                Color c = GetComponent<Renderer>().material.color;
                c.a = c.a / delta;
                GetComponent<Renderer>().material.color = c;
                isTriggered=false;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
            {
                ango.transform.position=pos;
                ice1.transform.position=ice1_pos;
                box1.transform.position=box1_pos+new Vector3(0f,3f,0f);
                box2.transform.position=box2_pos+new Vector3(0f,3f,0f);
                ice1.transform.localScale=ice1_scale;
                
                ice1.GetComponent<ice_up>().delta=d1;

            }   
    }
  
}