using UnityEngine;
using System.Collections.Generic;

namespace Assignment
{
    public class Assignment : MonoBehaviour
    {
        public void Start()
        {
            // AS01_CountWords();
            // AS02_CountNumber();
            // AS03_CheckValidBrackets();
            // AS04_PrintReverseLinkedList();
            // AS05_FindMiddleElement();
            // AS06_MergeDictionaries();
            // AS07_RemoveDuplicatesFromLinkedList();
            // AS08_TopFrequentNumber();
            // AS09_PlayerInventory();
            // AS10_GameEventQueue();
             AS11_PlayerStatsTracker();
        }

        #region Assignment

        [Header("AS01 - Count Words")]
        [SerializeField] private string[] as01Words;

        public void AS01_CountWords()
        {
            string[] words = as01Words;
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                string inputword = words[i];

                if (wordCounts.ContainsKey(inputword))
                {
                    wordCounts[inputword]++;
                }
                else
                {
                    wordCounts.Add(inputword, 1);
                }
            }

            string[] word = new string[wordCounts.Count];
            int[] counts = new int[wordCounts.Count];

            wordCounts.Keys.CopyTo(word, 0);
            wordCounts.Values.CopyTo(counts, 0);

            for (int i = 0; i < word.Length; i++)
            {
                Debug.Log("word: '" + word[i] + "' count: " + counts[i]);
            }
        
            

        }

        [Header("AS02 - Count Number")]
        [SerializeField] private int[] as02Numbers;

        public void AS02_CountNumber()
        {
            int[] numbers = as02Numbers;
            Dictionary<int, int> numberCounts = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                int inputNumber = numbers[i];

                if (numberCounts.ContainsKey(inputNumber))
                {
                    numberCounts[inputNumber]++;
                }
                else
                {
                    numberCounts.Add(inputNumber, 1);
                }
            }

            int[] number = new int[numberCounts.Count];
            int[] counts = new int[numberCounts.Count];

            numberCounts.Keys.CopyTo(number, 0);
            numberCounts.Values.CopyTo(counts, 0);

