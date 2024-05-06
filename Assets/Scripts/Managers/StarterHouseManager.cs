using System;
using System.Collections.Generic;
using UnityEngine;

public class StarterHouseManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> pathAssets;
    [SerializeField] private GameObject innerHouse;
    [SerializeField] private Camera houseCamera;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private bool playerInHouse;


    private void Start()
    {
        ReloadOnFirstLoad._trainReload = false;
        ReloadOnFirstLoad._zeppelinReload = false;
        ReloadOnFirstLoad._skeletonReload = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInHouse = true;
        }
        else
        {
            playerInHouse = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInHouse = false;
        }
    }

    private void Update()
    {
        if (playerInHouse)
        {
            houseCamera.enabled = true;
            mainCamera.enabled = false;
            innerHouse.SetActive(true);
            foreach (GameObject pathAsset in pathAssets)
            {
                pathAsset.SetActive(false);
            }
        }

        if (!playerInHouse)
        {
            houseCamera.enabled = false;
            mainCamera.enabled = true;
            innerHouse.SetActive(false);
            foreach (GameObject pathAsset in pathAssets)
            {
                pathAsset.SetActive(true);
            }
        }
    }
}
