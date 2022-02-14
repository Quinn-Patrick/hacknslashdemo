using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScoreCounter
{
    public int GetScore();
    public void AlterScore(int deltaScore);
    public void SetScore(int score);

    public string GetScoreName();

    public void SetScoreName(string name);
}
