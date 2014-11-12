using UnityEngine;
using System.Collections;

public class LevelBeginning : MonoBehaviour 
{

	void Start () 
	{
		//transform.GetChild(0).gameObject.GetComponent<Dialogue>().start();

	}
	
	void Update () 
	{
		if (transform.GetChild(0).gameObject.GetComponent<Dialogue>().complete)
		{
			Debug.Log("Start level!");
		}
	}
}
