using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Title : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> _text;
    private void Update()
    {
        if (Game.IsPaused())
        {
            foreach (TextMeshProUGUI t in _text)
            {
                t.alpha = 1f;
            }
        }
        else
        {
            foreach (TextMeshProUGUI t in _text)
            {
                t.alpha = 0f;
            }
        }
        if (SystemController.Instance.YesPressed() && Game.IsPaused())
        {
            Game.PauseUnpause();
        }
    }
}
