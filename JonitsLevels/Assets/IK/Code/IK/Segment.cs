using UnityEngine;

[System.Serializable]
public class Segment : MonoBehaviour {
    public Renderer renderer { get; private set; }
    public Vector3 LocalPos { get; private set; }
    public bool grounded;
    public Transform rotationHelper;

    void Awake() {
        FindRenderer();
        LocalPos = transform.localPosition;
        rotationHelper = new GameObject().transform;
        rotationHelper.name = name + "RotationHelper";
        rotationHelper.SetParent(transform);
        rotationHelper.transform.localPosition = Vector3.zero;
    }
    
    public void RestoreStartPos() {
        transform.localPosition = LocalPos;
    }

    public float GetLength() {
        FindRenderer();
        return renderer.bounds.size.y;
    }

    void FindRenderer() {
        if(renderer == null)    
            renderer = GetComponentInChildren<Renderer>();
    }
}
