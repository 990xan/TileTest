using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TileSystem{
    public class Chunk : ScriptableObject
    {
        public Tile[,,] tiles;
        public int width = 16;
        public int height = 16;
        public int depth = 16;
        public Vector3 chunkposition;

        public Chunk(int width, int height, int depth, Vector3 lChunkPosition){
            InitChunk();
            this.width = width;
            this.height = height;
            this.depth = depth;
            chunkposition = lChunkPosition;
        }

        public void InitChunk(){
            tiles = new Tile[width,height,depth];
            for (int ix = 0; ix < width; ix++){
                for (int iy = 0; iy < height; iy++){
                    for (int iz = 0; iz < depth; iz++){
                        tiles[ix, iy, iz] = new Tile(0, new Vector3(ix - width/2, iy - height/2, iz - depth/2));
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
