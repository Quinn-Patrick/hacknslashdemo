using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Chest : Entity
{
    //Whether or not the chest is opened
    private bool opened;

    

    //The meshes used when the chest is closed and opened, respectively
    public Mesh ClosedMesh;
    public Mesh OpenedMesh;

    public static event Action HitChest;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (opened)
        {
            this.gameObject.GetComponent<MeshFilter>().mesh = OpenedMesh;
        }
        else
        {
            this.gameObject.GetComponent<MeshFilter>().mesh = ClosedMesh;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hitbox"))
        {
            Hitbox box = other.gameObject.GetComponent<Hitbox>();
            if(box.gameObject.layer == 3 || box.gameObject.layer == 11)
            {
                if (!opened)
                {
                    HitChest?.Invoke();
                    SpewCoins();
                    opened = true;
                }
            }
        }
    }
    /// <summary>
    /// Causes the chest to spew coinage every which way.
    /// </summary>
    private void SpewCoins()
    {
        float forceMag = 25f;
        Vector3 pos = gameObject.transform.position;
        for(int i = 0; i < 50; i++)
        {
            Game.CoinPool.GetCoin(pos + new Vector3(0f, 3f, 0f), new Vector3(UnityEngine.Random.Range(-1f, 1f) *forceMag, UnityEngine.Random.Range(0.5f, 1f) * forceMag, UnityEngine.Random.Range(-1f, 1f) * forceMag));
        }
    }
}
