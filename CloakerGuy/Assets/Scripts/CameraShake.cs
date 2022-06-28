using UnityEngine;
using System.Collections;

namespace HSS {
	public class CameraShake : MonoBehaviour
	{
		public Transform camTransform;
		public float shakeDuration = 1f;
		private float shakeCounter;
		public float shakeAmount = 0.7f;
		public float decreaseFactor = 1.0f;
		private bool shouldShake;

		Vector3 originalPos;

		void Awake()
		{
			shouldShake = false;
			if (camTransform == null)
			{
				camTransform = GetComponent(typeof(Transform)) as Transform;
			}
		}

		void OnEnable()
		{
			BombController.BombExploded += ActivateShake;
			originalPos = camTransform.localPosition;
			
		}
		private void OnDisable()
		{
			BombController.BombExploded -= ActivateShake;
		}

		void ActivateShake() {
			shouldShake = true;
			shakeCounter = shakeDuration;
		}
		void Update()
		{
			if (shouldShake)
			{
				

				if (shakeCounter > 0)
				{
					camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

					shakeCounter -= Time.deltaTime * decreaseFactor;
				}
				else
				{
					shakeCounter = 0f;
					camTransform.localPosition = originalPos;
					shouldShake = false;
				}
			}
		}
	}
}