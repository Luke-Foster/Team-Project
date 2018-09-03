using UnityEngine;
using System.Collections;

public class Locust : MonoBehaviour {

	public PlayerController ControllerScript;
	public GameObject Player;
	public float speed = 0.1f;
	private float minDistance = 1.5f;
	private float range;
	public float AttackDelay = 0f;
	public float health = 2f;

	void Start ()
	{
		Player = GameObject.FindWithTag ("Player");
	}

	void Update ()
	{
		PlayerController ControllerScript = Player.GetComponent<PlayerController>();
		if (ControllerScript.Dead == false) {
			if (health > 0f) {
				if (AttackDelay <= 0f) {
					range = Vector2.Distance (transform.position, Player.transform.position);

					if (range > minDistance) {
						Debug.Log (range);

						transform.position = Vector2.MoveTowards (transform.position, Player.transform.position, speed * Time.deltaTime);
					} else {
						Attack ();
					}
				}
			} else {
				Destroy (this.gameObject);
			}
		}
		else {
			//Destroy locust when player dead
			Destroy (this.gameObject);
		}
	}
	void FixedUpdate()
	{
		AttackDelay -= 0.1f;
	}

	void Attack()
	{
		PlayerController ControllerScript = Player.GetComponent<PlayerController>();
		ControllerScript.Health -= 1f;
		//Do the attack animation
		AttackDelay = 10f;
	}
}
