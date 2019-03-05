using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextureGenerator
{
    //create texture from 1D color map
	public static Texture2D TextureFromColorMap(Color[] colorMap, int width, int height)
	{
		Texture2D texture = new Texture2D(width, height);
		texture.filterMode = FilterMode.Point;
		texture.wrapMode = TextureWrapMode.Clamp;
		texture.SetPixels(colorMap);
		texture.Apply();
		return texture;
	}

	// Take noise map and return 2D texture 
	public static Texture2D TextureFromHeightMap(float[,] heightMap)
	{
		//get width and height of the float array, noiseMap
		int width = heightMap.GetLength(0);
		int height = heightMap.GetLength(1);

		//set color of each pixel in the texture
		Color[] colorMap = new Color[width * height];
		for (int y = 0; y < height; y++)
		{
			for (int x = 0; x < width; x++)
			{
				// "y * width" = column of texture, "+ x" = row of texture
				//for each color in colorMap, lerp color between black and white
				colorMap[y * width + x] = Color.Lerp(Color.black, Color.white, heightMap[x, y]);
			}
		}

		//return black and white noise map
		return TextureFromColorMap(colorMap, width,height);
	}
}
