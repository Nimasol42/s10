using UnityEngine;
using UnityEngine.AI;
public class NPCWander : MonoBehaviour
{
    public int pointsCount = 3;
    public float spawnRange = 20f;
    private Vector3[] points;
    private NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        points = new Vector3[pointsCount];
        for (int i = 0; i < pointsCount; i++)
        {
            points[i] = new Vector3(Random.Range(-spawnRange, spawnRange), 0f, Random.Range(-spawnRange, spawnRange));
        }
        agent.SetDestination(points[Random.Range(0, points.Length)]);
    }
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            agent.SetDestination(points[Random.Range(0, points.Length)]);
    }
}