using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class mouuvement : MonoBehaviour
{
    private Animator anim;
    private String monger;
    private String boire;
    private String donser;
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action > actions = new Dictionary<string, Action >();

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start()
    {

        actions.Add("a", a);
        actions.Add("b", jump);
        actions.Add("c", b);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    
    }
    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }
    private void jump()
    {
         anim.SetBool("donser", true);
        anim.SetBool("monger", false);
        anim.SetBool("boire", false);
        transform.Translate(1, 0, 0);    
    }

    private void a()
    {
        anim.SetBool("donser", false);
        anim.SetBool("monger", true);
        anim.SetBool("boire", false);
    }
    private void b()
    {
        anim.SetBool("donser", false);
        anim.SetBool("monger", false);
        anim.SetBool("boire", true);
    }











}

