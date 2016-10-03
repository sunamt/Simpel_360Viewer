
using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class GalleryController : MonoBehaviour
{
    public int index;
    int indexMax;
    GameObject[] leftCubes;
    GameObject[] rightCubes;
    ViewController view;

    GameObject bc;
    GameObject lc;
    GameObject rc;

    Camera cam;

    void Start()
    {
        view = GameObject.Find("ViewController").GetComponent<ViewController>();

        cam = GameObject.Find("Camera_Right").GetComponent<Camera>();

        bc = GameObject.Find("BothCube");
        lc = GameObject.Find("LeftCube");
        rc = GameObject.Find("RightCube");

        if (view.isStereo)
        {
            bc.SetActive(false);
            lc.GetComponent<CubeController>().Initialize();
            rc.GetComponent<CubeController>().Initialize();

        }
        else
        {
            lc.SetActive(false);
            rc.SetActive(false);
            bc.GetComponent<CubeController>().Initialize();
        }

        // InitializeCubeMaps(view.isStereo, index);
    }

    public void ToggleStereo()
    {
        cam.cullingMask ^= 1 << 9; // R
        cam.cullingMask ^= 1 << 8; // L
        view.isStereo = !view.isStereo;
    }

/*
    void InitializeCubeMaps(bool stereo, int start)
    {

        string leftPath = "LeftCubeMaps";
        string rightPath = "RightCubeMaps";
        if (stereo)
        {
            leftCubes = Resources.LoadAll<GameObject>(leftPath);
            rightCubes = Resources.LoadAll<GameObject>(rightPath);
            Instantiate(leftCubes[start]);
            Instantiate(rightCubes[start]);
        }
        else
        {
            leftCubes = Resources.LoadAll<GameObject>(leftPath);
            Instantiate(leftCubes[start]);
        }
        indexMax = leftCubes.Length - 1;
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
*/

 /*   void IsIndexOutOfBounds()
    {
        if (index < 0)
            index = indexMax;
        else if (index > indexMax)
            index = 0;
    }*/
}