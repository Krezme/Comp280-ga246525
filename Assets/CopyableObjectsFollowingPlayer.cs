using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeardedManStudios.Forge.Networking.Generated;

public class CopyableObjectsFollowingPlayer : CopyableObjectsFollowingPlayerBehavior
{

    public float minPositon = 3.5f;

    public float maxPosition = 26.5f;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }
# if !UNITY_EDITOR
    public void PlayerGameObject() {
        if (networkObject.IsServer) {
            player = GameObject.FindGameObjectsWithTag("Player")[0];
        }
        else
        {
            player = GameObject.FindGameObjectsWithTag("Player")[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        float currentPlayerPosZ = player.transform.position.z;
        Debug.LogError(this.gameObject.name + " " + currentPlayerPosZ);
        float newPositionForCopyableObjectsZ = Mathf.Clamp(currentPlayerPosZ, minPositon, maxPosition);

        transform.position = new Vector3(transform.position.x, transform.position.y, newPositionForCopyableObjectsZ);
    }
# endif
}
