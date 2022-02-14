using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HealthSystem
{
    public int GetCurrentHealth();
    public int GetMaxHealth();
    public void SetCurrentHealth(int health);
    public void AlterCurrentHealth(int deltaHealth);
    public void SetMaxHealth(int maxHealth);
    public void AlterMaxHealth(int deltaMaxHealth);
    public void Death();
}
