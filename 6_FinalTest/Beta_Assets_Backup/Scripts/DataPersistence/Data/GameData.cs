using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData
{
    public Vector3 playerPosition;

    public int GetCoins;

    public int keys;


    public SerializableDictionary<string,bool> barrelDestroyed;
    public SerializableDictionary<string,bool> iceDestroyed;
    public SerializableDictionary<string,Vector3> boxPos;
    public SerializableDictionary<string,Vector3> iceScale;
    public SerializableDictionary<string,Vector3> doorPos;

    public GameData()
    {
        this.keys = 0;
        this.playerPosition = Vector3.zero;
        this.GetCoins = 0;
        this.barrelDestroyed = new SerializableDictionary<string,bool>();
        this.iceDestroyed = new SerializableDictionary<string,bool>();
        this.boxPos = new SerializableDictionary<string,Vector3>();
        this.iceScale = new SerializableDictionary<string,Vector3>();
        this.doorPos = new SerializableDictionary<string,Vector3>();
    }
}
