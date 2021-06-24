using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using USR.Controller;

namespace USR.Core
{
    public class FinishLine : MonoBehaviour
    {
        private bool m_FirstPlace = true;
        private bool m_SecondPlace = false;
        private bool m_ThirdPlace = false;
        private string m_FinishedText = "First";

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                PlayerController playercontroller = other.GetComponent<PlayerController>();
                playercontroller.m_Finished = true;
                Debug.Log(other.name + " has finished " + m_FinishedText);
                ContinueFinish();
            }
            if (other.tag == "AI")
            {
                AIController aiController = other.GetComponent<AIController>();
                aiController.m_Finished = true;
                Debug.Log(other.name + " has finished " + m_FinishedText);
                ContinueFinish();
            }
        }

        private void ContinueFinish()
        {
            if (m_FirstPlace == true)
            {
                m_SecondPlace = true;
                m_FirstPlace = false;
                m_FinishedText = "Second";
            }
            else if (m_SecondPlace == true)
            {
                m_ThirdPlace = true;
                m_SecondPlace = false;
                m_FinishedText = "Third";
            }
        }
    }
}
