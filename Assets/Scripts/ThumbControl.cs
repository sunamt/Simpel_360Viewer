using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ThumbControl : MonoBehaviour {

    public GameObject thumbnail;
    public Texture[] thumbs;
    private List<Thumb> thumbList = new List<Thumb>();

    class Thumb {
        public Texture texture;

        public Thumb(Texture t)
        {
            texture = t;
        }
    }

    void Start()
    {
     /* ViewController view = GetComponent<ViewController>().GetComponent<ViewController>();
        if(view.isStereo)
            thumbs = Resources.LoadAll<Texture>("thumbs_stereo");
        else*/
            thumbs = Resources.LoadAll<Texture>("thumbs_regular");

        for (int i = 0; i < thumbs.Length; i++)
        {
            thumbList.Add(new Thumb(thumbs[i]));
        }
        if (thumbs.Length > 0)
            SpawnThumbs();
    }

    void SpawnThumbs()
    {
        int rowLength = 3;
        int colLength = thumbList.Count / rowLength;
        if (thumbList.Count % rowLength > 0)
            colLength++;
        float space = .7f;

        thumbnail = Resources.Load<GameObject>("thumbplane");

        for(int i = 0; i < thumbList.Count; i++)
        {
            GameObject t = Instantiate(thumbnail, 
                new Vector3(
                    (i % rowLength + (i % rowLength * space)) - (rowLength / 2f) + space,
                    (i / rowLength + (i / rowLength * space)) - (colLength / 2f) + space, 4),
                    thumbnail.transform.rotation) as GameObject;
            t.GetComponentInChildren<Thumbnail>().SetThumbnail(thumbList[i].texture);
        }
    }

    void Update()
    {
        /*
        if(Input.GetMouseButtonDown(0) ){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 100))
				if(hit.transform.GetComponent<MemoryCard>() != null){
					hit.transform.GetComponent<MemoryCard>().Show();
				}
        */
    }
}
