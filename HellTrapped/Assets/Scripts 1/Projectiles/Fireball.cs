using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

	public Transform target;
	public float ProjectileSpeed = 20;
	public Vector3 OldPosition;
	public GameObject Player;

	void Start () 
	{
		Player = GameObject.FindGameObjectWithTag("Player");
		target = Player.transform;

		OldPosition = new Vector3(target.position.x, target.position.y, target.position.z);

	}

	// Update is called once per frame
	void Update () 
	{
		// distance moved since last frame:
		float amtToMove = ProjectileSpeed * Time.deltaTime;
		// translate projectile in its forward direction:
		this.transform.position = Vector3.MoveTowards(this.transform.position, OldPosition, amtToMove);

		if (this.transform.position == OldPosition) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		// If it hits an enemy...
		if (col.tag == "Enemy") {
			Destroy (col.gameObject); // one hit kill till health script implemented

			Destroy (gameObject);
		}
		else if (col.tag == "Player") {
			PlayerController ControllerScript = Player.GetComponent<PlayerController>();
			ControllerScript.Health -= 1f;
			Destroy (gameObject);
		}
		else if (col.tag == "Locust") {
			Destroy (gameObject);
		}
		else if (col.tag == "Abaddon") {
			//do nothing thats your spawn
		}
	}
}
