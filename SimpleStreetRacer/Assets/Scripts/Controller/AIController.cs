using System.Collections;
using UnityEngine;

namespace USR.Controller
{
    public class AIController : MonoBehaviour
    {

        public float m_Speed;
        public float m_TurnSpeed;
        public float m_SpeedModifier;
        public bool m_Finished = false;

        [SerializeField] private Transform[] routes;
        private int routeToGo;
        private float tParam;
        private Vector2 aiPosition;
        private bool coroutineAllowed;

        private void Start()
        {
            routeToGo = 0;
            tParam = 0f;
            coroutineAllowed = true;
        }

        private void Update()
        {
            if (coroutineAllowed)
            {
                StartCoroutine(GoByTheRoute(routeToGo));
            }

            int m_ForwardInput = 1;
            if (!m_Finished)
            {
                if (m_ForwardInput == 1)
                {
                    if (m_Speed <= 0)
                    {
                        m_Speed = m_Speed + Time.deltaTime * m_SpeedModifier;
                    }
                    m_Speed = m_Speed + Time.deltaTime * m_SpeedModifier;
                }
                else if (m_ForwardInput == -1)
                {
                    if (m_Speed >= 0)
                    {
                        m_Speed = m_Speed - Time.deltaTime * m_SpeedModifier;
                    }
                    m_Speed = m_Speed - Time.deltaTime * m_SpeedModifier;
                }
            }

            if (m_Finished)
            {
                if (m_Speed <= 0)
                {
                    m_Speed = m_Speed + Time.deltaTime * m_SpeedModifier * 3;
                }
                if (m_Speed >= 0)
                {
                    m_Speed = m_Speed - Time.deltaTime * m_SpeedModifier * 3;
                }
                if (m_Speed <= 0.5f && m_Speed >= -0.5f)
                {
                    m_Speed = 0;
                }
            }
        }

        private IEnumerator GoByTheRoute(int routeNum)
        {
            coroutineAllowed = false;

            Vector3 p0 = routes[routeNum].GetChild(0).position;
            Vector3 p1 = routes[routeNum].GetChild(1).position;
            Vector3 p2 = routes[routeNum].GetChild(2).position;
            Vector3 p3 = routes[routeNum].GetChild(3).position;

            while (tParam < 1)
            {
                tParam = m_Speed;

                aiPosition = Mathf.Pow(1 - tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3;
                Debug.Log(aiPosition);
                transform.position = aiPosition;
                yield return new WaitForEndOfFrame();
            }

            tParam = 0f;
            routeToGo += 1;

            if (routeToGo > routes.Length - 1)
            {
                routeToGo = 0;
            }

            coroutineAllowed = true;

        }

    }
}
