using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hero : MonoBehaviour
{
    public GameObject ango=null;
    private const float kHeroSpeed = 5f;  // 20-units in a second
    private float mHeroSpeed = kHeroSpeed;
    private Vector3 up=new Vector3(0f, 1f, 0f);
    private bool torch=true;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Assert(gm!=null);
        //ango = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q)){
            Application.Quit();
        }
        if (Input.GetKey(KeyCode.W)){
            transform.position += transform.up * (mHeroSpeed * Time.smoothDeltaTime * 2);
        }
        if (Input.GetKey(KeyCode.A)){
            transform.position -= transform.right * (mHeroSpeed * Time.smoothDeltaTime);
        }
        if (Input.GetKey(KeyCode.D)){
            transform.position += transform.right * (mHeroSpeed * Time.smoothDeltaTime);
        }
        transform.up=up;
    }

    public string GetKeyNum() {return "Key Numbers:  " + gm.numKey ;}
}
