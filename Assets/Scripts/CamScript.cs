using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
	public float speed = 0.1f;

	void Update()
	{
		transform.Translate(new Vector3(Input.GetAxis("Horizontal") * speed,
											Input.GetAxis("Vertical") * speed, 0f));
		GetComponent<Camera>().orthographicSize -= Input.GetAxis("Zoom") * speed;
	}
}
