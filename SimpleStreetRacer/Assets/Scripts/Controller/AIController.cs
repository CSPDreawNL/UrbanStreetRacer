using System.Collections;
using UnityEngine;
using PathCreation;

namespace USR.Controller
{
    public class AIController : MonoBehaviour
    {

        public float m_Speed;
        public float m_TurnSpeed;
        public float m_SpeedModifier;
        public bool m_Finished = false;
        int m_ForwardInput;

        public PathCreator pathCreator;
        public EndOfPathInstruction end;
        float distanceTravelled;

        private void Update()
        {

            m_ForwardInput = 1;
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
                else if (m_ForwardInput < 1)
                {
                    if (m_Speed >= 0)
                    {
                        m_Speed = m_Speed - Time.deltaTime * m_SpeedModifier;
                    }
                    m_Speed = m_Speed - Time.deltaTime * m_SpeedModifier;
                }
                if (pathCreator != null)
                {
                    distanceTravelled += m_Speed * Time.deltaTime;
                    transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, end);
                    transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, end);
                }
            }

            if (m_Finished)
            {
                m_ForwardInput = 0;
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
