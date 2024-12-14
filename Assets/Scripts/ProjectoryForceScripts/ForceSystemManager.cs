using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

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
	bool isHolding = false; // Fareyi basýlý tutma kontrolü
	[SerializeField] float holdThreshold = 0.25f; // Gecikme süresi

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
			if (IsPointerOverUI() || !GameManager.Instance.canDrag) return;

			if (Input.GetMouseButtonDown(0))
			{
				StartCoroutine(HoldDetection());
			}

			if (Input.GetMouseButtonUp(0))
			{
				// Eðer basýlý tutulmamýþsa OnDragEnd çalýþmasýn
				if (isHolding)
				{
					isDragging = false;
					isDragForce = false;
					OnDragEnd();
				}

				isHolding = false; // Basýlý tutma sýfýrlanýr
				StopAllCoroutines(); // Coroutine'i durdur
			}

			if (isDragging)
			{
				OnDrag();
			}
		}

	}

	IEnumerator HoldDetection()
	{
		isHolding = false; // Baþlangýçta basýlý tutulmadýðýný varsay
		yield return new WaitForSeconds(holdThreshold); // Gecikme süresi kadar bekle
		isHolding = true; // Basýlý tutulduðunu iþaretle
		isDragging = true; // Sürükleme iþlemini baþlat
		OnDragStart();
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
	private bool IsPointerOverUI()
	{
		// EventSystem'in PointerOverGameObject kontrolü
		return EventSystem.current.IsPointerOverGameObject();
	}
}