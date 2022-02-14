using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverText : MonoBehaviour
{
    [SerializeReference] private ILivingEntity _player;
    [SerializeField] private float _growthRate;
    private void Awake()
    {
        _player = transform.parent.transform.parent.gameObject.GetComponent<ILivingEntity>();
        transform.localScale = Vector3.zero;
    }
    private void Update()
    {
        if (_player.IsDead())
        {
            GrowText(_growthRate * Time.deltaTime);
            RestartInput();
        }
        else
        {
            GrowText(-_growthRate * Time.deltaTime);
        }
    }
    void GrowText(float growthFactor)
    {
        if (transform.localScale.x < 1)
        {
            transform.localScale += new Vector3(growthFactor, growthFactor, growthFactor);
        }
        EnsureTextSize();
    }
    void EnsureTextSize()
    {
        if (transform.localScale.x < 0)
        {
            transform.localScale = Vector3.zero;
        }
        if(transform.localScale.x > 1)
        {
            transform.localScale = new Vector3(1,1,1);
        }
    }
    void RestartInput()
    {
        if(transform.localScale.x > 0.9f)
        {
            if (SystemController.Instance.YesPressed())
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
