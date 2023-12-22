using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMoveAuto : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject human;
    [SerializeField] private Transform[] ListPointMove;
    [SerializeField] private float speedRun = 6;
    private float timeSleep;
    private bool isMove;
    private Vector3 target;
    private int index;
    private float timeIma;
    public bool phatHien = false;
    
    private void Start()
    {
        timeSleep = 10.0f;
        index = 0;
        target = ListPointMove[index].position;
        isMove = true;
        InvokeRepeating(nameof(randomTimeSleep), 8.0f, 15.0f);
        timeIma = 0;
    }
    private void Update()
    {
        if (player.position.y <= -8.5f)
        {
            phatHien = false;
        }
        if (!phatHien)
        {
            move();
        }
        else
        {
            target = player.position;
            human.transform.position = Vector3.MoveTowards(human.transform.position, target, speedRun * Time.fixedDeltaTime);
        }
    }
    private void move()
    {
        timeIma += Time.fixedDeltaTime / 10;
        if (timeIma >= timeSleep)
        {
            isMove = false;
            Invoke(nameof(resetMove), timeSleep);
            timeIma = 0;
        }
        if (isMove)
        {
            MoveHoyNao();
        }
    }
    private void resetMove()
    {
        isMove = true;
    }
    private void MoveHoyNao()
    {
        if (human.transform.position == target)
        {
            index++;
            if (index >= ListPointMove.Length)
            {
                index = 0;
            }
            target = ListPointMove[index].position;
        }
        human.transform.position = Vector3.MoveTowards(human.transform.position, target, speedRun * Time.fixedDeltaTime);
    }
    private void randomTimeSleep()
    {
        timeSleep = Random.Range(2.0f, 5.0f);
    }
}
