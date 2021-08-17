using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ProjectileSystem
{
    public class StraightProjectile : Projectile
    {
        public float speed;

        protected override void Awake()
        {
            base.Awake();
        }

        private void Update()
        {
            body.MovePosition(transform.forward * speed);
        }
    }
}