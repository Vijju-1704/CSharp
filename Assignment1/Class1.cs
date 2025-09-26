namespace Assignment1
{
    public class Class1
    {
        public List<int> FindAllIndexes(string string1, string string2)
        {
            if (string1 == null) throw new ArgumentNullException(nameof(string1));
            if (string2 == null) throw new ArgumentNullException(nameof(string2));
            List<int> indexes = new List<int>();
            if (string2 == "") return indexes;
            //int index = 0;
            //while ((index = bigString.IndexOf(smallString, index)) != -1)
            //{
            //    indexes.Add(index);
            //    index += smallString.Length; 
            //}
            for (int i = 0; i <= string1.Length - string2.Length; i++)
            {
                if (string1.Substring(i, string2.Length) == string2)
                {
                    indexes.Add(i);
                }
            }
            return indexes;
        }
    }
}
