using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ProjectileSystem
{
    public class BezierProjectile : Projectile
    {
        public List<Vector3> points = new List<Vector3>();
        public float delta;

        protected override void Awake()
        {
            base.Awake();
        }

        private void Update()
        {
            body.MovePosition(Bezier());
            delta += Time.deltaTime;
        }

        public Vector3 Bezier()
        {
            if (delta > 1f)
                return points[points.Count - 1];

            Vector3 result = Vector3.zero;
            List<Vector3> temp = points;

            for (int i = 0; i < points.Count - 1; ++i)
                Debug.DrawLine(temp[i], temp[i + 1], Color.red);
            

            while (temp.Count > 1)
            {
                List<Vector3> lerp = new List<Vector3>();
                for (int j = 0; j < temp.Count - 1; ++j)
                {
                    Vector3 p1 = temp[j];
                    Vector3 p2 = temp[j + 1];

                    lerp.Add(Vector3.Lerp(p1, p2, delta));
                }

                for (int i = 0; i < lerp.Count - 1; i++)
                {
                    Debug.DrawLine(lerp[i], lerp[i + 1], Color.blue);
                }

                temp = lerp;
            }

            result = temp[0];

            return result;
        }
    }
}