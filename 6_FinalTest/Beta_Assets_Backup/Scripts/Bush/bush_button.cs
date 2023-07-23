using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bush_button : MonoBehaviour
{
    public Main_Charactor hero_script=null;
    public GameObject hero = null;
    private float delta = 3.5f;

    public GameObject butt=null;
    public lever le=null;
    private GameObject mFireTemplate = null;
    private const int kLifeTime = 300; // Alife for this number of cycles
    private int mLifeCount = 0; 
    private bool onFire = false; 
    private bool destroyed = false;
    private bool extend = false;
    private AudioSource myAudio;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(butt!=null);
        // Debug.Assert(le!=null);
        Debug.Assert(hero!=null);
        // initialize the fire attribute
        butt.SetActive(false);
        mLifeCount = kLifeTime;
        mFireTemplate = Resources.Load<GameObject>("Prefabs/Fire");
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hero_script.equip_torch())
            fire_attribute();

    }

    void fire_attribute()
    {
        // measuring the distance between Ango and the onject
        float dis = Vector3.Distance(hero.transform.localPosition, transform.localPosition);
        if(dis<=delta)
        {
            if(Input.GetKeyDown(KeyCode.J))
            {
                if(!onFire)
                {
                    GameObject f2 = GameObject.Instantiate(mFireTemplate) as GameObject;
                    f2.transform.localPosition = transform.localPosition + new Vector3(-1f, 0f, -0.5f);
                    butt.SetActive(true);
                }
                onFire = true; 
            }
        }
        // the burning process
        if(onFire)
        {
            mLifeCount--;
            if(mLifeCount<=100)
                destroyed = true;
            if(mLifeCount<=200 && ! extend)
            {
                GameObject f1 = GameObject.Instantiate(mFireTemplate) as GameObject;
                f1.transform.localPosition = transform.localPosition + new Vector3(1f, 0f, -0.6f);
                extend = true;
            }
            SpriteRenderer s = GetComponent<SpriteRenderer>();
            Color c = s.color;
            const float delta = 0.005f;
            c.g -= delta;
            s.color = c;
            if(c.g <= 0)
                destroyed = true;
        }
        if(destroyed)
            Destroy(transform.gameObject);  // kills self
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Weapon" ){
            butt.SetActive(true);
            AudioSource.PlayClipAtPoint(myAudio.clip,transform.localPosition,1f);
            Destroy(gameObject);
        }
    }

    
}
