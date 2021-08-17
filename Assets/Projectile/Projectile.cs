using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace ProjectileSystem
{
    //[RequireComponent(typeof(Rigidbody))]
    //[RequireComponent(typeof(Collider))]
    public class Projectile : MonoBehaviour
    {
        [GetComponent] protected Rigidbody body;
        public float lifeTime = 1f;

        protected virtual void Awake()
        {
            //move += Movement.Straight;
            GetComponentAttributeSetter.DoUpdate_GetComponentAttribute(this);
            body.isKinematic = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            var collisionPoint = other.ClosestPoint(transform.position);
            var collisionNormal = (transform.position - collisionPoint).normalized;

            Debug.DrawLine(collisionPoint, collisionPoint + collisionNormal, Color.yellow, 2f);
        }
    }
}