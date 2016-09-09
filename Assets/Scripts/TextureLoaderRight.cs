/*using UnityEngine;
using System.Collections;

public class TextureLoaderRight : MonoBehaviour 
{
	public Renderer Rend;
	public GalleryController Curr;
	public GalleryController texR;

	private int CurrentTexture;

	// Use this for initialization
	void Start () 
	{
		Rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		CurrentTexture = Curr.currentImg;
		Rend.material.mainTexture = texR.texRigth [CurrentTexture];
	}
}
*/