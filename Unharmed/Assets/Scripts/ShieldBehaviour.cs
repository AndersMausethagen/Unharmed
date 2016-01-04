using UnityEngine;
using System.Collections;

public class ShieldBehaviour : MonoBehaviour 
{
	GameObject character;
	GameObject shield;
	public bool active = false;


	// Use this for initialization
	void Start () 
	{
		character = GameObject.FindGameObjectWithTag ("Player");
		shield = GameObject.FindGameObjectWithTag ("Shield");
	}
	
	// Update is called once per frame
	void Update () 
	{
		setActive ();

		Vector3 mousepos = Input.mousePosition;
		Vector3 player = new Vector3 (character.transform.position.x, character.transform.position.y);
		//shield.transform.rotation = Quaternion.Euler(0,0,mousepos.x)
		shield.transform.RotateAround(player,mousepos,100 *Time.deltaTime);

		//Vector2 objectpos = mousepos - shield;
		
		
	}
	
	void setActive()
	{
		if (Input.GetMouseButtonDown(0)) 
		{
			active = !active;
			Debug.Log (active);
		}
		if (active == true) 
		{
			shield.SetActive(true);
		}
		if (active == false) 
		{
			shield.SetActive(false);
		}

		
	}

}
