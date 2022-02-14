using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public List<GameObject> EphemeralObjects = new List<GameObject>();
    public int CoinCount = 0;
    public Vector3 StartingPosition = new Vector3();
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Returns the room to its original state, allowing it to be played again.
    /// </summary>
    public void ResetRoom()
    {
        player.GetComponent<Rigidbody>().MovePosition(StartingPosition);
        player.Resurrect();
        foreach(GameObject obj in EphemeralObjects)
        {
            obj.SetActive(true);
        }

    }
}
