using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Won't be applied to any object in the scene nor will it have multiple instances
public static class Noise
{
	/* generate a noise map and return a grid of values between 0 and 1
	 * octaves: a relation between two pitches whose frequency is in a 2:1 ratio
	 * Lacunarity: controls increase in frequency of octaves
	 * persistance: controls decrease in amplitude of octaves
	 */
	public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, int seed,
		float scale, int octaves, float persistance, float lacunarity, Vector2 offset)
	{
		float[,] noiseMap = new float[mapWidth, mapHeight];

		// Generate random seed
		System.Random prng = new System.Random(seed);
		Vector2[] octaveOffsets = new Vector2[octaves];
		// Generate random offset based on seed and given offset
		for (int i = 0; i < octaves; i++)
		{
			float offsetX = prng.Next(-100000, 100000) + offset.x;
			float offsetY = prng.Next(-100000, 100000) + offset.y;
			octaveOffsets[i] = new Vector2(offsetX, offsetY);
		}

		if(scale <= 0)
		{
			scale = 0.0001f;
		}

		// keep track of lowest and highest values in noiseMap
		float maxNoiseHeight = float.MinValue;
		float minNoiseHeight = float.MaxValue;

		float halfWidth = mapWidth / 2f;
		float halfHeight = mapHeight / 2f;

		//loop though new noise map and assign a perlin value to each element
		for(int y = 0; y < mapHeight; y++)
		{
			for(int x = 0; x < mapWidth; x++)
			{

				float amplitude = 1;		// y axis
				float frequency = 1;		// x axis
				float noiseHeight = 0;

				//octave loop
				for(int i = 0; i < octaves; i++)
				{
					// base sample points in the center
					// multiply by frequency
					// higher the frequency, the further the sample points will be
					//	which will cause the height values to change more rapidly
					// offset sample points
					float sampleX = (x-halfWidth) / scale * frequency + octaveOffsets[i].x;
					float sampleY = (y-halfHeight) / scale * frequency + octaveOffsets[i].y;

					// perlinValue range is [-1,1]. By default it is [0,1] 
					float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
					//increase noise height by the perlin value of each octave
					noiseHeight += perlinValue * amplitude;

					// At the end of each octave. 
					// Pers. is the range [0,1]. This decreases each octave
					amplitude *= persistance;
					// freq. increases each octave
					frequency *= lacunarity;	
				}

				// set max and min noise height
				if (noiseHeight > maxNoiseHeight) maxNoiseHeight = noiseHeight;
				else if(noiseHeight < minNoiseHeight) minNoiseHeight = noiseHeight;

				// Apply noiseHeight to noiseMap
				noiseMap[x, y] = noiseHeight;
			}
		}
		
		//normalize it so values are in range [0,1] Basically the value won't be outside of the normal range
		for (int y = 0; y < mapHeight; y++)
		{
			for (int x = 0; x < mapWidth; x++)
			{
				noiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x, y]);
			}
		}

		return noiseMap;
	}
    
}
