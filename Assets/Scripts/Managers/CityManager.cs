using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityManager : MonoBehaviour
{
    [SerializeField] private GameObject cityBackDrop;
    [SerializeField] private GameObject pathBackDrop;
    [SerializeField] private bool playerInCity;

    /*private void Start()
    {
        cityBackDrop.SetActive(false);
        pathBackDrop.SetActive(false);
    }*/

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInCity = true;
        }
        else
        {
            playerInCity = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInCity = false;
        }
    }

    private void Update()
    {
        if (playerInCity)
        {
            cityBackDrop.SetActive(true);
            pathBackDrop.SetActive(false);
        }

        if (!playerInCity)
        {
            cityBackDrop.SetActive(false);
            pathBackDrop.SetActive(true);
        }
    }
}
