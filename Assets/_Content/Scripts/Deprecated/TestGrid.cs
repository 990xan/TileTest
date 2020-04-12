using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TileSystem;


public class TestGrid : MonoBehaviour{


    public Tile[,,] tiles;
    public int width = 100;
    public int height = 30;
    public int depth = 100;
    public Tile test;

    void Start(){
        //StartCoroutine(InitializeGrid());
        InitializeGrid();
    }
    
    void Update(){
        
    }

    /*IEnumerator IInitializeGrid(){
        chunks = new Chunk[width,height,depth];
        for (int ix = 0; ix < width; ix++){
            for (int iy = 0; iy < height; iy++){
                for (int iz = 0; iz < depth; iz++){
                    chunks[ix, iy, iz] = new Chunk(cWidth, cHeight, cDepth, new Vector3(ix, iy, iz));
                    //Debug.Log("chunk");
                    //ChunkLoop(chunks[ix, iy, iz]);
                    yield return null;
                }
            }
        }
    }*/


    /*void InitializeGrid(){
        chunks = new Chunk[width,height,depth];
        for (int ix = 0; ix < width; ix++){
            for (int iy = 0; iy < height; iy++){
                for (int iz = 0; iz < depth; iz++){
                    chunks[ix, iy, iz] = new Chunk(cWidth, cHeight, cDepth, new Vector3(ix, iy, iz));
                    Debug.Log("chunk");
                    //ChunkLoop(chunks[ix, iy, iz]);
                    
                }
            }
        }
    }*/

    /*void ChunkLoop(Chunk chunk){
        for (int ix = 0; ix < cWidth; ix++){
            for (int iy = 0; iy < cHeight; iy++){
                for (int iz = 0; iz < cDepth; iz++){
                    int random = Random.Range(0, 2);
                    if (random == 1){
                        chunks[ix, iy, iz].GetTile(new Vector3(ix, iy, iz)).CopyTileData(test);
                    }
                    Debug.Log(random);
                }
            }
        }
    }*/


    void InitializeGrid(){
        tiles = new Tile[width,height,depth];
        for (int ix = 0; ix < width; ix++){
            for (int iy = 0; iy < height; iy++){
                for (int iz = 0; iz < depth; iz++){
                    tiles[ix, iy, iz] = new Tile(0, new Vector3(ix, iy, iz));
                    int random = Random.Range(0, 2);
                    if (random == 1){
                        //tiles[ix, iy, iz].CopyTileData(test);
                    }
                    Debug.Log(random);
                }
            }
        }
    }

    void OnDrawGizmos(){
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + width - 1, transform.position.y, transform.position.z));
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y + height - 1, transform.position.z));
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + depth - 1));
    }
}

    
