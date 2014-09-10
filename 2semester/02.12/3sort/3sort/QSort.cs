using System;

using NElemntType;

namespace NSort
{
    // quick sort
    class QSort
    {
        // quick sort массива mas с begin элемента до end.
        public static void Qsort(ElementType[] mas, int begin, int end)
        {
            int general = 0;
            int i = 0;
            for (i = 0; i < end - begin && mas[begin + i].Value() == mas[begin].Value(); i++) ;

            if (mas[begin].Value() == mas[begin + i].Value())
                return;
            else if (mas[begin].Value() < mas[begin + i].Value())
                general = mas[begin + i].Value();
            else
                general = mas[begin].Value();

            int left = begin;
            int right = end;

            while (left < right)
            {
                while (mas[left].Value() < general)
                    left++;
                while (mas[right].Value() > general || mas[right].Value() == general)
                    right--;
                if (left >= right)
                    break;
                ElementType.Swap(ref mas[left], ref mas[right]);

                left++;
                right--;
            }
            Qsort(mas, begin, right);
            Qsort(mas, left, end);
        }
    }
}
