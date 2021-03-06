﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

	public enum DrawMode {NoiseMap, ColorMap, Mesh, FalloffMap};
	public DrawMode drawMode;

	public bool updateOnPlay = true;

	private const int mapChunkSize = 241;
	[Range(0, 6)] public int levelOfDetail;
	public float		noiseScale;
	public int			octaves;
	[Range(0,1)]
	public float		persistance;
	public float		lacunarity;
	public int			seed;
	public Vector2		offset;

	public bool useFalloff;

	public float meshHeightMultiplier;
	public AnimationCurve meshHeightCurve;

	public bool				autoUpdate;
	public TerrainType[]	regions;

	private float[,] falloffMap;

	private void Awake()
	{
		falloffMap = FalloffGenerator.GenerateFalloffMap(mapChunkSize);
	}

	private void Start()
	{
		GenerateMap();
	}


	//Generate the map in the scene
	public void GenerateMap()
	{
		float[,] noiseMap = Noise.GenerateNoiseMap(mapChunkSize, mapChunkSize, seed, noiseScale, octaves, persistance, lacunarity, offset);

		// Color the map
		// Loop through every pixel of the noise map
		Color[] colorMap = new Color[mapChunkSize * mapChunkSize];
		for(int y = 0; y < mapChunkSize; y++)
		{
			for(int x= 0; x < mapChunkSize; x++)
			{
				if (useFalloff)
				{
					noiseMap[x, y] = Mathf.Clamp01(noiseMap[x, y] - falloffMap[x, y]);
				}

				//for every region
				float currentHeight = noiseMap[x, y];
				for(int i = 0; i < regions.Length; i++)
				{
					// if (x,y) is within region range, break out of region for loop
					if(currentHeight <= regions[i].height)
					{
						colorMap[y * mapChunkSize + x] = regions[i].color;
						break;
					}
				}
			}
		}

		MapDisplay display = FindObjectOfType<MapDisplay>();
		if(drawMode == DrawMode.NoiseMap)
		{
			display.DrawTexture(TextureGenerator.TextureFromHeightMap(noiseMap));
		}
		else if(drawMode == DrawMode.ColorMap)
		{
			display.DrawTexture(TextureGenerator.TextureFromColorMap(colorMap,mapChunkSize,mapChunkSize));
		}
		else if (drawMode == DrawMode.Mesh)
		{
			display.DrawMesh(MeshGenerator.GenerateTerrainMesh (noiseMap, meshHeightMultiplier, meshHeightCurve, levelOfDetail), TextureGenerator.TextureFromColorMap(colorMap, mapChunkSize, mapChunkSize));
		}
		else if (drawMode == DrawMode.FalloffMap)
		{
			display.DrawTexture(TextureGenerator.TextureFromHeightMap(FalloffGenerator.GenerateFalloffMap(mapChunkSize)));
		}

	}

	void OnValidate()
	{

		if(lacunarity < 1)
			lacunarity = 1;
		if (octaves < 0)
			octaves = 0;

		falloffMap = FalloffGenerator.GenerateFalloffMap(mapChunkSize);
	}

	[System.Serializable]
	public struct TerrainType
	{
		public string name;
		public float height;
		public Color color;

	}
}
