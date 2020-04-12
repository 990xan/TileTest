using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TileSystem;


public class TileCacheData : ScriptableObject
{

    public Dictionary<string, Tile> tileCache;
    public Tile[] tiles;

    public void PopulateCache(){
        tiles = Resources.LoadAll<Tile>("Tiles");
        foreach (Tile tile in tiles){
            tileCache.Add(tile.tileName, tile);
        }
    }
}
