using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torch : MonoBehaviour
{
    public GameObject hero;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(hero!=null);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=hero.transform.position-new Vector3(-0.5f,-0.1f,1f);
    }
}
