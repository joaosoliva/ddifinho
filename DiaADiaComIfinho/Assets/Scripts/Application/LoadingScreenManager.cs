using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingScreenManager : MonoBehaviour {

	[Header("Loading Visuals")]
	public TextMeshProUGUI loadingText;
	public Image progressBar, txt_background;
	public Image fadeOverlay;
    public Sprite[] images;

	[Header("Timing Settings")]
	public float waitOnLoadEnd = 0.25f;
	public float fadeDuration = 0.25f;

	[Header("Loading Settings")]
	public LoadSceneMode loadSceneMode = LoadSceneMode.Single;
	public ThreadPriority loadThreadPriority;

	[Header("Other")]
    // Coloque o audio listener da camera, para evitar multiplos audio listeners na cena.
	public AudioListener audioListener;
    public int index;

	AsyncOperation operation;
	Scene currentScene;

	public static int sceneToLoad = -1;
    //IMPORTANTE! Esse é o index na build da loading scene. Sempre que modificar a scene de loading, deve ficar atento que o index lá bata com o número aqui!
	static int loadingSceneIndex = 1;

	public static void LoadScene(int levelNum) {				
		Application.backgroundLoadingPriority = ThreadPriority.High;
		sceneToLoad = levelNum;
		SceneManager.LoadScene(loadingSceneIndex); //Toda vez que for chamar uma cena, chame esta linha de código, e adicione o index da cena como parâmetro, assim chamará o Loading também.
        
	}

	void Start() {
		if (sceneToLoad < 0)
			return;

		fadeOverlay.gameObject.SetActive(true); // Making sure it's on so that we can crossfade Alpha
		currentScene = SceneManager.GetActiveScene();
		StartCoroutine(LoadAsync(sceneToLoad));
        index = Random.Range(0, images.Length);
        txt_background.sprite = images[index];    
	}

	private IEnumerator LoadAsync(int levelNum) {
		ShowLoadingVisuals();

		yield return null; 

		FadeIn();
		StartOperation(levelNum);

		float lastProgress = 0f;

		// operation does not auto-activate scene, so it's stuck at 0.9
		while (DoneLoading() == false) {
			yield return null;

			if (Mathf.Approximately(operation.progress, lastProgress) == false) {
				progressBar.fillAmount = operation.progress;
				lastProgress = operation.progress;
			}
		}

		if (loadSceneMode == LoadSceneMode.Additive)
			audioListener.enabled = false;

		ShowCompletionVisuals();

		yield return new WaitForSeconds(waitOnLoadEnd);

		FadeOut();

		yield return new WaitForSeconds(fadeDuration);

		if (loadSceneMode == LoadSceneMode.Additive)
			SceneManager.UnloadSceneAsync(currentScene.name);
		else
			operation.allowSceneActivation = true;
	}

	private void StartOperation(int levelNum) {
		Application.backgroundLoadingPriority = loadThreadPriority;
		operation = SceneManager.LoadSceneAsync(levelNum, loadSceneMode);


		if (loadSceneMode == LoadSceneMode.Single)
			operation.allowSceneActivation = false;
	}

	private bool DoneLoading() {
		return (loadSceneMode == LoadSceneMode.Additive && operation.isDone) || (loadSceneMode == LoadSceneMode.Single && operation.progress >= 0.9f); 
	}

	void FadeIn() {
		fadeOverlay.CrossFadeAlpha(0, fadeDuration, true);
	}

	void FadeOut() {
		fadeOverlay.CrossFadeAlpha(1, fadeDuration, true);
	}

	void ShowLoadingVisuals() {

		progressBar.fillAmount = 0f;
		loadingText.text = "Carregando...";
	}

	void ShowCompletionVisuals() {

		progressBar.fillAmount = 1f;
		loadingText.text = "100% completo!";
	}

}