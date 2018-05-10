using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using TMPro;

public class ChangeLanguage : MonoBehaviour {

    [Header("Language")]
    [SerializeField]
    TextMeshProUGUI Language_FrasePrincipal;
    [Space]

    [Header("MainScreen")]
    [SerializeField]
    TextMeshProUGUI MainScreen_FrasePrincipal;
    [Space]

    [Header("Menu")]
    [SerializeField]
    TextMeshProUGUI Menu_Continuar;
    [SerializeField]
    TextMeshProUGUI Menu_Novo;
    [SerializeField]
    TextMeshProUGUI Menu_Opcoes;
    [SerializeField]
    TextMeshProUGUI Menu_Sair;
    [Space]

    [Header("Permission")]
    [SerializeField]
    TextMeshProUGUI Permission_Pergunta;
    [SerializeField]
    TextMeshProUGUI Permission_Sim;
    [SerializeField]
    TextMeshProUGUI Permission_Nao;
    [Space]

    [Header("Data")]
    [SerializeField]
    TextMeshProUGUI Data_Dropdown_Pergunta;
    [SerializeField]
    TMP_Dropdown Data_Dropdown;
    [SerializeField]
    TextMeshProUGUI Data_Toogle_Pergunta;
    [SerializeField]
    TextMeshProUGUI Data_Toogle_Sim;
    [SerializeField]
    TextMeshProUGUI Data_Toogle_Nao;
    [SerializeField]
    TextMeshProUGUI Data_Ok;
    [SerializeField]
    TextMeshProUGUI Data_Voltar;
    [Space]

    [Header("Difficulty")]
    [SerializeField]
    TextMeshProUGUI Difficulty_Pergunta;
    [SerializeField]
    TextMeshProUGUI Difficulty_Facil;
    [SerializeField]
    TextMeshProUGUI Difficulty_Medio;
    [SerializeField]
    TextMeshProUGUI Difficulty_Dificil;
    [SerializeField]
    TextMeshProUGUI Difficulty_Ok;
    [SerializeField]
    TextMeshProUGUI Difficulty_Voltar;
    [Space]

    [Header("Map")]
    [SerializeField]
    TextMeshProUGUI Map_Manha_Titulo;
    [SerializeField]
    TextMeshProUGUI Map_Manha_Imagem;
    [SerializeField]
    TextMeshProUGUI Map_Manha_Som;
    [SerializeField]
    TextMeshProUGUI Map_Tarde_Titulo;
    [SerializeField]
    TextMeshProUGUI Map_Tarde_Imagem;
    [SerializeField]
    TextMeshProUGUI Map_Tarde_Som;
    [SerializeField]
    TextMeshProUGUI Map_Noite_Titulo;
    [SerializeField]
    TextMeshProUGUI Map_Noite_Imagem;
    [SerializeField]
    TextMeshProUGUI Map_Noite_Som;
    [SerializeField]
    TextMeshProUGUI Map_Voltar;
    [Space]


    [Header("Option")]
    [SerializeField]
    TextMeshProUGUI Option_Titulo;
    [SerializeField]
    TextMeshProUGUI Option_Som_Pergunta;
    [SerializeField]
    TextMeshProUGUI Option_Language_Pergunta;
    [SerializeField]
    TextMeshProUGUI Option_Difficulty_Pergunta;
    [SerializeField]
    TextMeshProUGUI Option_Difficulty_Facil;
    [SerializeField]
    TextMeshProUGUI Option_Difficulty_Medio;
    [SerializeField]
    TextMeshProUGUI Option_Difficulty_Dificil;
    [SerializeField]
    TextMeshProUGUI Option_Credits_Pergunta;
    [SerializeField]
    TextMeshProUGUI Option_Credits_Botao;
    [SerializeField]
    TextMeshProUGUI Option_Sair;
    [Space]

    [Header("Tutorial")]
    [SerializeField]
    TextMeshProUGUI Tutorial_FrasePrincipal;
    [SerializeField]
    TextMeshProUGUI Tutorial_Repetir;
    [SerializeField]
    TextMeshProUGUI Tutorial_Continuar;
    [SerializeField]
    TextMeshProUGUI Tutorial_Voltar;
    [Space]

