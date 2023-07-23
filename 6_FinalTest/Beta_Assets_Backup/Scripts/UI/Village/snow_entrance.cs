using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snow_entrance : MonoBehaviour
{
    public string[] sentences; 
    private int index;
    public float typingSpeed;
    public GameObject continueButton;
    public GameObject TextPlane;
    // public TextMeshProUGUI textDisplay;


    // IEnumerator Type()
    // {
    //     // index = 0;
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

    // void OnEnable()
    // {
    //     index = 0;
    //     StartCoroutine(Type());
    //     // index = 0;
    // }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if(textDisplay.text == sentences[index])
        // {
        //     continueButton.SetActive(true);
        //     // if(Input.GetKeyDown(KeyCode.E))
        //     //     NextSentence();
        // }
    }
}
