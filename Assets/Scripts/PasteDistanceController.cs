using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasteDistanceController : MonoBehaviour
{
    
    float distanceValue = 0f;

    private Slider distanceSlider;

    private LocationOfCopy locationOfCopy;

    // Start is called before the first frame update
    void Start()
    {
        distanceSlider = UIReferences.instance.slider.GetComponent<Slider>();
        locationOfCopy = GetComponent<LocationOfCopy>();
    }

    // Update is called once per frame
    void Update()
    {
        
            
        distanceValue += Input.mouseScrollDelta.y / 25;
        distanceValue = Mathf.Clamp(distanceValue, 0.2f, 1);

        distanceSlider.value = distanceValue;
        SetCurrentDistanceOfCopy();

        Debug.Log(distanceValue);
    }

    void SetCurrentDistanceOfCopy()
    {
        locationOfCopy.currentDistanceOfCopy = distanceValue * locationOfCopy.maxDistanceOfCopy;
        locationOfCopy.currentDistanceOfCopy = locationOfCopy.currentDistanceOfCopy < locationOfCopy.minDistanceOfCopy ? locationOfCopy.minDistanceOfCopy : locationOfCopy.currentDistanceOfCopy;
    }
}
