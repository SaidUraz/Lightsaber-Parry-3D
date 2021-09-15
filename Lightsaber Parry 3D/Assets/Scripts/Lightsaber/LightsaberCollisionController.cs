using System;
using UnityEngine;

namespace Lightsaber
{
    public class LightsaberCollisionController : MonoBehaviour
    {
        #region Events

        public Action OnLightsabersCollide;
        public Action<Vector3> OnLightsabersCollideWithVector;

        #endregion Events

        #region Variables



        #endregion Variables

        #region Properties



        #endregion Properties

        #region Functions

        public void Initialize()
        {

        }

        public void SubscribeEvents()
        {

        }

        public void UnSubscribeEvents()
        {

        }

        #endregion Functions

        #region Collision

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Lightsaber"))
            {
                OnLightsabersCollide?.Invoke();
                OnLightsabersCollideWithVector?.Invoke(collision.contacts[0].point);
            }
        }

        #endregion Collision
    }
}