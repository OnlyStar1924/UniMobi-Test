using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonterController : MonoBehaviour
{
    private Transform wayPoint;

    private List<Transform> currentWaypoint;

    public float speed = 1f;

    private Transform nextPoint;
    private int curIndex;
    private int maxPoint;

    private Animator animator;
    private int animDir = 0;
    void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("dir", animDir);
        int ran = Random.Range(1, 4);
        wayPoint = GameObject.FindWithTag("WayPoint_" + ran.ToString()).transform;

        transform.position = wayPoint.gameObject.transform.GetChild(0).position;
        maxPoint = wayPoint.gameObject.transform.childCount;
        curIndex = 1;
        nextPoint = wayPoint.gameObject.transform.GetChild(1);
  
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position,
            nextPoint.transform.position,
            speed * Time.deltaTime);
        if (transform.position.x == nextPoint.position.x && transform.position.y == nextPoint.position.y)
        {
            if (curIndex < maxPoint - 1)
            {
                curIndex++;
                nextPoint = wayPoint.gameObject.transform.GetChild(curIndex);

                CheckDir(wayPoint.gameObject.transform.GetChild(curIndex - 1), nextPoint);

            }
            else
            {
                Destroy(gameObject);
            }
        }

    }

    private void CheckDir(Transform p1, Transform p2)
    {
        if (p1.position.y == p2.position.y) 
        {
            if (p2.position.x >= p1.position.x)
            {
                animDir = 2;
            }
            else
            {
                animDir = 3;

            }

        }
        else if (p1.position.x == p2.position.x)
        {
            if (p2.position.y >= p1.position.y)
            {
                animDir = 0;
            }
            else
            {
                animDir = 1;

            }
        }
        animator.SetInteger("dir", animDir);
    }

}
