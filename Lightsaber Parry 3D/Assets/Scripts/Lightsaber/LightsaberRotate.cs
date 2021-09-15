using UnityEngine;

public class LightsaberRotate : MonoBehaviour
{
    #region Events



    #endregion Events

    #region Variables

    private const float DEGREE_TO_RADIAN = Mathf.PI / 180f;

    private float _lerpT;
    private float _rotationAngle;
    private float _rotationSpeed;

    private Quaternion _targetQuaternion;
    private Quaternion _initialQuaternion;

	#endregion Variables

	#region Properties

	private float LerpT { get => _lerpT; set => _lerpT = value; }
	private float RotationAngle { get => _rotationAngle; set => _rotationAngle = value / 2f; }
	private float RotationSpeed { get => _rotationSpeed; set => _rotationSpeed = value; }
	
    private Quaternion TargetQuaternion { get => _targetQuaternion; set => _targetQuaternion = value; }
	private Quaternion InitialQuaternion { get => _initialQuaternion; set => _initialQuaternion = value; }

	#endregion Properties

	#region OnEnable - Update

	void OnEnable()
	{
        LerpT = 0;
        InitialQuaternion = transform.rotation;
        TargetQuaternion = new Quaternion(0,  Mathf.Sin(-RotationAngle * DEGREE_TO_RADIAN), 0, Mathf.Cos(-RotationAngle * DEGREE_TO_RADIAN)) * transform.rotation;
    }

	void Update()
    {
        RotateLightsaberByTime();
    }

    #endregion OnEnable - Update

    #region Functions

    public void Initialize(float rotationAngle, float rotationSpeed)
    {
        RotationAngle = rotationAngle;
        RotationSpeed = rotationSpeed;
    }

    public void EnableRotation()
	{
        enabled = true;
    }

    public void DisableRotation()
	{
        enabled = false;
    }

    public void RotateLightsaberByTime()
	{
		LerpT += Time.deltaTime * RotationSpeed; // Linear curve
		transform.rotation = Quaternion.Lerp(InitialQuaternion, TargetQuaternion, LerpT);

		if (LerpT >= 1f)
			DisableRotation();
    }

    #endregion Functions
}