    [Header("Minigame1")]
    [SerializeField]
    TextMeshProUGUI MiniGame1_Avaliacacao;
    [SerializeField]
    TextMeshProUGUI MiniGame1_Repetir;
    [SerializeField]
    TextMeshProUGUI MiniGame1_Voltar;
    [SerializeField]
    TextMeshProUGUI MiniGame1_Tutorial_FrasePrincipal;
    [SerializeField]
    TextMeshProUGUI MiniGame1_Tutorial_Sim;
    [SerializeField]
    TextMeshProUGUI MiniGame1_Tutorial_Nao;
    [Space]

    [Header("Minigame2")]
    [SerializeField]
    TextMeshProUGUI MiniGame2_Avaliacacao;
    [SerializeField]
    TextMeshProUGUI MiniGame2_Repetir;
    [SerializeField]
    TextMeshProUGUI MiniGame2_Voltar;
    [SerializeField]
    TextMeshProUGUI MiniGame2_Tutorial_FrasePrincipal;
    [SerializeField]
    TextMeshProUGUI MiniGame2_Tutorial_Sim;
    [SerializeField]
    TextMeshProUGUI MiniGame2_Tutorial_Nao;
    [Space]

    [Header("Minigame3")]
    [SerializeField]
    TextMeshProUGUI MiniGame3_Avaliacacao;
    [SerializeField]
    TextMeshProUGUI MiniGame3_Repetir;
    [SerializeField]
    TextMeshProUGUI MiniGame3_Voltar;
    [SerializeField]
    TextMeshProUGUI MiniGame3_Tutorial_FrasePrincipal;
    [SerializeField]
    TextMeshProUGUI MiniGame3_Tutorial_Sim;
    [SerializeField]
    TextMeshProUGUI MiniGame3_Tutorial_Nao;

    [Header("Minigame4")]
    [SerializeField]
    TextMeshProUGUI MiniGame4_Avaliacacao;
    [SerializeField]
    TextMeshProUGUI MiniGame4_Repetir;
    [SerializeField]
    TextMeshProUGUI MiniGame4_Voltar;
    [SerializeField]
    TextMeshProUGUI MiniGame4_Tutorial_FrasePrincipal;
    [SerializeField]
    TextMeshProUGUI MiniGame4_Tutorial_Sim;
    [SerializeField]
    TextMeshProUGUI MiniGame4_Tutorial_Nao;
    [Space]

