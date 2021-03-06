﻿using System;

namespace WordProcessing
{
    public struct Character
    {
        public char Value { get; set; }
        public bool? IsVowel
        {
            get
            {
                char[] masVowel = { 'а', 'у', 'е', 'ы', 'о', 'э', 'я', 'и', 'а', 'ю' };
                if (PunctuationMark.IsPunctuation(Value))
                {
                    return null;
                }
                else if (Array.IndexOf(masVowel, Char.ToLower(Value)) == -1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public Character(char value)
            :this()
        {
            Value = value;
        }
    }
}
