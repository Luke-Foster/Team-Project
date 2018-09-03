using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject Player;
	public GameObject Down;
	public GameObject Up;
	public GameObject Left;
	public GameObject Right;
	public Vector3 spawnspot = new Vector3 (0, 0, 0);

	public Sprite HolyS;
	public Sprite BloodS;
	public Sprite PoisonS;
	public Sprite OilS;

	public Sprite BackHoly;
	public Sprite LeftHoly;
	public Sprite RightHoly;

	public Animator anim;

	public float MoveSpeed = 2f;
	public float Delay = 0f;
	public bool DelayOver = true;
	public float Health = 5f;
	public float Reload = 5f;
	public float ShotSpeed = 10f;
	public float Range = 15f;
	public float Damage = 1f;
	public string AmmoType = "Holy";

	public int HolyAmmo = 10;
	public int BloodAmmo = 0;
	public int PoisonAmmo = 0;
	public int OilAmmo = 0;

	public bool OutOfAmmo = false;

	public bool Dead = false;

	private SpriteRenderer spriteRenderer;

	void Start () {
		spawnspot = Player.transform.position;
	}

	// Update is called once per frame
	void Update () {
		spriteRenderer = GetComponent<SpriteRenderer>();

		if (Health > 0f) {
			float v = Input.GetAxis ("Vertical");
			float h = Input.GetAxis ("Horizontal");
			ManageMovement (h, v);

			if (Delay > 0) {
				Delay -= 0.1f;
				DelayOver = false;
			} else {
				DelayOver = true;
			}


			if (Input.GetAxis ("ShootD") > 0 && DelayOver && !OutOfAmmo)
				ShootDown ();
			else if (Input.GetAxis ("ShootU") > 0 && DelayOver && !OutOfAmmo)
				ShootUp ();
			else if (Input.GetAxis ("ShootL") > 0 && DelayOver && !OutOfAmmo)
				ShootLeft ();
			else if (Input.GetAxis ("ShootR") > 0 && DelayOver && !OutOfAmmo)
				ShootRight ();
//Ammo Types
			if (Input.GetKeyDown (KeyCode.Alpha1) && HolyAmmo > 0) {
				AmmoType = "Holy";
				spriteRenderer.sprite = HolyS;
				OutOfAmmo = false;
			} 
			else if (Input.GetKey (KeyCode.Alpha2) && BloodAmmo > 0) {
				AmmoType = "Blood";
				spriteRenderer.sprite = BloodS;
				OutOfAmmo = false;
			} 
			else if (Input.GetKey (KeyCode.Alpha3) && PoisonAmmo > 0) {
				AmmoType = "Poison";
				spriteRenderer.sprite = PoisonS;
				OutOfAmmo = false;
			}
			else if (Input.GetKey (KeyCode.Alpha4) && OilAmmo > 0) {
				AmmoType = "Oil";
				spriteRenderer.sprite = OilS;
				OutOfAmmo = false;
			}
		}
		else {
			Dead = true;
			ManageMovement (0, 0);
			OutOfAmmo = true;
            //Player Dead display death
            Application.LoadLevel(3);
		}
	}

	void ManageMovement(float horizontal,float vertical) {

		anim.SetFloat ("Horizontal", horizontal);
		anim.SetFloat ("Vertical", vertical);

		if (horizontal < 0)
			spriteRenderer.sprite = LeftHoly;
		else if (horizontal > 0)
			spriteRenderer.sprite = RightHoly;
		else if (vertical > 0)
			spriteRenderer.sprite = BackHoly;
		else if (vertical < 0)
			spriteRenderer.sprite = HolyS;
		
		Vector3 movement = new Vector3 ((horizontal * MoveSpeed),(vertical * MoveSpeed), 0);
		GetComponent<Rigidbody2D>().velocity = movement;
	}

	void ShootDown()
	{
		spawnspot = (Player.transform.position - new Vector3 (0, 1, 0));
		GameObject Liquid = Instantiate (Down, spawnspot, Quaternion.identity) as GameObject;
		Liquid.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -ShotSpeed);
		spriteRenderer.sprite = HolyS;
		Delay = Reload;
		if (AmmoType == "Holy") {
			HolyAmmo -= 1;
			if (HolyAmmo <= 0)
				OutOfAmmo = true;
		} 
		else if (AmmoType == "Oil") {
			OilAmmo -= 1;
			if (OilAmmo <= 0)
				OutOfAmmo = true;
		}
		else if (AmmoType == "Blood") {
			BloodAmmo -= 1;
			if (BloodAmmo <= 0)
				OutOfAmmo = true;
		}
		else if (AmmoType == "Poison") {
			PoisonAmmo -= 1;
			if (PoisonAmmo <= 0)
				OutOfAmmo = true;
		}
	}

	void ShootUp()
	{
		spawnspot = (Player.transform.position - new Vector3 (0, -1, 0));
		GameObject Liquid = Instantiate (Up, spawnspot, Quaternion.identity) as GameObject;
		Liquid.GetComponent<Rigidbody2D>().velocity = new Vector2(0, ShotSpeed);
		spriteRenderer.sprite = BackHoly;
		Delay = Reload;
		if (AmmoType == "Holy") {
			HolyAmmo -= 1;
			if (HolyAmmo <= 0)
				OutOfAmmo = true;
		} 
		else if (AmmoType == "Oil") {
			OilAmmo -= 1;
			if (OilAmmo <= 0)
				OutOfAmmo = true;
		}
		else if (AmmoType == "Blood") {
			BloodAmmo -= 1;
			if (BloodAmmo <= 0)
				OutOfAmmo = true;
		}
		else if (AmmoType == "Poison") {
			PoisonAmmo -= 1;
			if (PoisonAmmo <= 0)
				OutOfAmmo = true;
		}
	}

	void ShootLeft()
	{
		spawnspot = (Player.transform.position - new Vector3 (1, 0, 0));
		GameObject Liquid = Instantiate (Left, spawnspot, Quaternion.identity) as GameObject;
		Liquid.GetComponent<Rigidbody2D>().velocity = new Vector2(-ShotSpeed, 0);
		spriteRenderer.sprite = LeftHoly;
		Delay = Reload;
		if (AmmoType == "Holy") {
			HolyAmmo -= 1;
			if (HolyAmmo <= 0)
				OutOfAmmo = true;
		} 
		else if (AmmoType == "Oil") {
			OilAmmo -= 1;
			if (OilAmmo <= 0)
				OutOfAmmo = true;
		}
		else if (AmmoType == "Blood") {
			BloodAmmo -= 1;
			if (BloodAmmo <= 0)
				OutOfAmmo = true;
		}
		else if (AmmoType == "Poison") {
			PoisonAmmo -= 1;
			if (PoisonAmmo <= 0)
				OutOfAmmo = true;
		}
	}

	void ShootRight()
	{
		spawnspot = (Player.transform.position - new Vector3 (-1, 0, 0));
		GameObject Liquid = Instantiate (Right, spawnspot, Quaternion.identity) as GameObject;
		Liquid.GetComponent<Rigidbody2D>().velocity = new Vector2(ShotSpeed, 0);
		spriteRenderer.sprite = RightHoly;
		Delay = Reload;
		if (AmmoType == "Holy") {
			HolyAmmo -= 1;
			if (HolyAmmo <= 0)
				OutOfAmmo = true;
		} 
		else if (AmmoType == "Oil") {
			OilAmmo -= 1;
			if (OilAmmo <= 0)
				OutOfAmmo = true;
		}
		else if (AmmoType == "Blood") {
			BloodAmmo -= 1;
			if (BloodAmmo <= 0)
				OutOfAmmo = true;
		}
		else if (AmmoType == "Poison") {
			PoisonAmmo -= 1;
			if (PoisonAmmo <= 0)
				OutOfAmmo = true;
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "PickUp")  // Temp tag
			Destroy (col.gameObject); 
		
		else if (col.tag == "OilPickUp") 
		{
			Destroy (col.gameObject);
			OilAmmo += 10;
		}
		else if (col.tag == "BloodPickUp") 
		{
			Destroy (col.gameObject);
			BloodAmmo += 10;
		}
		else if (col.tag == "HolyPickUp") 
		{
			Destroy (col.gameObject);
			HolyAmmo += 10;
		}
		else if (col.tag == "PoisonPickUp") 
		{
			Destroy (col.gameObject);
			PoisonAmmo += 10;
		}

	}
}
