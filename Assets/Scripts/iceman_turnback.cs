using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceman_turnback : MonoBehaviour
{
    public GameObject Ango;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ango")
            transform.localScale = new Vector3(-1f,1f,1f);    
    }
    
    private void Update() {
        if(transform.position.x + 2f < Ango.transform.position.x)
            transform.localScale = new Vector3(1f,1f,1f);
    }
}