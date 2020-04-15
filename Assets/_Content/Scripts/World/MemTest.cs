using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TileSystem;

public class MemTest : MonoBehaviour
{
    public ChunkObject chunkObject;

    void Start(){
        foreach(Tile tile in chunkObject.chunk.tiles){
            for(int i = 0; i < tile.tObjects.Length; i++){
                tile.tObjects[i] = TileCache.current.objectCache["Ground"];
            }
        }
    }
}
