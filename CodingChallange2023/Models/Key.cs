namespace CodingChallange2023.Models
{
    internal record Key
    {
        public string Value { get; set; }
        public bool IsOrdered
        {
            get
            {
                if (string.IsNullOrEmpty(this.Value))
                {
                    return false;
                }

                int lastChar = 0;

                for (int i = 0; i < this.Value.Length; i++)
                {
                    if (lastChar == 0 || this.Value[i] > lastChar)
                    {
                        lastChar = this.Value[i];
                        continue;
                    }

                    if (this.Value[i] < lastChar)
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
