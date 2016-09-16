using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;

public class LoadTimer : MonoBehaviour {

	[SerializeField] private VRCameraFade m_CameraFade; 

	public string m_MenuSceneName = "insertScene";
	public float Timer = 15f;
	public float FadeTimer = 4f;

		IEnumerator Start () {
		yield return new WaitForSeconds (Timer);

		m_CameraFade.FadeOut(true);
		yield return new WaitForSeconds (FadeTimer);
		SceneManager.LoadScene(m_MenuSceneName, LoadSceneMode.Single);
		}
	}
