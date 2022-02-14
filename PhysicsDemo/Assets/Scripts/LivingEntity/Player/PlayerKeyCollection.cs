using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyCollection : MonoBehaviour, IKeyCounter
{
    private int _keyCount = 0;
    private int _keyCountMax = 99;
    private string _name = "Keys";
    [SerializeField] private HeadsUpDisplay _hud;
    private void Awake()
    {
        if (_hud != null)
        {
            _hud._keys = (IKeyCounter)this;
        }
    }
    public void AlterScore(int deltaScore)
    {
        _keyCount += deltaScore;
        EnsureKeyCount();
    }
    public int GetScore()
    {
        return (_keyCount);
    }
    public string GetScoreName()
    {
        return _name;
    }
    public void SetScore(int score)
    {
        _keyCount = score;
        EnsureKeyCount();
    }
    public void SetScoreName(string name)
    {
        _name = name;
    }
    private void EnsureKeyCount()
    {
        if (_keyCount < 0)
        {
            _keyCount = 0;
        }
        else if (_keyCount > _keyCountMax)
        {
            _keyCount = _keyCountMax;
        }
    }
}
