using UnityEngine;
using System.Collections;

public class Liquid : MonoBehaviour 
	{
		public GameObject prefab;
		public GameObject Player;
		public float damage;

		void Start () 
		{
			Player = GameObject.FindWithTag ("Player");
			Destroy(gameObject, 2); // destroy after 2 seconds
		}
		

		void OnExplode()
		{
			// Do Exploding stuff
		}

		void OnTriggerEnter2D (Collider2D col) 
		{
			// If it hits an enemy...
		if (col.tag == "Enemy") 
		{
			Destroy (col.gameObject); // one hit kill till health script implemented

			OnExplode ();

			Destroy (gameObject);
		}
		else if (col.tag == "Locust") 
		{
			Destroy (gameObject);
			PlayerController ControllerScript = Player.GetComponent<PlayerController>();
			damage = ControllerScript.Damage;

			Locust locustScript = col.GetComponent<Locust> ();
			if (ControllerScript.AmmoType == "Holy" || ControllerScript.AmmoType == "Sin") 
			{
				locustScript.health -= 1f; // normal damage
			}
			else if (ControllerScript.AmmoType == "Oil" ) 
			{
				locustScript.health -= 2f; // insta kill
			}
			else if (ControllerScript.AmmoType == "Poison" ) 
			{
				if(locustScript.health < 2f)
				{
				locustScript.health += 1f; // heal to max health
				}
			}
		}
		else if (col.tag == "Abaddon") 
		{
			Destroy (gameObject);
			PlayerController ControllerScript = Player.GetComponent<PlayerController>();
			damage = ControllerScript.Damage;

			Abaddon abaddonScript = col.GetComponent<Abaddon> ();
			if (ControllerScript.AmmoType == "Oil" || ControllerScript.AmmoType == "Poison") 
			{
				abaddonScript.health -= 1f; // normal damage
			}
			else if (ControllerScript.AmmoType == "Holy" ) 
			{
				abaddonScript.health -= 2f; // Bonus Damage
			}
			else if (ControllerScript.AmmoType == "Sin" ) 
			{
				if(abaddonScript.health < 10f)
				{
					abaddonScript.health += 1f; // heal to max health
				}
			}
		}
			// Otherwise if the player manages to shoot himself
		else if(col.gameObject.tag != "Player")
		{
			OnExplode();
			Destroy (gameObject);
		}
		}
	}
