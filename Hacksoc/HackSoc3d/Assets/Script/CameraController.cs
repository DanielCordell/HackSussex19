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

    public Vector3 unshakenPosition;

    // Desired duration of the shake effect
    public float shakeDuration = 0f;
  
    // A measure of how quickly the shake effect should evaporate
    public float dampingSpeed = 1.0f;
      

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
        unshakenPosition = transform.position;
        
        // Shaking
        if (shakeDuration > 0)
        {
            transform.localPosition += Random.insideUnitSphere / 4;
   
            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = unshakenPosition;
        }
    }


    public void TriggerShake() {
        shakeDuration = 0.2f;
    }
}