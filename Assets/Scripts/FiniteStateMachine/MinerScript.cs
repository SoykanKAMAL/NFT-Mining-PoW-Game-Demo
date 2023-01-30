using UnityEngine;

namespace FiniteStateMachine
{
    public class MinerScript
    {
        public bool IsMinerIdle = true;
        public bool IsMineOnCooldown = true;
        public float mineSpeed = 1f;
        public float mineDuration = 20f;
        public float mineTimer = 0;
        
        public void Update()
        {
            if(!IsMineOnCooldown && IsMinerIdle && Input.GetKeyDown(KeyCode.Space))
            {
                IsMinerIdle = false;
                StartMining();
            }
            if(!IsMinerIdle)
            {
                Debug.Log("Mining...");
                mineTimer += Time.deltaTime * mineSpeed;
            }
        }
    }
}