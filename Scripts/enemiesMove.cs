
//The script will move the enemies with boids behaviour
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiesMove : MonoBehaviour
{
    float speed = 0.5f;
    float neidiastance = 3.0f;
    private float minDist = 3;
    float rotationSpeed = 2.0f;//how fast they change direction
    bool turning = false;
    private Vector3 middle = new Vector3(0, 2, 6); //new Vector3(3, 0.5f, 4);
  

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(0.5f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 7 || transform.position.x < -7 || transform.position.y > 2.4f || transform.position.y < 0 || transform.position.z > 8 || transform.position.z < 1)//keep me in the boundaries of the room
        { 
            turning = true;

            }else
            {
              turning = false;

            }

        if (turning)
        {
            //go towards the center
            Vector3 direction = middle - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);

            speed = Random.Range(0.5f, 1f); 
        }
        else
        {
            //randomness of movement
            if (Random.Range(0, 5) < 1) 
                ApplyRules();
        }
        transform.Translate(0, 0, Time.deltaTime * speed);



    }


    public void ApplyRules()
    {
        GameObject[] gos;
        gos = FlockingEffect.allEnemies;
        Vector3 vcentre = Vector3.zero; //the center of the group that is in
        Vector3 vavoid = Vector3.zero;
        float gSpeed = 0.1f;
        GameObject _parent = this.transform.parent.gameObject;
        Vector3 goalPos = _parent.GetComponent<FlockingEffect>().goalPos;
        float dist;
        int groupSize = 0;
        int count = 0;

        foreach (GameObject go in gos)
        {
            if (go != null)
            {

                if (go != this.gameObject)
                {

                    dist = Vector3.Distance(go.transform.position, this.transform.position);
                    if (dist <= neidiastance) //if neigbour-> add the centers
                    {
                        count++;
                        vcentre += go.transform.position;
                        groupSize++;
                        if (dist < minDist) // if it is too close-> go away
                        {
                            vavoid = vavoid + (this.transform.position - go.transform.position);
                        }
                        enemiesMove anotherFlock = go.GetComponent<enemiesMove>();
                        gSpeed = gSpeed + anotherFlock.speed;

                    }
                }
            }
            if (groupSize > 0) //calculate the average center and speed
            {
                vcentre = vcentre / groupSize + (goalPos - this.transform.position);
                speed = gSpeed / groupSize;
                Vector3 direction = (vcentre + vavoid) - transform.position;
                if (direction != Vector3.zero) //change direction
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
                }
            }
        }

    }


}
