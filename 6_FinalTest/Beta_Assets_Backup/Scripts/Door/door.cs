using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour,IDataPersistence
{
    private float MySpeed=3f;

    public GameManager gm;
    public GameObject ango_obj=null;
    public button thebutton;
    public Main_Charactor ango=null;
    private float posx,posy,posz;
    private float tmpy;
    private float delta=5f;
    private float hello=3f;
    private Vector3 up=new Vector3(0f, 1f, 0f);
    // Start is called before the first frame update

    [SerializeField] private string id;
    
    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    public void LoadData(GameData data)
    {
        if(data.doorPos.ContainsKey(id))
        {
            transform.position = data.doorPos[id];
        }
    }

    public void SaveData(ref GameData data)
    {
        if(data.doorPos.ContainsKey(id))
        {
            data.doorPos.Remove(id);
        }
        data.doorPos.Add(id,transform.position);
    }





    void Start()
    {
        
        Debug.Assert(thebutton!=null);
        //Debug.Assert(ango!=null);
        Debug.Assert(ango_obj!=null);
        Debug.Assert(gm!=null);
        posx=transform.localPosition.x;
        posy=transform.localPosition.y;
        posz=transform.localPosition.z;
        tmpy=posy+delta;
        ango=ango_obj.GetComponent<Main_Charactor>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(ango.gm.numKey);
        bool trigger=thebutton.Triggered();
        if(trigger){
            transform.localPosition = Vector3.MoveTowards(transform.localPosition,new Vector3(posx,tmpy,posz),MySpeed*Time.smoothDeltaTime);
        }
        else{
            transform.localPosition = Vector3.MoveTowards(transform.localPosition,new Vector3(posx,posy,posz),MySpeed*Time.smoothDeltaTime);
        }
        
        transform.up=up;
        /*
        float dist = Vector3.Distance(ango_obj.transform.localPosition, transform.localPosition);
        if(dist<hello){
            check_key();
        }
        */
    }

    private void check_key(){
        if(ango.gm.numKey>0)
        {
            if(Input.GetKey(KeyCode.E)){
                ango.gm.numKey--;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition,new Vector3(posx,tmpy,posz),MySpeed*Time.smoothDeltaTime);
            }
        }
    }
}
