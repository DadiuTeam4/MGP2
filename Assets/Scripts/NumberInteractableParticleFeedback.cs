using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class NumberInteractableParticleFeedback : MonoBehaviour {
	public float activeEmission;
	public float idleEmission;
	private ParticleSystem feedbackParticleSystem;
	private ParticleSystem.EmissionModule emissionModule;

	void Start()
	{
		feedbackParticleSystem = GetComponent<ParticleSystem>();
		emissionModule = feedbackParticleSystem.emission;
	}

	public void SetToActiveEmission()
	{
		emissionModule.rateOverTime = new ParticleSystem.MinMaxCurve(activeEmission, activeEmission);
	}

	public void SetToIdleEmission()
	{
		emissionModule.rateOverTime = new ParticleSystem.MinMaxCurve(idleEmission, idleEmission);
	}
}
