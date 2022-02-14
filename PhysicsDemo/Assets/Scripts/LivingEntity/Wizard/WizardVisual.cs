using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardVisual : AnimatedModel
{
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _transform = gameObject.transform;
        SetDirection();
        SetAnimation();
    }

    void FireballAttack()
    {
        Game.CannonballPool.GetCannonball(this.transform.position + new Vector3(0f, 0.5f, 0f), transform.eulerAngles.y, 500, 3);
    }
}
