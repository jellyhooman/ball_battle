using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float ballSpeed = Parameters.ballSpeed;
    public AttackerSoldier passedTo;

    private void Update()
    {
        if (transform.parent == null && passedTo != null)
        {
            Debug.Log("SET BALL");
            transform.position = Vector3.MoveTowards(transform.position, passedTo.transform.position, ballSpeed * Time.deltaTime);
            if (transform.position == passedTo.transform.position)
            {
                passedTo = null;
            }
        }
    }
}
