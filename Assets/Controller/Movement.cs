using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Rigidbody capsule;
    public Vector2 moveVal;
    public float movespeed = 10;

    private void Awake()
    {
        capsule = GetComponent<Rigidbody>();
        
    }

    public void Moving(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            // Debug.Log("performed");
            moveVal = value.ReadValue<Vector2>();
           // Debug.Log(moveVal.x +" " +moveVal.y);
           // capsule.AddForce(new Vector3(moveVal.x*movespeed,0f,moveVal.y*movespeed),ForceMode.Impulse);
           
        }

        if (value.canceled)
        {
            moveVal = value.ReadValue<Vector2>();
        }
    }
    
}
