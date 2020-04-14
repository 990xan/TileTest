using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace TileSystem{
    public class Tile : ScriptableObject
    {
        public Tile(int lChunkID, Vector3 lChunkPosition){
            chunkPosition = lChunkPosition;
            chunkID = lChunkID;
            tObjects = new TileObject[16];  //Might change array size later 
            // The first object in the array should be a terrain or empty, nothing else
        }

        public void CopyTileData(Tile tile){
            this.tObjects = tile.tObjects;
        }

        public void AddToObjects(TileObject tObject, int index){
            tObjects[index] = tObject;
        }

        public int chunkID;
        public Vector3 chunkPosition;
        public TileObject[] tObjects;
    }
}
