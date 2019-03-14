using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapUIEditor : MonoBehaviour
{
	MapGenerator MapGen;
	public Slider ScalSlider;
	public Slider OctSlider;
	public Slider PersSlider;
	public Slider LacSlider;

	public InputField W1;
	public InputField W2;
	public InputField Sd;
	public InputField G1;
	public InputField G2;
	public InputField R1;
	public InputField R2;
	public InputField Sn;

	public InputField seedInput;

	InputField[] inputs = new InputField[8];

	// Start is called before the first frame update
	void Start()
	{
		MapGen = GameObject.FindObjectOfType<MapGenerator>();
		
		ScalSlider.minValue = 20;
		ScalSlider.maxValue = 100;
		ScalSlider.value = MapGen.noiseScale;

		OctSlider.wholeNumbers = true;
		OctSlider.minValue = 1;
		OctSlider.maxValue = 5;
		OctSlider.value = MapGen.octaves;

		PersSlider.minValue = 0;
		PersSlider.maxValue = 1;
		PersSlider.value = MapGen.persistance;

		LacSlider.minValue = 0;
		LacSlider.maxValue = 20;
		LacSlider.value = MapGen.lacunarity;

		inputs[0] = W1;
		inputs[1] = W2;
		inputs[2] = Sd;
		inputs[3] = G1;
		inputs[4] = G2;
		inputs[5] = R1;
		inputs[6] = R2;
		inputs[7] = Sn;

		MapGen.GenerateMap();

	}
	

	// Update is called once per frame
	void Update()
	{
		MapGen.noiseScale = ScalSlider.value;
		MapGen.octaves = (int)OctSlider.value;
		MapGen.persistance = PersSlider.value;
		MapGen.lacunarity = LacSlider.value;

		//MapGen.regions[0].color = 

		if (Input.GetKey(KeyCode.W))
		{
			MapGen.offset.y -= .05f;
			MapGen.GenerateMap();
		}
		if (Input.GetKey(KeyCode.D))
		{
			MapGen.offset.x += .05f;
			MapGen.GenerateMap();
		}
		if (Input.GetKey(KeyCode.S))
		{
			MapGen.offset.y += .05f;
			MapGen.GenerateMap();
		}
		if (Input.GetKey(KeyCode.A))
		{
			MapGen.offset.x -= .05f;
			MapGen.GenerateMap();
		}
	}

	public void ConvertColors()
	{
		Color newCol;
		int colorindex = 0;

		foreach(InputField intput in inputs)
		{
			if (ColorUtility.TryParseHtmlString(intput.text, out newCol))
			{
				MapGen.regions[colorindex].color = newCol;
			}

			colorindex++;

		}

		MapGen.GenerateMap();
	}

	public void ChangeSeed()
	{
		MapGen.seed = int.Parse(seedInput.text);
		MapGen.GenerateMap();
	}

}



