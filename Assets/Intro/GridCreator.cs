using UnityEngine;
using System.Collections;

public class GridCreator : MonoBehaviour 
{
	public GameObject horizontalLine;
	public GameObject verticalLine;

	public float horizontalDelay;
	public float verticalDelay;

	public bool x;
	public bool y;
	public bool z;
	
	// Use this for initialization
	void Start () 
	{
		StartCoroutine(createHorizontalLine());
		StartCoroutine(createVerticalLine());
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	IEnumerator createHorizontalLine()
	{
		while (true)
		{
			yield return new WaitForSeconds(horizontalDelay);

			Instantiate(horizontalLine);
		}
	}

	IEnumerator createVerticalLine()
	{
		while (true)
		{
			yield return new WaitForSeconds(verticalDelay);

			for (int i = 0; i < 30; i++)
			{
				if (i == 0)
				{
					Instantiate(verticalLine);
				}
				else
				{
					Vector3 newPosition = verticalLine.transform.position;

					if (x)
					{
						newPosition.x += (i * 8);
					}
					else if (y)
					{
						newPosition.y += (i * 8);
					}
					else if (z)
					{
						newPosition.z += (i * 8);
					}

					Instantiate(verticalLine, newPosition, verticalLine.transform.rotation);
				}
			}
		}

	}
}
