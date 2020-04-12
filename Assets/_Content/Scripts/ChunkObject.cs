using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TileSystem{
public class ChunkObject : MonoBehaviour
    {
        public Chunk chunk;
        public int width = 16;
        public int height = 16;
        public int depth = 16;
        public string ground = "Ground";
        public string ore = "Ore";
        public Vector3 offset; //how much it is offset from the origin
        public TileCache tChache;

        void Start(){
            chunk = new Chunk(width, height, depth, transform.position);
            //GroundTest1();
            //GroundTest2();
            StartCoroutine(GroundTest());
        }

        /*void GroundTest1(){
            foreach(Tile tile in chunk.tiles){
                int random = Random.Range(0, 2);
                if (tile.chunkPosition.y <= 0){
                    tile.CopyTileData(tChache.tileCache[ground]);
                }
                if (tile.chunkPosition.y <= -1 && random == 1){
                    tile.CopyTileData(tChache.tileCache[ore]);
                }
            }
            
        }
        void GroundTest2(){
            foreach(Tile tile in chunk.tiles){
                if (tile.gObject != null){
                    //Debug.Log("This tile might be " + tile.gObject.name);
                    Instantiate(tile.gObject, tile.chunkPosition, new Quaternion(0,0,0,0));
                }
            }
        }*/

        IEnumerator GroundTest(){
            /*foreach(Tile tile in chunk.tiles){
                int random = Random.Range(0, 2);
                if (tile.chunkPosition.y <= 0){
                    tile.CopyTileData(tChache.tileCache[ground]);
                    Instantiate(tile.gObject, tile.chunkPosition, new Quaternion(0,0,0,0));
                }
                if (tile.chunkPosition.y <= -1 && random == 1){
                    tile.CopyTileData(tChache.tileCache[ore]);
                    Instantiate(tile.gObject, tile.chunkPosition, new Quaternion(0,0,0,0));
                }
                yield return new WaitForSecondsRealtime(.005f);
            }*/

            for (int ix = 0; ix < width; ix++){
                for (int iy = 0; iy < height; iy++){
                    for (int iz = 0; iz < depth; iz++){
                        int random = Random.Range(0, 2);
                        Tile tile = chunk.tiles[ix, iy, iz];
                        if (tile.chunkPosition.y <= 0){
                            tile.CopyTileData(tChache.tileCache[ground]);
                            Instantiate(tile.gObject, Vector3.Scale(tile.chunkPosition, transform.position), new Quaternion(0,0,0,0));
                        }
                        if (tile.chunkPosition.y <= -1 && random == 1){
                            tile.CopyTileData(tChache.tileCache[ore]);
                            Instantiate(tile.gObject, Vector3.Scale(tile.chunkPosition, transform.position), new Quaternion(0,0,0,0));
                        }
                        yield return null;
                    }
                }
            }


            
        }
        

        void OnDrawGizmos(){
            Gizmos.color = Color.cyan;
            Vector3 chunkCorner = new Vector3(transform.position.x - width/2, transform.position.y - height/2, transform.position.z - depth/2);
            Gizmos.DrawLine(chunkCorner, new Vector3(chunkCorner.x + width - 1, chunkCorner.y, chunkCorner.z));
            Gizmos.DrawLine(chunkCorner, new Vector3(chunkCorner.x, chunkCorner.y + height - 1, chunkCorner.z));
            Gizmos.DrawLine(chunkCorner, new Vector3(chunkCorner.x, chunkCorner.y, chunkCorner.z + depth - 1));
        }

    }
}
