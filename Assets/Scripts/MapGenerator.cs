using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
	public GameObject tilePrefab;
	public GameObject blueAntPrefab;
	public GameObject redAntPrefab;
	public int numbersOfAnts = 1;

	void Start()
	{
		for (int i = 0 ; i < 100 ; i++)
		{
			for (int j = 0 ; j < 100 ; j++)
			{
				Instantiate(tilePrefab, new Vector3((i * .1f) - 5f, (j * .1f) - 5f, 0f), Quaternion.identity);
			}
		}
		for (int i = 0 ; i < numbersOfAnts ; i++)
		{
			Instantiate(blueAntPrefab, new Vector3(0f, 0f, -.5f), Quaternion.identity);
		}
	}
}
