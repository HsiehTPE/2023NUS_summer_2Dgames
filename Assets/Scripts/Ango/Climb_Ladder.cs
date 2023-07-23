using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb_Ladder : MonoBehaviour
{
    private float vertical;
    private float speed;
    public bool isClimbing,touch;
    Animator myAnime;
    [SerializeField] private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        vertical = 0f;
        speed = 7f;
        isClimbing = touch = false;
        myAnime = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        if(touch && Mathf.Abs(vertical) > 0.1f) isClimbing = true;
    }

    private void FixedUpdate(){
        if(isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x,vertical*speed);
        }
        else
        {
            rb.gravityScale = 4f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Ladder"){
            touch = true;
            isClimbing = true;
            myAnime.SetBool("Climb",true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if(collision.tag == "Ladder"){
            touch = false;
            isClimbing = false;
            myAnime.SetBool("Climb",false);
        }
    }
}
