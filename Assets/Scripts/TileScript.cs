using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
	public int mode = 0;
	private bool isFilled = false;
	private float calpha = 0f;

	public void setFilled(bool b)
	{
		isFilled = b;
		if (mode == 0)
		{
			if (b)
				GetComponent<SpriteRenderer>().color = new Color(.7f, .7f, .7f, 1f);
			else
				GetComponent<SpriteRenderer>().color = new Color(.3f, .3f, .3f, 1f);
		}
		else if (mode == 1)
		{
			if (b)
				calpha = 1f;
		}
	}

	public bool getFilled()
	{
		return isFilled;
	}

	void Start()
	{
		if (mode == 0)
			GetComponent<SpriteRenderer>().color = new Color(.3f, .3f, .3f, 1f);
	}

	void Update()
	{
		if (mode == 1)
		{
			GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, calpha);
			if (calpha > 0f)
				calpha -= Time.deltaTime * 2.5f;
		}
	}
}
