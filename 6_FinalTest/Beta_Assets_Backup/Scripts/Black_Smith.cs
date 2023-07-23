using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black_Smith : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource myAudio;
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    private void audioplay()
    {
        myAudio.PlayOneShot(myAudio.clip);
    }
}
