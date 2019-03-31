using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntScript : MonoBehaviour
{
	public float initRotation = 90;
	public float UpdateTime = 0.025f;
	private GameObject tileToProcess;
	private Vector3 direction = new Vector3(0f, .1f, 0f);
	private Vector3 rotation;

	private void processTile(GameObject tile)
	{
		if (tile.gameObject.tag == "empty")
		{
			tile.gameObject.tag = "full";
			tile.GetComponent<SpriteRenderer>().color = Color.black;
			rotation = transform.eulerAngles;
			rotation.z -= initRotation;
			transform.eulerAngles = rotation;
		}
		else if (tile.gameObject.tag == "full")
		{
			tile.gameObject.tag = "empty";
			tile.GetComponent<SpriteRenderer>().color = Color.white;
			rotation = transform.eulerAngles;
			rotation.z += initRotation;
			transform.eulerAngles = rotation;
		}
		transform.Translate(direction);
	}

	private IEnumerator TickRate()
	{
		while (true)
		{
			processTile(tileToProcess);
			yield return new WaitForSeconds(UpdateTime);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		tileToProcess = col.gameObject;
	}

	void Start()
	{
		StartCoroutine(TickRate());
	}
}
