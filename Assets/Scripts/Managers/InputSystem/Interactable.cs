// Author: Mathias Dam Hedelund
// Contributors:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
	[Header("Visual feedback on touch")]
	[Range(1.01f, 1.2f)]
	public float boomMagnitude = 1.08f;
	[Range(0.0f, 0.5f)]
	public float boomTime = 0.1f;

	[HideInInspector]
	public float timeHeld;

	private bool booming;

    public ParticleSystem particleOnClick;

	public virtual void GiveTouchFeedback(Vector2 screenPos) 
	{
		if (!booming)
		{
			StartCoroutine(Boom());
			booming = true;
		}
        if (particleOnClick)
        {
            EmitParticle(screenPos);
        }
	}

	public virtual void OnTouchBegin(Vector2 position) {}
	public virtual void OnTouchHold() {}
	public virtual void OnTouchReleased() {}

	private IEnumerator Boom()
	{
		Vector3 originalScale = transform.localScale;
		Vector3 boomedScale = originalScale * boomMagnitude;
		float timeElapsed = 0.0f;
		float progress = 0.0f;
		while (timeElapsed < boomTime) 
		{
			timeElapsed += Time.deltaTime;
			progress = timeElapsed / boomTime;
			if (progress < 0.5f) 
			{
				transform.localScale = Vector3.Lerp(originalScale, boomedScale, progress * 2);
			}
			else
			{
				transform.localScale = Vector3.Lerp(boomedScale, originalScale, progress * 2 - 1);
			}
			yield return null;
		}
		booming = false;
	}

    void EmitParticle(Vector2 screenPos)
    {
        Vector3 worldPos = ScreenSpaceToWorldSpace(screenPos);
        Vector3 direction = Camera.main.ScreenPointToRay(screenPos).direction;
        particleOnClick.gameObject.transform.position = worldPos - direction;
        particleOnClick.Emit(1);
    }

    Vector3 ScreenSpaceToWorldSpace(Vector2 xy)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(xy);
        if (Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }
        return new Vector3();
    }
}
