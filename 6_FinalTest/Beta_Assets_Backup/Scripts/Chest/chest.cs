using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
    public Main_Charactor ango=null;
    public GameObject hero=null;
    public GameObject template=null;
    private float delta=3f;
    private float colorminus=0.7f;
    public bool UI=false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(ango!=null);
        Debug.Assert(hero!=null);
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(hero.transform.position, transform.position);
        if(dist<delta){
            UI=true;
            if(Input.GetKey(KeyCode.E))
            {
                UI=false;
                GenerateEmpytChest();
            }
        }
    }

    private void GenerateEmpytChest()
    {
        ango.gm.numKey++;
        template = Resources.Load<GameObject>("Prefabs/emptychest");
        GameObject p = GameObject.Instantiate(template) as GameObject;
        p.transform.position=transform.position;
        Destroy(gameObject);
    }
}
