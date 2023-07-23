using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chick : MonoBehaviour
{
    private AudioSource myAudio;
    private void Start() {
        myAudio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Weapon")
        {
            AudioSource.PlayClipAtPoint(myAudio.clip,new Vector3(transform.localPosition.x,transform.localPosition.y,-10f),0.7f);
            Destroy(gameObject);
        }
    }
}
