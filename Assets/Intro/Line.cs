using UnityEngine;
using System.Collections;

public class Line : MonoBehaviour {
	public float moveSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gameObject.name == "VerticalLine(Clone)" || gameObject.name == "VerticalLine 1(Clone)")
		{
			if (transform.position.z < 10)
			{
				Destroy (gameObject);
			}

		}
		else if (transform.position.z < -30)
		{
			Destroy (gameObject);
		}
		if (gameObject.name == "VerticalLine(Clone)" || gameObject.name == "VerticalLine 1(Clone)")
		{
			transform.Translate(Vector3.right * moveSpeed);
		}
		else
		{
			transform.Translate(-Vector3.forward * moveSpeed);
		}
	}
}
