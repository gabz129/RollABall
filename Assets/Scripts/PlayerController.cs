using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 1;
    public Text scoreText;

    Rigidbody player;
    int score = 0;

	void Start () {
        player = GetComponent<Rigidbody>();
        setScore();
	}

	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        player.AddForce(movement * speed);
	}


    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("PickUp")){
            other.gameObject.SetActive(false);
            score += 1;
            setScore();
        }
    }

    void setScore() {
        scoreText.text = "Score: " + score.ToString();
    }

}
