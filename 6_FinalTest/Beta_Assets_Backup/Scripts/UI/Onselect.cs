// using System.Threading.Tasks.Dataflow;
// using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.
using UnityEngine;

public class Onselect : MonoBehaviour, ISelectHandler
{
    public Bag bag;

    public void OnSelect(BaseEventData eventData)
    {
        bag.setCurrentItem(gameObject.name);
        Debug.Log(gameObject.name);
    }
}
