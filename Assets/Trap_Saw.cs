using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Saw : Trap
{
    private Animator anim;
    [SerializeField] private bool isWorking;

    [SerializeField] private Transform[] movePoint;
    [SerializeField] private float speed;

    private int movePointIndex;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isWorking", isWorking);

        transform.position = Vector3.MoveTowards(transform.position, movePoint[movePointIndex].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movePoint[movePointIndex].position) < 0.15f)
        {
            movePointIndex++;

            if (movePointIndex >= movePoint.Length)
                movePointIndex = 0;
        }


    }
}
