using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Player : MonoBehaviour 
{
	// GUI
	public Texture2D crosshairImage;

	public Rigidbody bulletPrefab;
	public float bulletForce;
	public float bulletDeathTime;

	private bool canShoot;
	public float shootDelay;
	private GameObject gunObject;
	private GameObject gunExtendObject;

	// Original values
	private Vector3 originalGunExtendScale;

	public float comboTime;
	public List<string> comboQueue;
	private int comboPosition;
	public GUIText comboLabel;


	void Start () 
	{
		canShoot = true;

		gunObject = transform.GetChild(0).GetChild(0).gameObject;

		gunExtendObject = transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
		originalGunExtendScale = gunExtendObject.transform.localScale;
	}
	
	void Update () 
	{
		handleGun();
	}

	void OnGUI()
	{
		GUI.DrawTexture(new Rect((Screen.width/2) - 12, (Screen.height/2) - 12, 24, 24), crosshairImage);
	}

	void handleGun()
	{
		Physics.IgnoreLayerCollision(8, 9);

		if (Input.GetMouseButtonDown(0))
		{
			if (canShoot)
			{

				StopCoroutine("comboTimer");
				
				comboQueue.Add("L");
				comboLabel.text += comboQueue[comboPosition];
				comboPosition++;
				
				StartCoroutine("comboTimer");

				// Start shot delay
				canShoot = false;


				// Shoot bullet
				if (comboPosition == 1)
				{
					Vector3 bulletPosition = transform.position + (transform.GetChild(0).forward * 0.7f) + (transform.GetChild(0).right * 0.3f) + (-transform.GetChild(0).up * 0.2f);
					bulletPosition.y += 0.5f;

					Rigidbody tempBullet = (Rigidbody) Instantiate(bulletPrefab, bulletPosition, Quaternion.identity);
					tempBullet.AddForce(transform.GetChild(0).forward * bulletForce);

					// Animate push back for gun
					Vector3 backGunRotation = gunObject.transform.localEulerAngles;
					backGunRotation.x -= 40;

					iTween.RotateTo(gunObject, iTween.Hash("rotation", backGunRotation, "time", (shootDelay/12), "OnCompleteTarget", gameObject, "OnComplete", "afterShot", "islocal", true, "easetype", iTween.EaseType.linear));
				}
				else if (comboPosition == 2)
				{
					// Move gun extender forward
					// TODO: extendPosition needs to be updated properly
					Vector3 extendPosition = gunExtendObject.transform.position;
					extendPosition += (transform.GetChild(0).forward * 0.06f);

					iTween.MoveTo(gunExtendObject, iTween.Hash("position", extendPosition, "time", 0.1f, "OnCompleteTarget", gameObject, "OnComplete", "stretch"));
					//stretch();

				}
				else if (comboPosition == 3)
				{
					Vector3 extendScale_1 = gunExtendObject.transform.localScale;
					extendScale_1.y += 0.05f;

					iTween.ScaleTo(gunExtendObject, iTween.Hash("scale", extendScale_1, "time", 0.1f, "OnCompleteTarget", gameObject, "OnComplete", "multiShot"));
				}

				// Start shot delay timer
				StartCoroutine("shootTimer");
			}
		}
	}

	void stretch()
	{
		// Stretch gun extender
		Vector3 extendScale_1 = gunExtendObject.transform.localScale;
		extendScale_1.x += 0.05f;
		
		iTween.ScaleTo(gunExtendObject, iTween.Hash("scale", extendScale_1, "time", 0.1f, "OnCompleteTarget", gameObject, "OnComplete", "multiShot"));
	}

	void multiShot()
	{
		if (comboPosition == 2)
		{
			Vector3 bulletPosition_1 = transform.position + (transform.GetChild(0).forward * 0.7f) + (transform.GetChild(0).right * 0.4f) + (-transform.GetChild(0).up * 0.2f);
			bulletPosition_1.y += 0.5f;
			Vector3 bulletPosition_2 = transform.position + (transform.GetChild(0).forward * 0.7f) + (transform.GetChild(0).right * 0.2f) + (-transform.GetChild(0).up * 0.2f);
			bulletPosition_2.y += 0.5f;
			
			Rigidbody tempBullet_1 = (Rigidbody) Instantiate(bulletPrefab, bulletPosition_1, Quaternion.identity);
			Rigidbody tempBullet_2 = (Rigidbody) Instantiate(bulletPrefab, bulletPosition_2, Quaternion.identity);

			tempBullet_1.AddForce(transform.GetChild(0).forward * bulletForce);
			tempBullet_2.AddForce(transform.GetChild(0).forward * bulletForce);
		}
		else if (comboPosition == 3)
		{
			Vector3 bulletPosition_1 = transform.position + (transform.GetChild(0).forward * 0.7f) + (transform.GetChild(0).right * 0.4f) + (-transform.GetChild(0).up * 0.2f);
			bulletPosition_1.y += 0.6f;
			Vector3 bulletPosition_2 = transform.position + (transform.GetChild(0).forward * 0.7f) + (transform.GetChild(0).right * 0.2f) + (-transform.GetChild(0).up * 0.2f);
			bulletPosition_2.y += 0.6f;

			Vector3 bulletPosition_3 = transform.position + (transform.GetChild(0).forward * 0.7f) + (transform.GetChild(0).right * 0.4f) + (-transform.GetChild(0).up * 0.2f);
			bulletPosition_3.y += 0.4f;
			Vector3 bulletPosition_4 = transform.position + (transform.GetChild(0).forward * 0.7f) + (transform.GetChild(0).right * 0.2f) + (-transform.GetChild(0).up * 0.2f);
			bulletPosition_4.y += 0.4f;
			
			Rigidbody tempBullet_1 = (Rigidbody) Instantiate(bulletPrefab, bulletPosition_1, Quaternion.identity);
			Rigidbody tempBullet_2 = (Rigidbody) Instantiate(bulletPrefab, bulletPosition_2, Quaternion.identity);
			Rigidbody tempBullet_3 = (Rigidbody) Instantiate(bulletPrefab, bulletPosition_3, Quaternion.identity);
			Rigidbody tempBullet_4 = (Rigidbody) Instantiate(bulletPrefab, bulletPosition_4, Quaternion.identity);
			
			tempBullet_1.AddForce(transform.GetChild(0).forward * bulletForce);
			tempBullet_2.AddForce(transform.GetChild(0).forward * bulletForce);
			tempBullet_3.AddForce(transform.GetChild(0).forward * bulletForce);
			tempBullet_4.AddForce(transform.GetChild(0).forward * bulletForce);
		}
	}

	IEnumerator shootTimer()
	{
		yield return new WaitForSeconds (shootDelay);

		canShoot = true;
	}

	IEnumerator comboTimer()
	{
		yield return new WaitForSeconds(comboTime);

		// Unextend 
		gunExtendObject.transform.localScale = originalGunExtendScale;

		Vector3 extendPosition = gunExtendObject.transform.position;
		extendPosition -= (transform.GetChild(0).forward * 0.06f);
		gunExtendObject.transform.position = extendPosition;

		// Clear combo queue
		comboQueue.Clear();

		// Clear combo label
		comboLabel.text = "";

		// Restart combo position
		comboPosition = 0;
	}

	void afterShot()
	{
		Vector3 originalGunRotation = gunObject.transform.localEulerAngles;
		originalGunRotation.x += 40;

		iTween.RotateTo(gunObject, iTween.Hash("rotation", originalGunRotation, "time", (shootDelay/1.5f), "islocal", true, "easetype", iTween.EaseType.linear));
	}
}
