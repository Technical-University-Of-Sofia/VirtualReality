using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Windows.Speech; //contains the classes for speech input
using System.Linq;//contains classes that simplify working with lists, dictionaries, etc.

public class SpeechInput : MonoBehaviour
{
    [System.Serializable()]
    public class CommandHandler
    {
        public string phrase;
        public UnityEvent handler;
    }

    public List<CommandHandler> commands;
    private KeywordRecognizer recognizer;

    private void Awake()
    {
        recognizer = new KeywordRecognizer(commands.Select(x => x.phrase).ToArray());
        recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
    }

    private void OnEnable()
    {
        recognizer.Start();
    }

    private void OnDisable()
    {
        recognizer.Stop();
    }

    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        CommandHandler ch = commands.First(x => x.phrase == args.text);
        if (ch != null && ch.handler != null)
        {
            ch.handler.Invoke();
        }
    }

    public void ChangeHandler(string phrase, UnityAction newHandler)
    {
        UnityEvent ue = commands.First(x => x.phrase == phrase).handler;
        ue.RemoveAllListeners();
        ue.AddListener(newHandler);
    }
}

