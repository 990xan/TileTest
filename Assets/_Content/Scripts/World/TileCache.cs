using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TileSystem;

public class TileCache : MonoBehaviour
{



    public Dictionary<string, Tile> tileCache;
    public Tile[] tiles;

    public void PopulateCache(){
        tileCache = new Dictionary<string, Tile>();
        tiles = Resources.LoadAll<Tile>("Tiles");
        foreach (Tile tile in tiles){
            tileCache.Add(tile.tileName, tile);
        }
    }

    void Awake(){
        PopulateCache();
    }

}
