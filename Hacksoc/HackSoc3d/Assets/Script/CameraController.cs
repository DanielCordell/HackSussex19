using UnityEngine;
using System.Collections.Generic;
 
public class CameraController : MonoBehaviour 
{
    private struct PointInSpace
    {
        public Vector3 Position;
        public float Time;
    }
     
    [SerializeField]
    public Transform player;
      
    [SerializeField]
    public Vector3 offset;
     
    [SerializeField]
    public float delay = 0.1f;
      
    [SerializeField]
    public float speed = 10;
      

    private Queue<PointInSpace> pointsInSpace = new Queue<PointInSpace>();
    void LateUpdate ()
    {
        // Add the current target position to the list of positions
        pointsInSpace.Enqueue( new PointInSpace() { Position = player.position, Time = Time.time } ) ;
         
        // Move the camera to the position of the target X seconds ago 
        if( pointsInSpace.Count > 0 && pointsInSpace.Peek().Time <= Time.time - delay + Mathf.Epsilon )
        {
            transform.position = Vector3.Lerp( transform.position, pointsInSpace.Dequeue().Position + offset, Time.deltaTime * speed);
        }
    }
}