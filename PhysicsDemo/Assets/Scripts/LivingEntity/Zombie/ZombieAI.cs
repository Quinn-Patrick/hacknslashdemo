using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : Controller
{
    //The entity that the zombie is attacking.
    public LivingEntity aggro = null;

    //The minimum distance from which the zombie will aggro to the player from.
    public float aggroDistance = 20.0f;

    //The zombie that this AI is controlling.
    public Zombie self;

    //The time in between attacks, public so it can be altered from the editor.
    public float attackInterval;
    //The time left until the next attack.
    private float attackCountdown;



    private void Awake()
    {
        moveForward = 0;
        moveSideways = 0;
        sprintHeld = false;
        attacking = false;
    }

    void Start()
    {
        attackCountdown = attackInterval;
        
    }

    private void OnEnable() { }

    void Update()
    {
        if(aggro == null)
        {            
            FindAggro();
        }
        else
        {
            if (Game.FindEntityDistance(self, aggro) > 1.2f)
            {
                HomeInOnTarget();
            }
                
            if(Game.FindEntityDistance(self, aggro) < 1.5f)
            {
                AttackingState();
            }
        }
    }

    /// <summary>
    /// Sets the input variables so as to track the target.
    /// </summary>
    private void HomeInOnTarget()
    {
        if(aggro != null)
        {
            Vector2 Point_1 = new Vector2(aggro.transform.position.x, aggro.transform.position.z);
            Vector2 Point_2 = new Vector2(self.transform.position.x, self.transform.position.z);
            float angle = Mathf.Atan2(Point_2.y - Point_1.y, Point_2.x - Point_1.x);
            
            moveForward = Mathf.Sin(angle);
            moveSideways = Mathf.Cos(angle);
        }
    }

    private void AttackingState()
    {
        attackCountdown -= Time.deltaTime;
        if(attackCountdown <= 0)
        {
            attacking = true;
            attackCountdown = attackInterval;
        }
        else
        {
            attacking = false;
        }
    }

    /// <summary>
    /// Locates the nearest player and aggros to them.
    /// </summary>
    private void FindAggro()
    {
        List<LivingEntity> players = Game.FindPlayers();
        float currentLeastDistance = 1000.0f;
        LivingEntity currentNearestPlayer = null;
        for(int i = 0; i < players.Count; i++)
        {
            float currentDistance = Game.FindEntityDistance(self, players[i]);
            if (currentDistance < currentLeastDistance)
            {
                currentLeastDistance = currentDistance;
                currentNearestPlayer = players[i];
            }
        }
        if (currentLeastDistance < aggroDistance)
        {
            aggro = currentNearestPlayer;
        }
    }
}
