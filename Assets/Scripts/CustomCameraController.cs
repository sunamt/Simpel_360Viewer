using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class CustomCameraController : MonoBehaviour {

	public float forwardVel = 2;
	public float acceleration = 1f;
	[SerializeField] private VRInput m_VrInput;                         // Reference to the VRInput to subscribe to swipe events.
	public float swipeDirectionFloat = 0;
	public float swSpeedForward = 25f;
	public float swSpeedBack = -15f;
	public float camHeight = 0.92f;
	private float vert;
	float forwardInput, turnInput;

	public Transform cameraTransform;
	public Rigidbody rBody;
	Quaternion targetRotation;
	public Quaternion TargetRotation 
	{
		get { return targetRotation; }
	}
		
	// Use this for initialization
	void Start () 
	{
		this.transform.position = GameObject.Find("NewEntryPoint").transform.position;
		this.transform.Translate (Vector3.up * camHeight);
		targetRotation = transform.rotation;
		forwardInput = turnInput = 0;
	}

	void GetInput () 
	{
		forwardInput = Input.GetAxis ("Vertical") + swipeDirectionFloat;
		swipeDirectionFloat = 0f;
	}

	void Update () 
	{
		GetInput ();
	}

	void FixedUpdate () 
	{
		Walk();
	}

	void Walk()
	{
		//move
		Vector3 dir = cameraTransform.forward;
		dir.y = 0;

		Vector3 targetVelocity = dir * forwardInput * forwardVel;
		rBody.velocity = Vector3.Lerp(rBody.velocity, targetVelocity, Time.deltaTime * acceleration);
	}

	/* new stuff */
	private void OnEnable ()
	{
		m_VrInput.OnSwipe += HandleSwipe;
	}
		
	private void OnDisable ()
	{
		m_VrInput.OnSwipe -= HandleSwipe;
	}
		
	private void HandleSwipe(VRInput.SwipeDirection swipeDirection)
	{
		switch (swipeDirection)
		{
		case VRInput.SwipeDirection.LEFT:
			this.swipeDirectionFloat = swSpeedForward;
			break;

		case VRInput.SwipeDirection.RIGHT:
			this.swipeDirectionFloat = swSpeedBack;
			break;
		}
	}
}
