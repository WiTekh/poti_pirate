using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Random = System.Random;

public class proceduralGen : MonoBehaviour {

    public const float maxViewDst = 64;

    [Header("End Island Spawn")]
    [SerializeField] private Vector3 spawnPoint;
    [SerializeField] private int spawnBiasX;
    [SerializeField] private int spawnBiasZ;
    
    private static Vector3 computedSP;

    public static Transform viewer;
    public static Vector2 viewerPosition;

    private static GameObject endIsland;
    public static GameObject waterPlane;

    private static int chunkSize;
    private int chunksVisibleInViewDst;

    private Dictionary<Vector2, TerrainChunk> terrainChunkDictionary = new Dictionary<Vector2, TerrainChunk>();
    private List<TerrainChunk> terrainChunksVisibleLastUpdate = new List<TerrainChunk>();

    void Start() 
    {
        Random rand = new Random();
        computedSP = new Vector3(rand.Next(-spawnBiasX, spawnBiasX+1), 0 , rand.Next(-spawnBiasZ, spawnBiasZ+1)) + spawnPoint;
        Debug.Log($"Island at : {computedSP}");

            chunkSize = 32;
        chunksVisibleInViewDst = Mathf.RoundToInt(maxViewDst / chunkSize);
        
        waterPlane = Resources.Load("waterPlane") as GameObject;
        endIsland = Resources.Load("end-island") as GameObject;
    }

    void Update() 
    {
        viewerPosition = new Vector2 (viewer.position.x, viewer.position.z);
        UpdateVisibleChunks ();
    }
        
    void UpdateVisibleChunks() 
    {
        for (int i = 0; i < terrainChunksVisibleLastUpdate.Count; i++) {
            terrainChunksVisibleLastUpdate[i].SetVisible (false);
        }
        terrainChunksVisibleLastUpdate.Clear ();
            
        int currentChunkCoordX = Mathf.RoundToInt (viewerPosition.x / chunkSize);
        int currentChunkCoordY = Mathf.RoundToInt (viewerPosition.y / chunkSize);

        for (int yOffset = -chunksVisibleInViewDst; yOffset <= chunksVisibleInViewDst; yOffset++) {
            for (int xOffset = -chunksVisibleInViewDst; xOffset <= chunksVisibleInViewDst; xOffset++) {
                Vector2 viewedChunkCoord = new Vector2 (currentChunkCoordX + xOffset, currentChunkCoordY + yOffset);

                if (terrainChunkDictionary.ContainsKey (viewedChunkCoord)) {
                    terrainChunkDictionary [viewedChunkCoord].UpdateTerrainChunk ();
                    if (terrainChunkDictionary [viewedChunkCoord].IsVisible ()) {
                        terrainChunksVisibleLastUpdate.Add (terrainChunkDictionary [viewedChunkCoord]);
                    }
                } else {
                    terrainChunkDictionary.Add (viewedChunkCoord, new TerrainChunk (viewedChunkCoord, chunkSize, transform));
                }
            }
        }
    }

    public class TerrainChunk {

        GameObject meshObject;
        Vector2 position;
        Bounds bounds;

        private int nbOfSharks;
        
        public TerrainChunk(Vector2 coord, int size, Transform parent) {
            position = coord * size;
            bounds = new Bounds(position,Vector2.one * size);
            Vector3 positionV3 = new Vector3(position.x,parent.position.y,position.y);

            meshObject = Instantiate(waterPlane, positionV3, Quaternion.identity);
            meshObject.transform.position = positionV3;
            meshObject.transform.parent = parent;
            SetVisible(false);
            
            //SpawnEndIsland 
            if ((computedSP.x < position.x + chunkSize/2 && computedSP.x > position.x - chunkSize/2) && (computedSP.z < position.y + chunkSize/2 && computedSP.z > position.y - chunkSize/2))
            {
                Instantiate(endIsland, computedSP, Quaternion.Euler(-90f, 0f, 0f));
            }
            
            //SpawnSharks
            Random rand = new Random();
            float rProb = (float) rand.NextDouble();
            nbOfSharks = rProb <= 0.3f ? 0 : rProb <= 0.9f ? 1 : 2; //30% chance of having no shark | 60% of having 1 | 10% of having 2
        }

        public void UpdateTerrainChunk() {
            float viewerDstFromNearestEdge = Mathf.Sqrt(bounds.SqrDistance (viewerPosition));
            bool visible = viewerDstFromNearestEdge <= maxViewDst;
            SetVisible (visible);
        }

        public void SetVisible(bool visible) {
            meshObject.SetActive (visible);
        }

        public bool IsVisible() {
            return meshObject.activeSelf;
        }
    }
}