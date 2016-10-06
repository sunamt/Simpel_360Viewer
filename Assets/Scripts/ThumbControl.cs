using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using VRStandardAssets.Utils;

public class ThumbControl : MonoBehaviour {

    GameObject thumbnail;
    public Texture[] thumbs;
    public Texture[] thumbsStereo;
    private List<Thumb> thumbList = new List<Thumb>();
    
    class Thumb {
        public Texture texture;
        public int num;

        public Thumb(Texture t, int i)
        {
            texture = t;
            num = i;
        }
    }

    void Start()
    {
        ViewController view = GameObject.Find("ViewController").GetComponent<ViewController>();

        thumbs = Resources.LoadAll<Texture>("thumbs_regular");

        for (int i = 0; i < thumbs.Length; i++)
        {
            thumbList.Add(new Thumb(thumbs[i], i));
        }
        if (thumbs.Length > 0)
            SpawnThumbs(); 
    }

    void SpawnThumbs()
    {
        //Note the name in the find method!
        Thumbnail[] children = GameObject.Find("ThumbnailList (ANOTHER LAYOUT IDEA)").GetComponentsInChildren<Thumbnail>();
        for (int i = 0; i < children.Length; i++)
        {
            children[i].SetThumbnail(thumbList[i].texture, thumbList[i].num);
        }
    }   
}
