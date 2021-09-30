using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetName : MonoBehaviour
{
    public CubeSpinner cubeSpinner;

    private void Start()
    {
        this.gameObject.GetComponent<Text>().text = cubeSpinner.displayName;
    }
}
