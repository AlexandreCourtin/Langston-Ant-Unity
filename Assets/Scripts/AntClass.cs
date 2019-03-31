using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant
{
	private int posX;
	private int posY;
	private bool goUp;
	private bool goRight;
	private bool goDown;
	private bool goLeft;

	public Ant(int x, int y)
	{
		posX = x;
		posY = y;
		goUp = true;
		goRight = false;
		goDown = false;
		goLeft = false;
	}

	public int getX()
	{
		return posX;
	}

	public int getY()
	{
		return posY;
	}

	public void setX(int x)
	{
		posX = x;
	}

	public void setY(int y)
	{
		posY = y;
	}

	public void rotate(bool r)
	{
		if (r)
		{
			if (goUp)
			{
				goUp = false;
				goRight = true;
			}
			else if (goRight)
			{
				goRight = false;
				goDown = true;
			}
			else if (goDown)
			{
				goDown = false;
				goLeft = true;
			}
			else if (goLeft)
			{
				goLeft = false;
				goUp = true;
			}
		}
		else
		{
			if (goUp)
			{
				goUp = false;
				goLeft = true;
			}
			else if (goRight)
			{
				goRight = false;
				goUp = true;
			}
			else if (goDown)
			{
				goDown = false;
				goRight = true;
			}
			else if (goLeft)
			{
				goLeft = false;
				goDown = true;
			}
		}
	}

	public void move()
	{
		if (goUp)
		{
			posY += 1;
		}
		else if (goRight)
		{
			posX += 1;
		}
		else if (goDown)
		{
			posY -= 1;
		}
		else if (goLeft)
		{
			posX -= 1;
		}
	}
}
