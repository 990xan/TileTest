using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TileSystem;

public class ChunkGObjectTest : MonoBehaviour
{
    public ChunkObject chunkObject;
    public Tile[] tiles;

    void Start(){
        StartCoroutine(Calculate());
    }

    IEnumerator Calculate(){
        int size = chunkObject.size;
        for (int ix = 0; ix < size; ix++){
                for (int iy = 0; iy < size; iy++){
                    for (int iz = 0; iz < size; iz++){
                        int random = Random.Range(0, 2);
                        Tile tile = chunkObject.chunk.tiles[ix, iy, iz];
                        if (tile.chunkPosition.y == 0){
                            tile.CopyTileData(chunkObject.tChache.tileCache[chunkObject.ground]);
                            Instantiate(tile.gObject, tile.chunkPosition + transform.position, new Quaternion(0,0,0,0));
                        }
                        if (tile.chunkPosition.y < 0 && random == 0){
                            tile.CopyTileData(chunkObject.tChache.tileCache[chunkObject.ground]);
                            Instantiate(tile.gObject, tile.chunkPosition + transform.position, new Quaternion(0,0,0,0));
                        }
                        if (tile.chunkPosition.y <= -1 && random == 1){
                            tile.CopyTileData(chunkObject.tChache.tileCache[chunkObject.ore]);
                            Instantiate(tile.gObject, tile.chunkPosition + transform.position, new Quaternion(0,0,0,0));
                        }
                        yield return null;
                    }
                }
            }
    }
    
}
