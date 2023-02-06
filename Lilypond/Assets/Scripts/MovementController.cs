using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] Camera lookCam;
    [SerializeField] public Rigidbody rb;
    [SerializeField] float moveSpeed;
    [SerializeField] float floatStrength;
    [SerializeField] float gravityMass = 0.01f;
    [SerializeField] ParticleSystem trail;
    public Vector3 lastForce;

    // Update is called once per frame
    void Update()
    {
        Vector3 move = Vector3.zero;
        move = PlayerInput();

        rb.AddForce(move * moveSpeed, ForceMode.Force);

        lastForce = move * moveSpeed;
    }

    void FixedUpdate()
    {
        rb.AddForce(Physics.gravity * gravityMass);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Interactable>())
        {
            other.GetComponentInParent<Interactable>().ActivateInteraction();
            
            var particlesMain = trail.main;
            particlesMain.maxParticles += 10;
            
            var emission = trail.emission;
            emission.rateOverDistanceMultiplier += 0.1f;
        }
    }

    Vector3 PlayerInput()
    {
        //float x = Input.GetAxis("Horizontal");
        //float y = Input.GetAxis("Vertical");

        if (Input.GetMouseButton(0))
        {
            return transform.forward;
        }

        return Vector3.zero;
    }
}
