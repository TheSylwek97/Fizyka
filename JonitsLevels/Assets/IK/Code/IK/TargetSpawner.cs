using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour {
	[SerializeField] GameObject targetPrefab;
	[SerializeField] float randomForceLowerValue;
	[SerializeField] float randomForceUpperValue;
	[SerializeField] float delay = 1f;

	void Start(){
		StartCoroutine(SpawnCor());
	}

	IEnumerator SpawnCor(){
		while (true) {
			var targetInstance = Instantiate(targetPrefab, transform);
			targetInstance.transform.position = transform.position;
			var rb = targetInstance.GetComponent<Rigidbody>();
			rb.AddForce(GetRandomDirection(),ForceMode.Impulse);
			yield return new WaitForSeconds(delay);
		}
	}

	Vector3 GetRandomDirection(){
		return new Vector3(GetRandomNumber(),GetRandomNumber(),GetRandomNumber());
	}

	float GetRandomNumber(){
		return Random.Range(randomForceLowerValue, randomForceUpperValue);
	}
}