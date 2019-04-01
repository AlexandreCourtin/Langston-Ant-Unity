using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class OptiScript : MonoBehaviour
{
	public Tilemap tilemap;
	public Tile tileEmpty;
	public Tile tileFull;
	public Tile tileAntBlue;
	public Tile tileAntRed;
	public Tile tileAntGreen;
	public Tile tileAntYellow;
	public Tile tileAntPink;
	public int sizeMap = 100;
	public float UpdateTime = 0.025f;
	public int NumbersOfAnts = 1;
	private Ant[] ants;
	private LangstonTileMap langmap;

	private void tickAnt(Ant ant)
	{
		langmap.changeTile(ant.getX(), ant.getY());
		if (langmap.getTile(ant.getX(), ant.getY()) == false)
		{
			ant.rotate(false);
			tilemap.SetTile(new Vector3Int(ant.getX() - (sizeMap / 2), ant.getY() - (sizeMap / 2), 0), tileEmpty);
		}
		else if (langmap.getTile(ant.getX(), ant.getY()) == true)
		{
			ant.rotate(true);
			tilemap.SetTile(new Vector3Int(ant.getX() - (sizeMap / 2), ant.getY() - (sizeMap / 2), 0), tileFull);
		}
		ant.move();
		checkBorders(ant);
	}

	private void checkBorders(Ant ant)
	{
		if (ant.getX() < 0)
			ant.setX(sizeMap - 2);
		else if (ant.getX() > sizeMap - 2)
			ant.setX(0);
		if (ant.getY() < 0)
			ant.setY(sizeMap - 2);
		else if (ant.getY() >  sizeMap - 2)
			ant.setY(0);
	}

	private IEnumerator TickRate()
	{
		while (true)
		{
			//LOGIQUE
			for (int i = 0 ; i < ants.Length ; i++)
			{
				tickAnt(ants[i]);
				tilemap.SetTile(new Vector3Int(ants[i].getX() - (sizeMap / 2), ants[i].getY() - (sizeMap / 2), 0), tileAntBlue);
			}
			yield return new WaitForSeconds(UpdateTime);
		}
	}

	void Start()
	{
		ants = new Ant[NumbersOfAnts];
		for (int i = 0 ; i < ants.Length ; i++)
			ants[i] = new Ant(sizeMap / 2, sizeMap / 2);
		langmap = new LangstonTileMap(sizeMap);
		for (int i = 0 ; i < sizeMap ; i++)
		{
			for (int j = 0 ; j < sizeMap ; j++)
			{
				if (langmap.getTile(i, j) == false)
					tilemap.SetTile(new Vector3Int(i - (sizeMap / 2), j - (sizeMap / 2), 0), tileEmpty);
				else
					tilemap.SetTile(new Vector3Int(i - (sizeMap / 2), j - (sizeMap / 2), 0), tileFull);
			}
		}
		StartCoroutine(TickRate());
	}
}
