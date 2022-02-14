using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFadeOut : MonoBehaviour
{
    LivingEntity _boss;
    BossHurtable _hurtbox;
    private void Awake()
    {
        _boss = gameObject.GetComponent<LivingEntity>();
        _hurtbox = gameObject.GetComponent<BossHurtable>();
        _boss.Killed += BeginFade;
    }
    private void BeginFade() => StartCoroutine(FadeOnDeath());
    IEnumerator FadeOnDeath()
    {
        if (_hurtbox != null && _boss != null)
        {
            Color c = _hurtbox._ouchMaterial.color;
            for (float alpha = 1f; alpha >= 0; alpha -= 0.3f * Time.deltaTime)
            {
                c.a = alpha;
                _hurtbox._ouchMaterial.color = c;
                yield return null;
            }
            _boss.gameObject.SetActive(false);
        }
    }
}
