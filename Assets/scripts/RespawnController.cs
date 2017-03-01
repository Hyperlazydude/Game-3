﻿using System.Collections;
using System.Linq;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    public float respawnGhostTime;

    private HorizontalController movement;
    private JumpController jumping;

    private Material material;
    private Transform playerTransform;
    private Collider2D playerCollider;
    private Rigidbody2D playerRB;

    private Vector3 lastPosition;
    
    private bool respawn;

    private void Awake()
    {
        this.movement = this.GetComponent<HorizontalController>();
        this.jumping = this.GetComponent<JumpController>();

        this.material = this.GetComponent<Renderer>().material;
        this.playerTransform = this.GetComponent<Transform>();
        this.playerCollider = this.GetComponent<Collider2D>();
        this.playerRB = this.GetComponent<Rigidbody2D>();

        this.lastPosition = this.playerTransform.position;

        this.respawn = false;
    }
    
    private void FixedUpdate()
    {
        if (this.respawn)
        {
            this.StartCoroutine(this.Respawn());

            this.respawn = false; 
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            float center = this.playerCollider.bounds.center.x;
            float extents = this.playerCollider.bounds.extents.x;

            float min = center - extents;
            float max = center + extents;

            float platformMin = collision.contacts.First().point.x;
            float platformMax = collision.contacts.Last().point.x;

            if (min >= platformMin && max <= platformMax)
                this.lastPosition = this.transform.position;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Death Barrier"))
            this.respawn = true;      
    }

    private IEnumerator Respawn()
    {
        this.playerTransform.position = this.lastPosition;
        this.playerRB.velocity = new Vector2();

        this.movement.enabled = false;
        this.jumping.enabled = false;
        
        this.material.color *= new Vector4(1, 1, 1, 0.5f);

        yield return new WaitForSeconds(this.respawnGhostTime);

        this.movement.enabled = true;
        this.jumping.enabled = true;

        this.material.color *= new Vector4(1, 1, 1, 2);
    }

}