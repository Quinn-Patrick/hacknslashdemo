using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoinCollection : MonoBehaviour, ICoinCounter
{
    private int _coinCount = 0;
    private int _maxCoinCount = 999999999;
    private string _name = "Coins";
    [SerializeField]private HeadsUpDisplay _hud;
    private void Awake()
    {
        if (_hud != null)
        {
            _hud._coins = (ICoinCounter)this;
        }
    }
    public void AlterScore(int deltaCoins)
    {
        _coinCount += deltaCoins;
        EnsureCoinCount();
    }

    public int GetScore()
    {
        return _coinCount;
    }

    public void SetScore(int coins)
    {
        _coinCount = coins;
        EnsureCoinCount();
    }
    public string GetScoreName()
    {
        return _name;
    }

    public void SetScoreName(string name)
    {
        _name = name;
    }

    private void EnsureCoinCount()
    {
        if(_coinCount < 0)
        {
            _coinCount = 0;
        }
        else if(_coinCount > _maxCoinCount)
        {
            _coinCount = _maxCoinCount;
        }
    }
}
