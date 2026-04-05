using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    private Transform player;
    [SerializeField] private CreatureConfig creatureConfig;
    [SerializeField] private float speed = 5f;
    private int currentIndex = 0;
    private Renderer cachedRenderer;
    private float waitTime = 1f;
    private float waitTimer = 0;
    private CreatureState creatureState;
    private Material currentColor;
    private float detectionRange;
    private float loseRange;

private void Awake()
    {
        cachedRenderer = GetComponent<Renderer>();
    }

    private void Start()
    {
        currentColor = cachedRenderer.material;
        creatureState = CreatureState.IDLE;

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null) player = playerObj.transform;

        if (creatureConfig != null)
        {
            speed = creatureConfig.maxSpeed;
            detectionRange = creatureConfig.detectionRange;
            loseRange = creatureConfig.detectionRange * 1.5f;
        }
    }

    private void Update()
    {

        switch (creatureState)
        {
            case CreatureState.IDLE:
                currentColor.color = Color.grey;
                waitTimer += Time.deltaTime;
                if(waitTimer >= waitTime)
                {
                    creatureState = CreatureState.PATROL;
                    waitTimer = 0;
                }
                break;
            case CreatureState.PATROL:
                currentColor.color = Color.yellow;
                EnemyPatrol();
                if(Vector3.Distance(transform.position, player.transform.position) < detectionRange)
                {
                    creatureState = CreatureState.CHASE;
                }
                break;
            case CreatureState.CHASE:
                currentColor.color = Color.red;
                transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, player.transform.position) > loseRange)
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

