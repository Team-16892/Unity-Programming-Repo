using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Defining all the varibales that are needed
    public float speed = 10f; // Setting the speed of the enemy.
    private Transform target; // Sets where the enemy should target.
    private int wavepointIndex = 0; // The no. of the wavepointIndex.   

    void Start()
    {
        target = Waypoints.points[0]; // Setting the target to the 1st waypoint.
    }

    void Update()
    {
        //Line 17&18 makes the enemy actually move
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World); 
        
        if(Vector3.Distance(transform.position, target.position) <= 0.2f) // Changes what waypoint you should to target.
        {
            GetNextWaypoint(); // Calls the GetNextWaypoint() method
            
        }
    }

    void GetNextWaypoint() // Defines GetNextWaypoint() mehtod.
    {
        if(wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return; 
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
        
    }
}
