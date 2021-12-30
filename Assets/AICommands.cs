using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICommands : MonoBehaviour
{
    public GameObject waveArm;
    public Animator waveArmAnimator;
    public bool isWaving;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            waveArm.gameObject.SetActive(true);
            waveArmAnimator.SetBool("isWaving", true);
            isWaving = true;
        }
    }
}
