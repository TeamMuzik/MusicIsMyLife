using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FactoryGame : MonoBehaviour
{
    private FactoryGameTimer FactoryGameTimerInstance;

    public GameObject[] keyBoardPrefabs; //키보드 이미지를 가진 오브젝트 리스트
    public KeyCode[] possibleKeys; //실제 입력할 키보드 리스트 (방향키, 스페이스바)
    public List<GameObject> spawnedKeyboards = new List<GameObject>();

    private GameObject doll;
    public GameObject[] DollPrefab;
    // public Sprite[] BearSprites;
    // public Sprite[] CatSprites;
    // public Sprite[] FoxSprites;
    // public Sprite[] DogSprites;
    public GameObject hand; // 손
    public Sprite[] handSprite; // 손 스프라이트들
    public static int currentHandIndex;

    [SerializeField]
    private TextMeshProUGUI stageNumText;
    [SerializeField]
    private TextMeshProUGUI moneyNumText;

    public AudioClip successSound;
    public AudioClip mistakeSound;
    public AudioClip dollMakingSound;
    private AudioSource audioSource;

    public static int factoryTurn; //지금 어떤 오브젝트를 입력할 차례인지 (0에서 시작)
    private static int stageNum = 0;
    public static int RandNum = 0;
    public int money = 0;

    private void Start()
    {
        stageNum = 0;
        money = 0;
        FactoryGameTimerInstance = FindObjectOfType<FactoryGameTimer>();
        audioSource = GetComponent<AudioSource>();
        // 손 스프라이트 인덱스
        currentHandIndex = 0;
    }

    public void SpawnKeyBoards()
    {
        foreach (GameObject keyboard in spawnedKeyboards)
        {
            Destroy(keyboard);
        }
        spawnedKeyboards.Clear();
        factoryTurn = 0;
        int index = 0;
        float yPos = 1.5f;
        RandNum = Random.Range(3, 7);
    
        switch (RandNum)
        {
            case 3:
                //인형 생성
                GameObject doll0Prefab = DollPrefab[0];
                Vector3 bearSpawn = new Vector3 (0.16f, 7.05f, 0);
                doll = Instantiate(doll0Prefab, bearSpawn, Quaternion.identity);
                // //키보드 생성
                // for (int i = 0; i < RandNum; i++)
                // {   
                //     float xPos = -1.5f + 1.5f*i;
                //     Vector3 spawnPosition = new Vector3 (xPos, yPos, 0);
                //     int randNum = Random.Range(0, possibleKeys.Length);
                //     GameObject selectedPrefab = keyBoardPrefabs[randNum];
                //     GameObject keyObject = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
                //     spawnedKeyboards.Add(keyObject);
                //     FactoryGameKeyboard keyScript = keyObject.GetComponent<FactoryGameKeyboard>(); //생성된 오브젝트의 키보드 스크립트 가져오기
                //     keyScript.SetKeySprite(possibleKeys[randNum], index++);
                // }
            break;

            case 4:
                GameObject doll1Prefab = DollPrefab[1];
                Vector3 catSpawn = new Vector3 (0.5f, 8f, 0);
                doll = Instantiate(doll1Prefab, catSpawn, Quaternion.identity);
                // for (int i = 0; i < RandNum; i++)
                // {
                //     float xPos = -2.25f + 1.5f*i;
                //     Vector3 spawnPosition = new Vector3 (xPos, yPos, 0);
                //     int randNum = Random.Range(0, possibleKeys.Length);
                //     GameObject selectedPrefab = keyBoardPrefabs[randNum];
                //     GameObject keyObject = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
                //     spawnedKeyboards.Add(keyObject);
                //     FactoryGameKeyboard keyScript = keyObject.GetComponent<FactoryGameKeyboard>(); //생성된 오브젝트의 키보드 스크립트 가져오기
                //     keyScript.SetKeySprite(possibleKeys[randNum], index++);
                // }
            break;

            case 5:
                GameObject doll2Prefab = DollPrefab[2];
                Vector3 foxSpawn = new Vector3 (0.35f, 7.8f, 0);
                doll = Instantiate(doll2Prefab, foxSpawn, Quaternion.identity);
                // for (int i = 0; i < RandNum; i++)
                // {
                //     float xPos = -3f + 1.5f*i;
                //     Vector3 spawnPosition = new Vector3 (xPos, yPos, 0);
                //     int randNum = Random.Range(0, possibleKeys.Length);
                //     GameObject selectedPrefab = keyBoardPrefabs[randNum];
                //     GameObject keyObject = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
                //     spawnedKeyboards.Add(keyObject);
                //     FactoryGameKeyboard keyScript = keyObject.GetComponent<FactoryGameKeyboard>(); //생성된 오브젝트의 키보드 스크립트 가져오기
                //     keyScript.SetKeySprite(possibleKeys[randNum], index++);
                // }
            break;

            case 6:
                GameObject doll3Prefab = DollPrefab[3];
                Vector3 dogSpawn = new Vector3 (0, 7, 0);
                doll = Instantiate(doll3Prefab, dogSpawn, Quaternion.identity);
                // for (int i = 0; i < RandNum; i++)
                // {
                //     float xPos = -3.75f + 1.5f*i;
                //     Vector3 spawnPosition = new Vector3 (xPos, yPos, 0);
                //     int randNum = Random.Range(0, possibleKeys.Length);
                //     GameObject selectedPrefab = keyBoardPrefabs[randNum];
                //     GameObject keyObject = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
                //     spawnedKeyboards.Add(keyObject);
                //     FactoryGameKeyboard keyScript = keyObject.GetComponent<FactoryGameKeyboard>(); //생성된 오브젝트의 키보드 스크립트 가져오기
                //     keyScript.SetKeySprite(possibleKeys[randNum], index++);
                // }
            break;
        }
    }
    public void increaseStageNum()
    {
        stageNum++;
    }

    public void moneyManager()
    {
        money += 1;
    }

    public void PlaySuccessSound()
    {
        audioSource.clip = successSound;
        audioSource.Play();
    }

    public void PlayMistakeSound()
    {
        audioSource.clip = mistakeSound;
        audioSource.Play();
    }
    public void PlayDollMakingSound()
    {
        audioSource.clip = dollMakingSound;
        audioSource.Play();
    }
    void Update()
    {
        hand.GetComponent<SpriteRenderer>().sprite = handSprite[currentHandIndex]; // 손 계속 업데이트
        if (FactoryGameTimer.totalTime < 0)
        {
            foreach (GameObject keyboard in spawnedKeyboards)
            {
                Destroy(keyboard);
            }
            spawnedKeyboards.Clear();
        }
        
        if (doll != null) 
        {
            // SpriteRenderer spriteRenderer = doll.GetComponent<SpriteRenderer>();
            // switch (RandNum)
            // {
            //     case 3:
            //         spriteRenderer.sprite = BearSprites[factoryTurn];
            //         break;
            //     case 4:
            //         spriteRenderer.sprite = CatSprites[factoryTurn];
            //         break;
            //     case 5:
            //         spriteRenderer.sprite = FoxSprites[factoryTurn];
            //         break;
            //     case 6:
            //         spriteRenderer.sprite = DogSprites[factoryTurn];
            //         break;
            // }
            if (FactoryGameTimer.totalTime > 0)
            {
                if (doll.transform.position.x > 9)
                {
                    Destroy(doll);
                    if (factoryTurn < RandNum)
                    {
                        StartCoroutine(FactoryGameTimerInstance.BlinkText(FactoryGameTimer.totalTime));
                        FactoryGameTimer.totalTime -= 4f;
                        foreach (GameObject keyboard in spawnedKeyboards)
                        {
                            Destroy(keyboard);
                        }
                        spawnedKeyboards.Clear();
                        PlayMistakeSound();
                        if (FactoryGameTimer.totalTime > 0)
                        {
                            SpawnKeyBoards();
                        }
                    }
                } 
            }
        }

        if (RandNum != 0 && factoryTurn == RandNum)
        {
            currentHandIndex = 3;
            moneyManager();
            increaseStageNum();
            SpawnKeyBoards();
            PlaySuccessSound();
        }

        moneyNumText.SetText(money.ToString() + "만원");
        stageNumText.SetText(stageNum.ToString() + "개");
    }


    public static void ChangeHandIndexInTurn()
    {
        currentHandIndex = factoryTurn % 2;
    }

    // 손 오브젝트의 스프라이트바꾸기

    /*public static IEnumerator HandSpriteWhenFinished()
    {
        hand.GetComponent<SpriteRenderer>().sprite = handSprite[0];
        yield return new WaitForSeconds(.25f);
    }*/

    // if (stageNum == 6)
    // {
    //     stageNum++;
    //     foreach (GameObject keyboard in spawnedKeyboards)
    //     {
    //         Destroy(keyboard);
    //     }
    //     spawnedKeyboards.Clear();
    //     StartPanel.SetActive(false);
    //     EndPanel.SetActive(true);
    //     moneyNumText.SetText(money.ToString()+"만원");
    //     StatusChanger.EarnMoney(money);
    //     //GameObject.FindWithTag("StatusChanger").GetComponent<StatusChanger>().earnMoney(money);
    // }

    // if (Timer.LimitTime < 0)
    // {
    //     StageNumPanel.SetActive(false);
    //     EndStagePanel.SetActive(true);
    //     stageNum = 1;
    //     Timer.LimitTime = 15f;

    //     foreach (GameObject keyboard in spawnedKeyboards)
    //     {
    //         Destroy(keyboard);
    //     }
    //     spawnedKeyboards.Clear();
    // }

    // if (turn == 9)
    // {
    //     turn = 0;
    //     increaseStageNum();
    //     SpawnKeyBoards();
    // }
}