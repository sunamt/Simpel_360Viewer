using System.Collections;
using UnityEngine;
using VRStandardAssets.Utils;

namespace VRStandardAssets.MainMenu
{
    // This script changes tint color
    // whilst the user is looking at it.
	public class ButtonHover : MonoBehaviour
    {

        [SerializeField] private MeshRenderer m_ScreenMesh;             // The mesh renderer who's texture will be changed.
        [SerializeField] private VRInteractiveItem m_VRInteractiveItem; // The VRInteractiveItem that needs to be looked at for the textures to play.
       											

		private bool m_Playing;      									// Whether the textures are currently being looped through.

																		
		void Awake () {
			m_ScreenMesh.material.SetColor ("_Tint", Color.grey);
		}

        private void OnEnable ()
        {
            m_VRInteractiveItem.OnOver += HandleOver;
            m_VRInteractiveItem.OnOut += HandleOut;
        }


        private void OnDisable ()
        {
            m_VRInteractiveItem.OnOver -= HandleOver;
            m_VRInteractiveItem.OnOut -= HandleOut;
        }


        private void HandleOver ()
        {
			// When the user looks at the VRInteractiveItem the tint color changes
            m_Playing = true;
			m_ScreenMesh.material.SetColor ("_Tint", Color.white);
        }


        private void HandleOut ()
        {
			// When the user looks away from the VRInteractiveItem the tint color changes
            m_Playing = false;
			m_ScreenMesh.material.SetColor ("_Tint", Color.grey);
        }

    }
}