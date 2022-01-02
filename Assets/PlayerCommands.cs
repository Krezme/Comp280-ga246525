using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommands : MonoBehaviour
{
    public GameObject player; //player gameobject
    public FieldOfView fieldOfView; // the Field of View script attached to this AI
    public AICommands aICommands; // The AICommands attached to the player
    public bool requredToLookAtPlayer; // if the AI is required to face the player
    public bool isWaving; // if the AI is waving 
    public bool isFollowing; // if the AI is following the player
}
