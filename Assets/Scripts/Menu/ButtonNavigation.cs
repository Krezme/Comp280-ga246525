using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonNavigation : MonoBehaviour
{
    public void LoadMenuScene () {
        SceneManager.LoadScene("Menu");
    }
    public void LoadTheHuedTrailsInfo() {
        SceneManager.LoadScene("TheHuedTrailsInfo");
    }
    public void LoadCampingWithMyBuddyInfo () {
        SceneManager.LoadScene("CampingWithMyBuddyInfo");
    }
    public void LoadTheHuedTrails () {
        SceneManager.LoadScene("MultiplayerMenu");
    }
    public void LoadCampingWithMyBuddy () {
        SceneManager.LoadScene("AIShowcase");
    }
    public void LoadControlsScene () {
        SceneManager.LoadScene("Controls");
    }
    public void LoadCredits () {
        SceneManager.LoadScene("Credits");
    }
    public void QuitGame () {
        Application.Quit();
# if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
# endif
    }
}
