using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ESCExitMenu : MonoBehaviour
{
    
    public GameObject exitWindow;
    public GameObject confirmation;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.lockState = CursorLockMode.None;
            exitWindow.SetActive(true);
        }
    }

    public void CloseExitMenu () {
        Cursor.lockState = CursorLockMode.Locked;
        exitWindow.SetActive(false);
    }

    public void OpenConfirmation () {
        confirmation.SetActive(true);
    }

    public void CloseConfirmation () {
        confirmation.SetActive(false);
    }
}
