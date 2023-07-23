using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Main_Charactor : MonoBehaviour,IDataPersistence
{
    private Vector3 up=new Vector3(0,1f,0);
    public GameManager gm;
    public float mySpeed;
    public Animator myAnime;
    Rigidbody2D myRigi;
    public bool jump,canJump,isSword;
    public int Attack;
    private int jumpForce;
    public GameObject attackCollider;
    private bool hasTorch;
    public AudioClip[] myAudioClip;
    AudioSource myAudio;
    public int GetCoins = 0;
    public bool get_torch = false;
    private int num=0;
    public float scalesize;
    private bool issmall;
    Vector3 firstsize;
    float y,sumtime;
    // Start is called before the first frame update

    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
        this.GetCoins = data.GetCoins;
        this.gm.numKey = data.keys;
    }

    public void SaveData(ref GameData data)
    {
        data.playerPosition = this.transform.position;
        data.GetCoins = this.GetCoins;
        data.keys = this.gm.numKey;
    }

    private void Awake(){
        mySpeed = 9f;
        myAnime = GetComponent<Animator>();
        myRigi = GetComponent<Rigidbody2D>();
        jumpForce = 16;
        Attack = 0;
        isSword = false;
        hasTorch = false;
        myAudio = GetComponent<AudioSource>();
        scalesize = 1f;
        issmall = true;
        y = sumtime = 0f;
        firstsize = transform.localScale;
    }

    // replace by hsieh bagsystem
    
    // private void TorchCheck(){
    //     if(get_torch)
    //     {
    //         if(Input.GetKeyDown(KeyCode.K) && !hasTorch && (num%3==2)){
    //             myAnime.SetBool("Torch",true);
    //             hasTorch = true;
    //         }

    //         else if(Input.GetKeyDown(KeyCode.K) && hasTorch &&(num%3!=2)){
    //             myAnime.SetBool("Torch",false);
    //             hasTorch = false;
    //         }
    //     }
    // }

    // private void SwordCheck(){
    //     if(!isSword && Input.GetKeyDown(KeyCode.K) && (num%3==1)){
    //         isSword = true;
    //         myAnime.SetBool("isSword",isSword);
    //     }
    //     else if(Input.GetKeyDown(KeyCode.K) && isSword){
    //         Attack=0;
    //         isSword = false;
    //         myAnime.SetBool("isSword",isSword);
    //     }
    // }
    
    // private void switch_weapon(){
    //     if(get_torch){
    //         if(Input.GetKeyDown(KeyCode.K)){
    //             num++;
    //             if(num%3==1){
    //                 isSword = true;
    //                 myAnime.SetBool("isSword",isSword);
    //             }
    //             if(num%3==2){
    //                 Attack=0;
    //                 isSword = false;
    //                 myAnime.SetBool("isSword",isSword);
    //                 myAnime.SetBool("Torch",true);
    //                 hasTorch = true;
    //             }
    //             if(num%3==0){
    //                 myAnime.SetBool("Torch",false);
    //                 hasTorch = false;
    //             }
    //         }
    //     }
    // }

    // Add by hsieh for bag system
    public void bag_null()
    {
        hasTorch = false;
        isSword = false;
        myAnime.SetBool("Torch",false);
        myAnime.SetBool("isSword",false);
    }

    public void bag_sword()
    {
        hasTorch = false;
        myAnime.SetBool("Torch",false);
        isSword = true;
        myAnime.SetBool("isSword",true);
    }

    public void bag_torch()
    {
        isSword = false;
        myAnime.SetBool("isSword",false);
        hasTorch = true;
        myAnime.SetBool("Torch",true);
    }
    //

    private void AttackSound()
    {
        myAudio.PlayOneShot(myAudioClip[2]);
    }

    private void AttackCheck(){
        if(Input.GetKeyDown(KeyCode.J) && isSword){
            //gameObject.tag="Weapon";
            Attack++;
            if(Attack == 1) myAnime.SetTrigger("Attack1");
            if(Attack == 2) myAnime.SetTrigger("Attack2");
            if(Attack == 3) myAnime.SetTrigger("Attack3");
            //gameObject.tag="Ango";
            //myAnime.SetInteger("Attack",Attack);
        }
        if(Attack == 3) Attack = 0;
    }
    // Update is called once per frame
    private void Update(){
        // if(Input.GetKeyDown(KeyCode.Escape))
        // {
        //     transform.position=new Vector3(35f,39f,0f);
        // }
        transform.up=up;

        if(Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            myAudio.PlayOneShot(myAudioClip[1]);
            jump = true;
        }
        AttackCheck();
        //TorchCheck();
        //SwordCheck();
        //switch_weapon();
        turnsmall();
    }

    private void FixedUpdate()
    {
        float a=Input.GetAxisRaw("Horizontal");
        if(a!=0 && !myAudio.isPlaying && canJump)
        {
            myAudio.PlayOneShot(myAudioClip[0]);
        }
        if(a>0) transform.localScale = new Vector3(scalesize,scalesize,scalesize);
        else if(a<0) transform.localScale = new Vector3(-1f*scalesize,scalesize,scalesize);

        myAnime.SetFloat("Run",Mathf.Abs(a));

        if(jump){
            myRigi.AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
            jump=false;
            myAnime.SetBool("Jump",true);
        }

        myRigi.velocity = new Vector2(a*mySpeed,myRigi.velocity.y);
    }

    public void SetAttackColliderOn(){
        attackCollider.SetActive(true);
    }

    public void SetAttackColliderOff(){
        attackCollider.SetActive(false);
    }

    public bool equip_torch() {return hasTorch;}
    public bool equip_sword() {return isSword;}

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Coin"){
            GetCoins++;
            Destroy(collision.gameObject);
        }
    }

    // private void OnGUI(){
    //     GUI.skin.label.fontSize = 50;
    //     GUI.Label(new Rect(20,20,500,500),"Coin num: " + GetCoins);
    // }
    private void turnsmall()
    {
         if(Input.GetKeyDown(KeyCode.U))
        {
            issmall = !issmall;
            if(!issmall && sumtime < 1f)
            {
                sumtime += 0.02f;
                y = 0.5f*sumtime*sumtime + 0.5f;
                scalesize = y;
                transform.localScale = y*firstsize;
                if(y > 1f)
                {
                    sumtime = 1f;
                    transform.localScale = new Vector3 (1f,1f,1f);
                }
            }
            if(issmall && sumtime > 0f)
            {
                sumtime -= 0.02f;
                y = -0.5f*sumtime*sumtime + 1f;
                scalesize = y;
                transform.localScale = y*firstsize;
                if(y < 0.5f)
                {
                    sumtime = 1f;
                    transform.localScale = new Vector3 (0.5f,0.5f,0.5f);
                }
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(!issmall && other.gameObject.tag == "box")
        {
            other.gameObject.GetComponent<Rigidbody2D>().mass = 10000f;
        }
        if(issmall && other.gameObject.tag == "box")
        {
            other.gameObject.GetComponent<Rigidbody2D>().mass = 5f;
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "box")
        {
            other.gameObject.GetComponent<Rigidbody2D>().mass = 5f;
        }
    }
}

