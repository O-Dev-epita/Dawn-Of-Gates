using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float speed = 3.0F;
	public float rotateSpeed = 2.0F;
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
	private Vector3 moveDirection = Vector3.zero;
	public float minimumX = -360F;
	public float maximumX = 360F;
	public GameObject shu;
	public GameObject shus;
	public float minimumY = -60F;
	public float maximumY = 60F;
	
	public GameObject leftPortal;
	public GameObject rightPortal;
	
	float rotationX = 0F;
	float rotationY = 0F;
	private float gravity = 20.0f;
	private float jumpSpeed = 4.0f;
	Quaternion originalRotation;
	
	void Update() {
		CharacterController controller = GetComponent<CharacterController>();
		/*transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
		Vector3 forward = -transform.TransformDirection(Vector3.forward);
		float curSpeed = speed * Input.GetAxis("Vertical");
		controller.SimpleMove(forward * curSpeed);*/
		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = -transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
			
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
		if (axes == RotationAxes.MouseXAndY)
		{
			
			rotationX += Input.GetAxis("Mouse X") * sensitivityX;
			rotationY += -Input.GetAxis("Mouse Y") * sensitivityY;
			
			rotationX = ClampAngle (rotationX, minimumX, maximumX);
			rotationY = ClampAngle (rotationY, minimumY, maximumY);
			
			Quaternion xQuaternion = Quaternion.AxisAngle (Vector3.up, Mathf.Deg2Rad * rotationX);
			Quaternion yQuaternion = Quaternion.AxisAngle (Vector3.left, Mathf.Deg2Rad * rotationY);
			
			transform.localRotation = originalRotation * xQuaternion * yQuaternion;
		}
		else if (axes == RotationAxes.MouseX)
		{
			rotationX += Input.GetAxis("Mouse X") * sensitivityX;
			rotationX = ClampAngle (rotationX, minimumX, maximumX);
			
			Quaternion xQuaternion = Quaternion.AxisAngle (Vector3.up, Mathf.Deg2Rad * rotationX);
			transform.localRotation = originalRotation * xQuaternion;
		}
		else
		{
			rotationY += -Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = ClampAngle (rotationY, minimumY, maximumY);
			
			Quaternion yQuaternion = Quaternion.AxisAngle (Vector3.left, Mathf.Deg2Rad * rotationY);
			transform.localRotation = originalRotation * yQuaternion;
		}
		if(Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
		{
			GameObject portal = Input.GetButtonDown("Fire1") ? leftPortal : rightPortal;	
			

			RaycastHit hit;
			bool rayTrigger = Physics.Raycast(shus.transform.position, shus.transform.forward, out hit, 100f);
			Object shuClone = Instantiate(shu,shus.transform.position,shus.transform.rotation);
			
			if(rayTrigger && hit.collider.tag == "room")
			{
				float distance = hit.distance;
				float speed = 10f;
				float time = distance / speed;
				Destroy(shuClone, time);
				StartCoroutine(createPortal(time, portal, hit));
				/*portal.transform.position = hit.point;
				portal.transform.rotation = Quaternion.LookRotation(hit.normal);*/
			}

			
			
		}
	}
	
	IEnumerator createPortal(float time, GameObject portal, RaycastHit hit)
	{
		yield return new WaitForSeconds(time);
		portal.transform.position = hit.point;
		portal.transform.rotation = Quaternion.LookRotation(hit.normal);
	}
	
	void Start ()
	{
		
		if (rigidbody)
			rigidbody.freezeRotation = true;
		originalRotation = transform.localRotation;
	}
	
	public static float ClampAngle (float angle, float min, float max)
	{
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp (angle, min, max);
	}
}