using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBurn : MonoBehaviour
{
    private GameObject mSmokeTemplate = null;
    private const int kLifeTime = 1600; // Alife for this number of cycles
    private int mLifeCount = 0; 
    // Start is called before the first frame update
    void Start()
    {
        mLifeCount = kLifeTime;
        mSmokeTemplate = Resources.Load<GameObject>("Prefabs/BurningSmoke");
        GameObject s = GameObject.Instantiate(mSmokeTemplate) as GameObject;
        s.transform.localPosition = transform.localPosition;
        s.transform.parent = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        mLifeCount --;
        if(mLifeCount<=0)
            Destroy(transform.gameObject);  // kills self
    }
}
