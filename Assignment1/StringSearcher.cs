namespace Assignment1
{
    public class StringSearcher
    {
        public List<int> FindAllIndexes(string mainString, string substring)
        {
            if (mainString == null) throw new ArgumentNullException(nameof(mainString));
            if (substring == null) throw new ArgumentNullException(nameof(substring));
            List<int> indexPositions = new List<int>();
            if (substring == "") return indexPositions;
            //int index = 0;
            //while ((index = bigString.IndexOf(smallString, index)) != -1)
            //{
            //    indexPositions.Add(index);
            //    index += smallString.Length; 
            //}
            for (int i = 0; i <= mainString.Length - substring.Length; i++)
            {
                if (mainString.Substring(i, substring.Length) == substring)
                {
                    indexPositions.Add(i);
                }
            }
            return indexPositions;
        }
    }
}