            for (int i = 0; i < number.Length; i++)
            {
                Debug.Log("number: " + number[i] + " count: " + counts[i]);
            }
        
           
        }

        [Header("AS03 - Check Valid Brackets")]
        [SerializeField] private string as03Input;

        public void AS03_CheckValidBrackets()
        {
            string input = as03Input;
            // 1. Dictionary จับคู่ วงเล็บเปิด -> วงเล็บปิด
            Dictionary<char, char> brackets =
             new Dictionary<char, char>()
             {
                { '(', ')' },
                { '[', ']' },
                { '{', '}' }
             };

            LinkedList<char> stack = new LinkedList<char>();

            bool isValid = true;

            for (int i = 0; i < input.Length; i++)
            {
                char current = input[i];

                if (brackets.ContainsKey(current))
                {
                    stack.AddLast(current);
                }
                else if (brackets.ContainsValue(current))
                {
                    if (stack.Count == 0)
                    {
                        isValid = false;
                        break;
                    }

                    char lastOpen = stack.Last.Value;

                    if (brackets[lastOpen] != current)
                    {
                        isValid = false;
                        break;
                    }

                    stack.RemoveLast();
                }
            }

            if (stack.Count > 0)
            {
                isValid = false;
            }

            if (isValid)
            {
                Debug.Log("Valid");
            }
            else
            {
                Debug.Log("Invalid");
            }
        
            
        }

        [Header("AS04 - Print Reverse Linked List")]
        [SerializeField] private IntLinkedListInput as04List = new IntLinkedListInput();

        public void AS04_PrintReverseLinkedList()
        {
            LinkedList<int> list = as04List.GetLinkedList();
            // ตรวจสอบว่าลิสต์ว่างหรือไม่
            if (list.Count == 0)
            {
                Debug.Log("List is empty");
                return;
            }

            // เริ่มจากโหนดสุดท้าย
            LinkedListNode<int> current = list.Last;

            // เดินย้อนกลับด้วย Previous
            while (current != null)
            {
                Debug.Log(current.Value);

                current = current.Previous;
            }
        
            
        }

        [Header("AS05 - Find Middle Element")]
        [SerializeField] private StringLinkedListInput as05List = new StringLinkedListInput();

        public void AS05_FindMiddleElement()
        {
            LinkedList<string> list = as05List.GetLinkedList();
            // ตรวจสอบว่าลิสต์ว่างหรือไม่
            if (list.Count == 0)
            {
                Debug.Log("List is empty");
                return;
            }

            // slow และ fast เริ่มที่โหนดแรก
            LinkedListNode<string> slow = list.First;
            LinkedListNode<string> fast = list.First;

            // fast เดิน 2 โหนด ส่วน slow เดิน 1 โหนด
            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            // แสดงค่าตรงกลาง
            Debug.Log(slow.Value);
        
            
        }

        [Header("AS06 - Merge Dictionaries")]
        [SerializeField] private StringIntDictionaryInput as06FirstDictionary = new StringIntDictionaryInput();
        [SerializeField] private StringIntDictionaryInput as06SecondDictionary = new StringIntDictionaryInput();

        public void AS06_MergeDictionaries()
        {
            Dictionary<string, int> dict1 = as06FirstDictionary.GetDictionary();
            Dictionary<string, int> dict2 = as06SecondDictionary.GetDictionary();

            // 1. สร้าง Dictionary ใหม่จาก dict1
            Dictionary<string, int> mergedDictionary =
                new Dictionary<string, int>(dict1);

            // 2. วนอ่านข้อมูลจาก dict2
            foreach (KeyValuePair<string, int> entry in dict2)
            {
                // 3. ตรวจสอบว่ามี key อยู่แล้วหรือไม่
                if (mergedDictionary.ContainsKey(entry.Key))
                {
                    // 4. ถ้ามี ให้บวกค่า
                    mergedDictionary[entry.Key] += entry.Value;
                }
                else
                {
                    // 5. ถ้ายังไม่มี ให้เพิ่ม key ใหม่
                    mergedDictionary.Add(entry.Key, entry.Value);
                }
            }

            // 6. แสดงผล
            foreach (KeyValuePair<string, int> entry in mergedDictionary)
            {
                Debug.Log("key: " + entry.Key + ", value: " + entry.Value);
            }
        
            
        }

        [Header("AS07 - Remove Duplicates From Linked List")]
        [SerializeField] private IntLinkedListInput as07List = new IntLinkedListInput();

        public void AS07_RemoveDuplicatesFromLinkedList()
        {
            LinkedList<int> list = as07List.GetLinkedList();
            // 1. ถ้ามีสมาชิกไม่เกิน 1 ตัว แสดงผลตามปกติ
            if (list.Count <= 1)
            {
                foreach (int value in list)
                {
                    Debug.Log(value);
                }

                return;
            }

            // 2. Dictionary เก็บค่าที่เคยพบ
            Dictionary<int, bool> seen = new Dictionary<int, bool>();

            // 3. เริ่มจากโหนดแรก
            LinkedListNode<int> current = list.First;

            while (current != null)
            {
                // 4. เก็บโหนดถัดไปก่อน เพราะ current อาจถูกลบ
                LinkedListNode<int> next = current.Next;

                // 5. ตรวจสอบว่าค่านี้เคยพบหรือยัง
                if (seen.ContainsKey(current.Value))
                {
                    // ถ้าเคยพบแล้ว ลบโหนดนี้
                    list.Remove(current);
                }
                else
                {
                    // ถ้ายังไม่เคยพบ ให้บันทึกไว้
                    seen.Add(current.Value, true);
                }

                // 6. ไปยังโหนดถัดไป
                current = next;
            }

            // แสดงผล LinkedList หลังลบข้อมูลซ้ำ
            foreach (int value in list)
            {
                Debug.Log(value);
            }
        
            
        }

        [Header("AS08 - Top Frequent Number")]
        [SerializeField] private int[] as08Numbers;

        public void AS08_TopFrequentNumber()
        {
            int[] numbers = as08Numbers;
            // 1. ตรวจสอบว่า Array ว่างหรือไม่
            if (numbers == null || numbers.Length == 0)
            {
                Debug.Log("Input array is empty");
                return;
            }

            // 2. สร้าง Dictionary สำหรับนับความถี่
            Dictionary<int, int> numberCounts =
                new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                int number = numbers[i];

                if (numberCounts.ContainsKey(number))
                {
                    numberCounts[number]++;
                }
                else
                {
                    numberCounts.Add(number, 1);
                }
            }

            // 3. เริ่มคำตอบจากตัวเลขตัวแรก
            int topNumber = numbers[0];
            int maxCount = numberCounts[topNumber];

            // 4. วนดูตัวเลขตามลำดับเดิม
            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];
                int currentCount = numberCounts[currentNumber];

                // 5. อัปเดตเฉพาะเมื่อมากกว่า
                if (currentCount > maxCount)
                {
                    topNumber = currentNumber;
                    maxCount = currentCount;
                }
            }

            // 6. แสดงผล
            Debug.Log(topNumber + " count: " + maxCount);
        
            
        }

        [Header("AS09 - Player Inventory")]
        [SerializeField] private StringIntDictionaryInput as09Inventory = new StringIntDictionaryInput();
        [SerializeField] private string as09ItemName;
        [SerializeField] private int as09Quantity;

        public void AS09_PlayerInventory()
        {
            Dictionary<string, int> inventory = as09Inventory.GetDictionary();
            string itemName = as09ItemName;
            int quantity = as09Quantity;
            if (inventory.ContainsKey(itemName))
            {
                inventory[itemName] += quantity;
            }
            else
            {
                inventory.Add(itemName, quantity);
            }

            foreach (KeyValuePair<string, int> item in inventory)
            {
                Debug.Log(item.Key + ": " + item.Value);
            }
        
        }

        [Header("AS10 - Game Event Queue")]
        [SerializeField] private GameEventLinkedListInput as10EventQueue = new GameEventLinkedListInput();

        public void AS10_GameEventQueue()
        {
            LinkedList<GameEvent> eventQueue = as10EventQueue.GetLinkedList();
            if (eventQueue.Count == 0)
            {
                Debug.Log("Event queue is empty");
                return;
            }

            while (eventQueue.Count > 0)
            {
                GameEvent currentEvent = eventQueue.First.Value;

                eventQueue.RemoveFirst();

                Debug.Log("Processing event: " + currentEvent.Name);

                Debug.Log("Remaining events in queue: " + eventQueue.Count);

                if (currentEvent.EventType == "enemy")
                {
                    Debug.Log("Enemy event processed - " + currentEvent.Name);
                }
                else if (currentEvent.EventType == "powerup")
                {
                    Debug.Log("Power-up event processed - " + currentEvent.Name);
                }
                else if (currentEvent.EventType == "level")
                {
                    Debug.Log("Level event processed - " + currentEvent.Name);
                }
            }

        }

        [Header("AS11 - Player Stats Tracker")]
        [SerializeField] private StringIntDictionaryInput as11PlayerStats = new StringIntDictionaryInput();
        [SerializeField] private string as11StatName;
        [SerializeField] private int as11Value;

        public void AS11_PlayerStatsTracker()
        {
            Dictionary<string, int> playerStats = as11PlayerStats.GetDictionary();
            string statName = as11StatName;
            int value = as11Value;
            if (playerStats.ContainsKey(statName))
            {
                playerStats[statName] += value;
            }
            else
            {
                playerStats.Add(statName, value);
            }

            Debug.Log("Updated " + statName + ": " + playerStats[statName]);

            Debug.Log("Current player statistics:");

            foreach (KeyValuePair<string, int> stat in playerStats)
            {
                Debug.Log(stat.Key + ": " + stat.Value);
            }
        }

        #endregion
    }
}
