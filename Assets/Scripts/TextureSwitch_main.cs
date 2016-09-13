using System.Collections;
using UnityEngine;
using VRStandardAssets.Utils;

namespace VRStandardAssets.MainMenu
{
    // This script changes tint color
    // whilst the user is looking at it.
	public class TextureSwitch_main : MonoBehaviour
	{

		[SerializeField] private MeshRenderer m_ScreenMesh;             // The mesh renderer who's texture will be changed.
		[SerializeField] private VRInteractiveItem m_VRInteractiveItem; // The VRInteractiveItem that needs to be looked at for the textures to play.
		[SerializeField] private Texture[] m_AnimTextures;              // The textures that will be looped through.

		private int m_CurrentTextureIndex;                              // The index of the textures array.
		private bool m_Playing;                                         // Whether the textures are currently being looped through.


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
			// When the user looks at the VRInteractiveItem the textures load vr index1.
			m_Playing = true;
			//  StartCoroutine (PlayTextures ());
			m_CurrentTextureIndex = 1;
			m_ScreenMesh.material.mainTexture = m_AnimTextures[m_CurrentTextureIndex];
		}


		private void HandleOut ()
		{
			// When the user looks away from the VRInteractiveItem the textures load vr index1.
			m_Playing = false;
			m_CurrentTextureIndex = 0;
			m_ScreenMesh.material.mainTexture = m_AnimTextures[m_CurrentTextureIndex];
		}

	}
}