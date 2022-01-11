using UnityEngine;
using System.Collections;
using Lean;

public class GuiBehaviour : MonoBehaviour 
{

	public static GuiBehaviour Instance;

	public GameObject trackedModel;

	static bool isVisible = true;
	static float fontSize;
	static float screenResX;
	static float screenResY;

	// Use this for initialization
	void Start () 
	{
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnGUI ()
	{
		if (isVisible)
		{
			if (TargetBehaviour.Instance.mShowGUI)
			{
				switch (Input.deviceOrientation)
				{
				case DeviceOrientation.LandscapeLeft:
					screenResX = Screen.width * 0.234375f;
					screenResY = Screen.height * 0.125f;
					fontSize = Screen.width * 0.0234375f;
					break;

				case DeviceOrientation.Portrait:
					screenResX = Screen.width * 0.4167f;
					screenResY = Screen.height * 0.0703125f;
					fontSize = Screen.width * 0.04167f;
					break;

				default:
					break;
				}

				if (GUI.Button (new Rect (0, 0, screenResX, screenResY), "<size="+fontSize+">Next</size>"))
				{
					//modelCostumeRef.SetActive (false);
					isVisible = false;

					trackedModel.GetComponent<SimpleMove>().enabled = true;
					trackedModel.GetComponent<SimpleRotateScale>().enabled = true;
				}
			}
		}
	}
}
