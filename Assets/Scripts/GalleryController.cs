
using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class GalleryController : MonoBehaviour
{
    /*
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
    */

    public int index;
    int indexMax;
    GameObject[] leftCubes;
    GameObject[] rightCubes;

    void Start()
    {
        string leftPath = "LeftCubeMaps"; // Resources/path
        string rightPath = "RightCubeMaps";

        leftCubes = Resources.LoadAll<GameObject>(leftPath);
        rightCubes = Resources.LoadAll<GameObject>(rightPath);

        indexMax = leftCubes.Length - 1;
        Instantiate(leftCubes[0]);
        Instantiate(rightCubes[0]);
    }

    public void ChangeCubeMap(bool forward)
    {
        Destroy(GameObject.Find(leftCubes[index].name + "(Clone)"));
        if (forward)
            index++;
        else
            index--;
        IsIndexOutOfBounds();
        Instantiate(leftCubes[index]);

    }

    public void ChangeCubeMapStereo(bool forward)
    {
        Destroy(GameObject.Find(leftCubes[index].name + "(Clone)"));
        Destroy(GameObject.Find(rightCubes[index].name + "(Clone)"));
        if (forward)
            index++;
        else
            index--;
        IsIndexOutOfBounds();
        Instantiate(leftCubes[index]);
        Instantiate(rightCubes[index]);

    }

    void IsIndexOutOfBounds()
    {
        if (index < 0)
            index = indexMax;
        else if (index > indexMax)
            index = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
            ChangeCubeMapStereo(true);
        if (Input.GetKeyDown(KeyCode.M))
            ChangeCubeMapStereo(false);
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

