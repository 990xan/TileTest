using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TileSystem;

public class TestSuperGrid : MonoBehaviour
{
    public ChunkObject chunkObject;
    public TileCache tileCache;
    public ChunkObject[,,] chunks;
    public int width;
    public int height;
    public int depth;
    public int cWidth;
    public int cHeight;
    public int cDepth;

    void Start(){
        chunks = new ChunkObject[width,height,depth];
        StartCoroutine(Generate());
    }


    IEnumerator Generate(){
        for (int ix = 0; ix < width; ix++){
                for (int iy = 0; iy < height; iy++){
                    for (int iz = 0; iz < depth; iz++){
                        ChunkFactory(cWidth, cHeight, cDepth, tileCache, new Vector3(ix, iy, iz), chunkObject);
                        yield return new WaitForSecondsRealtime(.5f);
                    }
                }
            }

    }

    void ChunkFactory(int cWidth, int cHeight, int cDepth, TileCache tCache, Vector3 cOffset, ChunkObject template){
        ChunkObject cObject = Instantiate(template, Vector3.Scale(cOffset, new Vector3(cWidth, cHeight, cDepth)), new Quaternion(0,0,0,0));
        cObject.width = cWidth;
        cObject.height = cHeight;
        cObject.depth = cDepth;
        cObject.tChache = tCache;
        cObject.offset = cOffset;
    }
}
