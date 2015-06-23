using UnityEngine;
using System.Collections;

using UnityEngine;
using System.Collections;

public class Ennemygoal : MonoBehaviour
{

    public Transform[] waypoints;
    private int indexw = 0;
    private NavMeshAgent agent;
    private bool playerInSight = false;
    private SphereCollider col;
    public GameObject player;
    private Vector3 lastPlayerSighting;
    private float ChaseTimer = 0.0f;
    private float chaseWaitTime = 5f;
    private float chaseTimer = 0f;
    private Vector3 resetpos;
    private Vector3 personalLastSighting;
    public GameObject posia;
    private Vector3 test = new Vector3(0f, -1f, 0f);
    private GameObject lifeBar;
    private Animator anim;
    private float atta = 0f;
    public GameObject ed;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        col = GetComponent<SphereCollider>();
        resetpos = this.transform.position;
        anim = GetComponent<Animator>();
        lifeBar = GameObject.FindGameObjectWithTag("life");

        Patrolling();
    }

    void Shoot()
    {
        agent.Stop();
        anim.SetBool("Attack", true);
        if (atta == 58f)
        {
            lifeBar.GetComponent<MyGui>().Life -= 0.1f;
            atta = 0f;
        }
        else
        {
            atta += 1f;
            
        }

    }

    void Update()
    {
        if(ed.GetComponent<EnnemyDeath>().life <= 0)
        {
            return;
        }

        if (playerInSight)
        {
            Shoot();
        }
        else if (personalLastSighting != resetpos)
        {
            Chasing();
        }
        else
        {
            Patrolling();
        }
        Debug.DrawLine(transform.position + transform.up, posia.transform.position, Color.red);
    }

    void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player")
        {
            playerInSight = false;


            //Vector3 direction = other.transform.position - transform.position;
            Vector3 direction = posia.transform.position - transform.position;

            float angle = Vector3.Angle(direction, transform.forward);


            if (angle < 200 * 0.5f)
            {
                RaycastHit hit;
                Debug.DrawRay(transform.position + transform.up, direction + test);

                if (Physics.Raycast(transform.position + transform.up, direction + test, out hit, col.radius))
                {

                    if (hit.collider.gameObject.tag == "Player")
                    {
                        playerInSight = true;
                        lastPlayerSighting = other.transform.position;
                        personalLastSighting = other.transform.position;


                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {

            playerInSight = false;
            anim.SetBool("Attack", false);
        }
    }

    void Chasing()
    {
        agent.speed = 6f;
        Vector3 sightingDeltaPos = this.lastPlayerSighting - this.transform.position;

        // If the the last personal sighting of the player is not close...
        if (sightingDeltaPos.sqrMagnitude > 4f)
        {
            // ... set the destination for the NavMeshAgent to the last personal sighting of the player.
            agent.destination = lastPlayerSighting;
        }



        if (agent.remainingDistance == 0)
        {

            
            chaseTimer += Time.deltaTime;

            // If the timer exceeds the wait time...
            if (chaseTimer >= chaseWaitTime)
            {

                chaseTimer = 0f;
                lastPlayerSighting = resetpos;
                personalLastSighting = resetpos;

            }
        }
        else
        {

            chaseTimer = 0f;
        }
    }


    void Patrolling()
    {
        agent.speed = 1f;
        if (agent.remainingDistance == agent.stoppingDistance)
        {
            if (indexw == 3)
            {
                this.indexw = 0;
            }
            else
            {
                this.indexw++;
            }
        }

        agent.destination = this.waypoints[indexw].position;
    }
}
