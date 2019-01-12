using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotArm : MonoBehaviour {
	[SerializeField] float movementSpeed;
	[SerializeField] float rotationSpeed;
	[SerializeField] Segment[] segments;
	[SerializeField] Transform target;
	public Transform start;
	public Transform end;
	float maxLength;

	#region Calculations
	
	public float CalculateArmLength() {
		var length = 0f;
		foreach (var segment in segments) {
			length += segment.GetLength();
		}
		return length;
	}

	void Start() {
		maxLength = CalculateArmLength();
	}

	bool IsMaxLengthAchieved() {
		return Vector3.Distance(start.position, end.position) > maxLength;
	}

	bool IsTargetAchieved() {
		var distance =
			Vector3.Distance(segments[0].transform.position + segments[0].transform.forward * segments[0].GetLength(),
				target.position);
		return distance < 0.1f;
	}
	#endregion

	#region TargetDetection
	void OnTriggerEnter(Collider other){
		var otherTransform = other.transform;
		if (otherTransform.CompareTag("Target"))
			target = otherTransform;
	}

	void OnTriggerExit(Collider other){
		target = null;
	}
	#endregion

	void Update(){
		if (target == null)
			return;
		UpdateRobotPosition();
	}
	
	void UpdateRobotPosition() {
		if (IsTargetAchieved())
			return;
		RotateTowards(segments[0],target);
		MoveTowards(segments[0], target);
		RotateTowards(segments[1],segments[0].transform);
		MoveTowards(segments[1], segments[0]);
		RotateTowards(segments[2],segments[1].transform);
		MoveTowards(segments[2], segments[1]);

	}

	void RotateTowards(Segment segment, Transform target, bool keepTargetGlobalTransform = true) {
		var targetGlobalRot = target.rotation;
//		segment.transform.LookAt(target);
		segment.rotationHelper.LookAt(target);
		segment.transform.rotation = Quaternion.Lerp(segment.transform.rotation, segment.rotationHelper.rotation, Time.deltaTime * rotationSpeed);
		if (!keepTargetGlobalTransform)
			return;
		target.rotation = targetGlobalRot;
	}
	void MoveTowards(Segment segment, Segment targetSegment, bool keepTargetGlobalTransform = true) {
		if(!segment.grounded)
			MoveTowards(segment,targetSegment.transform);
		if (keepTargetGlobalTransform)
			targetSegment.RestoreStartPos();
	}

	void MoveTowards(Segment segment, Transform target) {
		var segmentPos = segment.transform.position;
		if (!IsMaxLengthAchieved() && Vector3.Distance(segmentPos + segment.transform.forward * segment.GetLength(), target.position) > 0.1f)
			segment.transform.position = Vector3.MoveTowards(segmentPos, target.position, Time.deltaTime * movementSpeed);
	}
}
