using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TileSystem;

public class TileCache : MonoBehaviour
{
    public static TileCache current;


    public Dictionary<string, TileObject> objectCache;
    public TileObject[] tObjects;

    public void PopulateCache(){
        objectCache = new Dictionary<string, TileObject>();
        tObjects = Resources.LoadAll<TileObject>("Objects");
        foreach (TileObject tObject in tObjects){
            objectCache.Add(tObject.objectName, tObject);
        }
    }

    void Awake(){
        current = this;
        PopulateCache();
    }

}
