using UnityEngine;
using System.Collections;
 
public class FlyCamera : MonoBehaviour {
 
    public static float standardSpeed = 10.0f;
    public static float fastSpeed = 50.0f;
    public static float rotationSpeed = 60.0f;
    public static float orientation = 0.0f;
    public static float roll = 0.0f;
    public static float pitch = 0.0f;


    public static float positionalSpeed = 7.5f;
    private float inverter = 1.0f;
    // Rigidbody broomBody;
 
    float speed = standardSpeed;
 
    public GameObject CenterEyeAnchor;
    public GameObject broomAnchor;
    private Quaternion LastRotation;

 
    Rigidbody rb;
 
    void Start (){
        rb = GetComponent<Rigidbody> ();
        LastRotation = transform.rotation;
        orientation = rb.rotation.y;
        // broomBody = CenterEyeAnchor.GetComponent<Rigidbody>();
     }

    void Update () {
        if(OVRInput.Get(OVRInput.Button.Two)){
          InvertBroomDirection();
        }

        // Get Speed
        float primaryIndex = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
        float secondaryIndex = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger);
        float trigger = (primaryIndex * standardSpeed) + (secondaryIndex * fastSpeed);// > primaryIndex ? primaryHand : primaryIndex;
        speed = trigger;

        UpdateVelocity();
        UpdateOrientation();

    }

    private void UpdateVelocity(){
      // If we are moving
      if (speed != 0.0f){
        rb.velocity = broomAnchor.transform.forward * speed;// + CenterEyeAnchor.transform.right * (-0.01f * leftDifference * speed);
      }

      else if (speed == 0.0f && rb.velocity.magnitude > 0.0f){
        rb.velocity = broomAnchor.transform.forward * 0.0f + broomAnchor.transform.right * 0.0f;
      }
    }

    public void UpdateOrientation(){
      
      if(speed != 0.0f){
        Vector2 secondaryAxis = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        // Quaternion broomAxis = broomAnchor.transform.rotation;
        Quaternion broomAxis = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch);//OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        
        float diff = broomAxis.y * 2.0f;// * inverter;

        if (secondaryAxis.x != 0.0f){
          orientation = orientation + secondaryAxis.x;// * Time.deltaTime;
          rb.rotation = Quaternion.Euler(pitch, orientation, roll);
          Debug.Log("HI");
        } else { //if(diff != 0.0f ){
          if(diff != 0.0f) {
            orientation += diff;  
          } 
          rb.rotation = Quaternion.Euler(pitch, orientation, roll);// roll);
          Debug.Log(rb.rotation);
        }
      }
      
    
    }

    public void UpdateRoll(Quaternion broomAxis){
      if(Mathf.Abs(broomAxis.z) > 0.5f){
        roll = roll + broomAxis.z * 1.5f;

      } else if(roll != 0.0f){
        if(Mathf.Abs(roll) < 0.5f){
          roll = 0.0f;
        
        } 
        else if(roll < 0.0f){
          roll += 0.5f;

        }
        else {
          roll -= 0.5f;
        }
      }
    }

    public void UpdatePitch(Quaternion broomAxis){
      if(Mathf.Abs(broomAxis.x) > 0.5f){
        pitch = pitch + broomAxis.x * 1.5f;

      } else if(pitch != 0.0f){
        if(Mathf.Abs(pitch) < 0.5f){
          pitch = 0.0f;
        
        } 
        else if(pitch < 0.0f){
          pitch += 0.5f;

        }
        else {
          pitch -= 0.5f;
        }
      }
    }
    public void InvertBroomDirection(){
      inverter = inverter * -1.0f;
    }
}