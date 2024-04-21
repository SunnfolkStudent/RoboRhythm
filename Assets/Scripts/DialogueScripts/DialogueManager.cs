using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    [Header("Params")] 
        [SerializeField] private float typingSpeed = 0.04f;
        
        [Header("Load Globals JSON")]
        [SerializeField] private TextAsset loadGlobalsJSON;
        
        [Header("Choices UI")]
        [SerializeField] private GameObject[] choices;
        private TextMeshProUGUI[] choicesText;
    
        [Header("Audio")] 
        [SerializeField] private DialogueAudioInfoSO defaultAudioInfo;
        [SerializeField] private DialogueAudioInfoSO[] audioInfos;
        [SerializeField] private bool makePredictable;
        private DialogueAudioInfoSO currentAudioInfo;
        private Dictionary<string, DialogueAudioInfoSO> audioInfoDictionary;
        private AudioSource _audioSource;
        
        [Header("Dialogue UI")]
        [SerializeField] private GameObject dialoguePanel;
        [SerializeField] private Animator dialoguePanelAnimator;
        [SerializeField] private GameObject continueIcon;
        [SerializeField] private TextMeshProUGUI dialogueText;
        [SerializeField] private TextMeshProUGUI displayNameText;
        [SerializeField] private Animator portraitAnimator;
        private Animator layoutAnimator;
        
        public bool dialogueIsPlaying { get; private set; }
        
        private static DialogueManager instance;
    
        private Story currentStory;
    
        private bool canContinueToNextLine = false;
    
        private Coroutine displayLineCoroutine;
    
        private const string SPEAKER_TAG = "speaker";
        private const string PORTRAIT_TAG = "portrait";
        private const string LAYOUT_TAG = "layout";
        private const string AUDIO_TAG = "audio";
        private const string KEY_TAG = "key";

        private string keyGot;
    
        private DialogueVariables _dialogueVariables;
        
        private void Awake()
        {
            if (instance != null)
            {
                Debug.Log("Found more than one Dialogue Manager in scene");
            }
            instance = this;
    
            //_dialogueVariables = new DialogueVariables(loadGlobalsJSON);
    
            _audioSource = GetComponent<AudioSource>();
            currentAudioInfo = defaultAudioInfo;
        }
    
        public static DialogueManager GetInstance()
        {
            return instance;
        }
    
        private void Start()
        {
            dialogueIsPlaying = false;
            dialoguePanel.SetActive(false);
            //dialoguePanelAnimator.Play("Exit");
    
            //layoutAnimator = dialoguePanel.GetComponent<Animator>();
    
            choicesText = new TextMeshProUGUI[choices.Length];
            int index = 0;
            foreach (GameObject choice in choices)
            {
                choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
                index++;
            }
            InitializeAudioInfoDictionary();
        }
    
        private void InitializeAudioInfoDictionary()
        {
            audioInfoDictionary = new Dictionary<string, DialogueAudioInfoSO>();
            audioInfoDictionary.Add(defaultAudioInfo.id, defaultAudioInfo);
            foreach (DialogueAudioInfoSO audioInfo in audioInfos)
            {
                audioInfoDictionary.Add(audioInfo.id, audioInfo);
            }
        }
    
        private void SetCurrentAudioInfo(string id)
        {
            DialogueAudioInfoSO audioInfo = null;
            audioInfoDictionary.TryGetValue(id, out audioInfo);
            if (audioInfo != null)
            {
                this.currentAudioInfo = audioInfo;
            }
            else
            {
                Debug.LogWarning("Failed to find audio info for id" + id);
            }
        }
    
        private void Update()
        {
            if (!dialogueIsPlaying)
            {
                return;
            }
    
            if (currentStory.currentChoices.Count == 0 && canContinueToNextLine && Input.GetKeyDown(KeyCode.E))
            {
                ContinueStory();
            }
        }

        public void EnterDialogueMode(TextAsset inkJSON)
        {
            StartCoroutine(EnterDialogue(inkJSON));
        }
    
        private IEnumerator EnterDialogue(TextAsset inkJSON)
        {
            //PlayerInputScript.GetInstance().RegisterSubmitPressed();
            //PlayerInputScript.GetInstance().RegisterInteractPressed();
            
            currentStory = new Story(inkJSON.text);
            dialogueIsPlaying = true;
            dialoguePanel.SetActive(true);
            dialoguePanelAnimator.Play("Enter");
    
            //_dialogueVariables.StartListening(currentStory);
    
            //displayNameText.text = "???";
            //portraitAnimator.Play("Default");
            //layoutAnimator.Play("left");
            
            yield return new WaitForSeconds(1);
    
            ContinueStory();
        }
    
        private IEnumerator ExitDialogueMode()
        {
            yield return new WaitForSeconds(0.2f);
            
            //_dialogueVariables.StopListening(currentStory);
            //PlayerInputScript.GetInstance().RegisterInteractPressed();
            
            dialogueIsPlaying = false;
            dialoguePanelAnimator.Play("Exit");
            dialogueText.text = "";
            
            SetCurrentAudioInfo(defaultAudioInfo.id);
            
            yield return new WaitForSeconds(1);
            
            dialoguePanel.SetActive(false);
        }
    
        private void ContinueStory()
        {
            if (currentStory.canContinue)
            {
                if (displayLineCoroutine != null)
                {
                    StopCoroutine(displayLineCoroutine);
                }
                string nextLine = currentStory.Continue();
                HandleTags(currentStory.currentTags);
                displayLineCoroutine = StartCoroutine(DisplayLine(nextLine));
            }
            else
            {
                StartCoroutine(ExitDialogueMode());
            }
        }
    
        private IEnumerator DisplayLine(string line)
        {
            dialogueText.text = line;
            dialogueText.maxVisibleCharacters = 0;
    
            HideChoices();
            continueIcon.SetActive(false);
            canContinueToNextLine = false;
    
            bool isAddingRichTextTag = false;
            
            foreach (char letter in line.ToCharArray())
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    dialogueText.maxVisibleCharacters = line.Length;
                    break;
                }
    
                if (letter == '<' || isAddingRichTextTag)
                {
                    isAddingRichTextTag = true;
                    if (letter == '>')
                    {
                        isAddingRichTextTag = false;
                    }
                }
                else
                {
                    PlayDialogueSound(dialogueText.maxVisibleCharacters, dialogueText.text[dialogueText.maxVisibleCharacters]);
                    dialogueText.maxVisibleCharacters++;
                    yield return new WaitForSeconds(typingSpeed);
                }
            }
    
            DisplayChoices();
            continueIcon.SetActive(true);
            canContinueToNextLine = true;
        }
    
        private void PlayDialogueSound(int currentDisplayedCharacterCount, char currentCharacter)
        {
            AudioClip[] dialogueTypingSoundClips = currentAudioInfo.dialogueTypingSoundClips;
            int frequencyLevel = currentAudioInfo.frequencyLevel;
            float minPitch = currentAudioInfo.minPitch;
            float maxPitch = currentAudioInfo.maxPitch;
            bool stopAudioSource = currentAudioInfo.stopAudioSource;
            
            if (currentDisplayedCharacterCount % frequencyLevel == 0)
            {
                if (stopAudioSource)
                {
                    _audioSource.Stop();
                }
    
                AudioClip soundClip = null;
                if (makePredictable)
                {
                    int hashCode = currentCharacter.GetHashCode();
                    int predictableIndex = hashCode % dialogueTypingSoundClips.Length;
                    soundClip = dialogueTypingSoundClips[predictableIndex];
    
                    int minPitchInt = (int)(minPitch * 100);
                    int maxPitchInt = (int)(maxPitch * 100);
                    int pitchRangeInt = maxPitchInt - minPitchInt;
                    if (pitchRangeInt != 0)
                    {
                        int predictablePitchInt = (hashCode % pitchRangeInt) + minPitchInt;
                        float predictablePitch = predictablePitchInt / 100f;
                        _audioSource.pitch = predictablePitch;
                    }
                    else
                    {
                        _audioSource.pitch = minPitch;
                    }
                }
                else
                {
                    int randomIndex = Random.Range(0, dialogueTypingSoundClips.Length);
                    soundClip = dialogueTypingSoundClips[randomIndex];
                    _audioSource.pitch = Random.Range(minPitch, maxPitch);
                }
                _audioSource.PlayOneShot(soundClip);
            }
        }
    
        private void HideChoices()
        {
            foreach (GameObject choiceButton in choices)
            {
                choiceButton.SetActive(false);
            }
        }
    
        private void HandleTags(List<string> currentTags)
        {
            foreach (string tag in currentTags)
            {
                string[] splitTag = tag.Split(':');
                if (splitTag.Length != 2)
                {
                    Debug.LogError("Tag could not be appropriatley parsed: " + tag);
                }
    
                string tagKey = splitTag[0].Trim();
                string tagValue = splitTag[1].Trim();
    
                switch (tagKey)
                {
                    case SPEAKER_TAG:
                        displayNameText.text = tagValue;
                        break;
                    case PORTRAIT_TAG:
                        portraitAnimator.Play(tagValue);
                        break;
                    case LAYOUT_TAG:
                        layoutAnimator.Play(tagValue);
                        break;
                    case AUDIO_TAG:
                        SetCurrentAudioInfo(tagValue);
                        break;
                    case KEY_TAG:
                        Debug.Log("Key Obtained: " + tagValue);
                        keyGot = tagValue;
                        TaskManager.GetInstance().KeyObtained(tagValue);
                        break;
                    default:
                        Debug.LogWarning("Tag came in but is not currently being handled: " + tag);
                        break;
                }
            }
        }
    
        private void DisplayChoices()
        {
            List<Choice> currentChoices = currentStory.currentChoices;
    
            if (currentChoices.Count > choices.Length)
            {
                Debug.LogError("More choices were given than the UI can support. Number of choices given: " 
                               + currentChoices);
            }
    
            int index = 0;
    
            foreach (Choice choice in currentChoices)
            {
                choices[index].gameObject.SetActive(true);
                choicesText[index].text = choice.text;
                index++;
            }
    
            for (int i = index; i < choices.Length; i++)
            {
                choices[i].gameObject.SetActive(false);
            }
            
            EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
        }
    
        public void MakeChoice(int choiceIndex)
        {
            if(canContinueToNextLine)
            {
                currentStory.ChooseChoiceIndex(choiceIndex);
                //PlayerInputScript.GetInstance().RegisterSubmitPressed();
                ContinueStory();
            }
        }
    
        public Ink.Runtime.Object GetVariableState(string variableName)
        {
            Ink.Runtime.Object variableValue = null;
            _dialogueVariables.variables.TryGetValue(variableName, out variableValue);
            if (variableValue == null)
            {
                Debug.LogWarning("Ink Variable was found to be null: " + variableName);
            }
    
            return variableValue;
        }
    
        public void OnApplicationQuit()
        {
            if(_dialogueVariables != null)
            {
                _dialogueVariables.SaveVariable();
            }
        }
}