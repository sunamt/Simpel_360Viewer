using UnityEngine;
using System.Collections;

using System.IO;

public class CubeController : MonoBehaviour
{

    ViewController vc;
    int index;
    public int indexMax = 5;
    public string folder;

    void Start()
    {
        vc = GameObject.Find("ViewControllerTemp").GetComponent<ViewController>();
        index = vc.startImg;

        FindIndexMax(folder);
    }

    public void LoadTextures(bool forward)
    {
        if (forward)
            index++;
        else
            index--;
        IsIndexOutOfBounds();
        TextureSwitcher[] tss = gameObject.GetComponentsInChildren<TextureSwitcher>();
        foreach (TextureSwitcher ts in tss)
            ts.Switch(folder, index);
    }

    void IsIndexOutOfBounds()
    {
        if (index < 0)
            index = indexMax;
        else if (index > indexMax)
            index = 0;
    }

    void FindIndexMax(string folder)
    {
        string[] dir = Directory.GetDirectories(Application.dataPath + "/Resources/" + folder);
        indexMax = dir.Length - 1;
    }
}
