using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour 
{
	public float deathTime;

	void Start () 
	{
		StartCoroutine(deathTimer());
	}
	
	void Update () 
	{
	
	}

	IEnumerator deathTimer()
	{
		yield return new WaitForSeconds(deathTime);

		Destroy(gameObject);
	}
}
