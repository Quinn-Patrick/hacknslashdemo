using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    public int CoinValue { get; set; }

    public bool DestroyOnContact { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteractWithPlayer()
    {
        if (DestroyOnContact)
        {
            gameObject.SetActive(false);
        }
    }
}
