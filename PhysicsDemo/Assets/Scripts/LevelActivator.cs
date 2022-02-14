using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelActivator : MonoBehaviour
{
    [SerializeField] public List<Entity> Entities = new List<Entity>();
    public GameObject Cieling;
    public bool shuttersActive;
    private bool roomActive = false;
    public List<KillAllEnemiesDoor> ShutteredDoors = new List<KillAllEnemiesDoor>();
    void Start()
    {
        DeactivateRoom();
    }
    void Update()
    {
        bool allEnemiesDead = true;
        foreach(IEntity e in Entities)
        {
            if (e is LivingEntity)
            {
                LivingEntity en = (LivingEntity)e;
                if (en.CompareTag("Enemy"))
                {
                    if (!en.IsDead() && en.isActiveAndEnabled && roomActive)
                    {
                        allEnemiesDead = false;
                        foreach (KillAllEnemiesDoor k in ShutteredDoors)
                        {
                            k.gameObject.SetActive(true);
                        }
                    }
                }
            }
        }
        if (allEnemiesDead)
        {
            shuttersActive = false;
            foreach(KillAllEnemiesDoor k in ShutteredDoors)
            {
                k.gameObject.SetActive(false);
            }
        }
    }
    public void ActivateRoom()
    {
        roomActive = true;
        foreach (Entity e in Entities)
        {
            e.gameObject.SetActive(true);
        }
        shuttersActive = true;
        Cieling.SetActive(false);
    }
    public void DeactivateRoom()
    {
        roomActive = false;
        shuttersActive = false;
        foreach (Entity e in Entities)
        {
            e.gameObject.SetActive(false);
        }
        Cieling.SetActive(true);
    }

    public bool IsRoomActive()
    {
        return roomActive;
    }
}
