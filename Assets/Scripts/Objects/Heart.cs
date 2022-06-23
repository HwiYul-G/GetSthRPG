using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Powerup
{
    public FloatValue playerHealth;
    public FloatValue heartContainers;
    public float amountToIncrease;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            playerHealth.RuntimeValue += amountToIncrease;
            if(playerHealth.initialValue > heartContainers.RuntimeValue * 3f)
            {
                playerHealth.initialValue = heartContainers.RuntimeValue * 3f;
            }
            powerupSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
