using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class torch_chest : MonoBehaviour
{
    public Main_Charactor ango=null;
    public GameObject hero=null;
    public GameObject template=null;
    public GameObject dialog;
    private float delta=3f;
    private float colorminus=0.7f;
    public bool UI=false;

    // // add ui system
    // public string[] sentences; 
    // private int index;
    // public float typingSpeed;
    // public GameObject continueButton;
    // public GameObject TextPlane;
    // public TextMeshProUGUI textDisplay;
    // // new add ens here

    // // add ui system
    // IEnumerator Type()
    // {
    //     foreach(char letter in sentences[index].ToCharArray())
    //     {
    //         textDisplay.text += letter;
    //         yield return new WaitForSeconds(0.02f);
    //     }
    // }

    // public void NextSentence()
    // {
    //     continueButton.SetActive(false);
    //     if(index < sentences.Length-1)
    //     {
    //         index ++;
    //         textDisplay.text = "";
    //         StartCoroutine(Type());
    //     }
    //     else
    //     {
    //             textDisplay.text = "";
    //             continueButton.SetActive(false);
    //             TextPlane.SetActive(false);
    //             // 2
    //             // Time.timeScale = 1f; 
    //     }
    // }
    // // new add ends here

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(ango!=null);
        Debug.Assert(hero!=null);
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(hero.transform.localPosition, transform.localPosition);
        if(dist<delta){
            UI=true;
            if(Input.GetKey(KeyCode.E))
            {
                UI=false;
                GenerateEmpytChest();
                if(Input.GetKeyDown(KeyCode.E))
                {
                    dialog.SetActive(true);
                }
            }
        }

        // // add ui system
        // if(textDisplay.text == sentences[index])
        // {
        //     continueButton.SetActive(true);
        //     if(Input.GetKeyDown(KeyCode.E))
        //         NextSentence();
        // }
        // // new add ends here
    }

    private void GenerateEmpytChest()
    {
        // ango.gm.numKey++;
        ango.get_torch = true;
        template = Resources.Load<GameObject>("Prefabs/hallows_emptychest");
        GameObject p = GameObject.Instantiate(template) as GameObject;
        p.transform.localPosition=transform.localPosition;
        Destroy(gameObject);
    }
}
