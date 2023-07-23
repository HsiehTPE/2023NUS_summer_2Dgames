using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class go_to_village : MonoBehaviour
{
    private bool played=false;
    public GameObject hero;
    public float delta=3f;
    private AudioSource myAudio;

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(hero.transform.position, transform.position);
        if(dist<delta){
            if(!played){
                played=!played;
                myAudio.PlayOneShot(myAudio.clip);
            }
            if(Input.GetKey(KeyCode.E)){
                SceneManager.LoadScene("origin_village");
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
    }
}
