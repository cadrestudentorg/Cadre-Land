using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor (typeof (MapGenerator))]
public class MapGenEditor : Editor
{

	//Add "Generate button to the inspector of Map Generator
	public override void OnInspectorGUI()
	{
		MapGenerator mapGen = (MapGenerator)target;

		//if change was detected
		if(DrawDefaultInspector())
		{
			if(mapGen.autoUpdate)
			{
				mapGen.GenerateMap();
			}
		}

		//If button was pressed
		if (GUILayout.Button("Generate"))
		{
			mapGen.GenerateMap();
		}
	}

}
