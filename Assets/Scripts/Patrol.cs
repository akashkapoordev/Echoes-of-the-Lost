using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    [SerializeField] Transform player;
    [SerializeField] float speed = 5f;
    private  int currentIndex = 0;
    private float waitTime = 1f;
    private float waitTimer = 0;
    private CreatureState creatureState;
    private Renderer currentColor;


    private void Start()
    {
        currentColor = GetComponent<Renderer>();
        creatureState = CreatureState.IDLE;
    }

    private void Update()
    {

        switch (creatureState)
        {
            case CreatureState.IDLE:
                currentColor.material.color = Color.grey;
                waitTimer += Time.deltaTime;
                if(waitTimer >= waitTime)
                {
                    creatureState = CreatureState.PATROL;
                    waitTimer = 0;
                }
                break;
            case CreatureState.PATROL:
                currentColor.material.color = Color.yellow;
                EnemyPatrol();
                if(Vector3.Distance(transform.position,player.transform.position)<10)
                {
                    creatureState = CreatureState.CHASE;
                }
                break;
            case CreatureState.CHASE:
                currentColor.material.color = Color.red;
                transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, player.transform.position) >15 )
                {
                    creatureState = CreatureState.PATROL;
                }
                break;
        }
    }

    private void EnemyPatrol()
    {
        if (waypoints.Length == 0) return;

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentIndex].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, waypoints[currentIndex].position) < 0.1f)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= waitTime)
            {
                currentIndex = (currentIndex + 1) % waypoints.Length;
                waitTimer = 0;
            }

        }
        else
        {
            waitTimer = 0;
        }

    }
}

