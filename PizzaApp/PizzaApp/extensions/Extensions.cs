﻿namespace PizzaApp.extensions
{
    public static class StringExtensions
    {
        public static string PremiereLettreMajuscule(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            //MONTAGNARDE (str)
            
            string ret = str.ToLower();
            
            //montagnarde dans (ret)

            ret = ret.Substring(0, 1).ToUpper() + ret.Substring(1,ret.Length-1);
            
            //m dans (ret) + ontagnarde
            //Montagnarde
            
            return ret;
        }
    }
}