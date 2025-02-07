using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Turrent : MonoBehaviour
{
    public Transform turrent;
    public Transform target;

    public Transform muzzle;
    public LineRenderer lineRenderer;

    public float shootTime = 3.0f;
    public float timer;

    public TurrentMove[] tm;
    public Vector3 aimTarget;

    public AudioClip backgroundMusic;
    public AudioClip hitSound; // Sound effect for Hit
    private AudioSource audioSource; // AudioSource component
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = shootTime;
        aimTarget  = tm[0].target.transform.position;

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = false; // For sound effects
    }

    // Update is called once per frame
    void Update()
    {
        aimTarget = tm[0].GetComponent<Transform>().transform.position;

        timer -= Time.deltaTime;
        lineRenderer.SetPosition(0, muzzle.position);

        Ray ray = new Ray(muzzle.position, muzzle.transform.forward);
        UnityEngine.Debug.DrawRay(muzzle.position, muzzle.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hitData))
        {
            lineRenderer.SetPosition(1, hitData.point);
            if (timer <= 0)
            {

                audioSource.PlayOneShot(hitSound);
                timer = shootTime;
                TurrentMove mover = hitData.collider.GetComponent<TurrentMove>();
                if (mover != null)
                {
                    mover.Hit(); // Call the Hit function on the TransformMover
                }
            }
        }
        else
        {
            lineRenderer.SetPosition(1, muzzle.transform.forward*1000);

        }
        
    }


    public void aimTowards(Vector3 pos)
    {
        turrent.LookAt(pos);
    }
}
