using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace TileSystem{
    public class Tile : ScriptableObject
    {
        public Tile(Vector3 lChunkPosition, Vector3 lWorldPosition){
            chunkPosition = lChunkPosition;
            worldPosition = lWorldPosition;
            tObjects = new TileObject[16];  //Might change array size later 
            //do NOT use to store terrain objects, store terrain objects in dedicated slot
        }

        public void CopyTileData(Tile tile){
            this.tObjects = tile.tObjects;
            this.terrain = tile.terrain;
        }

        public Vector3 chunkPosition;
        public Vector3 worldPosition;
        public TileObject[] tObjects;
        public TerrainTileObject terrain;
    }
}
