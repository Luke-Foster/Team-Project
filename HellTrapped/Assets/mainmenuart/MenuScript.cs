using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

    public void Menu()
    {
        Application.LoadLevel(0);
    }
    public void StartGame()
	{
		Application.LoadLevel (1);
	}
	public void Control()
	{
		Application.LoadLevel (2);
	}
	public void Quit()
	{
		Application.Quit();
	}
}
