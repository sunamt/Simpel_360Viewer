using UnityEngine;

namespace VRStandardAssets.Utils
{ 
    // This class fades in and out arrows which indicate to
    // the player which direction they should be facing.
	public class PopUpmenu : MonoBehaviour
    {
        [SerializeField] private float m_FadeDuration = 0.5f;       // How long it takes for the arrows to appear and disappear.
        [SerializeField] private float m_ShowAngle = 60f;   
		[SerializeField] private float m_TurnAngle = 50f;  // How far from the desired facing direction the player must be facing for the arrows to appear.
        [SerializeField] private Transform m_DesiredDirection;      // Indicates which direction the player should be facing (uses world space forward if null).
        [SerializeField] private Transform m_Camera;                // Reference to the camera to determine which way the player is facing.
		[SerializeField] private TextMesh[] m_TextMeshes;                    // Reference to the mext meshes of the arrows used to fade them in and out.

        [SerializeField]
        private MeshRenderer m_Mesh;


        private float m_CurrentAlpha;                               // The alpha the arrows currently have.
        private float m_TargetAlpha;                                // The alpha the arrows are fading towards.
        private float m_FadeSpeed;                                  // How much the alpha should change per second (calculated from the fade duration).


        private const string k_MaterialPropertyName = "_Alpha";     // The name of the alpha property on the shader being used to fade the arrows.


	    private void Start ()
	    {
            // Speed is distance (zero alpha to one alpha) divided by time (duration).
            m_FadeSpeed = 1f / m_FadeDuration;
	    }


        private void Update()
        {
            // The vector in which the player should be facing is the forward direction of the transform specified or world space.
            Vector3 desiredForward = m_DesiredDirection == null ? Vector3.forward : m_DesiredDirection.forward;

            // The forward vector of the camera as it would be on a flat plane.
			Vector3 flatCamForward = Vector3.ProjectOnPlane(transform.forward, Vector3.right).normalized;

			Vector3 flatCamHoriz = Vector3.ProjectOnPlane(transform.forward, Vector3.up).normalized;

            // The difference angle between the desired facing and the current facing of the player.
            float angleDelta = Vector3.Angle (desiredForward, flatCamForward);


			float angleDeltaHoriz = Vector3.Angle (desiredForward, flatCamHoriz);

			if (angleDeltaHoriz > m_TurnAngle) {

				Vector3 camLook = m_Camera.transform.forward;
				camLook.y = 0f;
				Quaternion camQuat = Quaternion.LookRotation (camLook);

				transform.rotation = Quaternion.Slerp(transform.rotation, camQuat, Time.deltaTime);
			}

            // If the difference is greater than the angle at which the arrows are shown, their target alpha is one otherwise it is zero.
            m_TargetAlpha = angleDelta > m_ShowAngle ? 1f : 0f;

            // Increment the current alpha value towards the now chosen target alpha and the calculated speed.
            m_CurrentAlpha = Mathf.MoveTowards (m_CurrentAlpha, m_TargetAlpha, m_FadeSpeed * Time.deltaTime);

            // Go through all the arrow renderers and set the given property of their material to the current alpha.
			for (int i = 0; i < m_TextMeshes.Length; i++)
            {
				m_TextMeshes[i].color = new Color (m_TextMeshes [i].color.r, m_TextMeshes [i].color.b, m_TextMeshes [i].color.g, m_CurrentAlpha);
            }

            m_Mesh.material.SetFloat("_Alpha", m_CurrentAlpha);
        }


        // Turn off the arrows entirely.
        public void Hide()
        {
            gameObject.SetActive(false);
        }


        // Turn the arrows on.
        public void Show ()
        {
            gameObject.SetActive(true);
        }
    }
}