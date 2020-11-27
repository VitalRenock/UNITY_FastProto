using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMotor : MonoBehaviour
{
    [HideInInspector] public Rigidbody _shipRigidbody;
    float _inputsStrafeX;
    float _inputsStrafeY;
    float _inputsStrafeZ;
    float _inputsRotationX;
    float _inputsRotationY;
    float _inputsRotationZ;

    public float _shipPower = 1f;
    public float _shipAngularPower = 1f;
	[Range (0.001f, 0.01f)]
    public float _gyroPower = 0.01f;
    public float _gyroMinVelocityToZero = 0.1f;

    public bool _activateGyroscope;

    void Start()
    {
        _shipRigidbody = transform.GetComponent<Rigidbody>();
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
    }

    void Update()
    {
        _inputsStrafeX = Input.GetAxis("Strafe X");
        _inputsStrafeY = -Input.GetAxis("Strafe Y");
        _inputsStrafeZ = Input.GetAxis("Strafe Z");
        _inputsRotationX = -Input.GetAxis("Rotation X");
        _inputsRotationY = Input.GetAxis("Rotation Y");
        _inputsRotationZ = -Input.GetAxis("Rotation Z");
        if (Input.GetKeyDown(KeyCode.R)) { _activateGyroscope = !_activateGyroscope; }
    }

    private void FixedUpdate()
    {

        ShipMovements();
        if (_activateGyroscope == true && _inputsRotationX == 0f && _inputsStrafeY == 0f && _inputsRotationZ == 0f) { GyroscopeMovements(); }
    }


    private void ShipMovements()
    {
        _shipRigidbody.AddRelativeForce(new Vector3(_inputsStrafeX, _inputsStrafeY, _inputsStrafeZ) * _shipPower * Time.fixedDeltaTime);
        _shipRigidbody.AddRelativeTorque(new Vector3(_inputsRotationX, _inputsRotationY, _inputsRotationZ) * _shipAngularPower * Time.fixedDeltaTime);
    }

	//public AnimationCurve _gyroIntensity;
	//public float _gyroTime;
	private void GyroscopeMovements()
    {
        //Debug.Log("On gyro");
		// Gyroscope compensation
		//_gyroPower = _gyroIntensity.Evaluate(_gyroTime);

		//_shipRigidbody.AddForce(Vector3.Lerp(-_shipRigidbody.velocity, Vector3.zero, _gyroPower));
		_shipRigidbody.AddForce((-_shipRigidbody.velocity / _gyroPower) * Time.fixedDeltaTime);

        // Radian per seconde
        _shipRigidbody.AddTorque((-_shipRigidbody.angularVelocity * 5f) * Time.fixedDeltaTime);

		//_shipRigidbody.velocity = Vector3.zero;
    }

    private void OnDrawGizmos()
    {
        if (_shipRigidbody)
        {
            Vector3 shipPosOffSetA = _shipRigidbody.position + new Vector3(0f, 0f, 0f);
            Vector3 shipPosOffSetB = _shipRigidbody.position + new Vector3(0f, 0.1f, 0f);

            Gizmos.color = Color.red;
            Gizmos.DrawLine(shipPosOffSetA, shipPosOffSetA + (_shipRigidbody.velocity * Time.fixedDeltaTime * 100));
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(shipPosOffSetB, shipPosOffSetB + ((-_shipRigidbody.velocity / _gyroPower) * Time.fixedDeltaTime * 100));

            Gizmos.color = Color.blue;
            Gizmos.DrawLine(shipPosOffSetA, shipPosOffSetA + (_shipRigidbody.angularVelocity * 5f));
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(shipPosOffSetB, shipPosOffSetA + (-_shipRigidbody.angularVelocity * 5f));

			Gizmos.color = new Color(1f, 1f, 1f, 0.1f);
			int lineCount = 3;
			int lineLength = 2;
			int lineSpace = 2;
			for (int posX = -lineCount; posX < lineCount; posX += lineSpace)
			{
				for (int posY = -lineCount; posY < lineCount; posY += lineSpace)
				{
					for (int posZ = -lineCount; posZ < lineCount; posZ += lineSpace)
					{
						Gizmos.DrawRay(new Vector3(Mathf.Round(_shipRigidbody.position.x + posX), Mathf.Round(_shipRigidbody.position.y + posY), Mathf.Round(_shipRigidbody.position.z + posZ)), Vector3.forward * lineLength);
						Gizmos.DrawRay(new Vector3(Mathf.Round(_shipRigidbody.position.x + posX), Mathf.Round(_shipRigidbody.position.y + posY), Mathf.Round(_shipRigidbody.position.z + posZ)), Vector3.back * lineLength);

						Gizmos.DrawRay(new Vector3(Mathf.Round(_shipRigidbody.position.x + posX), Mathf.Round(_shipRigidbody.position.y + posY), Mathf.Round(_shipRigidbody.position.z + posZ)), Vector3.up * lineLength);
						Gizmos.DrawRay(new Vector3(Mathf.Round(_shipRigidbody.position.x + posX), Mathf.Round(_shipRigidbody.position.y + posY), Mathf.Round(_shipRigidbody.position.z + posZ)), Vector3.down * lineLength);

						Gizmos.DrawRay(new Vector3(Mathf.Round(_shipRigidbody.position.x + posX), Mathf.Round(_shipRigidbody.position.y + posY), Mathf.Round(_shipRigidbody.position.z + posZ)), Vector3.right * lineLength);
						Gizmos.DrawRay(new Vector3(Mathf.Round(_shipRigidbody.position.x + posX), Mathf.Round(_shipRigidbody.position.y + posY), Mathf.Round(_shipRigidbody.position.z + posZ)), Vector3.left * lineLength);

					}
				}
				
			}


		}
    }

    private void OnGUI()
    {
        //GUIText monText;
        //monText.text = "test2";
        //GUILayout.TextArea("Test");
    }
}
