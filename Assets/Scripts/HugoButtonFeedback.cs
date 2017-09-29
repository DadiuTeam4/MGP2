using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class HugoButtonFeedback : MonoBehaviour {
	private ParticleSystem hugoParticleSystem;

	void Start()
	{
		hugoParticleSystem = GetComponent<ParticleSystem>();
		EventManager.StartListening(EventName.HugoParticleFeedbackOn, StartParticles);
		EventManager.StartListening(EventName.HugoParticleFeedbackOff, StopParticles);
	}

	private void StartParticles()
	{
		hugoParticleSystem.Play();
	}

	private void StopParticles()
	{
		hugoParticleSystem.Stop();
		hugoParticleSystem.Clear();
	}
}
