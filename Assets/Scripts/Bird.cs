using UnityEngine;
using System.Collections;
using Assets.Scripts;

[RequireComponent(typeof(Rigidbody2D))]
public class Bird : MonoBehaviour
{
	public bool canUseSkill = true;

    // Use this for initialization
    void Start()
    {
        //trailrenderer is not visible until we throw the bird
        GetComponent<TrailRenderer>().enabled = false;
        GetComponent<TrailRenderer>().sortingLayerName = "Foreground";
        //no gravity at first
        GetComponent<Rigidbody2D>().isKinematic = true;
        //make the collider bigger to allow for easy touching
        State = BirdState.BeforeThrown;

    }



    void FixedUpdate()
    {
        //if we've thrown the bird
        //and its speed is very small
        if (State == BirdState.Thrown &&
            GetComponent<Rigidbody2D>().velocity.sqrMagnitude <= Constants.MinVelocity)
        {
            //destroy the bird after 2 seconds
            StartCoroutine(DestroyAfter(2));
        }
		if (State == BirdState.Thrown && Input.GetMouseButton(0))
		{
			if (GetComponent<Bird>().canUseSkill)
			{
				

				GameObject g1 = Instantiate (gameObject);
				GameObject g2 = Instantiate (gameObject);
				Vector3 originPos = transform.position;
				Vector3 originScale = transform.localScale;

				g1.transform.position = new Vector3 (originPos.x-1, originPos.y+1);
				g2.transform.position = new Vector3 (originPos.x-1, originPos.y-1);

				g1.transform.localScale=originScale/2;
				g2.transform.localScale=originScale/2;
				transform.localScale=originScale/2;
				

				GetComponent<Bird>().canUseSkill=false;
				StartCoroutine(setClone(g1,g2));

				GetComponent<Bird>().enabled=false;
			}
			
		}
		
	}
	
	public void OnThrow()
    {
        //play the sound
        GetComponent<AudioSource>().Play();
        //show the trail renderer
        GetComponent<TrailRenderer>().enabled = true;
        //allow for gravity forces
        GetComponent<Rigidbody2D>().isKinematic = false;
        //make the collider normal size
        State = BirdState.Thrown;


    }
	IEnumerator setClone(GameObject g1,GameObject g2)
	{
		yield return null;
		Vector2 originVelocity = GetComponent<Rigidbody2D> ().velocity;
		float delta = 2;
		g1.GetComponent<TrailRenderer>().enabled = true;
		g1.GetComponent<TrailRenderer>().sortingLayerName = "Foreground";
		g1.GetComponent<Rigidbody2D>().isKinematic = false;
		g1.GetComponent<Rigidbody2D> ().velocity = new Vector2(originVelocity.x,originVelocity.y+delta);
		g1.GetComponent<Bird>().State = BirdState.Thrown;
		g1.GetComponent<Bird>().canUseSkill = false;
		
		g2.GetComponent<TrailRenderer>().enabled = true;
		g2.GetComponent<TrailRenderer>().sortingLayerName = "Foreground";
		g2.GetComponent<Rigidbody2D>().isKinematic = false;
		g2.GetComponent<Rigidbody2D> ().velocity = new Vector2(originVelocity.x,originVelocity.y-delta);
		g2.GetComponent<Bird>().State = BirdState.Thrown;
		g2.GetComponent<Bird>().canUseSkill = false;
		
		

	}
	IEnumerator DestroyAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }

    public BirdState State
    {
        get;
        private set;
    }
}
