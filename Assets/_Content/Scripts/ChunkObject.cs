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
        public Vector3 offset; //how much it is offset from the origin, in 'gridspace' / if chunk is at 16, 32, 16 the offset will be 1,2,1
        public TileCache tChache;

        void Start(){
            chunk = new Chunk(size, transform.position);
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
