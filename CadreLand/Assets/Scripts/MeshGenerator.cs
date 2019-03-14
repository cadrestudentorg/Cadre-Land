using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MeshGenerator
{
	public static MeshData GenerateTerrainMesh(float[,] heightMap, float heightMultiplier, AnimationCurve heightCurve)
	{
		int   width    = heightMap.GetLength(0);
		int   height   = heightMap.GetLength(1);
		float topLeftX = (width - 1) / -2f;	
		float topLeftZ = (height - 1) / 2f;

		MeshData meshData = new MeshData(width, height);
		int vertexIndex = 0;	// keep track of where we are in this 1d array

		// loop through height map and create the vertices
		for (int y = 0; y < height; y++)
		{
			for (int x = 0; x < width; x++)
			{
				// assign vertices and uvs
				// offset from topleft to center mesh
				meshData.vertices[vertexIndex] = new Vector3(topLeftX + x, heightCurve.Evaluate(heightMap[x, y]) * heightMultiplier, topLeftZ - y);
				// tell each vertex where it is in relation to the map as a percentage
				// for both the X and Y axis
				meshData.uvs[vertexIndex] = new Vector2(x / (float)width, y / (float)height);

				// Add triangles from each square
				// ignore left and bottom edge vertices
				if (x < width - 1 && y < height - 1)
				{
					meshData.AddTriangle(vertexIndex, vertexIndex + width + 1, vertexIndex + width);
					meshData.AddTriangle(vertexIndex + width + 1, vertexIndex, vertexIndex + 1);
				}

				vertexIndex++;
			}
		}

		return meshData;
	}

}

public class MeshData
{
	public Vector3[]	vertices;
	public int[]		triangles;
	public Vector2[]	uvs;

	int					triangleIndex;

	// Create mesh data and calcutate how many elements the arrays will have
	public MeshData (int meshWidth, int meshHeight)
	{
		vertices = new Vector3[meshWidth * meshHeight];
		uvs = new Vector2[meshWidth * meshHeight];
		triangles = new int[(meshWidth - 1) * (meshHeight - 1) * 6];
	}

	public void AddTriangle(int a, int b, int c)
	{
		triangles[triangleIndex	+ 0] = a;
		triangles[triangleIndex + 1] = b;
		triangles[triangleIndex + 2] = c;
		triangleIndex += 3;
	}

	public Mesh CreateMesh()
	{
		Mesh mesh = new Mesh();
		//this order is important. Vertices first, then triangles
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.uv = uvs;
		mesh.RecalculateNormals();
		return mesh;
	}
}

