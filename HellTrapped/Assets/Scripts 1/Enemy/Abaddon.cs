using UnityEngine;
using System.Collections;

public class Abaddon : MonoBehaviour {

	public PlayerController ControllerScript;
	public GameObject Player;
	public float AttackDelay = 0f;
	public float health = 10f;
	public float Reload = 5f;

	public GameObject enemy;              
	public GameObject spawnPoint; 
	public GameObject fireball;
	public GameObject rightHand;
	public GameObject leftHand;

    public GameObject portal;

	public bool MovedRight = true;

	public bool FiredRight = true;

	void Start ()
	{
		Player = GameObject.FindWithTag ("Player");
		spawnPoint = this.spawnPoint;
	}

	void Update ()
	{
		if (health < 3)
			Reload = 1f;
		else if (health < 5)
			Reload = 2f;
		else if (health < 7)
			Reload = 3f;
		else if (health < 9)
			Reload = 4f;
		else
			Reload = 5f;

		PlayerController ControllerScript = Player.GetComponent<PlayerController>();

		//less than x43
		if (!MovedRight) {
			float amtToMove = 3f * Time.deltaTime;
			transform.position = Vector2.MoveTowards(this.transform.position, new Vector3 (42, this.transform.position.y, this.transform.position.z), amtToMove);
			if(this.transform.position.x < 43f)
			MovedRight = true;
		}

		//greater than x54
		if (MovedRight) {
			float amtToMove = 3f * Time.deltaTime;
			transform.position = Vector3.MoveTowards (this.transform.position, new Vector3 (55, this.transform.position.y, this.transform.position.z), amtToMove);
			if(this.transform.position.x > 54f)
				MovedRight = false;
		}

		if (ControllerScript.Dead == false) {
			if (health > 0f) {
				if (AttackDelay <= 0f) {

					if (health == 9 || health == 7 || health == 5 || health == 3 || health == 1) {
						Spawn ();
					} 
					else if (FiredRight) {
						AttackLeft ();
						FiredRight = false;
					}
					else {
						AttackRight ();
						FiredRight = true;
					}
				}
			} 
			else {
                portal.SetActive(true);
				Destroy (this.gameObject);
			}
		}
		else {
			//Destroy abaddon when player is dead
			Destroy (this.gameObject);
		}
	}
	void FixedUpdate()
	{
		AttackDelay -= 0.1f;
	}

	void AttackLeft()
	{
		//Launch fireball at player
		Instantiate (fireball, leftHand.transform.position, spawnPoint.transform.rotation);
		AttackDelay = Reload;
	}

	void AttackRight()
	{
		//Launch fireball at player
		Instantiate (fireball, rightHand.transform.position, spawnPoint.transform.rotation);
		AttackDelay = Reload;
	}

	void Spawn ()
	{
		//Spawn enemy from abaddon
		Instantiate (enemy, spawnPoint.transform.position, spawnPoint.transform.rotation);
		AttackDelay = 15f;
	}
}

