using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour

{

	public Camera cm;
	public float cmSize;
	public float standardsize = 40;


	// Use this for initialization
	void Start () 
	{
		//cm.orthographicSize = standardsize;
		cm.fieldOfView = standardsize;
		cmSize = standardsize;

	}
	
	// Update is called once per frame
	void Update () 
	{
		cm.fieldOfView = cmSize;

	}
}
