using UnityEngine;

public class FloatingObject : MonoBehaviour {

    Vector2 bobbing;

    public float bobbIntensity = 10f;
    public float bobbSpeed = 0.5f;

    void Start () {
        bobbing = new Vector2(Random.Range(0f, Mathf.PI * 2), Random.Range(0f, Mathf.PI * 2));
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        bobbing.x += Time.deltaTime * bobbSpeed;
        bobbing.y += Time.deltaTime * bobbSpeed / 3f;

        Quaternion upRot = Quaternion.Euler(Mathf.Sin(bobbing.x) * bobbIntensity, transform.rotation.eulerAngles.y, Mathf.Sin(bobbing.y) * bobbIntensity);

        transform.rotation = upRot;
    }
}
