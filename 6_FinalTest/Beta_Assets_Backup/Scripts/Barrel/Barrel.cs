using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour,IDataPersistence
{
    public GameObject[] gos;
    Animator Anime;
    AudioSource myAudio;
    public bool isDestroyed;

    [SerializeField] private string id;
    
    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    public void LoadData(GameData data)
    {
        data.barrelDestroyed.TryGetValue(id,out isDestroyed);
        if(isDestroyed)
        {
            gameObject.SetActive(false);
        }
    }

    public void SaveData(ref GameData data)
    {
        if(data.barrelDestroyed.ContainsKey(id))
        {
            data.barrelDestroyed.Remove(id);
        }
        data.barrelDestroyed.Add(id,isDestroyed);
    }

    void Awake(){
        Anime = GetComponent<Animator>();
        myAudio = GetComponent<AudioSource>();
        isDestroyed = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Weapon")
        {
            isDestroyed = true;
            FallDown();
        }
    }

    public void FallDown()
    {
        myAudio.PlayOneShot(myAudio.clip);
        Vector3 pos = transform.position;
        Instantiate(gos[Random.Range(0,gos.Length)],pos,Quaternion.identity);
        Anime.SetBool("Break",true);
        Destroy(gameObject,0.6f);
    }
}
