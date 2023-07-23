using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_up2 : MonoBehaviour
{
    private float posx,posy,posz;

    public button butt=null;
    private bool flag;
    private bool lever_state;
    private float Elevatorspeed;
    public float X_min=-1f,X_max=3.5f;
    void Start()
    {
        posx=transform.position.x;
        posy=transform.position.y;
        posz=transform.position.z;
        flag = true;
        Elevatorspeed = 2f;
        
    }

    // Update is called once per frame
    void Update()
    {
        lever_state = butt.Triggered();
        if(!lever_state)
        {
            if(transform.position.y < X_max){
                go_up();
            }
        }
        else
        {
            if(transform.position.y > X_min)
            Debug.Log(transform.position.y);
                go_down();
        }
    }

    private void go_up(){
        //transform.position += new Vector3(0f,Elevatorspeed * Time.deltaTime,0f);
        transform.position = Vector3.MoveTowards(transform.position,new Vector3(posx,X_max,posz),Elevatorspeed*Time.smoothDeltaTime);
    }

    private void go_down(){
        //transform.position -= new Vector3(0f,Elevatorspeed * Time.deltaTime,0f);
        transform.position = Vector3.MoveTowards(transform.position,new Vector3(posx,X_min,posz),Elevatorspeed*Time.smoothDeltaTime);

    }
}
