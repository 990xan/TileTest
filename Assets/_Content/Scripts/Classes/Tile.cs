using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace TileSystem{
    [CreateAssetMenu(fileName = "Unnamed Tile", menuName = "Tiles/Tile")]
    public class Tile : ScriptableObject
    {
        public Tile(int lChunkID, Vector3 lChunkPosition){
            chunkPosition = lChunkPosition;
            chunkID = lChunkID;
        }

        public void CopyTileData(Tile tile){
            this.tileName = tile.tileName;
            this.gObject = tile.gObject;
        }

        public string tileName;
        public int chunkID;
        public Vector3 chunkPosition;
        public GameObject gObject;
    }
}
