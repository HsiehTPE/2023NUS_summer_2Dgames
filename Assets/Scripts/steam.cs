using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class steam : MonoBehaviour
{
    private bool flag=false;
    private int num=0;
    public GameObject ango;
    public GameObject img;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        if(flag){
            num++;
            if(num>250){
                img.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(!flag){
            if(other.name=="ango"){
            flag=true;
            img.SetActive(true);
            }
        }
    }
}
