using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeardedManStudios.Forge.Networking.Generated;

public class WandFollowCamera : WandFollowCameraBehavior
{

    public GameObject cameraToFollow;


    // Start is called before the first frame update
    void Start()
    {
    }

    /// <summary>
    /// Follows the postion of the camera if this the owner player
    /// </summary>
    void Update()
    {
        if (networkObject == null) {
            return;
        }

        if (!networkObject.IsOwner) {
            transform.rotation = networkObject.rotation;
            return;
        }

        transform.rotation = cameraToFollow.transform.rotation;
        
        networkObject.rotation = transform.rotation;
    }
}
