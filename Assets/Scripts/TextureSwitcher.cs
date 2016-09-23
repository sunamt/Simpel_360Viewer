using UnityEngine;
using System.Collections;

public class TextureSwitcher : MonoBehaviour {

	public void Switch(string folder, int index)
    {
        Debug.Log("Getting sprites from: " + folder + "/" + index + "/" + gameObject.name);

        Sprite newTexture = Resources.Load<Sprite>(folder + "/" + index + "/" + gameObject.name);
        gameObject.GetComponent<SpriteRenderer>().sprite = newTexture;
    }

}
