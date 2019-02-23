using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Won't be applied to any object in the scene nor will it have multiple instances
public static class Noise
{
	//generate a noise map and return a grid of values between 0 and 1
	public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, float scale)
	{
		float[,] noiseMap = new float[mapWidth, mapHeight];

		if(scale <= 0)
		{
			scale = 0.0001f;
		}

		//loop though new noise map and assign a perlin value to each element
		for(int y = 0; y < mapHeight; y++)
		{
			for(int x = 0; x < mapWidth; x++)
			{
				float sampleX = x / scale;
				float sampleY = y / scale;

				float perlinValue = Mathf.PerlinNoise(sampleX, sampleY);
				noiseMap[x, y] = perlinValue;
			}
		}

		return noiseMap;
	}
    
}
