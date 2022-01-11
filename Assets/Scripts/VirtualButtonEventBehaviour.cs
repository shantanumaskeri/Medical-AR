using UnityEngine;
using System.Collections;
using Vuforia;

public class VirtualButtonEventBehaviour : MonoBehaviour, IVirtualButtonEventHandler 
{

	public static VirtualButtonEventBehaviour Instance;

	public GameObject trackedModel;

	static bool isVisible = true;

	// Use this for initialization
	void Start () 
	{
		Instance = this;

		VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();

		for (int i = 0; i<vbs.Length; i++) 
		{
			vbs[i].RegisterEventHandler (this);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void OnButtonPressed (VirtualButtonAbstractBehaviour vb) 
	{ 
		isVisible = !isVisible;

		trackedModel.SetActive (isVisible);
	}

	public void OnButtonReleased (VirtualButtonAbstractBehaviour vb) 
	{ 

	}
}
