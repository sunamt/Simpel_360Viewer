using UnityEngine;
using System.Collections;

public class Dont_destroy : MonoBehaviour 
{
	void Awake() 
	{
		DontDestroyOnLoad(transform.gameObject);
	}
}
