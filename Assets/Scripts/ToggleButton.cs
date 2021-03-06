﻿using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;
using System;

public class ToggleButton : MonoBehaviour {

    public event Action<ToggleButton> OnButtonSelected;                   // This event is triggered when the selection of the button has finished.

    [SerializeField]
    private VRCameraFade m_CameraFade;                 // This fades the scene out when a new scene is about to be loaded.
    [SerializeField]
    private SelectionRadial m_SelectionRadial;         // This controls when the selection is complete.
    [SerializeField]
    private VRInteractiveItem m_InteractiveItem;       // The interactive item for where the user should click to load the level.

    private bool m_GazeOver;                                            // Whether the user is looking at the VRInteractiveItem currently.


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
        // When the user looks at the rendering of the scene, show the radial.
        m_SelectionRadial.Show();

        m_GazeOver = true;
    }


    private void HandleOut()
    {
        // When the user looks away from the rendering of the scene, hide the radial.
        m_SelectionRadial.Hide();

        m_GazeOver = false;
    }


    private void HandleSelectionComplete()
    {
        // If the user is looking at the rendering of the scene when the radial's selection finishes, activate the button.
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

        //For varied button interaction

        gc = GameObject.Find("Gallery").GetComponent<GalleryController>();
        gc.ToggleStereo();

        view = GameObject.Find("ViewController").GetComponent<ViewController>();

        if (view.isStereo)
            toggleIcon.material.mainTexture = on;
        else
            toggleIcon.material.mainTexture = off;
    }

    void Start()
    {
        view = GameObject.Find("ViewController").GetComponent<ViewController>();
        if (view.isStereo)
            toggleIcon.material.mainTexture = on;
        else
            toggleIcon.material.mainTexture = off;
    }

    GalleryController gc;
    ViewController view;
    [SerializeField] private Renderer toggleIcon;
    [SerializeField] private Texture on;
    [SerializeField] private Texture off;
}
