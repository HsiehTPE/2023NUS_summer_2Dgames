using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever : MonoBehaviour
{
    private bool lever_state;
    private bool canturn;
    private AudioSource myAudio;
    Animator myAnim;
    // Start is called before the first frame update
    void Start()
    {
        lever_state = false;
        canturn = false;
        myAnim = GetComponent<Animator>();
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canturn)
        {
            lever_state = !lever_state;
            myAudio.PlayOneShot(myAudio.clip);
        }      
        if(lever_state)
            myAnim.SetBool("inverturn",true);
        if(!lever_state)
            myAnim.SetBool("inverturn",false);
        
    }

    private void FixedUpdate()
    {
        myAnim.SetBool("Turn",lever_state);
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if(collision.name == "ango")
            canturn = true;
    } 
    private void OnTriggerExit2D(Collider2D collision) 
    {
        if(collision.name == "ango")
            canturn = false;
    }

    public bool Getturn()
    {
        return lever_state;
    }
}