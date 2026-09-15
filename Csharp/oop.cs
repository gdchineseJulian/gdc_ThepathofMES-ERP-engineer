//建立Class，用關鍵字class
class Car
{
  //在**類別裡面**宣告的variable叫做field(attribute屬性)
  string color = "blue";
}


//物件是按照類別建立出來的實例，是類別的實例，有class就能create objects.
//用class的名字當成關鍵字，接著自己取一個物件名字，再加上new加class的名字
//一個class可以建多個物件，同class不同物件，屬性欄位一模一樣，但屬性的值各自獨立。
class Student
{
  string name = "Kun";
  static void Main(string[] args){
    Student s1 = new Student();
    Student s2 = new Student();
    Student s3 = new Student();
}


//Fields and methods inside classes are often referred to as "Class Members"
//屬性和方法在一起常常也叫做"類成員"
class cup
{
  string name;
  int price;

  public void fillwater()
  {
    Console.WriteLine("hi");
  }
}


//我們可以Access物件的fields，用關鍵字dot ".", 物件.屬性
//既然可以Access，那也就可以修改，可以在建立物件之後，去Access物件屬性更新屬性。
class Car
{
  string color = "red";
  int maxSpeed = 230;

  static void Main(string[] args)
  {
    Car myObj = new Car();
    Console.WriteLine(myObj.color);
    Console.WriteLine(myObj.maxSpeed);

    myObj.color = "green";
    //此時Console顯示"green"


    Car volvo = new Car();
    volvo.color = "black";
    volvo.maxSpeed = 500;
    
    Car ferrai = new Car();
    ferrai.color = "red";
    ferrai.maxSpeed = 1000;
  }
}


//在class裡面的Methods是用來定義物件的"行為"的，
//在 C# 中，如果方法前面都不寫（省略 public），則C#預設是 private（私有的）。代表這個方法只有在同一個類別（Class）內部才能被呼叫
//private就像機車裡面的引擎阿、火星塞阿...；public則是外面的發動按鈕

using System;

class Student
{
    string name = "Julian";
    int age = 20;

    // 1. 這是 PUBLIC 方法：外面的人可以叫學生講話
    public void speak(string sentence)
    {
        // 在真正講出來之前，先呼叫內部的私有方法來「過濾字串」
        string cleanSentence = FilterBadWords(sentence);
        
        Console.WriteLine($"{name} 說：{cleanSentence}");
    }

    // 2. 這是 PRIVATE 方法（加了 private，或什麼都不寫也是預設 private）
    // 作用：內部檢查字串。這個方法只有這整個 class 內部的程式（例如上面的 speak）可以呼叫。
    private string FilterBadWords(string text)
    {
        // 簡單的過濾邏輯：如果發現有 "笨蛋"，就變成 "**"
        if (text.Contains("笨蛋"))
        {
            return text.Replace("笨蛋", "**");
        }
        return text;
    }

    static void Main(string[] args)
    {
        Student julian = new Student();

        // ✅ 可以執行！因為 speak 是 public
        julian.speak("你這個大笨蛋！"); 
        
        // ❌ 如果你把下面這行的註解拿掉，程式會直接報錯（編譯失敗）！
        // 錯誤訊息會說：'Student.FilterBadWords(string)' 因其保護層級而無法存取
        // julian.FilterBadWords("測試"); 
    }
}

//建構子 Constructor 
//一特殊方法，唯一任務就是：在物件出生的那一刻，幫物件做初始化
//名字要跟class完全一樣，且沒有回傳類型；就算自己不寫，C#也會初始化一個 叫Default Constructor
//有建構子的話，就可以在建立物件時，將資料作為參數傳入進去物件? 而不用一個一個屬性去Access

class Drinkmenuitem
{
  public name 
  public sugar 

/*
問題：一種飲料可能會有多種糖，這該怎辦？難道是DrinkOne_半糖、DrinkOne_全糖..嗎?

不，這樣組合會很大。在這裡我是要建立"飲料品項的清單"，糖度是由杯子決定，而不是飲料本身決定...
對，沒錯！回想起現實生活，糖是另外加入的。因此應該是 奶茶(附註: 半糖、去冰)。

類別應該只要記錄這款飲料的本質屬性（例如：名稱、大杯價格、中杯價格、是否能做熱飲）。
至於「sugar 有很多種」，應該把它記錄成這款飲料「支援哪些糖度」。

*/


class DrinkMenuitem
{
    public string Name { get; set; }
    public int Price { get; set; }
    
    // 用一個清單（List），記錄這款飲料「可以做哪些甜度」
    // 比如：奶茶可以選 [全糖, 半糖, 微糖]，但有些特定的果汁只能選 [固定甜度]
    public List<string> AvailableSugarLevels { get; set; }

    public DrinkMenuitem(string name, int price, List<string> sugarLevels)
    {
        Name = name;
        Price = price;
        AvailableSugarLevels = sugarLevels;
    }


    static void Main(string[] args)
    {
        // 定義店裡基本的糖度清單
        List<string> standardSugar = new List<string> { "全糖", "半糖", "微糖", "無糖" };
        List<string> fixedSugar = new List<string> { "固定甜度" };
        
        // 建立菜單資料
        DrinkMenuitem item1 = new DrinkMenuitem("阿薩姆奶茶", 50, standardSugar);
        DrinkMenuitem item2 = new DrinkMenuitem("翡翠綠茶", 35, standardSugar);
        DrinkMenuitem item3 = new DrinkMenuitem("冬瓜檸檬", 45, fixedSugar); // 這款不能調甜度
    
       
    }
}

