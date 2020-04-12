using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TileSystem;

public class TestGridTester : MonoBehaviour
{
    public Vector3 samplePoint;
    public bool samplePosition;
    public ChunkObject chunk;
    public MeshRenderer mRenderer;
    public Vector3 output;

    void Start(){
        mRenderer = GetComponent<MeshRenderer>();
    }

    void Update(){
        if (samplePosition == true){
            samplePoint = transform.position;
        } 
        samplePoint = samplePoint.Round(0);
        Tile tile = chunk.chunk.tiles[(int)samplePoint.x - chunk.width/2, (int)samplePoint.y - chunk.height/2, (int)samplePoint.z - chunk.height/2];
        if (tile.tileName != null){
            mRenderer.enabled = true;
        } else {
            mRenderer.enabled = false;
        }
        
    }
}
