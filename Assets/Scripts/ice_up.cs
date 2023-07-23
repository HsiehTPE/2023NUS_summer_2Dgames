using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ice_up : MonoBehaviour,IDataPersistence
{
    private Vector3 up=new Vector3(0f,1f,0f);
    public GameObject weapon=null;
    private int life=3;
    public Main_Charactor hero_script=null;
    public GameObject hero=null;
    public float delta;
    public float minus;
    private AudioSource myAudio;
    private bool canplay;
    public bool icedes = false;
    // Start is called before the first frame update

    [SerializeField] private string id;
    
    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    public void LoadData(GameData data)
    {
        data.iceDestroyed.TryGetValue(id,out icedes);
        if(data.iceScale.ContainsKey(id))
        {
            transform.localScale = data.iceScale[id];
        }
        if(icedes)
        {
            gameObject.SetActive(false);
        }
    }

    public void SaveData(ref GameData data)
    {
        if(data.iceDestroyed.ContainsKey(id))
        {
            data.iceDestroyed.Remove(id);
        }
        data.iceDestroyed.Add(id,icedes);

        if(data.iceScale.ContainsKey(id))
        {
            data.iceScale.Remove(id);
        }
        data.iceScale.Add(id,transform.localScale);
    }

    void Start()
    {
        Debug.Assert(hero!=null);
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.up=up;
        if(hero_script.equip_torch())
        {
            float dist = Vector3.Distance(hero.transform.position, transform.position);
            if(dist<delta)
            {
                if(!myAudio.isPlaying)
                    canplay = true;
                float sx = transform.localScale.x;
                float s=transform.localScale.y;
                if(s>0){
                    s -= minus*Time.smoothDeltaTime;
                    delta-=minus*Time.smoothDeltaTime;
                }
                transform.localScale = new Vector3(sx, s, 1);
                if(s<1f){
                    s=0.001f;
                    icedes = true;
                }
            }
            else
                canplay = false;
            if(canplay && !myAudio.isPlaying)
                myAudio.PlayOneShot(myAudio.clip);
            if(!canplay)
                myAudio.Stop();
        }
    }

}
