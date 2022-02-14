using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static HitboxPool HitPool;
    public static CoinPool CoinPool;
    public static bool[] UniversalSwitchesPressed = new bool[3];
    public static CannonballPool CannonballPool;
    public static ParticleEffectPool EffectPool;
    private static List<LivingEntity> ActiveEntities = new List<LivingEntity>();
    public static LivingEntity LastHit;
    public static int GuiOffset = 0;
    private static bool Paused = false;
    private void Awake()
    {
        Game.PauseUnpause();
    }
    public static void AddToActiveEntities(LivingEntity entity)
    {
        if (!Game.ActiveEntities.Contains(entity))
        {
            Game.ActiveEntities.Add(entity);
        }
    }
    public static void RemoveFromActiveEntities(LivingEntity entity)
    {
        ActiveEntities.Remove(entity);        
    }
    public static List<LivingEntity> FindPlayers()
    {
        List<LivingEntity> players = new List<LivingEntity>();
        for(int i = 0; i < ActiveEntities.Count; i++)
        {
            if (ActiveEntities[i].IsPlayer())
            {
                players.Add(ActiveEntities[i]);
            }
        }
        return players;
    }
    public static float FindEntityDistance(LivingEntity entity1, LivingEntity entity2)
    {
        return Mathf.Sqrt(Sqr(entity1.transform.position.x- entity2.transform.position.x) + Sqr(entity1.transform.position.y - entity2.transform.position.y) + Sqr(entity1.transform.position.z - entity2.transform.position.z));
    }
    public static float Sqr(float number)
    {
        return number * number;
    }
    public static float FindEntityAngle(Vector3 Point_1 , Vector3 Point_2)
    {
        
        float angle = Mathf.Atan2(Point_2.y - Point_1.y, Point_2.x - Point_1.x);
        return Mathf.Rad2Deg*angle+90;
    }
    private void OnGUI()
    {
        GuiOffset = 0;
    }
    public static int GetGuiOffset()
    {
        GuiOffset++;
        return GuiOffset;
    }
    public static void PauseUnpause()
    {
        Paused = !Paused;
        if (Paused) Time.timeScale = 0f;
        if(!Paused) Time.timeScale = 1f;
    }
    public static bool IsPaused()
    {
        return Paused;
    }
}
