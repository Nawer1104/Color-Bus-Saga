using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bus : MonoBehaviour
{
    public List<Passenger> passengers = new List<Passenger>();

    public List<Type> passengersTypeRequired = new List<Type>();

    private int index;

    private void Awake()
    {
        index = 0;
    }

    public void AddPassenger(Passenger passenger)
    {
        if (!passengers.Contains(passenger))
        {
            if (passenger.type != passengersTypeRequired[index])
            {
                passenger.IncorrectTypePassenger();
            }
            else
            {
                passengers.Add(passenger);
                passenger.CorrectType();
                index++;

                BusFull();
            }
        }
    }

    public void BusFull()
    {
        if (index == passengersTypeRequired.Count)
        {
            gameObject.SetActive(false);
            GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].NextBus();
        }
    }
}
