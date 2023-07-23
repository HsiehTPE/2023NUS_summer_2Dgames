using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSupport : MonoBehaviour
{
    public GameObject ango=null;
    private Vector3 minus=new Vector3(0f,4f,-10f);
    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(ango!=null);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition=ango.transform.localPosition+minus;
    }
}
