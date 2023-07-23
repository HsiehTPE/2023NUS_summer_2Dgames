using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box_vill : MonoBehaviour
{
    private float posx,posy,posz;
    public GameObject myson=null;
    private int life=2;
    private AudioSource myAudio;
    private static int num=0;
    private float tmp;
    public float delta;
    // Start is called before the first frame update
    private void Awake() {
        myson=Resources.Load<GameObject>("Prefabs/box");
        posx=transform.position.x;
        posy=transform.position.y;
        posz=transform.position.z;
        myAudio = GetComponent<AudioSource>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Weapon")
        {
            life--;
            if(life < 1){
                AudioSource.PlayClipAtPoint(myAudio.clip,transform.position,1f);
                Destroy(gameObject);
            }
        }
    }*/

    public void FallDown() 
    {
        AudioSource.PlayClipAtPoint(myAudio.clip,transform.position,1f);
        //GameObject f1 = GameObject.Instantiate(myson) as GameObject;
        //num++;
        //tmp=delta+posy;
        //f1.transform.position = new Vector3(posx,tmp,posz);
        Destroy(gameObject);
        //transform.position=new Vector3(posx,tmp,posz);
    }
}
