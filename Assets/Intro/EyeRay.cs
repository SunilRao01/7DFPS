using UnityEngine;
using System.Collections;

public class EyeRay : MonoBehaviour 
{
	public float eyeSpeed;
	public float eyeDistance;

	void Start () 
	{
	
	}
	
	void Update () 
	{
		Vector3 newRotation = transform.eulerAngles;
		newRotation.y = Mathf.Sin(Time.time * eyeSpeed) * eyeDistance;
		transform.eulerAngles = newRotation;
	}
}
