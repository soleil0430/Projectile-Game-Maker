using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace ProjectileSystem
{
    [System.Serializable]
    public struct MoveConfig
    {
        public float speed;
        public Rigidbody body;
        public Vector3 direction;
    }

    [System.Serializable]
    public struct BezierConfig
    {
        public List<Vector3> points;

        public float delta;
    }



    public static class Movement
    {
        public delegate Vector3 GetVelocity(MoveConfig _config);

        public static void Func() { Debug.Log("Func"); }

        public static Vector3 Straight(MoveConfig _config)
        {
            Vector3 result = Vector3.zero;

            result = _config.speed * _config.direction;

            return result;
        }

        public static Vector3 Bezier(BezierConfig _config)
        {
            Vector3 result = Vector3.zero;

            if (_config.delta > 1f)
                return _config.points[_config.points.Count - 1];

            List<Vector3> points = _config.points;
            for (int i = 0; i < points.Count - 1; ++i)
            {
                Debug.DrawLine(points[i], points[i + 1], Color.red);
            }

            int a = 0;
            while (points.Count > 1)
            {
                List<Vector3> temp = new List<Vector3>();
                for (int j = 0; j < points.Count - 1; ++j)
                {
                    Vector3 p1 = points[j];
                    Vector3 p2 = points[j + 1];
                    
                    temp.Add(Vector3.Lerp(p1, p2, _config.delta));
                }

                for (int i = 0; i < temp.Count -1; i++)
                {
                    Debug.DrawLine(temp[i], temp[i+1], Color.blue);
                }

                points = temp;


                //무한루프 방지
                a++;
                if (a > 10000)
                {
                    break;
                }
            }

            result = points[0];

            return result;
        }
    }
}