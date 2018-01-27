using UnityEngine;
using System;
public class DataTranslator : MonoBehaviour {

    private static string Kills_Symbol = "[KILLS]";
    private static string Death_Symbol = "[DEATHS]";

    public static string ValuesToData( int kills, int deaths)
    {
        return Kills_Symbol + kills + "/" + Death_Symbol + deaths;
    }

    public static int DataToKills(string data)
    {
        return int.Parse(DataToValue(data , Kills_Symbol));
    }

    public static int DataToDeaths(string data)
    {
        return int.Parse(DataToValue(data, Death_Symbol));
    }

    public static string DataToValue (string data, string symbol)
    {
        string[] pieces = data.Split('/');
        foreach (string piece in pieces)
        {
            if (piece.StartsWith(symbol))
            {
                return piece.Substring(symbol.Length);
            }
        }

        Debug.LogError(symbol + " not found in  " + data);
        return "";
    }
}
