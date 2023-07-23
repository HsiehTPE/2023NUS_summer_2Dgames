using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mill_rotation : MonoBehaviour
{
    private float rotationspeed;
    // Start is called before the first frame update
    void Start()
    {
        rotationspeed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f,0f,rotationspeed * Time.deltaTime);
    }
}
