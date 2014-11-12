using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour 
{
	private GameObject menuObject;
	private GameObject dialogueObject;
	private GameObject faceObject;

	private Vector3 originalTextPosition;

	public bool level1;
	public bool level2;
	public bool level3;

	private bool levelStarted;

	// Use this for initialization
	void Start () 
	{
		menuObject = GameObject.Find("Text");
		faceObject = GameObject.Find("AlienHead");

		originalTextPosition = menuObject.transform.position;

		dialogueObject = GameObject.Find("Dialogue");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Return) && !levelStarted)
		{
			levelStarted = true;

			menuObject.transform.position = Vector3.zero;
			Debug.Log("Face has " + faceObject.transform.childCount.ToString() + " children");
			Destroy(faceObject.transform.GetChild(1).gameObject);
			Destroy(faceObject.transform.GetChild(2).gameObject);

			//Camera.main.GetComponent<FadeOut>().fade = true;

			/*if (level1)
			{
				dialogueObject.GetComponent<Dialogue>().start();
			}*/
		}

		/*if (dialogueObject.GetComponent<Dialogue>().complete)
		{
			if (level1)
			{
				Application.LoadLevel("Level1Tutorial");
			}
		}*/
	}
}
