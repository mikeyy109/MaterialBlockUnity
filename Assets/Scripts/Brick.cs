using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public static int brickCount = 0;
	
	public AudioClip crack;
	public AudioClip broke;

	//public int maxHits;
	private int timesHit;
	private LevelManager levelManager;
	public Sprite[] hitSprites;
	private bool isBreakable; 

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if(isBreakable){
			brickCount++;
		}
		
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		AudioSource.PlayClipAtPoint(crack, transform.position);
		if(isBreakable){
			HandleHits();
		}
		
	}
	
	void HandleHits(){
		timesHit++;
		if(timesHit >= hitSprites.Length+1){
			AudioSource.PlayClipAtPoint(broke, transform.position);
			brickCount--;
			levelManager.BrickDestroyed();
			Destroy(gameObject);
		} else {
			LoadSprites();
		}
	}
	
	// TODO Remove Simulate later.
	
	void SimulateWin(){
		levelManager.LoadNextLevel();
	}
	
	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
	}
}
