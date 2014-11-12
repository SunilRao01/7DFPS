using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CutsceneCamera : MonoBehaviour 
{
	public List<string> pathNames;
	public List<float> pathSpeeds;
	private int counter;

	// Use this for initialization
	void Start () 
	{
		counter = 0;

		startCutscene ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void startCutscene()
	{
		//animation.Play("run");
		iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("Intro_1"), "speed", pathSpeeds[counter], "easetype", iTween.EaseType.linear, "orienttopath", false, "movetopath", false));
	
	}
}
