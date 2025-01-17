using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collision : MonoBehaviour
{
	private System.Random _random = new System.Random();
	private Dictionary<string, Color> colorByColorName;
	private static List<string> colorsList;
	private static string curColor;
	private int score = 0;
	private AudioSource audioSource;

	public AudioClip starCollectSound;
	public AudioClip playerDeathSound;
	public AudioClip colorSwitchSound;
	public bool isGameOver = false;
	public Color blue;
	public Color green;
	public Color red;
	public Color purple;
	public TextMeshProUGUI scoreUI;
	public SpriteRenderer playerSprite;
	public GameObject playerDeathParticle;
	public GameObject obstacleSpawner;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
		colorByColorName = new Dictionary<string, Color>
        {
            { "Blue", blue },
			{ "Green", green },
			{ "Red", red },
			{ "Purple", purple }
        };
		colorsList = colorByColorName.Keys.ToList();
        SetPlayerColor(colorsList);
	}

	void Update()
	{
		scoreUI.text = score.ToString();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Star")
		{
			audioSource.PlayOneShot(starCollectSound);
			obstacleSpawner.GetComponent<SpawnObstacle>().Spawn((int)col.gameObject.transform.position.y);
			score += 1;
			return;
		}
		if (col.tag == "ColorChanger")
		{
			audioSource.PlayOneShot(colorSwitchSound);
			SetNewPlayerColor();
			Destroy(col.gameObject);
			return;
		}
		if (col.tag != curColor || col.tag == "BoxCollider")
		{
			audioSource.PlayOneShot(playerDeathSound);
			isGameOver = true;
			Instantiate(playerDeathParticle, gameObject.transform.position, Quaternion.identity);
			playerSprite.color = Color.clear;
			Rigidbody2D rigidbody = gameObject.GetComponent<Rigidbody2D>();
			CircleCollider2D collider = gameObject.GetComponent<CircleCollider2D>();
			rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;
			Destroy(collider);
		}
	}

	void SetNewPlayerColor()
	{
		List<string> leftColors = colorsList.Where(val => val != curColor).ToList();
		SetPlayerColor(leftColors);
	}

	void SetPlayerColor(List<string> colors)
	{
		int colorNum = _random.Next(colors.Count);
		curColor = colors[colorNum];
		playerSprite.color = colorByColorName[curColor];
	}
}
