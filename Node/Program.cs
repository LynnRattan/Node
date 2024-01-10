using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;

namespace Node
{
    internal class Program
    {
        //תרגיל 8
        //פעולה המקבלת מצביע לחוליה 
        //מחזירה אמת אם החוליות מסודרות בסדר עולה
        //ושקר אחרת
        //אורך הקלט n: כמות החוליות
        //המקרה הגרוע: החוליות מסודרות בסדר עולה
        //הפעולה מתבצעת n-1 פעמים
        //ובכל סיבוב הלולאה מתבצעות פעולות קבועות מכאן שסיבוכיות הפעולה: O(n) 


        public static bool IsAscending(Node<int> lst)
        {

            while (lst != null && lst.GetNext() != null)
            {
                if (lst.GetValue() >= (lst.GetNext()).GetValue())
                    return false;
                lst = lst.GetNext();
            }
            return true;
        }

        //אורך הקלט n: כמות החוליות
        //המקרה הגרוע: החוליות מסודרות בסדר עולה
        //הפעולה מבצעת n-1  קריאות
        //ובכל קריאה הלולאה מתבצעות פעולות קבועות מכאן שסיבוכיות הפעולה: O(n)

        //כמו קודם רק מימוש רקורסיבי
        public static bool IsAscendingRecursive(Node<int> lst)
        {
            if (lst.GetNext() == null)
            {
                return true;
            }
            if (lst.GetValue() >= (lst.GetNext()).GetValue())
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

        //אורך הקלט n: כמות החוליות
        //המקרה הגרוע:x לא קיים בשרשרת החוליות
        // הפעולה מתבצעת n פעמים
        //ובכל סיבוב הלולאה מתבצעות פעולות קבועות מכאן שסיבוכיות הפעולה:O(n) 
        public static bool IsExists<T>(Node<T> lst, T x)
        {
            while (lst != null)
            {
                if ((lst.GetValue()).Equals(x))
                    return true;
                lst = lst.GetNext();
            }
            return false;
        }
        //אורך הקלט n:כמות החוליות
        //המקרה הגרוע:x לא קיים בשרשרת החוליות
        //הפעולה מבצעת n  קריאות
        //ובכל קריאה הלולאה מתבצעות פעולות קבועות מכאן שסיבוכיות הפעולה:O(n)

        public static bool IsExistsRecursive<T>(Node<T> lst, T x)
        {
            if (lst == null)
                return false;
            if ((lst.GetValue()).Equals(x))
                return true;
            return IsExistsRecursive(lst.GetNext(), x);

        }

        public static void AddToEnd<T>(Node<T> newNode, Node<T> lst)
        {
            while (lst.HasNext())
            {
                lst = lst.GetNext();
            }

            lst.SetNext(newNode);

        }

        public void AddToMidEnd(Node<int> newNode, Node<int> lst)
        {
            while (lst.HasNext() && newNode.GetValue() > (lst.GetNext()).GetValue())
            {
                lst = lst.GetNext();
            }
            newNode.SetNext(lst.GetNext());
            lst.SetNext(newNode);

        }

        //public static Node<int> Create(int from, int to, int quantity)
        //{
        //    List<Node<int>> list = new List<Node<int>>();
        //    Random rnd = new Random();
        //    for (int i = 0; i < quantity - 1; i++)
        //    {
        //        list[i].SetValue(rnd.Next(from, to + 1));
        //        list[i].SetNext(list[i + 1]);
        //    }
        //    return list[0];
        //}


        public static Node<T> DeleteValue<T>(Node<T> lst, T value)
        {

            Node<T> head = lst; //שומר על הראש
            if (head.Equals(value))
            {
                head=lst.GetNext();
                lst.SetNext(null);
                
            }


            Node<T> next = lst.GetNext();

             while(lst.HasNext()&& next.GetValue().Equals(value)) 
                {

                lst = next;
                next = lst.GetNext();

                }

            lst.SetNext(next.GetNext());
            next.SetNext(null);
            return head;
        }

        //תרגיל 2
        //אורך הקלט n:כמות החוליות
        //סיבוכיות:O(n)
        public static int HowMany(Node<int> lst,int num)
        {
            Node<int> head = lst;
            int counter = 0;
            int valueBefore = lst.GetValue();
            int value = 0;
            if (valueBefore == num)
            {
                counter++;
            }
            while (lst.HasNext())
            {
                lst = lst.GetNext();
                value = lst.GetValue();
                if(value == num && valueBefore != value)
                    counter++;
                valueBefore = value;
            }
            return counter;
        }

        //תרגיל 4
        //אורך הקלט n:כמות החוליות
        //סיבוכיות:O(n)
        public static char MoreEvenOrOdd(Node<int> lst)
        {
            int z = 0;
            int e = 0;
            if ((lst.GetValue()) % 2 == 0)
                z++;
            else
                e++;
            while (lst!=null && lst.HasNext())
            {
                lst = lst.GetNext();
                if ((lst.GetValue()) % 2 == 0)
                    z++;
                else
                    e++;
            }
            if (z > e)
                return 'z';
      
            else if (e > z)
                return 'e';
            
            return 's';
                
        }

        //תרגיל 6
        //אורך הקלט n: כמות החוליות
        //סיבוכיות:O(n)
        public static Node<int> OnlyOnce(Node <int> lst)
        {
            Node<int> head = lst;
            while(lst.HasNext() && lst.GetNext().GetValue()==lst.GetValue())
            {
                    lst.SetNext(lst.GetNext().GetNext());
                    lst.GetNext().SetNext(null);
                    lst=lst.GetNext();
            }
                
            return head;
        }

        //תרגיל 10
        //אורך הקלט n: num
        //סיבוכיות:O(n)
        public static Node<int> Sidra(int begginer, int num)
        {
            Node<int> lst = new Node<int>(begginer);
            Node<int> head = lst;
            for(int i = 0; i < num-1; i++)
            {
                begginer++;
                Node<int> next = new Node<int>(begginer);
                lst.SetNext(next);
                lst = next;
            }
            return head;
        }

        //תרגיל 12
        //אורך הקלט n: כמות החוליות
        //סיבוכיות:O(n)
        public static bool Balanced(Node<int> lst)
        {
            Node<int> head = lst;
            int counter = 0;
            int sum = 0;
            double avg;
            int bigger = 0;
            int smaller = 0;
            while (lst.HasNext())
            {
                sum += lst.GetValue();
                counter++;
                lst= lst.GetNext();
            }
            lst = head;
            avg = (double)(sum / counter);

            for (int i = 0; i < counter; i++)
            {
                if(lst.GetValue()<avg)
                    smaller++;
                if(lst.GetValue()>avg)
                    bigger++;
            }
            if(smaller == bigger)
            return true;
            else return false;
        }

        public static Node<int> GetMax(Node<int> lst) //פעולה המחזירה את החוליה בעלת הערך הגדול ביותר (אם יש כמה אז מחזירה את הראשונה)
        {
            Node<int> head = lst;
            int max = lst.GetValue();
            Node<int> maxNode= lst;
            while (lst != null && lst.HasNext())
            {
                if (lst.GetValue() > max)
                {
                    max = lst.GetValue();
                    maxNode = lst;
                }
                lst = lst.GetNext();
            }
            return maxNode;
            
        }
        //תרגיל 14
        //אורך הקלט n: 
        //סיבוכיות:O(n^2)
        public static Node<int> RemoveNBig(Node<int> lst, int n)
        {
          Node<int> head = lst;
          Node<int> next = lst.GetNext();
          Node<int> maxNode;
            int max=0;
            for(int i=0; i<n; i++)
            {
                maxNode = GetMax(lst);
                if(lst.Equals(maxNode))
                {
                    lst = next;
                    lst.SetNext(null);
                    head=lst;
                }
                else
                {
                    while(!(next.Equals(maxNode)))
                          {
                              lst=next;
                          }
                    lst.SetNext(next.GetNext());
                    next.SetNext(null);
                }       
            }
              return head;
        }

        public static int BiggerBigNum(Node<int> lis1, Node<int> lis2)
        { 
            Node<int> head1 = lis1;
            Node<int> head2 = lis2;
            int bigger = 0;

            if (lis1.Equals(lis2))
                return 0;

            while(lis1!=null)
            {
                if(lis2!=null)
                {
                   
                    if (lis1.GetValue() > lis2.GetValue())
                        bigger= 1;
                    if(lis1.GetValue() < lis2.GetValue())
                       bigger= 2;
                    lis1 = lis1.GetNext();
                    lis2 = lis2.GetNext();
                }
                else bigger=1; 
            }

            lis1 = head1;
            lis2 = head2;

            while (lis2 != null)
            {
                if (lis1 != null)
                {
                    if (lis1.GetValue() > lis2.GetValue())
                        bigger = 1;
                    if (lis1.GetValue() < lis2.GetValue())
                        bigger= 2;
                    lis2 = lis2.GetNext();
                    lis1=lis1.GetNext();
                }
                else bigger = 2;
            }

            
            return bigger;
        }

        public static Node<T> Delete<T>(Node<T> lst, Node<T> lst2)
        {

            Node<T> head = lst; //שומר על הראש
            if (head.Equals(lst2))
            {
                head = lst.GetNext();
                lst.SetNext(null);

            }


            Node<T> next = lst.GetNext();

            while (lst.HasNext() && !next.Equals(lst2))
            {

                lst = next;
                next = lst.GetNext();

            }

            lst.SetNext(next.GetNext());
            next.SetNext(null);
            return head;
           
        }

        public static Node<T> CancelLis2<T>(Node<T> lis1, Node<T> lis2)
        {
            Node<T> head1 = lis1;
            Node<T> head2 = lis2;
            //int counter2=0;

            //while(lis2!=null)
            //{
            //    counter2++;
            //    lis2 = lis2.GetNext();
            //}

            //lis2 = head2;

            while(lis1!=null)
            {
               
                   if(lis1.Equals(lis2))
                {
                    head1=Delete(head1, lis1);
                    lis2 = lis2.GetNext();
                }

                lis1 = lis1.GetNext();

            }

            return head1;
        }

        static void Main(string[] args)
        {
            Node<int> lst1 = new Node<int>(4, new Node<int>(5, new Node<int>(6, new Node<int>(2))));//[4, next]=>[5, next]=>[6, next]=>[7, next]=>null

            //Console.WriteLine(IsAscending(lst1));//should print True
            //Console.WriteLine(IsAscendingRecursive(lst1));//should print True
            Node<int> lst2 = new Node<int>(4, new Node<int>(5, new Node<int>(6, new Node<int>(7))));//[4, next]=>[5, next]=>[6, next]=>[2, next]=>null
            //Console.WriteLine(IsAscending(lst2));//should print False
            //Console.WriteLine(IsAscendingRecursive(lst2));//should print False
            //Node<int> lst3 = new Node<int>(4, new Node<int>(5, new Node<int>(4, new Node<int>(9))));//[4, next]=>[5, next]=>[4, next]=>[9, next]=>null
            //Console.WriteLine(IsAscending(lst3));//should print False
            //Console.WriteLine(IsAscendingRecursive(lst3));//should print False

            //Node<char> lst4 = new Node<char>('t', new Node<char>('A', new Node<char>('l', new Node<char>('s', new Node<char>('i')))));//['t', next]=>['a', next]=>['l', next]=>['s', next]=>['i', next]=>null
            //Console.WriteLine(IsExists(lst1, 5));//should print True
            //Console.WriteLine(IsExists(lst4, 'i'));//should print True
            //Console.WriteLine(IsExists(lst4, 'I'));//should print False
            //Console.WriteLine(IsExistsRecursive(lst1, 5));//should print True
            //Console.WriteLine(IsExistsRecursive(lst4, 'i'));//should print True
            //Console.WriteLine(IsExistsRecursive(lst4, 'I'));//should print False

            //Console.WriteLine(Sidra(5,4));

            Console.WriteLine(BiggerBigNum(lst1, lst2));
            Console.WriteLine(CancelLis2(lst1, lst2));
        }
    


    }


}
    
