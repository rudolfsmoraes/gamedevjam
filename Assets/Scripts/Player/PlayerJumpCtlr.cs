﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Classe responsável por efetuar o pulo do player
/// </summary>
public class PlayerJumpCtlr : MonoBehaviour
{
    [Header("Força do pulo")]
    [SerializeField] float forceJump;
    [Header("Base do player")]
    [SerializeField] Transform groundCheck;
    [Header("Distancia a ser verificada para o pulo em relação a base")]
    [SerializeField] float groundDistance = 0.4f;
    [Header("Os layermasks que irão permitir o pulo")]
    [SerializeField] LayerMask groundMask;
    // Update is called once per frame
    void FixedUpdate()
    {
        Jump();
    }

    /// <summary>
    /// Efetua o pulo do player
    /// </summary>
    void Jump(){
        if(Input.GetButtonDown("Jump")){
            bool isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);
            if(isGrounded){
                PlayerMng.Instance.RigidbodyPlayer.velocity = new Vector3(PlayerMng.Instance.RigidbodyPlayer.velocity.x, 0, PlayerMng.Instance.RigidbodyPlayer.velocity.z);
                PlayerMng.Instance.RigidbodyPlayer.AddForce(Vector3.up*forceJump*Time.deltaTime);
            }
        }
    }
}
