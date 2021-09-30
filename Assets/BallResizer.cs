using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BallResizer : MonoBehaviour
{

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector3 scaleChange = new Vector3(
                Random.Range(-0.1f, 0.2f),
                Random.Range(-0.1f, 0.2f),
                Random.Range(-0.1f, 0.2f)
            );
            gameObject.transform.localScale += scaleChange;
        }
    }
}