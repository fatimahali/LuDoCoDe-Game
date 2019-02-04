using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePath : MonoBehaviour
{

    public Transform[] TokenPosition;

    [SerializeField]
    private float moveSpeed = 5f;

    [HideInInspector]
    public int waypointIndex = 0;

    public bool moveAllowed = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = TokenPosition[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveAllowed)
            Move();

    }

    private void Move()
    {
        if (waypointIndex <= TokenPosition.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position,
            TokenPosition[waypointIndex].transform.position,
            moveSpeed * Time.deltaTime);

            if (transform.position == TokenPosition[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
    }
}
