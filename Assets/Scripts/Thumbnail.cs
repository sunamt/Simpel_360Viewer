using UnityEngine;
using System.Collections;

public class Thumbnail : MonoBehaviour {

    public int number;

	public void SetThumbnail(Texture t, int i)
    {
        gameObject.GetComponent<Renderer>().material.mainTexture = t;
        number = i;
    }
}