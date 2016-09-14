using UnityEngine;
using System.Collections;

public class Thumbnail : MonoBehaviour {

	public void SetThumbnail(Texture t)
    {
        gameObject.GetComponent<Renderer>().material.mainTexture = t;
    }
}