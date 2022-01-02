using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeardedManStudios.Forge.Networking.Generated;

public class CopyableObjectsFollowingPlayer : CopyableObjectsFollowingPlayerBehavior
{

    public float minPositon = 3.5f;

    public float maxPosition = 26.5f;

    private GameObject player;

    protected override void NetworkStart()
    {
        base.NetworkStart();

        if (!networkObject.IsOwner) {
            this.enabled = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
# if !UNITY_EDITOR
    /// <summary>
    /// Setting the correct gameobject to follow
    /// </summary>
    public void PlayerGameObject() {
        if (networkObject.IsServer) {
            player = GameObject.FindGameObjectsWithTag("Player")[0];
        }
        else
        {
            player = GameObject.FindGameObjectsWithTag("Player")[0];
        }
    }

    /// <summary>
    /// moving the object to follow the player and clamping the position to the givend float variables above
    /// </summary>
    void Update()
    {
        float currentPlayerPosZ = player.transform.position.z;
        float newPositionForCopyableObjectsZ = Mathf.Clamp(currentPlayerPosZ, minPositon, maxPosition);

        transform.position = new Vector3(transform.position.x, transform.position.y, newPositionForCopyableObjectsZ);
    }
# endif
}
