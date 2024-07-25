// 2024-07-25 AI-Tag
// This was created with assistance from Muse, a Unity Artificial Intelligence product

using System;
using UnityEditor;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
        public float speed = 5.0f;
        public float runningSpeed = 10.0f;
        public float jumpHeight = 8.0f;
        private CharacterController controller;
        private Vector3 playerVelocity;
        private bool groundedPlayer;
        private float gravityValue = -9.81f;
    
        private void Start()
        {
            controller = gameObject.GetComponent<CharacterController>();
        }
    
        void Update()
        {
            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }
    
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            controller.Move(move * Time.deltaTime * (Input.GetKey(KeyCode.LeftShift) ? runningSpeed : speed));
    
            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
            }
    
            // Changes the height position of the player..
            if (Input.GetButtonDown("Jump") && groundedPlayer)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }
    
            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }
    }
