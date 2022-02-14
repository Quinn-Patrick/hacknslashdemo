using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAllEnemiesDoor : Entity
{
    public LevelActivator room;
    void Update()
    {
        if (!room.IsRoomActive())
        {
            gameObject.SetActive(false);
        }
    }
}
