using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    Vector2 movement;
    public float speed = 10;
    public Rigidbody2D rb;
    public Animator animator;
    private TrailRenderer trailRenderer;

    [SerializeField] private float dashingVelocity = 30f;
    [SerializeField] private float dashingTime = 0.5f;
    [SerializeField] private float dashingCoolDown = 0.5f;

    private Vector2 dashingDir;
    private bool isDashing;
    private bool canDash = true;
    private KeyCode lastHitKey = KeyCode.S;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        trailRenderer = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    { 
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical"); 

        movement.Normalize();
            
        rb.velocity = movement * speed;
    

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.Space) && canDash){
            isDashing = true;
            canDash = false;
            trailRenderer.emitting = true;
            dashingDir = new Vector2(movement.x, movement.y);

            if (dashingDir == Vector2.zero) {
                if (lastHitKey == KeyCode.A){
                dashingDir = new Vector2(-transform.localScale.x, 0);
                } 
                if (lastHitKey == KeyCode.D){
                dashingDir = new Vector2(transform.localScale.x, 0);
                } 
                if (lastHitKey == KeyCode.W){
                dashingDir = new Vector2(0, transform.localScale.y);
                } 
                if (lastHitKey == KeyCode.S){
                dashingDir = new Vector2(0, -transform.localScale.x);
                }
            }

            StartCoroutine(StopDashing());
        }

        if (isDashing) {
            rb.velocity = dashingDir.normalized * dashingVelocity;
            return;
        }
        
    }

    void OnGUI(){
        if (Input.GetKeyDown(KeyCode.A)){
                lastHitKey = KeyCode.A;
            } 
            if (Input.GetKeyDown(KeyCode.D)){
                lastHitKey = KeyCode.D;
            } 
            if (Input.GetKeyDown(KeyCode.W)){
                lastHitKey = KeyCode.W;
            } 
            if (Input.GetKeyDown(KeyCode.S)){
                lastHitKey = KeyCode.S;
            }
    }

    private IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(dashingTime);
        trailRenderer.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(dashingCoolDown);
        canDash = true;
    }


}

