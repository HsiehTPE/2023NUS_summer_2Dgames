using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boar : MonoBehaviour
{
    public Vector3 targetposition;
    public float MySpeed=0.01f;
    Animator Anime;
    Vector3 OriginPosition,TurnPoint;
    bool isFirstTimeIdle;
    public GameObject player;
    public int EnemyLife;

    private void Awake(){
        Anime = GetComponent<Animator>();
        OriginPosition = new Vector3(transform.position.x,transform.position.y,transform.position.z);
        isFirstTimeIdle = true;
        EnemyLife = 3;
    }

    void Update(){
        if(Vector3.Distance(player.transform.localPosition,transform.localPosition) < 1.8f){
            if(Anime.GetCurrentAnimatorStateInfo(0).IsName("Boar_Attack")){
                return;
            }
            Anime.SetTrigger("Attack");
            return;
        }

        if(transform.position.x == targetposition.x){
            Anime.SetTrigger("Idle");
            TurnPoint = OriginPosition;
            transform.localScale = new Vector3(-1.0f,1.0f,1.0f);
            isFirstTimeIdle = false;
        }
        else if(transform.position.x == OriginPosition.x){
            if(!isFirstTimeIdle){
                Anime.SetTrigger("Idle");
            }
            TurnPoint = targetposition;
            transform.localScale = new Vector3(1.0f,1.0f,1.0f);
        }

        if(Anime.GetCurrentAnimatorStateInfo(0).IsName("Boar_Walk")){
            transform.position = Vector3.MoveTowards(transform.position,TurnPoint,MySpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Weapon" ){
            EnemyLife--;
            if(EnemyLife >= 1){

            }
            else if(EnemyLife < 1){
                Anime.SetTrigger("Die");
                Destroy(gameObject,1.2f);
            }
        }
    }
}
