using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LangstonTileMap
{
	private bool[,] tiles;

	public LangstonTileMap(int size)
	{
		tiles = new bool[size,size];
		for (int i = 0 ; i < size ; i++)
		{
			for (int j = 0 ; j < size ; j++)
			{
				tiles[i,j] = (i + j) % 2 == 0;
			}
		}
	}

	public bool getTile(int i, int j)
	{
		return tiles[i,j];
	}

	public void changeTile(int i, int j)
	{
		if (tiles[i,j] == false)
			tiles[i,j] = true;
		else
			tiles[i,j] = false;
	}
}
