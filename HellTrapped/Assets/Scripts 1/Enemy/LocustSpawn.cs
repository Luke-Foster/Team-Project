using UnityEngine;
using System.Collections;

public class LocustSpawn : MonoBehaviour {

	public GameObject OilPickup;
	public GameObject HolyPickup;
	public GameObject PoisonPickup;
	public GameObject BloodPickup;
	public GameObject enemy;
	public GameObject Boss;
	public bool BossRoom = false;
	public GameObject[] spawnPoints;     

	void Awake ()
	{
		//spawnPoints = GameObject.FindGameObjectsWithTag ("SpawnSpot");
		//Spawn ();
	}


	public void Spawn ()
	{
		int number = Random.Range (1, 5);

		// Find a random index between zero and one less than the number of spawn points.
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		if (BossRoom == false)
		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		Instantiate (enemy, spawnPoints [spawnPointIndex].transform.position, spawnPoints [spawnPointIndex].transform.rotation);
		else
			Boss.SetActive (true);

		if(number == 1) Instantiate(OilPickup, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.rotation);
		if(number == 2) Instantiate(HolyPickup, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.rotation);
		if(number == 3) Instantiate(PoisonPickup, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.rotation);
		if(number == 4) Instantiate(BloodPickup, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.rotation);
		//if(number == 5)  // Number 5 is for instantiating journal Entries for the user in future versions.
	}
}