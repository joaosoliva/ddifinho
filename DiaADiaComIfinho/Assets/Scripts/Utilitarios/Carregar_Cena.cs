using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Carregar_Cena : MonoBehaviour {

    Animator anim_carregamento;
    enum cena_alvo { Inicio, Fase_1 };

    [Header("Configuração básica")]
    [SerializeField]
    cena_alvo Cena_alvo;

    [Space]
    [SerializeField]
    Slider progresso;
    [SerializeField]
    TextMeshProUGUI valor;

    //Objetos que não podem ser destruídos na passagem de cena
    [Space]
    [SerializeField]
    GameObject[] Nao_destruir;

    private string Cena_Carregada;

    //Caso o valor seja 0 o tempo mínimo será o tempo de carregamento da nova cena.
    private float Tempo_minimo;

    private void Awake()
    {

        switch (Cena_alvo)
        {
            case cena_alvo.Inicio:
                Cena_Carregada = "Inicio";
                break;

            case cena_alvo.Fase_1:
                Cena_Carregada = "Fase_1";
                break;
        }

        Tempo_minimo = 1f;

        anim_carregamento = gameObject.GetComponent<Animator>();

        Debug.Log(SceneManager.GetActiveScene().name);

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Loading_Game()
    {
        anim_carregamento.Play("Iniciar", 0);

        for (int i = 0; i < Nao_destruir.Length; i++)
        {
            DontDestroyOnLoad(Nao_destruir[i]);
        }

        DontDestroyOnLoad(gameObject);

        StartCoroutine(StartLoadScene());
    }

    public IEnumerator StartLoadScene()
    {

        AsyncOperation carregando;

        float auxTime = 0;

        float Tempo_alvo = Time.time + Tempo_minimo;

        carregando = SceneManager.LoadSceneAsync(Cena_Carregada);

        carregando.allowSceneActivation = false;

        while (!carregando.isDone)
        {
            float porcentagem = (carregando.progress / 0.9f) * 100;

            valor.text = "Carregando.... " + porcentagem.ToString("0.00") + "%";
            progresso.value = porcentagem;

            auxTime += Time.deltaTime;

            if (porcentagem == 100)
            {
                Debug.Log("Carregado");
                break;
            }

            yield return new WaitForEndOfFrame();
        }

        //Aguarda até o tempo alvo e a conclusão da animação da tela de carregamento
        while (auxTime < Tempo_alvo && 
            anim_carregamento.GetCurrentAnimatorClipInfo(0).Length > anim_carregamento.GetCurrentAnimatorStateInfo(0).normalizedTime)
        {
            //Evita travar no frame até executar a tarefa (permite uma transição suave)
            yield return new WaitForEndOfFrame();

            auxTime += Time.deltaTime;

        }

        carregando.allowSceneActivation = true;

        anim_carregamento.Play("Finalizar", 0);

    }
}

