using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;

namespace VRStandardAssets.Menu
{
    // This script is for loading scenes from the main menu.
    // Each 'button' will be a rendering showing the scene
    // that will be loaded and use the SelectionRadial.
    public class MenuButton : MonoBehaviour
    {
        public event Action<MenuButton> OnButtonSelected;                   // This event is triggered when the selection of the button has finished.


        [SerializeField] private string m_SceneToLoad;                      // The name of the scene to load.
        [SerializeField] private VRCameraFade m_CameraFade;                 // This fades the scene out when a new scene is about to be loaded.
        [SerializeField] private SelectionRadial m_SelectionRadial;         // This controls when the selection is complete.
        [SerializeField] private VRInteractiveItem m_InteractiveItem;       // The interactive item for where the user should click to load the level.


        private bool m_GazeOver;                                            // Whether the user is looking at the VRInteractiveItem currently.


        private void OnEnable ()
        {
            m_InteractiveItem.OnOver += HandleOver;
            m_InteractiveItem.OnOut += HandleOut;
            m_SelectionRadial.OnSelectionComplete += HandleSelectionComplete;
        }


        private void OnDisable ()
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
            if(m_GazeOver)
                StartCoroutine (ActivateButton());
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

            //For varied button interaction
            CubeController cc;
            CubeController cc2;
            GalleryController gc;
            ViewController view = GameObject.Find("ViewController").GetComponent<ViewController>();
             

            string itemName = m_InteractiveItem.name;
            switch (itemName)
            {
                case "Forward":
                    /*if (view.isStereo)
                    {*/
                        cc = GameObject.Find("LeftCube").GetComponent<CubeController>();
                        cc2 = GameObject.Find("RightCube").GetComponent<CubeController>();
                        cc.LoadTextures(true);
                        cc2.LoadTextures(true);
                    /*}
                    else
                    {
                        cc = GameObject.Find("BothCube").GetComponent<CubeController>();
                        cc.LoadTextures(true);
                    }*/
                    break;
                case "Back":
                   /* if (view.isStereo)
                    {*/
                        cc = GameObject.Find("LeftCube").GetComponent<CubeController>();
                        cc2 = GameObject.Find("RightCube").GetComponent<CubeController>();
                        cc.LoadTextures(false);
                        cc2.LoadTextures(false);
                   /* }
                    else
                    {
                        cc = GameObject.Find("BothCube").GetComponent<CubeController>();
                        cc.LoadTextures(false);
                    }*/
                    break;
                case "Leave":
                    SceneManager.LoadScene(m_SceneToLoad, LoadSceneMode.Single);
                    break;
                case "Toggle":
                    gc = GameObject.Find("Gallery").GetComponent<GalleryController>();
                    gc.ToggleStereo();
                    break;
		/*	    case "StereoscopicMenu":
                    view.isStereo = true;
                    SceneManager.LoadScene(m_SceneToLoad, LoadSceneMode.Single);
                    break;
			    case "Regular360Menu":
                    view.isStereo = false;
                    SceneManager.LoadScene(m_SceneToLoad, LoadSceneMode.Single);
                    break;*/
            }

            m_CameraFade.FadeInBlack(true);

        }

    }
}