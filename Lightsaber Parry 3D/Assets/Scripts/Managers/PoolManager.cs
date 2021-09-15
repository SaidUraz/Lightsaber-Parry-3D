using UnityEngine;
using System.Collections.Generic;

namespace Framework.Pool
{
    public class PoolManager
    {
		#region Variables

		private static int _collisionCount;

		private GameObject _poolItemParent;
		private GameObject _collideParticleGameObject;

		private Stack<CollideParticlePoolItemController> _collideParticlePoolItemControllerStack;

		#endregion Variables

		#region Properties

		private static int CollisionCount { get => _collisionCount; set => _collisionCount = value; }
		private GameObject PoolItemParent { get => _poolItemParent; set => _poolItemParent = value; }
		private GameObject CollideParticleGameObject { get => _collideParticleGameObject; set => _collideParticleGameObject = value; }
		private Stack<CollideParticlePoolItemController> CollideParticlePoolItemControllerStack { get => _collideParticlePoolItemControllerStack; set => _collideParticlePoolItemControllerStack = value; }

		#endregion Properties

		#region Functions

		public PoolManager()
		{
			Initialize();
		}

		public void Initialize()
		{
			PoolItemParent = new GameObject("Pool_Item_Parent");

			CollideParticleGameObject = Resources.Load("Prefabs/Particles/Spark_Particle") as GameObject;
			CollideParticlePoolItemControllerStack = new Stack<CollideParticlePoolItemController>();
		}

		public void ActivateCollideParticlePoolItem(Vector3 position)
		{
			CollisionCount++;

			if (CollisionCount % 2 == 0)
			{
				CollideParticlePoolItemController collideParticlePoolItemController;

				if (CollideParticlePoolItemControllerStack.Count > 0)
				{
					collideParticlePoolItemController = CollideParticlePoolItemControllerStack.Pop();
				}
				else
				{
					GameObject collideParticlePoolItemGameObject = GameObject.Instantiate(CollideParticleGameObject, PoolItemParent.transform);
					collideParticlePoolItemController = collideParticlePoolItemGameObject.GetComponent<CollideParticlePoolItemController>();
					collideParticlePoolItemController.Initialize();
					collideParticlePoolItemController.OnParticleSystemDisabled += PushCollideParticlePoolItemControllerToStack;
				}

				if (collideParticlePoolItemController)
				{
					collideParticlePoolItemController.InitializePoolItem(position);
				}
			}
		}

		private void PushCollideParticlePoolItemControllerToStack(CollideParticlePoolItemController collideParticlePoolItemController)
		{
			CollideParticlePoolItemControllerStack.Push(collideParticlePoolItemController);
		}

		#endregion Functions
	}
}