using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking.Unity;

public class BallResizer : GameBallBehavior
{

    // Update is called once per frame
    void Update()
    {
        // TODO write your new code here
        // if you're not sure what to do, have a look at Part 1 again :).
        // Note, we're syncing the scale not the rotation this time!

        if (networkObject == null) {
            return;
        }

        if (!networkObject.IsOwner)
        {
            transform.position = networkObject.position;
            transform.localScale = networkObject.scale;
            transform.rotation = networkObject.rotation;
            return;
        }

        networkObject.position = transform.position;
        networkObject.scale = transform.localScale;
        networkObject.rotation = transform.rotation;
    }

    public void OnCollisionEnter(Collision collision)
    {
        // only the server can do ball resizing
        if (!networkObject.IsOwner) {
            return;
        }

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