using System;

interface IParent
{
    string Info();  
    void Metod();   
}


public class Child1 : IParent
{
    private string name;
    private double price;
    private string paperQuality; 

    public Child1(string name, string paperQuality)
    {
        this.name = name;
        this.paperQuality = paperQuality.ToLower();
    }

    public void Metod()
    {
        if (paperQuality == "high")
            price = 200;
        else
            price = 100;
    }

    public string Info()
    {
        return $"[Журнал] Назва: {name}, Якість паперу: {paperQuality}, Ціна: {price}";
    }
}


public class Child2 : IParent
{
    private string name;
    private double price;
    private string coverType; 
    private int pages;

    public Child2(string name, string coverType, int pages)
    {
        this.name = name;
        this.coverType = coverType.ToLower();
        this.pages = pages;
    }

    public void Metod()
    {
        price = pages * 0.2;
        if (coverType == "hard")
            price += 15;
        else
            price += 5;
    }

    public string Info()
    {
        return $"[Книга] Назва: {name}, Обкладинка: {coverType}, Сторінок: {pages}, Ціна: {price:F2}";
    }
}


public class Program
{
    public static void Main()
    {
        Random rnd = new Random();

        for (int i = 0; i < 5; i++)
        {
            IParent item;
            int type = rnd.Next(2); 

            if (type == 0)
            {
                
                string name = $"Журнал{i + 1}";
                string quality = rnd.Next(2) == 0 ? "high" : "low";
                item = new Child1(name, quality);
            }
            else
            {
                
                string name = $"Книга{i + 1}";
                string cover = rnd.Next(2) == 0 ? "hard" : "soft";
                int pages = rnd.Next(50, 301); 
                item = new Child2(name, cover, pages);
            }

            item.Metod();
            Console.WriteLine(item.Info());
            Console.WriteLine(new string('-', 50));
        }
    }
}

