using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Up : MonoBehaviour
{
    private int GetCoins = 0;

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Coin"){
            GetCoins++;
            Destroy(collision.gameObject);
        }
    }

    private void OnGUI(){
        GUI.skin.label.fontSize = 50;
        GUI.Label(new Rect(20,20,500,500),"Coin num: " + GetCoins);
    }
}
