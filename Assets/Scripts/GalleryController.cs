
using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class GalleryController : MonoBehaviour 
{
	public int index;

	public Renderer renderer;

	//path: resources/textures/360_pics/0...
	//folder: 360_pics or 360_stereo_pics, imgnum: 0,1,2
	void Replace(string folder, int imgnum)
	{
		renderer = GetComponent<Renderer>();
		Material[] mats = renderer.materials; //element 0-5
		Object[] textures = Resources.LoadAll(folder + "/" + imgnum); //requires a folder called resources. looking at resources/folder/imgnum
		for(int i = 0; i <= mats.Length-1; i++)
		{
			mats[i].mainTexture = (Texture)textures[i]; // set material i's main texture to texture i <- needs the textures to be ordered so that the first in the list fits the correct surface of the cubemap
		}
	}

	// Need a way to return to beginning or end when reaching the opposite
	public void NextTexture(bool forward)
	{
		string folder = "360_pics";
		if (forward)
			index++;
		else
			index--;
		Replace(folder,index);
	}

}

	/*[SerializeField] private VRInput m_VrInput;                        // Reference to the VRInput to subscribe to swipe events.
	public int currentImg;
	public Texture[] texLeft;
	public Texture[] texRigth;

	private int TotalTex;
	void Start() 
	{
		TotalTex = texLeft.Length-1;
	}

	void Update () 
	{
		
	}
	void ImgCheck ()
	{
		if (currentImg <= 0) {
			currentImg = 0;
		}
		if (currentImg > TotalTex) {
			currentImg = 0;
		}
	}

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
			currentImg--;
			ImgCheck();
			break;

		case VRInput.SwipeDirection.RIGHT:
			currentImg++;
			ImgCheck();
			break;
		}
	}
*/

