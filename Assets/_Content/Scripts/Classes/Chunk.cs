using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TileSystem{
    public class Chunk : ScriptableObject
    {
        public Tile[,,] tiles;
        public int size;
        public Vector3 chunkposition;

        public Chunk(int size, Vector3 lChunkPosition){
            this.size = size;
            chunkposition = lChunkPosition;
            InitChunk();
        }

        public void InitChunk(){
            tiles = new Tile[size,size,size];
            int sizeHalf = size /2;
            for (int ix = 0; ix < size; ix++){
                for (int iy = 0; iy < size; iy++){
                    for (int iz = 0; iz < size; iz++){
                        Vector3 tCP = new Vector3(ix - sizeHalf, iy - sizeHalf, iz - sizeHalf); // tCP = tile chunk position 
                        Vector3 tWP = new Vector3(tCP.x + chunkposition.x, tCP.y + chunkposition.y, tCP.z + chunkposition.z); //tWP = tile world position
                        tiles[ix, iy, iz] = new Tile(tCP, tWP);
                    }
                }
            }

        }
        public void CopyChunkData(Tile[,,] cTiles){
            this.tiles = cTiles;
        }

        public Tile GetTile(Vector3 position){
            return tiles[(int)position.x, (int)position.y, (int)position.z];
        }
    }
}
