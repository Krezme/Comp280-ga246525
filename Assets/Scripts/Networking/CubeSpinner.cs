using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeardedManStudios.Forge.Networking.Generated;
public class CubeSpinner : CubeSpinnerBehavior
{
    float speed = 15;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        // check if the network object exists, if not, then return
        if (networkObject == null)
        {
            return;
        }
        // if we are not the owner, just update from the network object directly
        if (!networkObject.IsOwner)
        {
            transform.position = networkObject.position;
            transform.rotation = networkObject.rotation;
            return;
        }
        // update the cube position using the standard unity axis
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0,
        Input.GetAxis("Vertical")).normalized * speed * Time.deltaTime;
        // if we're the owner, we need to update the network object to tell everyone else
        networkObject.position = transform.position;
        networkObject.rotation = transform.rotation;
    }
}