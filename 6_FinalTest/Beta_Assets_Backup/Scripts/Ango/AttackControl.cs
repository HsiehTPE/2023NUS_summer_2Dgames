using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Barrel")) collision.GetComponent<Barrel>().FallDown();

        if(collision.gameObject.CompareTag("box")) collision.GetComponent<box>().FallDown();
        if(collision.gameObject.CompareTag("box_vill")) collision.GetComponent<box_vill>().FallDown();
    }
}
