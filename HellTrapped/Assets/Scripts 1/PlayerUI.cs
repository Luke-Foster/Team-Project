using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerUI : MonoBehaviour {

	public GameObject Heart1;
	public GameObject Heart2;
	public GameObject Heart3;
	public GameObject Heart4;
	public GameObject Heart5;

	public float health;
	public GameObject Player;
	private PlayerController Controller;

    public GameObject Holy;
    public GameObject Blood;
    public GameObject Poison;
    public GameObject Oil;
    public GameObject Select;

	public Text HolyNum;
	public Text BloodNum;
	public Text PoisonNum;
	public Text OilNum;


    void Start () 
	{
		Controller = Player.GetComponent<PlayerController> ();
        Select.transform.position = Holy.transform.position;
	}

	void Update () 
	{
		health = Controller.Health;
		if (health == 4) {
			Heart5.SetActive (false);
		}
		else if (health == 3) {
			Heart5.SetActive (false);
			Heart4.SetActive (false);
		}
		else if (health == 2) {
			Heart5.SetActive (false);
			Heart4.SetActive (false);
			Heart3.SetActive (false);
		}
		else if (health == 1) {
			Heart5.SetActive (false);
			Heart4.SetActive (false);
			Heart3.SetActive (false);
			Heart2.SetActive (false);
		}
		else if (health == 0) {
			Heart5.SetActive (false);
			Heart4.SetActive (false);
			Heart3.SetActive (false);
			Heart2.SetActive (false);
			Heart1.SetActive (false);
		}
        if (Controller.AmmoType == "Holy")
        {
            Select.transform.position = Holy.transform.position;
        }
        if (Controller.AmmoType == "Blood")
        {
            Select.transform.position = Blood.transform.position;
        }
        if (Controller.AmmoType == "Poison")
        {
            Select.transform.position = Poison.transform.position;
        }
        if (Controller.AmmoType == "Oil")
        {
            Select.transform.position = Oil.transform.position;
        }
			
		HolyNum.text = Controller.HolyAmmo.ToString ();
		OilNum.text = Controller.OilAmmo.ToString ();
		BloodNum.text = Controller.BloodAmmo.ToString ();
		PoisonNum.text = Controller.PoisonAmmo.ToString ();
    }
}
