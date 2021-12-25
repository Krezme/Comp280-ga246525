using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeardedManStudios.Forge.Networking.Unity;

public class GameLogic : MonoBehaviour
{
    public CopyableObjectsFollowingPlayer[] ObjectsToCoppyScripts;

    // Start is called before the first frame update
    void Start()
    {
#if !UNITY_EDITOR
        NetworkManager.Instance.InstantiatePlayerMovement();
        ObjectsToCoppyScripts[0].PlayerGameObject();
        ObjectsToCoppyScripts[1].PlayerGameObject();
#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
