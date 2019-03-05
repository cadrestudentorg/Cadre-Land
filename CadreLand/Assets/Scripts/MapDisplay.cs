using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
	public Renderer textureRender;

	// Apply texture to a plane in the scene
	public void DrawTexture(Texture2D texture)
	{
		//Update texture and plane scale in the scene
		textureRender.sharedMaterial.mainTexture = texture;
		textureRender.transform.localScale = new Vector3(texture.width, 1, texture.height);
	}
}
