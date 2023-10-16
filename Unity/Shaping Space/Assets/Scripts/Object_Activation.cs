using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Activation : MonoBehaviour
{
    public GameObject targetObject;
    public float activationDistance = 2.0f;

    private bool playerInRange = false;

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            targetObject.SetActive(!targetObject.activeSelf);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
