using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TileSystem{
public class ChunkObject : MonoBehaviour
    {
        public Chunk chunk;
        public int size = 16; //the width, height, and depth, must be even or everything will break and burn
        public string ground = "Ground";
        public string ore = "Ore";
        public Vector3 offset; //how much it is offset from the origin
        public TileCache tChache;

        void Start(){
            chunk = new Chunk(size, transform.position);
            //GroundTest1();
            StartCoroutine(GroundTest());
        }

        void GroundTest1(){
            for (int ix = 0; ix < size; ix++){
                for (int iy = 0; iy < size; iy++){
                    for (int iz = 0; iz < size; iz++){
                        int random = Random.Range(0, 2);
                        Tile tile = chunk.tiles[ix, iy, iz];
                        if (tile.chunkPosition.y <= 0){
                            tile.CopyTileData(tChache.tileCache[ground]);
                            //Instantiate(tile.gObject, tile.chunkPosition, new Quaternion(0,0,0,0));
                        }
                        if (tile.chunkPosition.y <= -1 && random == 1){
                            tile.CopyTileData(tChache.tileCache[ore]);
                            //Instantiate(tile.gObject, tile.chunkPosition, new Quaternion(0,0,0,0));
                        }
                    }
                }
            }
        }
            

        IEnumerator GroundTest(){
            for (int ix = 0; ix < size; ix++){
                for (int iy = 0; iy < size; iy++){
                    for (int iz = 0; iz < size; iz++){
                        int random = Random.Range(0, 2);
                        Tile tile = chunk.tiles[ix, iy, iz];
                        if (tile.chunkPosition.y <= 0){
                            tile.CopyTileData(tChache.tileCache[ground]);
                            Instantiate(tile.gObject, tile.chunkPosition + transform.position, new Quaternion(0,0,0,0));
                        }
                        if (tile.chunkPosition.y <= -1 && random == 1){
                            tile.CopyTileData(tChache.tileCache[ore]);
                            Instantiate(tile.gObject, tile.chunkPosition + transform.position, new Quaternion(0,0,0,0));
                        }
                        yield return null;
                    }
                }
            }
        }
        

        void OnDrawGizmos(){
            Gizmos.color = Color.cyan;
            int sizeHalf = size/2;
            Vector3 chunkCorner = new Vector3(transform.position.x - sizeHalf, transform.position.y - sizeHalf, transform.position.z - sizeHalf);
            Gizmos.DrawLine(chunkCorner, new Vector3(chunkCorner.x + size - 1, chunkCorner.y, chunkCorner.z));
            Gizmos.DrawLine(chunkCorner, new Vector3(chunkCorner.x, chunkCorner.y + size - 1, chunkCorner.z));
            Gizmos.DrawLine(chunkCorner, new Vector3(chunkCorner.x, chunkCorner.y, chunkCorner.z + size - 1));
        }

    }
}