    [Header("Minigame5")]
    [SerializeField]
    TextMeshProUGUI MiniGame5_Avaliacacao;
    [SerializeField]
    TextMeshProUGUI MiniGame5_Repetir;
    [SerializeField]
    TextMeshProUGUI MiniGame5_Voltar;
    [SerializeField]
    TextMeshProUGUI MiniGame5_Tutorial_FrasePrincipal;
    [SerializeField]
    TextMeshProUGUI MiniGame5_Tutorial_Sim;
    [SerializeField]
    TextMeshProUGUI MiniGame5_Tutorial_Nao;
    //[Space]

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetLanguage()
    {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(Resources.Load<TextAsset>("Idiomas/" + PlayerPrefs.GetString("Lingua")).ToString());

        Language_FrasePrincipal.text = doc.SelectSingleNode("//Language/FrasePrincipal").InnerText;
        MainScreen_FrasePrincipal.text = doc.SelectSingleNode("//MainScreen/FrasePrincipal").InnerText;
        Menu_Continuar.text = doc.SelectSingleNode("//Menu/Continuar").InnerText;
        Menu_Novo.text = doc.SelectSingleNode("//Menu/Novo").InnerText;
        Menu_Opcoes.text = doc.SelectSingleNode("//Menu/Opcoes").InnerText;
        Menu_Sair.text = doc.SelectSingleNode("//Menu/Sair").InnerText;

        Permission_Pergunta.text = doc.SelectSingleNode("//Permission/Pergunta").InnerText;
        Permission_Sim.text = doc.SelectSingleNode("//Permission/Sim").InnerText;
        Permission_Nao.text = doc.SelectSingleNode("//Permission/Nao").InnerText;


        Data_Dropdown_Pergunta.text = doc.SelectSingleNode("//Data/DropDown/Pergunta").InnerText;
        for (int i = 0; i < Data_Dropdown.options.Count; i++)
        {
            Data_Dropdown.options[i].text = doc.SelectSingleNode("//Data/DropDown/Opcao" + (i + 1)).InnerText;
        }
        Data_Dropdown.RefreshShownValue();
        Data_Toogle_Pergunta.text = doc.SelectSingleNode("//Data/Toogle/Pergunta").InnerText;
        Data_Toogle_Sim.text = doc.SelectSingleNode("//Data/Toogle/Sim").InnerText;
        Data_Toogle_Nao.text = doc.SelectSingleNode("//Data/Toogle/Nao").InnerText;
        Data_Ok.text = doc.SelectSingleNode("//Data/Ok").InnerText;
        Data_Voltar.text = doc.SelectSingleNode("//Data/Voltar").InnerText;

        Difficulty_Pergunta.text = doc.SelectSingleNode("//Difficulty/Pergunta").InnerText;
        Difficulty_Facil.text = doc.SelectSingleNode("//Difficulty/Facil").InnerText;
        Difficulty_Medio.text = doc.SelectSingleNode("//Difficulty/Medio").InnerText;
        Difficulty_Dificil.text = doc.SelectSingleNode("//Difficulty/Dificil").InnerText;
        Difficulty_Ok.text = doc.SelectSingleNode("//Difficulty/Ok").InnerText;
        Difficulty_Voltar.text = doc.SelectSingleNode("//Difficulty/Voltar").InnerText;


        Map_Manha_Titulo.text = doc.SelectSingleNode("//Map/Manha/Titulo").InnerText;
        Map_Manha_Imagem.text = doc.SelectSingleNode("//Map/Manha/Imagem").InnerText;
        Map_Manha_Som.text = doc.SelectSingleNode("//Map/Manha/Som").InnerText;
        Map_Tarde_Titulo.text = doc.SelectSingleNode("//Map/Tarde/Titulo").InnerText;
        Map_Tarde_Imagem.text = doc.SelectSingleNode("//Map/Tarde/Imagem").InnerText;
        Map_Tarde_Som.text = doc.SelectSingleNode("//Map/Tarde/Som").InnerText;
        Map_Noite_Titulo.text = doc.SelectSingleNode("//Map/Noite/Titulo").InnerText;
        Map_Noite_Imagem.text = doc.SelectSingleNode("//Map/Noite/Imagem").InnerText;
        Map_Noite_Som.text = doc.SelectSingleNode("//Map/Noite/Som").InnerText;
        Map_Voltar.text = doc.SelectSingleNode("//Map/Voltar").InnerText;

        Option_Titulo.text = doc.SelectSingleNode("//Option/Titulo").InnerText;
        Option_Som_Pergunta.text = doc.SelectSingleNode("//Option/Sound/Pergunta").InnerText;
        Option_Language_Pergunta.text = doc.SelectSingleNode("//Option/Language/Pergunta").InnerText;
        Option_Difficulty_Pergunta.text = doc.SelectSingleNode("//Option/Difficulty/Pergunta").InnerText;
        Option_Difficulty_Facil.text = doc.SelectSingleNode("//Option/Difficulty/Facil").InnerText;
        Option_Difficulty_Medio.text = doc.SelectSingleNode("//Option/Difficulty/Medio").InnerText;
        Option_Difficulty_Dificil.text = doc.SelectSingleNode("//Option/Difficulty/Dificil").InnerText;
        Option_Credits_Pergunta.text = doc.SelectSingleNode("//Option/Credits/Pergunta").InnerText;
        Option_Credits_Botao.text = doc.SelectSingleNode("//Option/Credits/Botao").InnerText;
        Option_Sair.text = doc.SelectSingleNode("//Option/Sair").InnerText;


        Tutorial_FrasePrincipal.text = doc.SelectSingleNode("//Tutorial/FrasePrincipal").InnerText;
        Tutorial_Repetir.text = doc.SelectSingleNode("//Tutorial/Repetir").InnerText;
        Tutorial_Continuar.text = doc.SelectSingleNode("//Tutorial/Continuar").InnerText;
        Tutorial_Voltar.text = doc.SelectSingleNode("//Tutorial/Voltar").InnerText;

        MiniGame1_Avaliacacao.text = doc.SelectSingleNode("//MinigameBasic/Score/Avaliacao").InnerText;
        MiniGame1_Repetir.text = doc.SelectSingleNode("//MinigameBasic/Score/Repetir").InnerText;
        MiniGame1_Voltar.text = doc.SelectSingleNode("//MinigameBasic/Score/Voltar").InnerText;
        MiniGame1_Tutorial_FrasePrincipal.text = doc.SelectSingleNode("//MinigameBasic/Tutorial/FrasePrincipal").InnerText;
        MiniGame1_Tutorial_Sim.text = doc.SelectSingleNode("//MinigameBasic/Tutorial/Sim").InnerText;
        MiniGame1_Tutorial_Nao.text = doc.SelectSingleNode("//MinigameBasic/Tutorial/Nao").InnerText;


        MiniGame2_Avaliacacao.text = doc.SelectSingleNode("//MinigameBasic/Score/Avaliacao").InnerText;
        MiniGame2_Repetir.text = doc.SelectSingleNode("//MinigameBasic/Score/Repetir").InnerText;
        MiniGame2_Voltar.text = doc.SelectSingleNode("//MinigameBasic/Score/Voltar").InnerText;
        MiniGame2_Tutorial_FrasePrincipal.text = doc.SelectSingleNode("//MinigameBasic/Tutorial/FrasePrincipal").InnerText;
        MiniGame2_Tutorial_Sim.text = doc.SelectSingleNode("//MinigameBasic/Tutorial/Sim").InnerText;
        MiniGame2_Tutorial_Nao.text = doc.SelectSingleNode("//MinigameBasic/Tutorial/Nao").InnerText;


        MiniGame3_Avaliacacao.text = doc.SelectSingleNode("//MinigameBasic/Score/Avaliacao").InnerText;
        MiniGame3_Repetir.text = doc.SelectSingleNode("//MinigameBasic/Score/Repetir").InnerText;
        MiniGame3_Voltar.text = doc.SelectSingleNode("//MinigameBasic/Score/Voltar").InnerText;
        MiniGame3_Tutorial_FrasePrincipal.text = doc.SelectSingleNode("//MinigameBasic/Tutorial/FrasePrincipal").InnerText;
        MiniGame3_Tutorial_Sim.text = doc.SelectSingleNode("//MinigameBasic/Tutorial/Sim").InnerText;
        MiniGame3_Tutorial_Nao.text = doc.SelectSingleNode("//MinigameBasic/Tutorial/Nao").InnerText;

        MiniGame4_Avaliacacao.text = doc.SelectSingleNode("//MinigameBasic/Score/Avaliacao").InnerText;
        MiniGame4_Repetir.text = doc.SelectSingleNode("//MinigameBasic/Score/Repetir").InnerText;
        MiniGame4_Voltar.text = doc.SelectSingleNode("//MinigameBasic/Score/Voltar").InnerText;
        MiniGame4_Tutorial_FrasePrincipal.text = doc.SelectSingleNode("//MinigameBasic/Tutorial/FrasePrincipal").InnerText;
        MiniGame4_Tutorial_Sim.text = doc.SelectSingleNode("//MinigameBasic/Tutorial/Sim").InnerText;
        MiniGame4_Tutorial_Nao.text = doc.SelectSingleNode("//MinigameBasic/Tutorial/Nao").InnerText;

        MiniGame5_Avaliacacao.text = doc.SelectSingleNode("//MinigameBasic/Score/Avaliacao").InnerText;
        MiniGame5_Repetir.text = doc.SelectSingleNode("//MinigameBasic/Score/Repetir").InnerText;
        MiniGame5_Voltar.text = doc.SelectSingleNode("//MinigameBasic/Score/Voltar").InnerText;
        MiniGame5_Tutorial_FrasePrincipal.text = doc.SelectSingleNode("//MinigameBasic/Tutorial/FrasePrincipal").InnerText;
        MiniGame5_Tutorial_Sim.text = doc.SelectSingleNode("//MinigameBasic/Tutorial/Sim").InnerText;
        MiniGame5_Tutorial_Nao.text = doc.SelectSingleNode("//MinigameBasic/Tutorial/Nao").InnerText;

        //MiniGame6_Avaliacacao.text = doc.SelectSingleNode("//MinigameBasic/Score/Avaliacao").InnerText;
        //MiniGame6_Repetir.text = doc.SelectSingleNode("//MinigameBasic/Score/Repetir").InnerText;
        //MiniGame6_Voltar.text = doc.SelectSingleNode("//MinigameBasic/Score/Voltar").InnerText;
        //MiniGame6_Tutorial_FrasePrincipal.text = doc.SelectSingleNode("//MinigameBasic/Tutorial/FrasePrincipal").InnerText;
        //MiniGame6_Tutorial_Sim.text = doc.SelectSingleNode("//MinigameBasic/Tutorial/Sim").InnerText;
        //MiniGame6_Tutorial_Nao.text = doc.SelectSingleNode("//MinigameBasic/Tutorial/Nao").InnerText;
    }
}
