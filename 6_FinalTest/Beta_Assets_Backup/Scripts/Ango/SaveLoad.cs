using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public Vector3 point;

    void Awake(){
        point = new Vector3(transform.position.x,transform.position.y,transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "SavePoint" ){
            point.x = collision.transform.position.x;
            point.y = collision.transform.position.y;
            point.z = collision.transform.position.z;
        }
    }
    
    void Update(){
        if(Input.GetKeyDown(KeyCode.T)){
            transform.position = new Vector3(point.x,point.y,point.z);
        }
    }
}
