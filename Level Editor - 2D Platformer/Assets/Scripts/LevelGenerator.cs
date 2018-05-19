using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

	public Texture2D mapTexture;
	public PixelToObject[] pixelColorMappings;

	private Color pixelColor;

	void Start ()
	{
		GenerateLevel ();
	}

	void GenerateLevel ()
	{
		// Scan whole Texture and get positions of objects
		for (int i = 0; i < mapTexture.width; i++) {
			for (int j = 0; j < mapTexture.height; j++) { 
				GenerateObject (i, j);
			}
		}
	}

	void GenerateObject (int x, int y)
	{
		// Read pixel color
		pixelColor = mapTexture.GetPixel (x, y);

		if (pixelColor.a == 0) {
			// Do nothing
			return;
		}
			
		foreach (PixelToObject pixelColorMapping in pixelColorMappings) {
			// Scan pixelColorMappings Array for matching color maping
			if (pixelColorMapping.pixelColor.Equals (pixelColor)) {
				Vector2 position = new Vector2 (x, y);
				Instantiate (pixelColorMapping.prefab, position, Quaternion.identity, transform);
			}
		}
	}
}
