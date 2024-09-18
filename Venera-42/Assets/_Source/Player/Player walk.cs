using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Playerwalk : PlayerMovement
{
    private void Update()
    {
        MovePlayer();
    }

    protected override void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector3 move = new Vector3(horizontal, 0, vertical) * (moveSpeed * Time.deltaTime);
        
        transform.Translate(move);
    }
}
