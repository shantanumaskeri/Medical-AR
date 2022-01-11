using UnityEngine;
using System.Collections;

public class CharacterManagerBehaviour : MonoBehaviour
{

	public GameObject modelCostumeRef;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (0))
		{
			modelCostumeRef.SetActive (false);
		}
	}
}
