﻿using UnityEngine;

namespace USR.Controller
{
    public class PlayerController : MonoBehaviour
    {

        public float m_Speed;
        public float m_TurnSpeed;
        public int m_SpeedModifier;
        private float m_HorizontalInput;
        private float m_ForwardInput;
        public bool m_Finished = false;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            m_HorizontalInput = Input.GetAxis("Horizontal");
            m_ForwardInput = Input.GetAxis("Vertical");

            transform.Translate(Vector3.forward * Time.deltaTime * m_Speed);

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
            else if (m_ForwardInput == 0)
            {
                if (m_Speed <= 0)
                {
                    m_Speed = m_Speed + Time.deltaTime * m_SpeedModifier;
                }
                if (m_Speed >= 0)
                {
                    m_Speed = m_Speed - Time.deltaTime * m_SpeedModifier;
                }
                if (m_Speed <= 0.5f && m_Speed >= -0.5f)
                {
                    m_Speed = 0;
                }
            }



            if (m_Speed <= -0.5f || m_Speed >= 0.5f)
            {
                if (m_Speed < 0)
                {
                    m_HorizontalInput = -m_HorizontalInput;
                }
                transform.Rotate(Vector3.up * Time.deltaTime * m_TurnSpeed * m_HorizontalInput);
            }
        }
    }
}