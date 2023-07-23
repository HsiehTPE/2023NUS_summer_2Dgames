using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    private bool isTriggered=false;
    private float delta=0.5f;
    public SpriteRenderer sp;
    private int num=0;
    private AudioSource myAudio;
    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        num++;
        if(num==1){
        myAudio.PlayOneShot(myAudio.clip);
        Color c = GetComponent<Renderer>().material.color;
        c.a = c.a * delta;
        GetComponent<Renderer>().material.color = c;
        }
        isTriggered=true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        num--;
        if(num==0){
            Color c = GetComponent<Renderer>().material.color;
            c.a = c.a / delta;
            GetComponent<Renderer>().material.color = c;
            isTriggered=false;
        }
    }

    public bool Triggered() {return isTriggered;}
}
