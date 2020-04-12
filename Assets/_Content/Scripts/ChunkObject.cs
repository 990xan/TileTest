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
        public string ground;
        public string ore;
        public Vector3 offset; //how much it is offset from the origin
        public TileCache tChache;

        void Start(){
            chunk = new Chunk(width, height, depth, transform.position);
            GroundTest1();
            GroundTest2();
        }

        void GroundTest1(){
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
