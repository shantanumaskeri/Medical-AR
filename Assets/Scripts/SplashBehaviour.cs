using UnityEngine;
using System.Collections;

public class SplashBehaviour : MonoBehaviour 
{

	public float changeTime = 3.0f;

	// Use this for initialization
	void Start () 
	{
		Invoke ("MoveToInstruction", changeTime);
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void MoveToInstruction ()
	{
		Application.LoadLevelAsync ("instruction");
	}
}
