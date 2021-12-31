using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommands : MonoBehaviour
{
    public GameObject player;
    public FieldOfView fieldOfView;
    public AICommands aICommands;
    public bool requredToLookAtPlayer;
    public bool isWaving;
    public bool isFollowing;

    public void WaveEnd() {
        if (!isFollowing) {
            requredToLookAtPlayer = false;
        }
    }
}
