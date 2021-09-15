using UnityEngine;

namespace Lightsaber
{
    public class LightsaberController : MonoBehaviour
    {
        #region Variables

        private const float DEGREE_TO_RADIAN = Mathf.PI / 180f;

        private Vector3 _initialPosition;
        private Quaternion _rotationQuaternion;

        private Rigidbody _rigidbody;
        [SerializeField] private GameObject _dotProductHelper;

        private LightsaberRotate _lightsaberRotate;
        private LightsaberCollisionController _lightsaberCollisionController;

		#endregion Variables

		#region Properties

		private Vector3 InitialPosition { get => _initialPosition; set => _initialPosition = value; }
		private Quaternion RotationQuaternion { get => _rotationQuaternion; set => _rotationQuaternion = value; }
		
		private Rigidbody Rigidbody { get => _rigidbody; set => _rigidbody = value; }
		public GameObject DotProductHelper { get => _dotProductHelper; set => _dotProductHelper = value; }
		
        public LightsaberRotate LightsaberRotate { get => _lightsaberRotate; set => _lightsaberRotate = value; }
        public LightsaberCollisionController LightsaberCollisionController { get => _lightsaberCollisionController; set => _lightsaberCollisionController = value; }

		#endregion Properties

		#region Functions

		public void Initialize(float rotationAngle, float rotationSpeed)
        {
            InitialPosition = transform.position;

            Rigidbody = GetComponent<Rigidbody>();

            LightsaberRotate = GetComponent<LightsaberRotate>();
            LightsaberCollisionController = GetComponent<LightsaberCollisionController>();

            LightsaberRotate.Initialize(rotationAngle, rotationSpeed);
        }

        public void ResetLightsaber()
		{
            transform.position = InitialPosition;

            Rigidbody.velocity = Vector3.zero;
            Rigidbody.angularVelocity = Vector3.zero;

            transform.rotation = Quaternion.identity;

            LightsaberRotate.enabled = false;
        }

        public void EnableLightsaberRotate()
		{
            LightsaberRotate.EnableRotation();
		}

        public void SetLightsaberRotation(float value)
		{
            RotationQuaternion = new Quaternion(0, 0, Mathf.Sin(DEGREE_TO_RADIAN * value * 45f), Mathf.Cos(DEGREE_TO_RADIAN * value * 45f));
            transform.rotation = RotationQuaternion;
        }

		#endregion Functions
	}
}