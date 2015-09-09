using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridConstructor : MonoBehaviour
{

    List<string> m_ListofText = new List<string>();//Définir la liste dans laquelle sont rangés les éléments.

    public GameObject m_Prefab;//l'objet à instancier

    GameObject m_ButtonInstance;// instance de l'objet à instancier


    NewBehaviourScript m_Script;// son script
    RectTransform m_Rect;// ici son recttransform, permet d'avoir ses dimensions

    float posx;// position d'instanciation en x
    float posy;// position d'instanciation en y

    public int m_LineLength;//longueur des lignes 

	// Use this for initialization
	void Start ()
    {
        m_ListofText.Add( "Blue");
        m_ListofText.Add("Green");
        m_ListofText.Add("Red");
        m_ListofText.Add("Yellow");
        m_ListofText.Add("Orange");
        m_ListofText.Add("Purple");
        m_ListofText.Add("Brown");




        m_Script = m_Prefab.GetComponent<NewBehaviourScript>();//récupération du script de l'objet
        m_Rect = m_Prefab.GetComponent<RectTransform>();//récupération de son recttransform

        posy = 900f;// définition de la première position en y, se souvenir que le repère va vers le haut.

        int i = m_ListofText.Count;// une valeur qui fait la longueur de la liste au départ, elle sera décrémentée par la suite 

        int testvalue = m_ListofText.Count - i; // une seconde valeur qui est égale à la longueur de la liste - la valeur décrémentée, elle sert de valeur d'index pour la liste 

        while (i>0) // tant que la valeur décrémentante est supérieur à 0, en gros tant qu'on a pas parcouru l'intégralité de la liste 
            {

            
            for (int j =0;j<m_LineLength;j++) //une boucle qui permet de lancer plusieurs fois l'action de poser un objet et donc de construire la grille, la valeur de j doit être égale au nombre de gameobject que l'on souhaite avoir de largeur
                 {
                if (i > 0)//si la valeur décrémentante est supérieure à 0, nécessaire puisque la vérification de la valeur de i ne se fait qu'en sortie de boucle et que la décrémentation de i se fait à l'intérieur de la boucle. 
                {
                    testvalue = m_ListofText.Count - i;//actualisation de la valeur d'index. Dans ce format-là, la liste est parcourue du [0] vers le [max] 
                
                    m_Script.m_ButtonName = m_ListofText[testvalue];//on change la valeur de définition du game object qui sera instancié durant cette boucle
                    if (j == 0)// dans le cas où j est égale à 0, c'est à dire si l'objet à instancier est le premier de la ligne
                    {
                        posx = 100f;//définir sa position en x par rapport à son parent
                    }

                    else // si ce n'est pas le premier objet de la ligne 
                    {
                        posx += (m_Rect.rect.width + 15f); // on définit sa position d'instanciation par rapport à celle de l'objet précédent et on lui accorde un léger écart
                    }
                    m_ButtonInstance = Instantiate(m_Prefab, new Vector3(posx, posy), transform.rotation) as GameObject;//on instancie le l'objet selon les positions précédemment définies
                    m_ButtonInstance.transform.SetParent(this.transform);//On définie comme parent de l'objet le truc entre parenthèse (ici l'endroit où est posé le script)
                    

                    i--;// on décrémente la valeur décrémentante 
                   
                }
            }
                posy += -50f;//on définit la position d'instanciation en y de l'objet, en sortie de boucle cela permet de ne changer l'instanciation en y que l'orsque la ligne précédente est terminée. 
            }
	}
	
	
}
