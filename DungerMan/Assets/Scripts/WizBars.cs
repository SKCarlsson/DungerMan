using UnityEngine;
using System.Collections;

public class WizBars : MonoBehaviour
{
	
	Rect box = new Rect(10, 10, 200, 40);
	Rect box2 = new Rect(10, 60, 200, 40);
	
	private Texture2D background;
	private Texture2D foreground;
	private Texture2D background2;
	private Texture2D foreground2;
	
	public float health = 50;
	public int maxHealth = 100;
	public float mana = 50;
	public int maxMana = 100;
	
	void Start()
	{
		
		background = new Texture2D(1, 1, TextureFormat.RGB24, false);
		foreground = new Texture2D(1, 1, TextureFormat.RGB24, false);
		background2 = new Texture2D(1, 1, TextureFormat.RGB24, false);
		foreground2 = new Texture2D(1, 1, TextureFormat.RGB24, false);
		
		background.SetPixel(0, 0, Color.red);
		foreground.SetPixel(0, 0, Color.green);
		background2.SetPixel(0, 0, Color.black);
		foreground2.SetPixel(0, 0, Color.blue);
		
		background.Apply();
		foreground.Apply();
		background2.Apply();
		foreground2.Apply();
		
		
	}
	
	void Update()
	{
		health = this.gameObject.GetComponent<Wizard>().playerHealth;
		mana = this.gameObject.GetComponent<Wizard>().Mana;
	}
	
	void OnGUI()
	{
		GUI.BeginGroup(box);
		{
			GUI.DrawTexture(new Rect(0, 0, box.width, box.height), background, ScaleMode.StretchToFill);
			GUI.DrawTexture(new Rect(0, 0, box.width*health/maxHealth, box.height), foreground, ScaleMode.StretchToFill);
		}
		GUI.EndGroup();
		GUI.BeginGroup(box2);
		{
			GUI.DrawTexture(new Rect(0, 0, box2.width, box2.height), background2, ScaleMode.StretchToFill);
			GUI.DrawTexture(new Rect(0, 0, box2.width*mana/maxMana, box2.height), foreground2, ScaleMode.StretchToFill);
		}
		GUI.EndGroup();
	}
	
}