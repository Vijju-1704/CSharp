namespace Assignment1
{
    internal class Class1
    {
        public List<int> FindAllIndexes(string s1, string s2)
        {
            List<int> indexes = new List<int>();
            //int index = 0;
            //while ((index = bigString.IndexOf(smallString, index)) != -1)
            //{
            //    indexes.Add(index);
            //    index += smallString.Length; 
            //}
            for (int i = 0; i <= s1.Length - s2.Length; i++)
            {
                if (s1.Substring(i, s2.Length) == s2)
                {
                    indexes.Add(i);
                }
            }
            return indexes;
        }
    }
}
