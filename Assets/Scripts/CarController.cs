using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

    public float carLeftRightSpeed;
    Vector3 position;

    public UiManager ui;

    public AudioManager am;

	// float middle = Screen.width/2;

    // public float minPos = 2.56f;
    // public float maxPosHorizontal = 2.6f;

	bool currentPlatformAndroid = false;

	Rigidbody2D rb;

	void Awake()
	{

		#if UNITY_ANDROID 
				currentPlatformAndroid = true;
		#else
				currentPlatformAndroid = false;
		#endif

		rb = GetComponent<Rigidbody2D> ();

		am.carSound.Play();
	}

	void Start () {
        // ui = GetComponent<UiManager>();

        position = transform.position;

		if (currentPlatformAndroid == true) {
		
			Debug.Log ("Android");
		}
		else{
			Debug.Log("Windows");
		}

	}

	// Update is called once per frame
	void Update () {

		if (currentPlatformAndroid == true) {
		
			// Android specific code
			// TouchMove();
			AccelerometerMove();
		
		} else {
			position.y += Input.GetAxis ("Vertical") * carLeftRightSpeed * Time.deltaTime;
			position.y = Mathf.Clamp (position.y, -5.0f, 2.6f);
			position.x += Input.GetAxis ("Horizontal") * carLeftRightSpeed * Time.deltaTime;
			position.x = Mathf.Clamp (position.x, -2.56f, 2.6f);
			transform.position = position;
		}
	
		position = transform.position;
		position.x = Mathf.Clamp (position.x, -2.56f, 2.6f);
		position.y = Mathf.Clamp (position.y, -5.0f, 2.6f);
		transform.position = position;
		// carLeftRightSpeed += 0.01f;
	}

    void OnCollisionEnter2D(Collision2D col){

        if(col.gameObject.tag == "EnemyCar")
        {
            // Destroy(gameObject);
			gameObject.SetActive(false);

            ui.GameOver();
            am.carSound.Stop();
        }
    }

	void AccelerometerMove(){
	
		float x = Input.acceleration.x;
		// Debug.Log ("X = " + x);


		if (x < -0.1f) {
			MoveLeft ();
		}
		else if (x > 0.1f) {
			MoveRight ();
		}
		else {
			SetVelocityZero();
		}
	}

	/* public void TouchMove(){
	
		if (Input.touchCount > 0) {

			Touch touch = Input.GetTouch(0);


			if(touch.position.x < middle && touch.phase == TouchPhase.Began){

				MoveLeft();
				
			}
			else if(touch.position.x > middle && touch.phase == TouchPhase.Began){

				MoveRight();

			}
			else{
				SetVelocityZero();
			}
		
		}
	} */

	public void Accelerate(){
		
		rb.velocity = new Vector2 (0,0);
	}

	public void DeAccelerate(){
		
		rb.velocity = new Vector2 (0, 0);
	}

	public void MoveLeft(){

		rb.velocity = new Vector2 (-carLeftRightSpeed, 0);
	}

	public void MoveRight(){

		rb.velocity = new Vector2 (carLeftRightSpeed, 0);
	}

	public void SetVelocityZero(){

		rb.velocity = Vector2.zero;
	}
}
