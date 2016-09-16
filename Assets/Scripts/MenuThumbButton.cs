using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;

public class MenuThumbButton : MonoBehaviour
{

    public event Action<MenuThumbButton> OnButtonSelected;

    [SerializeField] private VRInteractiveItem m_InteractiveItem;
    [SerializeField] private VRCameraFade m_CameraFade;
    [SerializeField] private SelectionRadial m_SelectionRadial;

    private bool m_GazeOver;

    private void OnEnable()
    {
        m_InteractiveItem.OnOver += HandleOver;
        m_InteractiveItem.OnOut += HandleOut;
        m_SelectionRadial.OnSelectionComplete += HandleSelectionComplete;
    }


    private void OnDisable()
    {
        m_InteractiveItem.OnOver -= HandleOver;
        m_InteractiveItem.OnOut -= HandleOut;
        m_SelectionRadial.OnSelectionComplete -= HandleSelectionComplete;
    }


    private void HandleOver()
    {
        m_SelectionRadial.Show();
        m_GazeOver = true;
    }


    private void HandleOut()
    {
        m_SelectionRadial.Hide();
        m_GazeOver = false;
    }


    private void HandleSelectionComplete()
    {
        if (m_GazeOver)
            StartCoroutine(ActivateButton());
    }


    private IEnumerator ActivateButton()
    {
        // If the camera is already fading, ignore.
        if (m_CameraFade.IsFading)
            yield break;

        // If anything is subscribed to the OnButtonSelected event, call it.
        if (OnButtonSelected != null)
            OnButtonSelected(this);

        // Wait for the camera to fade out.
        yield return StartCoroutine(m_CameraFade.BeginFadeOut(true));
        
        ViewController view = GameObject.Find("ViewController").GetComponent<ViewController>();
        view.startImg = gameObject.GetComponent<Thumbnail>().number;
        if (view.isStereo)
            SceneManager.LoadScene("Gallery_CubeMap", LoadSceneMode.Single);
        else
            SceneManager.LoadScene("Gallery_CubeMap_LeftOnly", LoadSceneMode.Single);
        m_CameraFade.FadeInBlack(true);
    }
}
