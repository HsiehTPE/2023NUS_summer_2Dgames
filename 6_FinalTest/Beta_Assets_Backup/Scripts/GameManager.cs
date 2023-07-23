using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Main_Charactor angoscript=null;
    public GameObject ango_obj=null;
    public Text numkey=null;
    public int numKey=0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(angoscript!=null);
        Debug.Assert(ango_obj!=null);
        // if (ango_obj) DontDestroyOnLoad(ango_obj);
        //angoscript.get_torch=true;
        //Debug.Assert(numkey!=null);
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKey(KeyCode.Q))
            Application.Quit();*/
        numkey.text = numKey.ToString();
    }
}
