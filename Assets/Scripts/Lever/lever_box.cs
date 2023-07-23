using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever_box : MonoBehaviour
{
    private GameObject box_template;
    private bool lever_state;
    private bool canturn;
    Animator myAnim;
    private AudioSource myAudio;
    // Start is called before the first frame update
    void Start()
    {
        box_template=Resources.Load<GameObject>("Prefabs/box");
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
            myAudio.PlayOneShot(myAudio.clip);
            if(!lever_state){
            GameObject box= GameObject.Instantiate(box_template) as GameObject;
            box.transform.position=new Vector3(60f,35f,0f);
            }
            lever_state = !lever_state;
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