using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeardedManStudios.Forge.Networking.Generated;

public class RaybitchSynk : RaybitchSynkBehavior
{
    // Start is called before the first frame update
    public MeshRenderer thisMeshRenderer;
    public Material player2Material;

    void Start()
    {
# if !UNITY_EDITOR
        if (networkObject == null) {
            return;
        }

        if (!networkObject.IsOwner) {
            thisMeshRenderer.material = player2Material;
        }
#endif
    }

    // Update is called once per frame
    void Update()
    {
# if !UNITY_EDITOR
        if (networkObject == null) {
            return;
        }

        if (!networkObject.IsOwner) {
            transform.position = networkObject.position;
            return;
        }

        networkObject.position = transform.position;
#endif
    }
}
