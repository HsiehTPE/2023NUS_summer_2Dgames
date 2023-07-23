using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_key : MonoBehaviour,IDataPersistence
{
    public GameObject ango_obj=null;
    public Main_Charactor ango=null;
    private float posx,posy,posz;
    public float y_max;
    private float tmpy;
    private float delta=5f;
    private float hello=3f;
    private bool willup;
    private Vector3 up=new Vector3(0f, 1f, 0f);
    private AudioSource myAudio;
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
        Debug.Assert(ango!=null);
        Debug.Assert(ango_obj!=null);
        posx=transform.localPosition.x;
        posy=transform.localPosition.y;
        posz=transform.localPosition.z;
        tmpy=posy+delta;
        myAudio = GetComponent<AudioSource>();
        willup = false;
    }

    

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(ango.gm.numKey);
        transform.up=up;
        
        float dist = Vector3.Distance(ango_obj.transform.localPosition, transform.localPosition);
        if(dist<hello){
            check_key();
        }
        if(willup && transform.localPosition.y <= y_max)
        {
            transform.localPosition += new Vector3(0f,0.05f,0f);
        }
    }

    private void check_key(){
        if(ango.gm.numKey>0)
        {
            if(Input.GetKey(KeyCode.E))
            {
                ango.gm.numKey--;
                myAudio.PlayOneShot(myAudio.clip);
                willup = true;
            }
        }
    }
}
