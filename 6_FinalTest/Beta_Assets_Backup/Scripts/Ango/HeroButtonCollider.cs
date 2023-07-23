// using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroButtonCollider : MonoBehaviour
{
    Main_Charactor HeroScript;

    private int num;
    // Start is called before the first frame update
    private void Awake()
    {
        HeroScript = GetComponentInParent<Main_Charactor>();
        num = 0;
    }

    void Update(){
        // Debug.Log(HeroScript.canJump);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if((collision.tag == "Ground"||collision.tag == "box"||collision.tag == "Barrel"||collision.tag == "box_vill")){
            HeroScript.canJump = true;
            HeroScript.myAnime.SetBool("Jump",false);
            num++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if((collision.tag == "Ground"||collision.tag == "box"||collision.tag == "Barrel"||collision.tag == "box_vill"))
        {
            num--;
            if(num == 0) HeroScript.canJump = false;
        }
    }
}
