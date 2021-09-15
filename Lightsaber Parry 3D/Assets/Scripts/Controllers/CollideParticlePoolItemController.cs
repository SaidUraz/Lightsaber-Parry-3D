using System;
using UnityEngine;

public class CollideParticlePoolItemController : MonoBehaviour
{
    #region Events

    public Action<CollideParticlePoolItemController> OnParticleSystemDisabled;

    #endregion Events

    #region Variables

    private ParticleSystem _particleSystem;

	#endregion Variables

	#region Properties

	private ParticleSystem ParticleSystem { get => _particleSystem; set => _particleSystem = value; }

	#endregion Properties

	#region Functions

	public void Initialize()
    {
        ParticleSystem = GetComponent<ParticleSystem>();
    }

    public void InitializePoolItem(Vector3 position)
	{
        gameObject.SetActive(true);
        transform.position = position;
        ParticleSystem.Play();
    }

	private void OnParticleSystemStopped()
	{
        gameObject.SetActive(false);
        OnParticleSystemDisabled?.Invoke(this);
    }

	#endregion Functions
}