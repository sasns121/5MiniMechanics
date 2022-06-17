using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    public float MinGroundNormalY = .65f;
    public float GravityModifier = 1f;
    public float MoveSpeed;
    public float JumpPower;
    public LayerMask LayerMask;

    protected Vector2 Velosity;
    protected Vector2 targetVelosity;
    protected bool isGrounded;
    protected Vector2 groundNormal;
    protected Rigidbody2D rb2D;
    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);

    protected const float minMoveDistance = 0.001f;
    protected const float shellRadius = 0.01f;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(LayerMask);
        contactFilter.useLayerMask = true;
    }
    private void Update()
    {
        targetVelosity = new Vector2(Input.GetAxis("Horizontal"), 0)* MoveSpeed;
       
        if (Input.GetButtonDown("Jump") && isGrounded)
            Velosity.y = JumpPower;

    }
    private void FixedUpdate()
    {
        Velosity += GravityModifier * Physics2D.gravity * Time.fixedDeltaTime;
        Velosity.x = targetVelosity.x;

        isGrounded = false;

        Vector2 deltaPosition = Velosity * Time.fixedDeltaTime;
        Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);
        Vector2 move = moveAlongGround * deltaPosition.x;

        Movement(move, false);
        move = Vector2.up * deltaPosition.y; //?
        Movement(move, true);                //?
    }
    void Movement(Vector2 move, bool yMovement) {
        float distance = move.magnitude;
        if (distance > minMoveDistance)
        {
            int count = rb2D.Cast(move, contactFilter, hitBuffer, distance + shellRadius);
           
            hitBufferList.Clear();

            for (int i = 0; i < count; i++) 
            {
                hitBufferList.Add(hitBuffer[i]);

            }

            for(int i = 0; i < hitBufferList.Count; i++) 
            {
                Vector2 currentNormal = hitBufferList[i].normal;
                if (currentNormal.y > MinGroundNormalY) {
                    isGrounded = true;
                    if (yMovement) 
                    {
                        groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }

                float projection = Vector2.Dot(Velosity, currentNormal);
                if (projection < 0)
                {
                    Velosity = Velosity - projection * currentNormal;
                }
                float modifiredDistance = hitBufferList[i].distance - shellRadius;
                distance = modifiredDistance < distance ? modifiredDistance : distance;
            }

        }
        rb2D.position += move.normalized * distance;
    }
}
