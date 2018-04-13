using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.IO;

public class Observador : MonoBehaviour {

    private static string filePath;
    private static string fileName = "Profile.xml";
    private static XmlDocument doc;

    // Use this for initialization
    void Start() {
        doc = new XmlDocument();

        filePath = Path.Combine(Application.persistentDataPath, fileName);

        if (File.Exists(filePath))
        {
            doc.Load(filePath);
        }

        else
        {
            IniciarDocumento();
        }
    }

    // Update is called once per frame
    void Update() {

    }


    void IniciarDocumento()
    {
        XmlElement dados = doc.CreateElement("Dados");
        doc.AppendChild(dados);
        SaveData();
    }

    static public void CriarUsuario(string idade_canvas, string autismo_canvas)
    {
        //Resetamos o doc para a versão oficial para evitar duplicadas de dados
        doc.Load(filePath);

        XmlElement usuario = doc.CreateElement("Usuario");
        usuario.SetAttribute("id", Buscar_ID_Livre().ToString());

        XmlElement idade = doc.CreateElement("Idade");
        idade.InnerText = idade_canvas;
        XmlElement autismo = doc.CreateElement("Autismo");
        autismo.InnerText = autismo_canvas;

        usuario.AppendChild(idade);
        usuario.AppendChild(autismo);

        for (int i = 1; i < Menu.total_minigames + 1; i++)
        {
            XmlElement score = doc.CreateElement("Score_Minigame_" + i + "_easy");
            score.InnerText = "0";
            usuario.AppendChild(score);

            score = doc.CreateElement("Score_Minigame_" + i + "_normal");
            score.InnerText = "0";
            usuario.AppendChild(score);

            score = doc.CreateElement("Score_Minigame_" + i + "_hard");
            score.InnerText = "0";
            usuario.AppendChild(score);
        }

        doc.SelectSingleNode("Dados").AppendChild(usuario);
    }

    static public void OficializarUsuario()
    {
        SaveData();
    }

    static int Buscar_ID_Livre()
    {
        XmlNodeList list = doc.SelectNodes("/Dados/Usuario");

        int aux = 0;
        if (list.Count >= 1)
        {
            foreach (XmlNode x in list)
            {
                if (aux < int.Parse(((XmlElement)x).GetAttribute("id")))
                {
                    aux = int.Parse(((XmlElement)x).GetAttribute("id"));
                }

            }
        }

        //Se não houver nenhum elemento no xml o ID a ser passado será 1

        aux++;

        return aux;
    }

    //Método destinado a encontrar o ID do último usuário criado

    static int Buscar_ID_Atual()
    {
        XmlNodeList list = doc.SelectNodes("/Dados/Usuario");

        int aux = 0;

        if (list.Count >= 1)
        {
            foreach (XmlNode x in list)
            {
                if (aux < int.Parse(((XmlElement)x).GetAttribute("id")))
                {
                    aux = int.Parse(((XmlElement)x).GetAttribute("id"));
                }

            }
        }

        return aux;
    }

    static public void AtualizarScore(int valor, int minigame)
    {
        doc.SelectSingleNode("//Usuario[@id='" + Buscar_ID_Atual() + "']/Score_Minigame_" + minigame + "_" + PlayerPrefs.GetString("Dificuldade")).InnerText = valor.ToString();
        Debug.Log("atualizado");
        SaveData();
    }

    static public void SaveData()
    {
        doc.Save(filePath);
    }
}
