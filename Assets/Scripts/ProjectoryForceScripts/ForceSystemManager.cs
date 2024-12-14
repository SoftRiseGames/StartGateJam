using UnityEngine;

public class ForceSystemManager : MonoBehaviour
{
	#region Singleton class: GameManager

	public static ForceSystemManager Instance;

	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
	}

	#endregion

	Camera cam;

	public BallScript ball;
	public Trajectory trajectory;
	[SerializeField] float pushForce = 4f;

	bool isDragging = false;

	Vector2 startPoint;
	Vector2 endPoint;
	Vector2 direction;
	Vector2 force;
	float distance;
	public bool isDragForce;
	void Start()
	{
		cam = Camera.main;
		ball.DeActivatedRb();
		isDragForce = true;
	}

	void Update()
	{
		DragUpdater();
	}

	void DragUpdater()
    {

		if (isDragForce)
		{
			if (Input.GetMouseButtonDown(0))
			{
				isDragging = true;
				OnDragStart();
			}
			if (Input.GetMouseButtonUp(0))
			{
				isDragging = false;
				isDragForce = false;
				OnDragEnd();
			}

			if (isDragging)
			{
				OnDrag();
			}
		}

	}
	void OnDragStart()
	{
		ball.DeActivatedRb();
		startPoint = cam.ScreenToWorldPoint(Input.mousePosition);

		trajectory.Show();
	}

	void OnDrag()
	{
		endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
		distance = Vector2.Distance(startPoint, endPoint);
		direction = (startPoint - endPoint).normalized;
		force = direction * distance * pushForce;

		
		Debug.DrawLine(startPoint, endPoint);


		trajectory.UdpateDots(ball.BallPose, force);
	}

	void OnDragEnd()
	{
	
		ball.ActivateRb();

		ball.Push(force);

		trajectory.Hide();
	}

}