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
    public static int _guiOffset = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Adds the given entity to the active entities list.
    /// </summary>
    /// <param name="entity"></param>
    public static void AddToActiveEntities(LivingEntity entity)
    {
        if (!Game.ActiveEntities.Contains(entity))
        {
            Game.ActiveEntities.Add(entity);
        }
    }

    /// <summary>
    /// Removes the given entity from the active entities list.
    /// </summary>
    /// <param name="entity"></param>
    public static void RemoveFromActiveEntities(LivingEntity entity)
    {
        ActiveEntities.Remove(entity);        
    }

    /// <summary>
    /// Returns a list of active entities which are players.
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Finds and returns the distance 
    /// </summary>
    /// <param name="entity1">The fist entity.</param>
    /// <param name="entity2">The second entity.</param>
    /// <returns>The distance between them, as a float.</returns>
    public static float FindEntityDistance(LivingEntity entity1, LivingEntity entity2)
    {
        return Mathf.Sqrt(Sqr(entity1.transform.position.x- entity2.transform.position.x) + Sqr(entity1.transform.position.y - entity2.transform.position.y) + Sqr(entity1.transform.position.z - entity2.transform.position.z));
    }

    /// <summary>
    /// Easily return the square of a number.
    /// </summary>
    /// <param name="number">The number to square.</param>
    /// <returns>The square of the number.</returns>
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
        _guiOffset = 0;
    }

    public static int GetGuiOffset()
    {
        _guiOffset++;
        return _guiOffset;
    }
}
