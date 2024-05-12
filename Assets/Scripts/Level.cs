using System.Collections;
using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class Level : MonoBehaviour
{
    public List<Bus> buses;

    private int index;

    public bool canPlay;

    public Transform startPos;

    private bool isLevelCompleted;

    private void Awake()
    {
        index = 0;

        canPlay = false;

        isLevelCompleted = false;
    }

    public Bus GetCurrentBus()
    {
        return buses[index];
    }

    private void Start()
    {
        MoveBusToPosition();
    }

    public void MoveBusToPosition()
    {
        canPlay = false;
        buses[index].gameObject.transform.DOMove(startPos.position, 1f).OnComplete(() => {
            canPlay = true;
        });
    }

    public void NextBus()
    {
        index++;

        if (index == buses.Count)
            return;

        MoveBusToPosition();
    }

    private void Update()
    {
        if (isLevelCompleted)
            return;

        if (index == buses.Count)
        {
            isLevelCompleted = true;
            GameManager.Instance.CheckLevelUp();
        }
    }
}
