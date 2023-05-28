using System;
using System.Collections.Generic;

namespace Task4
{
    public class Matrice
    {
        #region Exceptions
        public class OutOfBoundException : Exception { }
        public class OutOfOrderException : Exception { }
        public class UnmatchingAdditionException : Exception { }
        public class ZeroElementException : Exception { }
        public class FalseEntryException : Exception { }
        #endregion

        #region Variables
        private readonly int n, b1, b2;

        private List<int> v;
        #endregion

        #region Constructors
        public Matrice(int n, int b1, int b2)
        {
            if (BoundCheck(n, b1, b2)) throw new OutOfBoundException();
            if (OrderCheck(b1, b2)) throw new OutOfOrderException();
            if (SumCheck(n, b1, b2)) throw new UnmatchingAdditionException();

            this.n = n;
            this.b1 = b1;
            this.b2 = b2;

            int vSize = (n * (n + 1)) / 2;
            v = new List<int>(new int[vSize]);

            Random rand = new Random();

            for (int i = 0; i < this.n; i++)
            {
                for (int j = 0; j < this.n; j++)
                {
                    if (i < this.b1 && j < this.b1) SetV(i, j, rand.Next(1, 9), v);

                    if (i >= this.b1 && j >= this.b1) SetV(i, j, rand.Next(1, 9), v);
                }
            }
        }

        public Matrice() { }
        #endregion

        #region Matrice Functions
        public int PrintCurrentMatrice(int i, int j)
        {
            v = GetV();

            if (i < b1 && j < b1) return GetElem(i, j);

            if (i >= b1 && j >= b1) return GetElem(i, j);

            if ((i < b1 && j >= b1) || (i >= b1 && j < b1)) return 0;

            return 0;
        }

        public int GetEntry(int i, int j)
        {
            v = GetV();

            if (EntryCheck(v, i, j)) throw new FalseEntryException();

            return GetElem(i, j);
        }

        public List<int> Addition(Matrice m)
        {
            v = GetV();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    v[IndV(i, j)] += m.v[IndV(i, j)];
                }
            }

            return v;
        }

        public List<int> Multiplication(Matrice m)
        {
            v = GetV();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int temp = 0;

                    for (int k = 0; k < n; k++)
                    {
                        temp += v[IndV(i, j)] * m.v[IndV(j, k)];
                    }

                    v[IndV(i, j)] = temp;
                }
            }

            return v;
        }
        #endregion

        #region Vector Functions
        private int IndV(int i, int j)
        {
            return j + i * (i + 1) / 2;
        }

        private int SetV(int i, int j, int e, List<int> v)
        {
            v[IndV(i, j)] = e;

            return v[IndV(i, j)];
        }

        private List<int> GetV()
        {
            return v;
        }

        private int GetElem(int i, int j)
        {
            return v[IndV(i, j)];
        }
        #endregion

        #region Pre-Conditions
        public bool BoundCheck(int n, int b1, int b2)
        {
            return (b1 > n || b1 < 1 || b2 > n || b2 < 1 || n < 1);
        }

        public bool OrderCheck(int b1, int b2)
        {
            return (b1 >= b2);
        }

        public bool SumCheck(int n, int b1, int b2)
        {
            return (b1 + b2 != n);
        }

        public bool EntryCheck(List<int> v, int i, int j)
        {
            return v.Count < IndV(i, j);
        }
        #endregion
    }
}