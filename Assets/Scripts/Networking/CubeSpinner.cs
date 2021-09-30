using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using UnityEngine;
using UnityEngine.UI;
// We extend PlayerBehavior which extends NetworkBehavior which extends MonoBehaviour
public class CubeSpinner : CubeSpinnerBehavior
{

    public Text displayNameText;
    float speed = 15;

    // These strings are to be used to construct a player's name
    // by randomly combining 2 strings
    private int[] nameParts = new int[] {
        0001, 0010, 0011, 0100, 0101, 0110, 0111, 1000
    };

    public int displayName { get; private set; }
    // NetworkStart() is **automatically** called, when a networkObject
    // has been fully setup on the network and ready/finalized on the network!
    // In simpler words, think of it like Unity's Start() but for the network ;)
    protected override void NetworkStart()
    {
        base.NetworkStart();
        // If this networkObject is actually the **enemy** Player
        // hence not the one we will control and own
        if (!networkObject.IsOwner)
        {
            // There is no reason to try and simulate physics since
            // the position is being sent across the network anyway
            Destroy(GetComponent<Rigidbody>());
        }
        // Assign the name when this object is setup on the network
        ChangeName();
    }
    public void ChangeName()
    {
        // Only the owning client of this object can assign the name
        if (!networkObject.IsOwner)
            return;
        // Get a random index for the first name
        int first = Random.Range(0, nameParts.Length - 1);
        // Get a random index for the last name
        int last = Random.Range(0, nameParts.Length - 1);
        // Assign the name to the random selection
        displayName = nameParts[first] + nameParts[last];
        // Send an RPC to let everyone know what the name is for this player
        // We use "AllBuffered" so that if people come late they will get the
        // latest name for this object
        // We pass in "Name" for the args because we have 1 argument that
        // is to be a string as it is set in the NCW
        networkObject.SendRpc(RPC_UPDATE_NAME, Receivers.AllBuffered, displayName);
    }
    // Default Unity update method

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
            displayNameText.text = networkObject.displayNameString.ToString();
            return;
        }
        // update the cube position using the standard unity axis
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0,
        Input.GetAxis("Vertical")).normalized * speed * Time.deltaTime;
        displayNameText.text = displayName.ToString();
        
        // if we're the owner, we need to update the network object to tell everyone else
        networkObject.position = transform.position;
        networkObject.rotation = transform.rotation;
        networkObject.displayNameString = displayName;
    }

    public override void UpdateName(RpcArgs args)
    {
        displayNameText.text = displayName.ToString();
    }
}