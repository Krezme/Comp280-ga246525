using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasteDistanceController : MonoBehaviour
{
    
    float distanceValue = 0f;

    private Slider distanceSlider;

    // Start is called before the first frame update
    void Start()
    {
        distanceSlider = UIReferences.instance.slider.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
            
        distanceValue += Input.mouseScrollDelta.y / 25;
        distanceValue = Mathf.Clamp(distanceValue, 0, 1);

        distanceSlider.value = distanceValue;

        Debug.Log(distanceValue);
    }
}
