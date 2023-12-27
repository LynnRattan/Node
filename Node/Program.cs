﻿namespace Node
{
    internal class Program
    {
        //פעולה המקבלת מצביע לחוליה 
        //מחזירה אמת אם החוליות מסודרות בסדר עולה
        //ושקר אחרת
        //אורך הקלט n: מספר החוליות
        //המקרה הגרוע: החוליות מסודרות בסדר עולה
        //הפעולה מתבצעת n פעמים
        //ובכל סיבוב הלולאה מתבצעות פעולות קבועות (שתיים) מכאן שסיבוכיות הפעולה: O(n) 


        public static bool IsAscending(Node<int> lst)
        {
            
            while (lst != null && lst.GetNext()!=null) 
            {
                if(lst.GetValue() > (lst.GetNext()).GetValue())
                    return false;
                lst = lst.GetNext();
            }
            return true;
        }

        //אורך הקלט n: מספר החוליות
        //המקרה הגרוע: החוליות מסודרות בסדר עולה
        //הפעולה מבצעת n  קריאות
        //ובכל קריאה הלולאה מתבצעות פעולות קבועות מכאן שסיבוכיות הפעולה: O(n)

        //כמו קודם רק מימוש רקורסיבי
        public static bool IsAscendingRecursive(Node<int> lst)
        {
           if(lst.GetNext() == null)
            {
                return true;
            }
                if (lst.GetValue() > (lst.GetNext()).GetValue())
                    return false;
                return IsAscendingRecursive(lst.GetNext());
        }

        //פעולה גנרית המחזירה אמת אם 
        //x 
        //קיים בשרשרת החוליות 
        //lst
        //ושקר אחחרת
        //שימו לב שבפעולה גנרית אין 
        //לא ניתן להשתמש ב
        //==
        //יש להתשמש בפעולה של
        //object
        //Equals

        //אורך הקלט n:
        //המקרה הגרוע:
        //הפעולה מתבצעת.... ובכל סיבוב הלולאה מתבצעות.... מכאן שסיבוכיות הפעולה: 
        public static bool IsExists<T>(Node<T> lst, T x)
        {
            throw new NotImplementedException("TO DO");
        }
        //אורך הקלט n:
        //המקרה הגרוע:
        //הפעולה מבצעת ....  קריאות ובכל קריאה הלולאה מתבצעות.... מכאן שסיבוכיות הפעולה: 

        public static bool IsExistsRecursive<T>(Node<T> lst, T x)
        {
            throw new NotImplementedException("TO DO");
        }


        static void Main(string[] args)
        {
            Node<int> lst1 = new Node<int>(4, new Node<int>(5, new Node<int>(6, new Node<int>(7))));//[4, next]=>[5, next]=>[6, next]=>[7, next]=>null

            Console.WriteLine(IsAscending(lst1));//should print True
            Console.WriteLine(IsAscendingRecursive(lst1));//should print True
            Node<int> lst2 = new Node<int>(4, new Node<int>(5, new Node<int>(6, new Node<int>(2))));//[4, next]=>[5, next]=>[6, next]=>[2, next]=>null
            Console.WriteLine(IsAscending(lst2));//should print False
            Console.WriteLine(IsAscendingRecursive(lst2));//should print False
            Node<int> lst3 = new Node<int>(4, new Node<int>(5, new Node<int>(4, new Node<int>(9))));//[4, next]=>[5, next]=>[4, next]=>[9, next]=>null
            Console.WriteLine(IsAscending(lst3));//should print False
            Console.WriteLine(IsAscendingRecursive(lst3));//should print False

            Node<char> lst4 = new Node<char>('t', new Node<char>('A', new Node<char>('l', new Node<char>('s', new Node<char>('i')))));//['t', next]=>['a', next]=>['l', next]=>['s', next]=>['i', next]=>null
            Console.WriteLine(IsExists(lst1, 5));//should print True
            Console.WriteLine(IsExists(lst4, 'i'));//should print True
            Console.WriteLine(IsExists(lst4, 'I'));//should print False
            Console.WriteLine(IsExistsRecursive(lst1, 5));//should print True
            Console.WriteLine(IsExistsRecursive(lst4, 'i'));//should print True
            Console.WriteLine(IsExistsRecursive(lst4, 'I'));//should print False


        }


    }


}
    