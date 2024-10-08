using UnityEngine;
using System.Collections;

public class VR_Fade : MonoBehaviour
{
	public static VR_Fade instance { get; private set; }
	public float fadeTime = 2.0f;
	public Color fadeColor = new Color(0.01f, 0.01f, 0.01f, 1.0f);
	public bool fadeOnStart = true;
	public int renderQueue = 5000;
	public bool FadeInCheck;
	public bool FadeOutCheck;

	private float explicitFadeAlpha = 0.0f;
	private float animatedFadeAlpha = 0.0f;
	private float uiFadeAlpha = 0.0f;

	private MeshRenderer fadeRenderer;
	private MeshFilter fadeMesh;
	private Material fadeMaterial = null;

	void Start()
	{
		if (gameObject.name.StartsWith("OculusMRC_"))
		{
			Destroy(this);
			return;
		}

		fadeMaterial = new Material(Shader.Find("Oculus/Unlit Transparent Color"));
		fadeMesh = gameObject.AddComponent<MeshFilter>();
		fadeRenderer = gameObject.AddComponent<MeshRenderer>();

		var mesh = new Mesh();
		fadeMesh.mesh = mesh;
		
		Vector3[] vertices = new Vector3[4];
		float width = 5f;
		float height = 5f;
		float depth = 1f;

		vertices[0] = new Vector3(-width, -height, depth);
		vertices[1] = new Vector3(width, -height, depth);
		vertices[2] = new Vector3(-width, height, depth);
		vertices[3] = new Vector3(width, height, depth);

		mesh.vertices = vertices;

		int[] tri = new int[6];

		tri[0] = 0;
		tri[1] = 2;
		tri[2] = 1;
		tri[3] = 2;
		tri[4] = 3;
		tri[5] = 1;

		mesh.triangles = tri;

		Vector3[] normals = new Vector3[4];
		normals[0] = -Vector3.forward;
		normals[1] = -Vector3.forward;
		normals[2] = -Vector3.forward;
		normals[3] = -Vector3.forward;

		mesh.normals = normals;

		Vector2[] uv = new Vector2[4];
		uv[0] = new Vector2(0, 0);
		uv[1] = new Vector2(1, 0);
		uv[2] = new Vector2(0, 1);
		uv[3] = new Vector2(1, 1);

		mesh.uv = uv;

		if (fadeOnStart)
		{
			if (FadeInCheck == true)
			{
				FadeIn();
			}
			else if (FadeOutCheck == true)
			{
				FadeOut();
			}
		}

            instance = this;
	}

	public void FadeIn()
	{
        
			StartCoroutine(Fade(1.0f, 0.0f));
		
	}

	public void FadeOut()
	{
		
			StartCoroutine(Fade(0, 1));
		
	}

	void OnEnable()
	{
		if (!fadeOnStart)
		{
			explicitFadeAlpha = 0.0f;
			animatedFadeAlpha = 0.0f;
			uiFadeAlpha = 0.0f;
		}
	}

	void OnDestroy()
	{
		instance = null;

		if (fadeRenderer != null)
			Destroy(fadeRenderer);
		if (fadeMaterial != null)
			Destroy(fadeMaterial);
		if (fadeMesh != null)
			Destroy(fadeMesh);
	}

	public void SetUIFade(float level)
	{
		uiFadeAlpha = Mathf.Clamp01(level);
		SetMaterialAlpha();
	}

	public void SetExplicitFade(float level)
	{
		explicitFadeAlpha = level;
		SetMaterialAlpha();
	}

	IEnumerator Fade(float startAlpha, float endAlpha)
	{
		float elapsedTime = 0.0f;
		while (elapsedTime < fadeTime)
		{
			elapsedTime += Time.deltaTime;
			animatedFadeAlpha = Mathf.Lerp(startAlpha, endAlpha, Mathf.Clamp01(elapsedTime / fadeTime));
			SetMaterialAlpha();
			yield return new WaitForEndOfFrame();
		}
		animatedFadeAlpha = endAlpha;
		SetMaterialAlpha();
	}

	private void SetMaterialAlpha()
	{
		Color color = fadeColor;
		color.a = Mathf.Max(explicitFadeAlpha, animatedFadeAlpha, uiFadeAlpha);
		if (fadeMaterial != null)
		{
			fadeMaterial.color = color;
			fadeMaterial.renderQueue = renderQueue;
			fadeRenderer.material = fadeMaterial;
			fadeRenderer.enabled = color.a > 0;
		}
	}
}
