using UnityEngine;
using System.Collections;
using Vuforia;

public class TargetBehaviour : MonoBehaviour, ITrackableEventHandler 
{

	public static TargetBehaviour Instance;

	private TrackableBehaviour mTrackableBehaviour;

	public bool mShowGUI = false;

	// Use this for initialization
	void Start () 
	{
		Instance = this;

		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		
		if (mTrackableBehaviour) 
		{
			mTrackableBehaviour.RegisterTrackableEventHandler (this);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	public void OnTrackableStateChanged (TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.TRACKED || newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			mShowGUI = true;
		}
		else
		{
			mShowGUI = false;
		}
	}
}
