using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_2 : MonoBehaviour
{
    public lever a;
    private bool flag;
    private bool lever_state;
    private float Elevatorspeed;
    private float X_min,X_max;
    void Start()
    {
        Debug.Assert(a!=null);
        flag = false;
        Elevatorspeed = 2f;
        X_min = 55f;
        X_max = 70f;
    }

    // Update is called once per frame
    void Update()
    {
        lever_state = a.Getturn();
        if(lever_state == true)
        {
            if(flag == false)
            {
                transform.position += new Vector3(Elevatorspeed * Time.deltaTime,0f,0f);
            }
            if(flag == true)
            {
                transform.position -= new Vector3(Elevatorspeed * Time.deltaTime,0f,0f);
            }
            if(transform.position.x >= X_max || transform.position.x <= X_min)
                flag = !flag;
        }
    }
}
