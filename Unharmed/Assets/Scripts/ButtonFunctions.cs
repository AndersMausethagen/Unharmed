using UnityEngine;
using System.Collections;

public class ButtonFunctions : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	 public void startGame()
	{
		Application.LoadLevel (1);
	}

	public void quitGame()
	{
		Application.Quit ();
	}
}
