using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceManEnemy : Enemy
{
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (Vector3.Distance(target.position, this.transform.position) <= chaseRadius 
            && Vector3.Distance(target.position,this.transform.position)>attackRadius)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position,target.position, moveSpeed*Time.deltaTime);
        }
    }
}
