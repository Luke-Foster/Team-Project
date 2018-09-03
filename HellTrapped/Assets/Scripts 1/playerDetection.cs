using UnityEngine;
using System.Collections;

public class playerDetection : MonoBehaviour {

	GameObject CurrentDoor;

	public GameObject BossCam;
	public GameObject PlayerCamera;
	public GameObject Camera;
	public GameObject Corridor;
	public GameObject Room1;
	public GameObject Room1Spawn;
	public GameObject Room2;
	public GameObject Room2Spawn;
	public GameObject Room3;
	public GameObject Room3Spawn;
	public GameObject BossRoom;
	public GameObject BossRoomSpawn;

	public GameObject Rdoor1;
	public GameObject Rdoor2;
	public GameObject Rdoor3;
	public GameObject Bdoor;

	public Sprite DoorOpen;
	public Sprite DoorClosed;

	public int number;

	private LocustSpawn SpawnScript;

	public GameObject[] Enemies;

	public float cooldown = 0f;

	void Start () 
	{
		CurrentDoor = null;
	}

	void Update () 
	{
		cooldown -= Time.deltaTime;
		Enemies = GameObject.FindGameObjectsWithTag ("Locust");
	}

	void Transport ()
	{
		//PlayerCamera.SetActive (false);
		//Camera.SetActive (true);

		number = Random.Range (1, 4);
		if (number == 1) 
		{
			SpawnScript = Room1Spawn.GetComponent<LocustSpawn> ();
			Camera.transform.position = Room1.transform.position;
			transform.position = Rdoor1.transform.position;
			SpawnScript.Spawn ();
			SpawnScript = null;
		}
		if (number == 2) 
		{
			SpawnScript = Room2Spawn.GetComponent<LocustSpawn> ();
			Camera.transform.position = Room2.transform.position;
			transform.position = Rdoor2.transform.position;
			SpawnScript.Spawn ();
			SpawnScript = null;
		}
		if (number == 3) 
		{
			SpawnScript = Room3Spawn.GetComponent<LocustSpawn> ();
			Camera.transform.position = Room3.transform.position;
			transform.position = Rdoor3.transform.position;
			SpawnScript.Spawn ();
			SpawnScript = null;
		}

		//cooldown = 2f;
	}
	void OnCollisionEnter2D (Collision2D col)
	{
		/////////////////////////////////////////////////////////////////////////////////////////
		//////////////////////////|CORRIDOR DOORS|///////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////////////////////////
		if (col.gameObject.tag == "door" && Enemies.Length == 0 && cooldown < 0) {
			if (col.gameObject.name == "Cdoor1") 
			{
				Debug.Log ("Cdoor 1");
				CurrentDoor = col.gameObject;
				Transport ();
			}
			if (col.gameObject.name == "Cdoor2") 
			{
				Debug.Log ("Cdoor 2");
				CurrentDoor = col.gameObject;
				Transport ();
			}
			if (col.gameObject.name == "Cdoor3") 
			{
				Debug.Log ("Cdoor 3");
				CurrentDoor = col.gameObject;
				Transport ();
			}
			if (col.gameObject.name == "Cdoor4") 
			{
				Debug.Log ("Cdoor 4");
				CurrentDoor = col.gameObject;
				Transport ();
			}
			if (col.gameObject.name == "Cdoor5") 
			{
				Debug.Log ("Cdoor 5");
				CurrentDoor = col.gameObject;
				Transport ();
			}
			if (col.gameObject.name == "Cdoor6") 
			{
				Debug.Log ("Cdoor 6");
				CurrentDoor = col.gameObject;
				Transport ();
			}
			if (col.gameObject.name == "Cdoor7") 
			{
				Debug.Log ("Cdoor 7");
				CurrentDoor = col.gameObject;
				Transport ();
			}
			if (col.gameObject.name == "Cdoor8") 
			{
				Debug.Log ("Cdoor 8");
				CurrentDoor = col.gameObject;
				Transport ();
			}
			if (col.gameObject.name == "Cdoor9") 
			{
				Debug.Log ("Cdoor 9");
				CurrentDoor = col.gameObject;
				Transport ();
			}
			if (col.gameObject.name == "Cdoor10") 
			{
				Debug.Log ("Cdoor 10");
				CurrentDoor = col.gameObject;
				Transport ();
			}
			/////////////////////////////////////////////////////////////////////////////////////////
			//////////////////////////|ROOM DOORS|///////////////////////////////////////////////////
			/////////////////////////////////////////////////////////////////////////////////////////
			if (col.gameObject.name == "Rdoor1") 
			{
				Debug.Log ("rdoor 1");
				transform.position = CurrentDoor.transform.position;
				CurrentDoor = null;
				PlayerCamera.SetActive (true);
				Camera.SetActive (false);
				//Camera.transform.position = Corridor.transform.position;
				cooldown = 2f;
			}
			if (col.gameObject.name == "Rdoor2") 
			{
				Debug.Log ("rdoor 2");
				transform.position = CurrentDoor.transform.position;
				CurrentDoor = null;
				PlayerCamera.SetActive (true);
				Camera.SetActive (false);
				//Camera.transform.position = Corridor.transform.position;
				cooldown = 2f;
			}
			if (col.gameObject.name == "Rdoor3") 
			{
				Debug.Log ("rdoor 3");
				transform.position = CurrentDoor.transform.position;
				CurrentDoor = null;
				PlayerCamera.SetActive (true);
				Camera.SetActive (false);
				//Camera.transform.position = Corridor.transform.position;
				cooldown = 2f;
			}
			/////////////////////////////////////////////////////////////////////////////////////////
			//////////////////////////|BOSS DOOR|////////////////////////////////////////////////////
			/////////////////////////////////////////////////////////////////////////////////////////
			if (col.gameObject.name == "BossDoor") 
			{
				PlayerCamera.SetActive (false);
				BossCam.SetActive (true);
				SpawnScript = BossRoomSpawn.GetComponent<LocustSpawn> ();
				SpawnScript.BossRoom = true;
				this.transform.position = BossRoom.transform.position;
				this.transform.position += new Vector3 (0, 0, -44);
				Camera.transform.position = BossRoom.transform.position;
				SpawnScript.Spawn ();
				SpawnScript = null;
			}
		}
	}

}