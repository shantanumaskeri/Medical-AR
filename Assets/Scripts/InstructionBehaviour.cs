using UnityEngine;
using System.Collections;

public class InstructionBehaviour : MonoBehaviour 
{

	public GameObject instructionStep1;
	public GameObject instructionStep2;
	public GameObject initializingStep;
	public Texture2D progressBar;
	
	AsyncOperation loadOp;

	float originalWidth = 640.0f; 
	float originalHeight = 1136.0f;
	float progress;

	Vector3 scale;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			
			if (Physics.Raycast (ray, out hit))
			{
				HideInstructionSteps ();
				MoveToApplication ();
			}
		}

		if (Input.touchCount == 1)
		{
			for (int i = 0; i < Input.touchCount; i++)
			{
				Touch touch = Input.GetTouch(i);

				if (touch.phase == TouchPhase.Began)
				{
					RaycastHit hit;
					Ray ray = Camera.main.ScreenPointToRay (touch.position);
					
					if (Physics.Raycast (ray, out hit))
					{
						if (hit.collider.name == "InstructionScreen")
						{
							HideInstructionSteps ();
							MoveToApplication ();
						}
					}
				}
			}
		}
	}

	void OnGUI ()
	{
		if (loadOp != null)
		{
			scale.x = Screen.width/originalWidth; 
			scale.y = Screen.height/originalHeight; 
			scale.z = 1;
			var svMat = GUI.matrix; 
			GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);

			progress = loadOp.progress;

			GUI.DrawTexture (new Rect (80, 700, 400 * Mathf.Clamp01(progress), 50), progressBar);
		}
	}

	void HideInstructionSteps ()
	{
		instructionStep1.SetActive (false);
		instructionStep2.SetActive (false);
		initializingStep.SetActive (true);
	}

	void MoveToApplication ()
	{
		loadOp = Application.LoadLevelAsync ("medicARe");
	}
}
