using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadTimer : MonoBehaviour {

	public string m_MenuSceneName = "insertScene";
	public float Timer = 15f;
		IEnumerator Start () {
		yield return new WaitForSeconds (Timer);
		//Application.LoadLevel(SceneToLoad);
		SceneManager.LoadScene(m_MenuSceneName, LoadSceneMode.Single);
		}
	}
