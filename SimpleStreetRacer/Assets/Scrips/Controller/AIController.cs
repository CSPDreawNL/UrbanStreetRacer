using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace USR.Controller
{
    public class AIController : MonoBehaviour
    {

        public float m_Speed;
        public float m_TurnSpeed;
        public int m_SpeedModifier;
        public bool m_Finished = false;

        void Update()
        {
            int m_ForwardInput = 1;

            transform.Translate(Vector3.forward * Time.deltaTime * m_Speed);

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
    }
}
